using MedicalServices.DTO;
using MedicalServices.Models;

namespace MedicalServices.Services
{
    public interface ILocationService
    {
        public Task<string> AddOrUpdateLocation(LocationDTO request);
        List<Location> GetNearbyDoctors(double lat, double lng, double distanceInKm);

    }
}
