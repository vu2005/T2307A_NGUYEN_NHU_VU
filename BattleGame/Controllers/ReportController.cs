using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BattleGame.Data;
using BattleGame.Models;

namespace BattleGame.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly BattleGameContext _context;

        public ReportController(BattleGameContext context)
        {
            _context = context;
        }

        [HttpGet("getassetsbyplayer")]
        public async Task<IActionResult> GetAssetsByPlayer()
        {
            var result = await (from pa in _context.PlayerAssets
                                join p in _context.Players on pa.PlayerId equals p.PlayerId
                                join a in _context.Assets on pa.AssetId equals a.AssetId
                                select new
                                {
                                    p.PlayerName,
                                    p.Level,
                                    p.Age,
                                    AssetName = a.AssetName
                                }).ToListAsync();
            return Ok(result);
        }
    }
}
