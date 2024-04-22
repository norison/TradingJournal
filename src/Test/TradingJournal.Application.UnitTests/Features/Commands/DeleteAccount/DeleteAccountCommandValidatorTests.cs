using AutoFixture;
using FluentValidation.TestHelper;
using TradingJournal.Application.Features.Accounts.Commands.DeleteAccount;

namespace TradingJournal.Application.UnitTests.Features.Commands.DeleteAccount;

public class DeleteAccountCommandValidatorTests : TestBase
{
    private readonly DeleteAccountCommandValidator _validator = new();

    [Fact]
    public void GivenValidCommand_WhenValidating_ThenShouldPass()
    {
        // Arrange
        var command = Fixture.Create<DeleteAccountCommand>();

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Id);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void GivenInvalidCommand_WhenIdInvalid_ThenShouldFail(long id)
    {
        // Arrange
        var command = Fixture.Build<DeleteAccountCommand>().With(x => x.Id, id).Create();

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Id);
    }
}