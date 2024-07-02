using ChatBot.Repository.ChatBot.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatBot.Repository.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PerguntaData> Questions { get; set; }

        
    }
}
