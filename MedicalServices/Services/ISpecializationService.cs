using MedicalServices.DTO;
using MedicalServices.Models;

namespace MedicalServices.Services
{
    public interface ISpecializationService
    {
        Task<List<GetAllSpecializaion>> GetAllSpecializationsAsync();
        Task<List<DrDTO>> GetDoctorsBySpecializationIDAsync(int specializationId);
        Task<bool> AddSpecializationAsync(string name , IFormFile? image);
        Task<bool> RemoveSpecializationAsync(int specializationId);
        Task<bool> UpdateSpecializationImageAsync(int specializationId, IFormFile image);


    }
}
