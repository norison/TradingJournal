using Mediator;
using Norison.TradingJournal.Application.Abstractions.Storages.Accounts;
using Norison.TradingJournal.Application.Models;

namespace Norison.TradingJournal.Application.Features.Accounts.Queries.GetAccounts;

public class GetAccountsQueryHandler(IAccountsStorage accountsStorage)
    : IQueryHandler<GetAccountsQuery, IEnumerable<Account>>
{
    public async ValueTask<IEnumerable<Account>> Handle(GetAccountsQuery query, CancellationToken cancellationToken)
    {
        return await accountsStorage.GetAccountsAsync(cancellationToken);
    }
}