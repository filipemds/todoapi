using TodoApi.Domain.Enums;

namespace TodoApi.Domain.Entities;

public class TarefaEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Titulo { get; set; }
    public string? Descricao { get; set; }
    public StatusTarefaEnum Status { get; set; }
    public DateTime DataVencimento { get; set; }
}
