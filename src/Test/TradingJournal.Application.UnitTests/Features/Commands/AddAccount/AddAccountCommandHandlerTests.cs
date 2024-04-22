using AutoFixture;
using FluentAssertions;
using NSubstitute;
using PAP.NSubstitute.FluentAssertionsBridge;
using TradingJournal.Application.Abstractions.Storages.Accounts;
using TradingJournal.Application.Abstractions.Storages.Accounts.Models;
using TradingJournal.Application.Features.Accounts.Commands.AddAccount;

namespace TradingJournal.Application.UnitTests.Features.Commands.AddAccount;

public class AddAccountCommandHandlerTests : TestBase
{
    private readonly IAccountsStorage _accountsStorage;
    private readonly AddAccountCommandHandler _handler;

    public AddAccountCommandHandlerTests()
    {
        _accountsStorage = Substitute.For<IAccountsStorage>();
        _handler = new AddAccountCommandHandler(_accountsStorage);
    }

    [Fact]
    public async Task Handle_WhenCalled_ThenShouldCallAddAccount()
    {
        // Arrange
        var command = Fixture.Create<AddAccountCommand>();

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        await _accountsStorage
            .Received(1)
            .AddAccountAsync(Verify.That<AddUpdateAccountModel>(model => model.Should().BeEquivalentTo(command)));
    }
}