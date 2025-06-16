namespace TodoApi.Infra.UnitOfWork;

using System.Threading.Tasks;
using TodoApi.Infra.Repositories;

public interface IUnitOfWork
{
    ITarefaRepository Tarefas { get; }
    Task CommitAsync();
}
