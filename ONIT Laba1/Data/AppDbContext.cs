using Microsoft.EntityFrameworkCore;
using ONIT_Laba1.Data.Models;

namespace ONIT_Laba1.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {

    }

    public DbSet<Song> Songs { get; set; }
}
