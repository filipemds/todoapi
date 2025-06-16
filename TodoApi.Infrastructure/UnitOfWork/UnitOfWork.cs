using TodoApi.Infra.Data;
using TodoApi.Infra.Repositories;

namespace TodoApi.Infra.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public ITarefaRepository Tarefas { get; }

    public UnitOfWork(AppDbContext context, ITarefaRepository tarefaRepository)
    {
        _context = context;
        Tarefas = tarefaRepository;
    }

    public async Task CommitAsync() => await _context.SaveChangesAsync();
}
