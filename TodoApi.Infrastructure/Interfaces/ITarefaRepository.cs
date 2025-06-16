using TodoApi.Domain.Entities;
using TodoApi.Domain.Enums;

namespace TodoApi.Infra.Repositories;

public interface ITarefaRepository
{
    Task<IEnumerable<TarefaEntity>> GetAllAsync();
    Task<TarefaEntity> GetByIdAsync(Guid id);
    Task<IEnumerable<TarefaEntity>> GetFilteredAsync(StatusTarefaEnum? status, DateTime? dataVencimento);
    Task AddAsync(TarefaEntity tarefa);
    void Update(TarefaEntity tarefa);
    void Remove(TarefaEntity tarefa);
}
