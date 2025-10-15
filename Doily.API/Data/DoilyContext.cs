using Doily.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doily.API.Data;

public class DoilyContext(DbContextOptions dbContextOptions): DbContext(dbContextOptions)
{
    public DbSet<User> Users { get; set; }
    public DbSet<TaskItem> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Entidade User
        // Criando um PK (Primary Key)
        modelBuilder.Entity<User>()
            .HasKey(u => u.ID);
        // Definindo colunas obrigatórias
        modelBuilder.Entity<User>()
            .Property(u => u.FirstName)
            .IsRequired();

        modelBuilder.Entity<User>()
            .Property(u => u.LastName)
            .IsRequired();
        // Definindo colunas unicas
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();

        // Entidade Task
        modelBuilder.Entity<TaskItem>()
            .HasKey(t => t.ID);

        // Definido colunas obrigatórias
        modelBuilder.Entity<TaskItem>()
            .Property(t => t.Title)
            .IsRequired();

        modelBuilder.Entity<TaskItem>()
            .Property(t => t.Description)
            .IsRequired();

        // Definindo valor padrão
        modelBuilder.Entity<TaskItem>()
            .Property(t => t.IsCompleted)
            .HasDefaultValue(false);

        // Definindo chave estrangeira
        modelBuilder.Entity<TaskItem>()
            .HasOne(t => t.User)
            .WithMany(u => u.Tasks)
            .HasForeignKey(t => t.UserID);
    }
}
