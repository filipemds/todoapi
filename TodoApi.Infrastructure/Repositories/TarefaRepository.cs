using Microsoft.EntityFrameworkCore;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Enums;
using TodoApi.Infra.Data;

namespace TodoApi.Infra.Repositories;

public class TarefaRepository : ITarefaRepository
{
    private readonly AppDbContext _context;
    public TarefaRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<TarefaEntity>> GetAllAsync() => await _context.Tarefas.ToListAsync();

    public async Task<TarefaEntity> GetByIdAsync(Guid id) => await _context.Tarefas.FindAsync(id);

    public async Task<IEnumerable<TarefaEntity>> GetFilteredAsync(StatusTarefaEnum? status, DateTime? dataVencimento)
    {
        return await _context.Tarefas.Where(t =>
            (!status.HasValue || t.Status == status) &&
            (!dataVencimento.HasValue || t.DataVencimento.Date == dataVencimento.Value.Date)
        ).ToListAsync();
    }

    public async Task AddAsync(TarefaEntity tarefa) => await _context.Tarefas.AddAsync(tarefa);

    public void Update(TarefaEntity tarefa) => _context.Tarefas.Update(tarefa);

    public void Remove(TarefaEntity tarefa) => _context.Tarefas.Remove(tarefa);
}
