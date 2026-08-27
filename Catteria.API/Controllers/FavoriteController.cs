using Catteria.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Catteria.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;

        public FavoritesController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        private string GetUserId()
        {
            var idClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? User.FindFirst("id")?.Value
                ?? throw new System.Exception("User id not found in claims.");
            return idClaim;
        }


        //[HttpPost("{productId}")]
        //public async Task<IActionResult> Toggle(int productId)
        //{
        //    var userId = GetUserId();
        //    var isFavorite = await _favoriteService.ToggleFavoriteAsync(userId, productId);
        //    return Ok(new { isFavorite });
        //}

        [Authorize]
        [HttpPost("{productId}")]
        public async Task<IActionResult> Toggle(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var isFavorite = await _favoriteService
                .ToggleFavoriteAsync(userId, productId);

            return Ok(new { isFavorite });
        }

        [HttpGet]
        public async Task<IActionResult> GetMyFavorites()
        {
            var userId = GetUserId();
            var favorites = await _favoriteService.GetFavoritesByUserAsync(userId);
            return Ok(favorites);
        }
    }
}