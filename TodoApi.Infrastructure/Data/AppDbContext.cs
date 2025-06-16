using Microsoft.EntityFrameworkCore;
using TodoApi.Domain.Entities;

namespace TodoApi.Infra.Data;

public class AppDbContext : DbContext
{
    public DbSet<TarefaEntity> Tarefas { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
