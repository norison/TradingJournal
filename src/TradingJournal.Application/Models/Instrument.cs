﻿using TradingJournal.Application.Models.Enums;

namespace TradingJournal.Application.Models;

public class Instrument
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Market Market { get; set; }
}