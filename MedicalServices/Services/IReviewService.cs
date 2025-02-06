using MedicalServices.DTO;
using MedicalServices.Models;

namespace MedicalServices.Services
{
    public interface IReviewService
    {
       Task<bool> AddReviewAsync(ReviewDTO dto);
       Task<List<GetReviewsDTO>> GetAllReviewsAsync(int doctorId);
    }
}
