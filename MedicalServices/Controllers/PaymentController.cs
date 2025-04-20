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

            var doctorPrice = await _context.DoctorSchedules
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
                SuccessUrl = $"http://localhost:5282/success?bookingId={bookingId}",
                CancelUrl = "http://localhost:5282/cancel",
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

            var doctorSchedule = await _context.DoctorSchedules
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

    }
}
