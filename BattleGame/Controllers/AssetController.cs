using System.Linq;
using System.Threading.Tasks;
using BattleGame.Data;
using BattleGame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BattleGame.Controllers
{
    public class AssetController : Controller
    {
        private readonly BattleGameContext _context;

        // Constructor to inject the database context
        public AssetController(BattleGameContext context)
        {
            _context = context;
        }

        // GET: /Asset/Index
        public async Task<IActionResult> Index()
        {
            var assets = await _context.Assets.ToListAsync(); // Get list of assets from database
            return View(assets); // Return assets list to Index view
        }

        // GET: /Asset/CreateAsset
        public IActionResult CreateAsset()
        {
            return View(); // Return the view to create a new asset
        }

        // POST: /Asset/RegisterAsset
        [HttpPost]
        public async Task<IActionResult> RegisterAsset(Asset asset)
        {
            if (asset == null || string.IsNullOrEmpty(asset.AssetName) || asset.LevelRequire <= 0)
            {
                return BadRequest("Invalid asset data."); // Return bad request if data is invalid
            }

            _context.Assets.Add(asset); // Add new asset to the database
            await _context.SaveChangesAsync(); // Save changes to the database
            return RedirectToAction("Index"); // Redirect to asset list after successful creation
        }
    }
}
