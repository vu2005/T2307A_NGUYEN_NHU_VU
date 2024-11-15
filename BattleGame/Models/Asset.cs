using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BattleGame.Models
{
    public class Asset
    {
        [Key]
        public string AssetId { get; set; } = Guid.NewGuid().ToString(); // Sử dụng GUID để tạo ID duy nhất

        [Required]
        [MaxLength(64)]
        public string AssetName { get; set; }

        public int LevelRequire { get; set; }

        public ICollection<PlayerAsset> PlayerAssets { get; set; }
    }
}
