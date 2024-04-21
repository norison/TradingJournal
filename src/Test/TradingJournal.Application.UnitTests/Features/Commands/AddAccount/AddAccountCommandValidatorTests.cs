using AutoFixture;
using FluentAssertions;
using FluentValidation.TestHelper;
using TradingJournal.Application.Features.Accounts.Commands.AddAccount;
using TradingJournal.Application.Models.Enums;

namespace TradingJournal.Application.UnitTests.Features.Commands.AddAccount;

public class AddAccountCommandValidatorTests : TestBase
{
    private readonly AddAccountCommandValidator _validator = new();

    [Fact]
    public void GivenValidCommand_WhenValidating_ThenShouldPass()
    {
        // Arrange
        var command = Fixture.Create<AddAccountCommand>();

        // Act
        var result = _validator.Validate(command);

        // Assert
        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("This is a very long name that exceeds the maximum length of 50 characters.")]
    public async Task GivenInvalidCommand_WhenInvalidName_ThenShouldFail(string name)
    {
        // Arrange
        var command = Fixture.Build<AddAccountCommand>().With(x => x.Name, name).Create();

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
        var command = Fixture.Build<AddAccountCommand>().With(x => x.RiskBalance, riskBalance).Create();

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
        var command = Fixture.Build<AddAccountCommand>().With(x => x.Split, split).Create();

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
            .Build<AddAccountCommand>()
            .With(x => x.Type, (AccountType)10)
            .Create();

        // Act
        var result = await _validator.TestValidateAsync(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Type);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public async Task GivenInvalidCommand_WhenInvalidDescription_ThenShouldFail(string description)
    {
        // Arrange
        var command = Fixture.Build<AddAccountCommand>().With(x => x.Description, description).Create();

        // Act
        var result = await _validator.TestValidateAsync(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Description);
    }
}