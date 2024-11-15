using System.ComponentModel.DataAnnotations.Schema;

namespace BattleGame.Models
{
    public class PlayerAsset
    {
        public string PlayerId { get; set; }

        public string AssetId { get; set; }

        [ForeignKey("PlayerId")]
        public Player Player { get; set; }

        [ForeignKey("AssetId")]
        public Asset Asset { get; set; }
    }
}
