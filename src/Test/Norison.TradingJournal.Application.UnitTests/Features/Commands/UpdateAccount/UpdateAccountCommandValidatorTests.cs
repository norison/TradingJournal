using AutoFixture;
using FluentValidation.TestHelper;
using Norison.TradingJournal.Application.Features.Accounts.Commands.UpdateAccount;
using Norison.TradingJournal.Application.Models.Enums;

namespace Norison.TradingJournal.Application.UnitTests.Features.Commands.UpdateAccount;

public class UpdateAccountCommandValidatorTests : TestBase
{
    private readonly UpdateAccountCommandValidator _validator = new();

    [Fact]
    public async Task GivenValidCommand_WhenValidating_ThenShouldPass()
    {
        // Arrange
        var command = Fixture.Create<UpdateAccountCommand>();

        // Act
        var result = await _validator.TestValidateAsync(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
    
    [Fact]
    public async Task GivenInvalidCommand_WhenInvalidId_ThenShouldFail()
    {
        // Arrange
        var command = Fixture.Build<UpdateAccountCommand>().With(x => x.Id, 0).Create();

        // Act
        var result = await _validator.TestValidateAsync(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Id);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("This is a very long name that exceeds the maximum length of 50 characters.")]
    public async Task GivenInvalidCommand_WhenInvalidName_ThenShouldFail(string name)
    {
        // Arrange
        var command = Fixture.Build<UpdateAccountCommand>().With(x => x.Name, name).Create();

        // Act
        var result = await _validator.TestValidateAsync(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task GivenInvalidCommand_WhenInvalidRiskBalance_ThenShouldFail(decimal riskBalance)
    {
        // Arrange
        var command = Fixture.Build<UpdateAccountCommand>().With(x => x.RiskBalance, riskBalance).Create();

        // Act
        var result = await _validator.TestValidateAsync(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.RiskBalance);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task GivenInvalidCommand_WhenInvalidSplit_ThenShouldFail(decimal split)
    {
        // Arrange
        var command = Fixture.Build<UpdateAccountCommand>().With(x => x.Split, split).Create();

        // Act
        var result = await _validator.TestValidateAsync(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Split);
    }

    [Fact]
    public async Task GivenInvalidCommand_WhenInvalidType_ThenShouldFail()
    {
        // Arrange
        var command = Fixture
            .Build<UpdateAccountCommand>()
            .With(x => x.Type, (AccountType)10)
            .Create();

        // Act
        var result = await _validator.TestValidateAsync(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Type);
    }
    
    [Theory]
    [MemberData(nameof(InvalidDescriptionData))]
    public async Task GivenInvalidCommand_WhenInvalidDescription_ThenShouldFail(string description)
    {
        // Arrange
        var command = Fixture.Build<UpdateAccountCommand>().With(x => x.Description, description).Create();

        // Act
        var result = await _validator.TestValidateAsync(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Description);
    }
    
    public static IEnumerable<object[]> InvalidDescriptionData =>
        new List<object[]>
        {
            new object[] { new string('a', 501) }
        };
}