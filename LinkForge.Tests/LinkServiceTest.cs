using LinkForge.Application.DTO;
using LinkForge.Application.Interfaces;
using LinkForge.Application.Services;
using LinkForge.Domain.Entities;
using Moq;
using Xunit;

/// <summary>
/// Набор unit-тестов для сервиса <see cref="LinkService"/>.
/// 
/// Проверяет корректность бизнес-логики работы с короткими ссылками:
/// создание, получение, обновление и удаление ссылок.
///
/// В тестах используется мок репозитория <see cref="ILinkRepository"/>
/// с помощью библиотеки Moq, чтобы изолировать сервис от базы данных
/// и тестировать только бизнес-логику.
/// </summary>
/// 
namespace LinkForge.Tests;

public class LinkServiceTests
{
    private readonly Mock<ILinkRepository> _repositoryMock;
    private readonly LinkService _service;

    public LinkServiceTests()
    {
        _repositoryMock = new Mock<ILinkRepository>();
        _service = new LinkService(_repositoryMock.Object);
    }

    [Fact]
    public async Task CreateAsync_Should_Add_Link()
    {
        var request = new CreateLinkRequest
        {
            Url = "https://google.com"
        };

        await _service.CreateAsync(request);

        _repositoryMock.Verify(x =>
                x.AddAsync(It.IsAny<ShortLink>()),
            Times.Once);
    }

    [Fact]
    public async Task CreateAsync_Should_Throw_Exception_For_Invalid_Url()
    {
        var request = new CreateLinkRequest
        {
            Url = "invalid-url"
        };

        await Assert.ThrowsAsync<Exception>(() =>
            _service.CreateAsync(request));
    }
    
    [Fact]
    public async Task DeleteAsync_Should_Call_Repository_Delete()
    {
        var id = Guid.NewGuid();

        await _service.DeleteAsync(id);

        _repositoryMock.Verify(x =>
                x.DeleteAsync(id),
            Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_Should_Update_Link()
    {
        var request = new UpdateLinkRequest
        {
            Id = Guid.NewGuid(),
            OriginalUrl = "https://youtube.com"
        };

        await _service.UpdateAsync(request);

        _repositoryMock.Verify(x =>
                x.UpdateAsync(It.IsAny<ShortLink>()),
            Times.Once);
    }
}