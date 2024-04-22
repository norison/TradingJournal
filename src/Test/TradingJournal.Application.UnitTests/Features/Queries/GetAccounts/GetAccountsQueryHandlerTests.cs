using AutoFixture;
using FluentAssertions;
using NSubstitute;
using TradingJournal.Application.Abstractions.Storages.Accounts;
using TradingJournal.Application.Features.Accounts.Queries.GetAccounts;
using TradingJournal.Application.Models;

namespace TradingJournal.Application.UnitTests.Features.Queries.GetAccounts;

public class GetAccountsQueryHandlerTests : TestBase
{
    private readonly IAccountsStorage _accountsStorage;
    private readonly GetAccountsQueryHandler _handler;
    
    public GetAccountsQueryHandlerTests()
    {
        _accountsStorage = Substitute.For<IAccountsStorage>();
        _handler = new GetAccountsQueryHandler(_accountsStorage);
    }
    
    [Fact]
    public async Task Handle_WhenCalled_ThenShouldReturnAccounts()
    {
        // Arrange
        var query = Fixture.Create<GetAccountsQuery>();
        var accounts = Fixture.CreateMany<Account>().ToList();

        _accountsStorage
            .GetAccountsAsync(CancellationToken.None)
            .Returns(accounts);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().BeEquivalentTo(accounts);
    }
}