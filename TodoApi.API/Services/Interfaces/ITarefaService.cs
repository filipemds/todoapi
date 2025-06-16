using TodoApi.Domain.Entities;
using TodoApi.Domain.Enums;

namespace TodoApi.Services.Interfaces;

public interface ITarefaService
{
    Task<IEnumerable<TarefaEntity>> GetAllAsync();
    Task<TarefaEntity> GetByIdAsync(Guid id);
    Task<IEnumerable<TarefaEntity>> GetFilteredAsync(StatusTarefaEnum? status, DateTime? dataVencimento);
    Task AddAsync(TarefaEntity tarefa);
    Task UpdateAsync(TarefaEntity tarefa);
    Task RemoveAsync(Guid id);
}
