using Microsoft.EntityFrameworkCore;

namespace RpsGame_NoDb
{
    public class RpsDbContext : RpsDbContext
    {
        DbSet<Player> players {get;set;}}
        DbSet<Round> rounds {get;set;}}
        DbSet<Match> matches {get;set;}

        protected override void OnConfiguration(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;");
        }
    }
}