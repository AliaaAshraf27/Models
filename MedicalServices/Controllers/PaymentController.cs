using MedicalServices.DbContext;
using MedicalServices.Enums;
using MedicalServices.Helper;
using MedicalServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;
using Swashbuckle.AspNetCore.Annotations;

namespace MedicalServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly StripeModel _stripeModel;
        private readonly ChargeService _chargeService;
        private readonly TokenService _tokenService;
        private readonly CustomerService _customerService;

        public PaymentController(ApplicationDbContext context,
                                 IOptions<StripeModel> stripeModel,
                                 ChargeService chargeService,
                                 TokenService tokenService,
                                 CustomerService customerService)
        {
            _context = context;
            _stripeModel = stripeModel.Value;
            _chargeService = chargeService;
            _tokenService = tokenService;
            _customerService = customerService;
        }

        [HttpPost("Pay")]
        public async Task<IActionResult> Pay([FromForm] int doctorId, [FromForm] int bookingId)
        {
            var bookingExist = await _context.Bookings.FindAsync(bookingId);
            if (bookingExist == null)
                return NotFound("This Booking is not found");

            var doctorPrice = await _context.AvailableAppointments
                .Where(d => d.DoctorId == doctorId)
                .Select(p => p.Price)
                .FirstOrDefaultAsync();

            float price = doctorPrice;

            StripeConfiguration.ApiKey = _stripeModel.Secretkey;

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
        {
            new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    Currency = "usd",
                    UnitAmountDecimal = (decimal)price,
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = "Consultation",
                    }
                },
                Quantity = 1,
            },
        },
                Mode = "payment",
                SuccessUrl = $"http://medicalservicesproject.runasp.net/success?bookingId={bookingId}",
                CancelUrl = "http://medicalservicesproject.runasp.net/cancel",
                Metadata = new Dictionary<string, string>
        {
            { "bookingId", bookingId.ToString() }
        }
            };

            var service = new SessionService();
            var session = await service.CreateAsync(options);

            return Ok(new { paymentUrl = session.Url, bookingId });
        }

        [HttpPost("confirmPay")]
        [SwaggerOperation(Summary = "Confirm payment and mark booking as completed")]
        [SwaggerResponse(200, "Payment confirmed")]
        [SwaggerResponse(404, "Booking not found")]
        public async Task<IActionResult> ConfirmPayment([FromQuery] int bookingId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            if (booking == null)
                return NotFound(new { error = "Booking not found" });

            var doctorSchedule = await _context.AvailableAppointments
                .Where(s => s.DoctorId == booking.DoctorId)
                .FirstOrDefaultAsync();

            var payment = new Payment
            {
                BookingId = bookingId,
                Amount = doctorSchedule?.Price ?? 0,
                Status = PaymentStatus.Paid
            };

            booking.Status = BookingStatus.Completed;

            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Payment confirmed and booking completed." });
        }
        [HttpPost("stripe-webhook")]
        public async Task<IActionResult> StripeWebhook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                    json,
                    Request.Headers["Stripe-Signature"],
                    _stripeModel.WebhookSecret
                );

                var session = stripeEvent.Data.Object as Session;
                if (session == null)
                    return BadRequest();

                var bookingId = int.Parse(session.Metadata["bookingId"]);

                var booking = await _context.Bookings.FindAsync(bookingId);
                if (booking == null)
                    return NotFound();

                switch (stripeEvent.Type)
                {
                    case "checkout.session.completed":
                        var doctorPrice = await _context.AvailableAppointments
                            .Where(a => a.DoctorId == booking.DoctorId)
                            .Select(a => a.Price)
                            .FirstOrDefaultAsync();

                        booking.Status = BookingStatus.Completed;

                        var payment = new Payment
                        {
                            BookingId = bookingId,
                            Amount = doctorPrice,
                            Status = PaymentStatus.Paid
                        };

                        _context.Payments.Add(payment);
                        await _context.SaveChangesAsync();
                        return Ok("Payment Status is paid");

                        break;

                    case "checkout.session.expired":
                        booking.Status = BookingStatus.Cancel;
                        await _context.SaveChangesAsync();
                        return Problem("Payment Status is expired");
                        break;

                    case "payment_intent.payment_failed":
                        booking.Status = BookingStatus.Failed;
                        await _context.SaveChangesAsync();
                        return Problem("Payment Status is Failed");
                        break;
                    default:
                        return BadRequest("Failed to pay");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = $"Webhook Error: {ex.Message}" });
            }
        }

    }
}
