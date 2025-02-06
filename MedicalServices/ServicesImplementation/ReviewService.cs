using MedicalServices.DbContext;
using MedicalServices.DTO;
using MedicalServices.Hubs;
using MedicalServices.Models;
using MedicalServices.Services;
using Microsoft.AspNetCore.SignalR;

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
    }
}
