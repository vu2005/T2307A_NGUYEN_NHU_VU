using BattleGame.Models;
using Microsoft.EntityFrameworkCore;

namespace BattleGame.Data
{
    public class BattleGameContext : DbContext
    {
        public BattleGameContext(DbContextOptions<BattleGameContext> options)
            : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<PlayerAsset> PlayerAssets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure composite key for PlayerAsset
            modelBuilder.Entity<PlayerAsset>().HasKey(pa => new { pa.PlayerId, pa.AssetId });

            modelBuilder
                .Entity<PlayerAsset>()
                .HasOne(pa => pa.Player)
                .WithMany(p => p.PlayerAssets)
                .HasForeignKey(pa => pa.PlayerId);

            modelBuilder
                .Entity<PlayerAsset>()
                .HasOne(pa => pa.Asset)
                .WithMany(a => a.PlayerAssets)
                .HasForeignKey(pa => pa.AssetId);

            // Seed data for Players
            modelBuilder
                .Entity<Player>()
                .HasData(
                    new Player
                    {
                        PlayerId = "1",
                        PlayerName = "Alice",
                        FullName = "Alice Wonderland",
                        Age = 25,
                        Level = 10,
                        Email = "alice@wonderland.com",
                    },
                    new Player
                    {
                        PlayerId = "2",
                        PlayerName = "Bob",
                        FullName = "Robert Smith",
                        Age = 30,
                        Level = 15,
                        Email = "bob@smith.com",
                    },
                    new Player
                    {
                        PlayerId = "3",
                        PlayerName = "Charlie",
                        FullName = "Charles Chaplin",
                        Age = 28,
                        Level = 8,
                        Email = "charlie@chaplin.com",
                    }
                );

            // Seed data for Assets
            modelBuilder
                .Entity<Asset>()
                .HasData(
                    new Asset
                    {
                        AssetId = "1",
                        AssetName = "Sword of Light",
                        LevelRequire = 5,
                    },
                    new Asset
                    {
                        AssetId = "2",
                        AssetName = "Shield of Darkness",
                        LevelRequire = 3,
                    },
                    new Asset
                    {
                        AssetId = "3",
                        AssetName = "Potion of Health",
                        LevelRequire = 1,
                    }
                );

            // Seed data for PlayerAssets
            modelBuilder
                .Entity<PlayerAsset>()
                .HasData(
                    new PlayerAsset { PlayerId = "1", AssetId = "1" },
                    new PlayerAsset { PlayerId = "2", AssetId = "2" },
                    new PlayerAsset { PlayerId = "3", AssetId = "3" },
                    new PlayerAsset { PlayerId = "1", AssetId = "3" }
                );
        }
    }
}
