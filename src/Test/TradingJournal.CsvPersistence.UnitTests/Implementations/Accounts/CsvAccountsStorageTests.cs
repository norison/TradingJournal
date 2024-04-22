using AutoFixture;
using FluentAssertions;
using NSubstitute;
using PAP.NSubstitute.FluentAssertionsBridge;
using TradingJournal.Application.Abstractions.Storages.Accounts.Models;
using TradingJournal.Application.Models;
using TradingJournal.CsvPersistence.Implementations.Accounts;
using TradingJournal.CsvPersistence.Services.Csv;

namespace TradingJournal.CsvPersistence.UnitTests.Implementations.Accounts;

public class CsvAccountsStorageTests : TestBase
{
    private readonly ICsvClient _csvClient;
    private readonly CsvAccountsStorage _storage;

    public CsvAccountsStorageTests()
    {
        _csvClient = Substitute.For<ICsvClient>();
        _storage = new CsvAccountsStorage(_csvClient);
    }

    [Fact]
    public async Task AddAccountAsync_WhenCalled_ThenShouldAddAccount()
    {
        // Arrange
        var model = Fixture.Create<AddUpdateAccountModel>();
        var accounts = Fixture.CreateMany<Account>().ToList();
        var expectedCount = accounts.Count + 1;
        var expectedId = accounts.Max(x => x.Id) + 1;

        _csvClient.ReadRecordsAsync<Account>(CancellationToken.None).Returns(accounts);

        // Act
        var result = await _storage.AddAccountAsync(model);

        // Assert
        result.Should().Be(expectedId);
        await _csvClient
            .Received()
            .WriteRecordsAsync(Verify.That<IEnumerable<Account>>(records =>
            {
                records
                    .Should()
                    .HaveCount(expectedCount)
                    .And.ContainSingle(account => account.Id == expectedId)
                    .Which.Should().BeEquivalentTo(model);
            }));
    }
    
    [Fact]
    public async Task GetAccountsAsync_WhenCalled_ThenShouldReturnAccounts()
    {
        // Arrange
        var accounts = Fixture.CreateMany<Account>().ToList();
        
        _csvClient.ReadRecordsAsync<Account>(CancellationToken.None).Returns(accounts);

        // Act
        var result = await _storage.GetAccountsAsync();

        // Assert
        result.Should().BeEquivalentTo(accounts);
    }
    
    [Fact]
    public async Task GetAccountByIdAsync_WhenCalled_ThenShouldReturnAccount()
    {
        // Arrange
        var accounts = Fixture.CreateMany<Account>().ToList();
        var id = accounts.First().Id;
        
        _csvClient.ReadRecordsAsync<Account>(CancellationToken.None).Returns(accounts);

        // Act
        var result = await _storage.GetAccountByIdAsync(id);

        // Assert
        result.Should().BeEquivalentTo(accounts.First());
    }
    
    [Fact]
    public async Task UpdateAccountAsync_WhenCalled_ThenShouldUpdateAccount()
    {
        // Arrange
        var model = Fixture.Create<AddUpdateAccountModel>();
        var accounts = Fixture.CreateMany<Account>().ToList();
        var id = accounts.First().Id;
        
        _csvClient.ReadRecordsAsync<Account>(CancellationToken.None).Returns(accounts);

        // Act
        await _storage.UpdateAccountAsync(id, model);

        // Assert
        await _csvClient
            .Received()
            .WriteRecordsAsync(Verify.That<IEnumerable<Account>>(records =>
            {
                records
                    .Should()
                    .HaveCount(accounts.Count)
                    .And.ContainSingle(account => account.Id == id)
                    .Which.Should().BeEquivalentTo(model);
            }));
    }
    
    [Fact]
    public async Task DeleteAccountAsync_WhenCalled_ThenShouldDeleteAccount()
    {
        // Arrange
        var accounts = Fixture.CreateMany<Account>().ToList();
        var id = accounts.First().Id;
        var expectedCount = accounts.Count - 1;
        
        _csvClient.ReadRecordsAsync<Account>(CancellationToken.None).Returns(accounts);

        // Act
        await _storage.DeleteAccountAsync(id);

        // Assert
        await _csvClient
            .Received()
            .WriteRecordsAsync(Verify.That<IEnumerable<Account>>(records =>
            {
                records
                    .Should()
                    .HaveCount(expectedCount)
                    .And.NotContain(account => account.Id == id);
            }));
    }
}