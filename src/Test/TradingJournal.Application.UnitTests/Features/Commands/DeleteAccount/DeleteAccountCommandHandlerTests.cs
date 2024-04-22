using AutoFixture;
using FluentAssertions;
using NSubstitute;
using TradingJournal.Application.Abstractions.Storages.Accounts;
using TradingJournal.Application.Exceptions.Accounts;
using TradingJournal.Application.Features.Accounts.Commands.DeleteAccount;
using TradingJournal.Application.Models;

namespace TradingJournal.Application.UnitTests.Features.Commands.DeleteAccount;

public class DeleteAccountCommandHandlerTests : TestBase
{
    private readonly IAccountsStorage _accountsStorage;
    private readonly DeleteAccountCommandHandler _handler;

    public DeleteAccountCommandHandlerTests()
    {
        _accountsStorage = Substitute.For<IAccountsStorage>();
        _handler = new DeleteAccountCommandHandler(_accountsStorage);
    }

    [Fact]
    public async Task Handle_WhenCalled_ThenShouldCallDeleteAccount()
    {
        // Arrange
        var command = Fixture.Create<DeleteAccountCommand>();
        var account = Fixture.Build<Account>().With(x => x.Id, command.Id).Create();

        _accountsStorage
            .GetAccountByIdAsync(command.Id)
            .Returns(account);

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        await _accountsStorage
            .Received(1)
            .DeleteAccountAsync(command.Id);
    }
    
    [Fact]
    public async Task Handle_WhenNoAccount_ThenShouldThrowNotFoundException()
    {
        // Arrange
        var command = Fixture.Create<DeleteAccountCommand>();
        
        _accountsStorage
            .GetAccountByIdAsync(command.Id)
            .Returns((Account?)null);

        // Act & Assert
        await _handler
            .Invoking(async x => await x.Handle(command, CancellationToken.None))
            .Should()
            .ThrowExactlyAsync<AccountNotFoundException>()
            .WithMessage($"Account with id {command.Id} not found.");
    }
}