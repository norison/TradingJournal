using AutoFixture;

namespace TradingJournal.CsvPersistence.UnitTests;

public abstract class TestBase
{
    protected Fixture Fixture { get; } = new();
}