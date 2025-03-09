using MedicalServices.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalServices.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDTO>> GetAllPatientsAsync();
    }
}