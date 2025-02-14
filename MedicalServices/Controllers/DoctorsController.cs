﻿using MedicalServices.AppMetaData;
using MedicalServices.DTO;
using MedicalServices.Services;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace MedicalServices.Controllers
{
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorServices _drServices;
        #region Constructor
        public DoctorsController(IDoctorServices drServices)
        {
            _drServices = drServices;
        }
        #endregion
        #region End point

        [HttpGet(Router.DoctorsRouting.GetList)]
        public async Task<IActionResult> GetAllDoctors([FromQuery] Filter filter)
        {
            try
            {
                var doctors = await _drServices.GetAllDoctorsAsync(filter);
                if (doctors == null || !doctors.Any())
                    return NotFound("No doctors found in the database");
                return Ok(doctors);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed: " + ex.Message);
            }

        }
        [HttpGet("GetDoctorDetails/{doctorId}")]
        public async Task<IActionResult> GetDoctorDetails(int doctorId)
        {
            var doctor = await _drServices.GetDoctorDetailsAsync(doctorId);
            if (doctor == null)
                return NotFound("Doctor not found.");

            return Ok(doctor);
        }
        [HttpPost(Router.DoctorsRouting.AddFavoriteDR)]
        public async Task<IActionResult> AddFavoriteDR ([FromBody]FavoriteDrDTO dto)
        {
           var success = await _drServices.AddToFavoriteAsync(dto);
            if (!success)
                return BadRequest("Doctor is already in favorites.");

            return Ok("Doctor added to favorites.");
        }
        #endregion
    }
}
