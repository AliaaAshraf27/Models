using MedicalServices.Enums;
using MedicalServices.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Seeders
{
    public static class RoleSeeder
    {
        public static async Task SeedAsync(RoleManager<Role> roleManager)
        {
            var CheckRole = await roleManager.Roles.SingleOrDefaultAsync(n => n.Name == DefaultRoles.Admin.ToString());
            if (CheckRole is null)
            {
                var adminRole = new Role { Name = DefaultRoles.Admin.ToString() };

                await roleManager.CreateAsync(adminRole);
            }
            var CheckDoctorRole = await roleManager.Roles.SingleOrDefaultAsync(n => n.Name == DefaultRoles.Doctor.ToString());
            if (CheckDoctorRole is null)
            {
                var doctorRole = new Role { Name = DefaultRoles.Doctor.ToString() };

                await roleManager.CreateAsync(doctorRole);
            }
            var CheckPatientRole = await roleManager.Roles.SingleOrDefaultAsync(n => n.Name == DefaultRoles.Patient.ToString());
            if (CheckPatientRole is null)
            {
                var patientRole = new Role { Name = DefaultRoles.Patient.ToString() };

                await roleManager.CreateAsync(patientRole);
            }
        }
    }
}
