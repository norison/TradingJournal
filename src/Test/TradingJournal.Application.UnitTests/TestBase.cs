using AutoFixture;

namespace TradingJournal.Application.UnitTests;

public abstract class TestBase
{
    protected Fixture Fixture { get; } = new();
}