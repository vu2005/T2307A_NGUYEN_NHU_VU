using System.Linq;
using System.Threading.Tasks;
using BattleGame.Data;
using BattleGame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BattleGame.Controllers
{
    public class PlayerController : Controller
    {
        private readonly BattleGameContext _context;

        public PlayerController(BattleGameContext context)
        {
            _context = context;
        }

        // GET: /Player/Index
        public async Task<IActionResult> Index()
        {
            var players = await _context.Players.ToListAsync(); // Get list of players from database
            return View(players); // Return players list to Index view
        }

        // GET: /Player/CreatePlayer
        public IActionResult CreatePlayer()
        {
            return View(); // Return the view to create a new player
        }

        // POST: /Player/RegisterPlayer
        [HttpPost]
        public async Task<IActionResult> RegisterPlayer(Player player)
        {
            if (
                player == null
                || string.IsNullOrEmpty(player.PlayerName)
                || player.Level <= 0
                || player.Age <= 0
            )
            {
                return BadRequest("Invalid player data.");
            }

            _context.Players.Add(player); // Add new player to database
            await _context.SaveChangesAsync(); // Save changes to the database
            return RedirectToAction("Index"); // Redirect to player list after successful creation
        }
    }
}
