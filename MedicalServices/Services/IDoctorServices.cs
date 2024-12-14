using MedicalServices.DTO;
using MedicalServices.Models;

namespace MedicalServices.Services
{
    public interface IDoctorServices
    {
        public Task<List<DoctorDTO>> GetAllDoctorsAsync(Filter filter);
    }
}
