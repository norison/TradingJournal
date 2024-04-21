﻿using TradingJournal.Application.Models;

namespace TradingJournal.Application.Abstractions;

public interface ITradesStorage
{
    Task AddTradeAsync(Trade trade);
    Task<IEnumerable<Trade>> GetTradesAsync();
    Task<Trade> GetTradeAsync(int id);
    Task UpdateTradeAsync(Trade trade);
    Task DeleteTradeAsync(int id);
}