﻿using MedicalServices.DbContext;
using MedicalServices.DTO;
using MedicalServices.Hubs;
using MedicalServices.Models;
using MedicalServices.Models.Identity;
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
        public async Task <List<GetReviewsByDrDTO>> GetReviewsByDrAsync(int doctorId)
        {
            var reviews = await _dbContext.Reviews.Where(x => x.DoctorId == doctorId)
            .Select(x => new GetReviewsByDrDTO
            {
                Comment = x.Comment,
                SenderName = x.Patient.User.Name,
                SenderImage = x.Patient.User.Photo != null ? $"data:image/png;base64,{Convert.ToBase64String(x.Patient.User.Photo)}" : null,
                Rating = x.Rating,
                Age = x.Patient.Age
            }).ToListAsync();
            return reviews;
        }

        // all reviews 
        public async Task<List<ReviewsDetialDTO>> GetAllReviewsAsync()
        {
            return await _dbContext.Reviews
            .Select(x => new ReviewsDetialDTO
            {
                Id = x.Id,
                Comment = x.Comment,
                PatientName = x.Patient.User.Name,
                DoctorName = x.Doctor.User.Name,
                Rating = x.Rating

            }).ToListAsync();
        }
        public async Task<bool> DeleteReviewAsync(int reviewId)
        {
            var review = await _dbContext.Reviews.FindAsync(reviewId);
            if (review == null)
            {
                return false;
            }
            _dbContext.Reviews.Remove(review);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
