using MedicalServices.DbContext;
using MedicalServices.DTO;
using MedicalServices.Models;
using MedicalServices.Models.Identity;
using MedicalServices.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.ServicesImplementation
{
    public class LocationService : ILocationService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        public LocationService(ApplicationDbContext dbContext, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<string> AddOrUpdateLocation(LocationDTO request)
        {
            var user = await _dbContext.Users.FindAsync(request.UserId);
            if (user == null)
                return "User Is not found";
            var userRole = await _userManager.GetRolesAsync(user);

            if (userRole == null)
                return "UserRole Is not exist";

            var existingLocation = await _dbContext.Locations
                                                    .FirstOrDefaultAsync(l => l.UserId == request.UserId);
            if (existingLocation != null)
            {
                existingLocation.Latitude = request.Latitude;
                existingLocation.Longitude = request.Longitude;
            }
            else
            {
                var newLocation = new Location
                {
                    UserId = request.UserId,
                    UserRole = userRole.FirstOrDefault().ToString(),
                    Latitude = request.Latitude,
                    Longitude = request.Longitude
                };

                await _dbContext.Locations.AddAsync(newLocation);
            }

            await _dbContext.SaveChangesAsync();
            return "Location updated successfully";
        }
        public List<Location> GetNearbyDoctors(double lat, double lng, double distanceInKm)
        {
            var allDoctors = _dbContext.Locations
                .Where(l => l.UserRole == "Doctor")
                .ToList();

            var nearbyDoctors = allDoctors
                .Where(d => CalculateDistance(lat, lng, d.Latitude, d.Longitude) <= distanceInKm * 1000)
                .ToList();

            return nearbyDoctors;
        }


        #region Function Help
        private double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            var R = 6371e3;
            var phi1 = lat1 * Math.PI / 180;
            var phi2 = lat2 * Math.PI / 180;
            var deltaPhi = (lat2 - lat1) * Math.PI / 180;
            var deltaLambda = (lon2 - lon1) * Math.PI / 180;

            var a = Math.Sin(deltaPhi / 2) * Math.Sin(deltaPhi / 2) +
                    Math.Cos(phi1) * Math.Cos(phi2) *
                    Math.Sin(deltaLambda / 2) * Math.Sin(deltaLambda / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            var distance = R * c;
            return distance;
        }
        #endregion
    }



}
