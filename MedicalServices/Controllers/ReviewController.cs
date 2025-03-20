﻿using MedicalServices.AppMetaData;
using MedicalServices.DTO;
using MedicalServices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalServices.Controllers
{
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        [HttpPost(Router.ReviewRouting.AddReview)]
        public async Task<IActionResult> AddReview([FromBody]ReviewDTO dto)
        {
            var review = await _reviewService.AddReviewAsync(dto);
            if(review == false) return BadRequest("Invalid review data");
            return Ok("Review has been added successfully"); ;
        }
        [HttpGet(Router.ReviewRouting.GetAllReviewsById)]
        public async Task<IActionResult> GetAllReviewsByDrId(int doctorId)
        {
            var reviews = await _reviewService.GetReviewsByDrAsync(doctorId);
            if(reviews == null) return BadRequest(string.Empty);
            return Ok(reviews);
        }
        [HttpGet(Router.ReviewRouting.GetAllReviews)]
        public async Task<IActionResult> GetAllReviews()
        {
            var reviews = await _reviewService.GetAllReviewsAsync();
            if (reviews == null) return BadRequest(string.Empty);
            return Ok(reviews);
        }
        [HttpDelete(Router.ReviewRouting.DeleteReview)]
        public async Task<IActionResult> DeleteReview(int reviewId)
        {
            var review = await _reviewService.DeleteReviewAsync(reviewId);
            if (review == false) return NotFound("Invalid review id");
            return Ok("Review has been deleted successfully");
        }
    }
}
