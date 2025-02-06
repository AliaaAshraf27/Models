using MedicalServices.DTO;
using MedicalServices.Models;

namespace MedicalServices.Services
{
    public interface IReviewService
    {
       Task<bool> AddReviewAsync(ReviewDTO dto);
    }
}
