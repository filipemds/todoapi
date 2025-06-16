using Microsoft.AspNetCore.Mvc;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Enums;
using TodoApi.Services.Interfaces;

namespace TodoApi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TarefasController : ControllerBase
{
    private readonly ITarefaService _service;
    public TarefasController(ITarefaService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] StatusTarefaEnum? status, [FromQuery] DateTime? dataVencimento)
    {
        var tarefas = await _service.GetFilteredAsync(status, dataVencimento);
        return Ok(tarefas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var tarefa = await _service.GetByIdAsync(id);
        if (tarefa == null) return NotFound();
        return Ok(tarefa);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TarefaEntity tarefa)
    {
        await _service.AddAsync(tarefa);
        return CreatedAtAction(nameof(GetById), new { id = tarefa.Id }, tarefa);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] TarefaEntity tarefa)
    {
        if (id != tarefa.Id) return BadRequest();
        await _service.UpdateAsync(tarefa);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.RemoveAsync(id);
        return NoContent();
    }
}
