using Doily.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doily.API.Data;

public class DoilyContext(DbContextOptions dbContextOptions): DbContext(dbContextOptions)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Criando um PK (Primary Key)
        modelBuilder.Entity<User>().HasKey(u => u.ID);
        // Definindo colunas obrigatórias
        modelBuilder.Entity<User>().Property(u => u.FirstName).IsRequired();
        modelBuilder.Entity<User>().Property(u => u.LastName).IsRequired();
        // Definindo colunas unicas
        modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
    }
}
