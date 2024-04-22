using Mediator;
using TradingJournal.Application.Abstractions.Storages.Accounts;
using TradingJournal.Application.Models;

namespace TradingJournal.Application.Features.Accounts.Queries.GetAccounts;

public class GetAccountsQueryHandler(IAccountsStorage accountsStorage)
    : IQueryHandler<GetAccountsQuery, IEnumerable<Account>>
{
    public async ValueTask<IEnumerable<Account>> Handle(GetAccountsQuery query, CancellationToken cancellationToken)
    {
        return await accountsStorage.GetAccountsAsync(cancellationToken);
    }
}