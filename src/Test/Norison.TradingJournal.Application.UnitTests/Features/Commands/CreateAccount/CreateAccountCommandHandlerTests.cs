using AutoFixture;
using FluentAssertions;
using Norison.TradingJournal.Application.Abstractions.Storages.Accounts;
using Norison.TradingJournal.Application.Abstractions.Storages.Accounts.Models;
using Norison.TradingJournal.Application.Features.Accounts.Commands.CreateAccount;
using NSubstitute;
using PAP.NSubstitute.FluentAssertionsBridge;

namespace Norison.TradingJournal.Application.UnitTests.Features.Commands.CreateAccount;

public class CreateAccountCommandHandlerTests : TestBase
{
    private readonly IAccountsStorage _accountsStorage;
    private readonly CreateAccountCommandHandler _handler;

    public CreateAccountCommandHandlerTests()
    {
        _accountsStorage = Substitute.For<IAccountsStorage>();
        _handler = new CreateAccountCommandHandler(_accountsStorage);
    }

    [Fact]
    public async Task Handle_WhenCalled_ThenShouldCallAddAccount()
    {
        // Arrange
        var command = Fixture.Create<CreateAccountCommand>();

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        await _accountsStorage
            .Received(1)
            .AddAccountAsync(Verify.That<AddUpdateAccountModel>(model => model.Should().BeEquivalentTo(command)));
    }
}