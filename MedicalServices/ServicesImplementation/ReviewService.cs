using MedicalServices.DbContext;
using MedicalServices.DTO;
using MedicalServices.Hubs;
using MedicalServices.Models;
using MedicalServices.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.ServicesImplementation
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext _dbContext;
        public ReviewService(ApplicationDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }
       public async Task<bool> AddReviewAsync(ReviewDTO dto)
        {
            var review = new Review()
            {
                Comment = dto.Comment,
                Rating = dto.Rating,
                DoctorId = dto.DoctorId,
                PatientId = dto.PatientId,

            };
               _dbContext.Reviews.Add(review);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        // all reviews about this doctor 
        public async Task <List<GetReviewsDTO>> GetAllReviewsAsync(int doctorId)
        {
            var reviews = await _dbContext.Reviews.Where(x => x.DoctorId == doctorId)
            .Select(x => new GetReviewsDTO
            {
                Comment = x.Comment,
                SenderName = x.Patient.User.Name
            }).ToListAsync();
            return reviews;
        }
    }
}
