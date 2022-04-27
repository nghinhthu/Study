using LiveSport.Models;
using LiveSport.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveSport.Controllers
{
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IFootballService _footbalServicel;

        public MatchController(IFootballService footbalService)
        {
            _footbalServicel = footbalService;
        }

        [HttpGet]
        [Route("api/Matches")]
        public async Task<IEnumerable<MatchViewModel>> GetMatchesAsync()
        {
            return await _footbalServicel.GetMatchesAsync();
        }

        [HttpPost]
        [Route("api/Matches")]
        public async Task UpdateMatchAsync(MatchUpdateModel model)
        {
            await _footbalServicel.UpdateMatchAsync(model);
        }
    }
}
