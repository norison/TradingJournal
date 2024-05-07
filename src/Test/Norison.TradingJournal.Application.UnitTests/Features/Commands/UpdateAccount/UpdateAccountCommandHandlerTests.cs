using AutoFixture;
using FluentAssertions;
using NSubstitute;
using PAP.NSubstitute.FluentAssertionsBridge;
using Norison.TradingJournal.Application.Abstractions.Storages.Accounts;
using Norison.TradingJournal.Application.Abstractions.Storages.Accounts.Models;
using Norison.TradingJournal.Application.Exceptions.Accounts;
using Norison.TradingJournal.Application.Features.Accounts.Commands.UpdateAccount;
using Norison.TradingJournal.Application.Models;

namespace Norison.TradingJournal.Application.UnitTests.Features.Commands.UpdateAccount;

public class UpdateAccountCommandHandlerTests : TestBase
{
    private readonly IAccountsStorage _accountsStorage;
    private readonly UpdateAccountCommandHandler _handler;

    public UpdateAccountCommandHandlerTests()
    {
        _accountsStorage = Substitute.For<IAccountsStorage>();
        _handler = new UpdateAccountCommandHandler(_accountsStorage);
    }

    [Fact]
    public async Task Handle_WhenNoAccount_ThenShouldThrowNotFoundException()
    {
        // Arrange
        var command = Fixture.Create<UpdateAccountCommand>();

        _accountsStorage
            .GetAccountByIdAsync(command.Id, CancellationToken.None)
            .Returns((Account?)null);

        // Act & Assert
        await _handler
            .Invoking(async x => await x.Handle(command, CancellationToken.None))
            .Should()
            .ThrowExactlyAsync<AccountNotFoundException>()
            .WithMessage($"Account with id {command.Id} not found.");
    }

    [Fact]
    public async Task Handle_WhenCalled_ThenShouldCallUpdateAccount()
    {
        // Arrange
        var command = Fixture.Create<UpdateAccountCommand>();
        var account = Fixture.Build<Account>().With(x => x.Id, command.Id).Create();
        
        _accountsStorage
            .GetAccountByIdAsync(command.Id, CancellationToken.None)
            .Returns(account);

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        await _accountsStorage
            .Received(1)
            .UpdateAccountAsync(
                command.Id,
                Verify.That<AddUpdateAccountModel>(model => model
                    .Should()
                    .BeEquivalentTo(command, options => options.Excluding(x => x.Id))),
                CancellationToken.None);
    }
}