using MedicalServices.DTO;
using MedicalServices.Models;

namespace MedicalServices.Services
{
    public interface IReviewService
    {
       Task<bool> AddReviewAsync(ReviewDTO dto);
        Task<List<GetReviewsByDrDTO>> GetReviewsByDrAsync(int doctorId);
       Task<List<ReviewsDetialDTO>> GetAllReviewsAsync();
        Task<bool> DeleteReviewAsync(int reviewId);
    }
}
