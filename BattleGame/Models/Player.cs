using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BattleGame.Models
{
    public class Player
    {
        [Key]
        public string PlayerId { get; set; } = Guid.NewGuid().ToString(); // Sử dụng GUID để tạo ID duy nhất

        [Required]
        [MaxLength(64)]
        public string PlayerName { get; set; }

        [Required]
        [MaxLength(128)]
        public string FullName { get; set; }

        public int Age { get; set; }
        public int Level { get; set; }

        [Required]
        [MaxLength(64)]
        public string Email { get; set; }

        public ICollection<PlayerAsset> PlayerAssets { get; set; }
    }
}
