using Moq;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Enums;
using TodoApi.Infra.Repositories;
using TodoApi.Infra.UnitOfWork;
using TodoApi.Services.Services;

namespace TodoApi.Tests
{
    public class TarefaServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<ITarefaRepository> _repositoryMock;
        private readonly TarefaService _service;

        public TarefaServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _repositoryMock = new Mock<ITarefaRepository>();
            _unitOfWorkMock.Setup(u => u.Tarefas).Returns(_repositoryMock.Object);
            _service = new TarefaService(_unitOfWorkMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnListOfTarefas()
        {
            // Arrange
            var tarefas = new List<TarefaEntity>
            {
                new TarefaEntity { Id = Guid.NewGuid(), Titulo = "Teste 1", Descricao = "Descrição", Status = StatusTarefaEnum.Pendente, DataVencimento = DateTime.Now }
            };

            _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(tarefas);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public async Task AddAsync_ShouldCallAddAndCommit()
        {
            // Arrange
            var tarefa = new TarefaEntity { Id = Guid.NewGuid(), Titulo = "Nova tarefa", Descricao = "Descrição", Status = StatusTarefaEnum.Pendente, DataVencimento = DateTime.Now };

            // Act
            await _service.AddAsync(tarefa);

            // Assert
            _repositoryMock.Verify(r => r.AddAsync(tarefa), Times.Once);
            _unitOfWorkMock.Verify(u => u.CommitAsync(), Times.Once);
        }
    }
}
