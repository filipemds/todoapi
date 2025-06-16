using TodoApi.Domain.Entities;
using TodoApi.Domain.Enums;
using TodoApi.Infra.UnitOfWork;
using TodoApi.Services.Interfaces;

namespace TodoApi.Services.Services;

public class TarefaService : ITarefaService
{
    private readonly IUnitOfWork _unitOfWork;
    public TarefaService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<IEnumerable<TarefaEntity>> GetAllAsync() => await _unitOfWork.Tarefas.GetAllAsync();

    public async Task<TarefaEntity> GetByIdAsync(Guid id) => await _unitOfWork.Tarefas.GetByIdAsync(id);

    public async Task<IEnumerable<TarefaEntity>> GetFilteredAsync(StatusTarefaEnum? status, DateTime? dataVencimento)
        => await _unitOfWork.Tarefas.GetFilteredAsync(status, dataVencimento);

    public async Task AddAsync(TarefaEntity tarefa)
    {
        await _unitOfWork.Tarefas.AddAsync(tarefa);
        await _unitOfWork.CommitAsync();
    }

    public async Task UpdateAsync(TarefaEntity tarefa)
    {
        _unitOfWork.Tarefas.Update(tarefa);
        await _unitOfWork.CommitAsync();
    }

    public async Task RemoveAsync(Guid id)
    {
        var tarefa = await _unitOfWork.Tarefas.GetByIdAsync(id);
        if (tarefa == null) throw new Exception("Tarefa não encontrada.");
        _unitOfWork.Tarefas.Remove(tarefa);
        await _unitOfWork.CommitAsync();
    }
}
