/*
 * This file is automatically generated; any changes will be lost.
 */

namespace Cdr.Banking.Common.Agents;

/// <summary>
/// Defines the <see cref="Account"/> HTTP agent.
/// </summary>
public partial interface IAccountAgent
{
    /// <summary>
    /// Get all accounts.
    /// </summary>
    /// <param name="args">The Args (see <see cref="AccountArgs"/>).</param>
    /// <param name="paging">The <see cref="PagingArgs"/>.</param>
    /// <param name="requestOptions">The optional <see cref="HttpRequestOptions"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>A <see cref="HttpResult"/>.</returns>
    Task<HttpResult<AccountCollectionResult>> GetAccountsAsync(AccountArgs? args, PagingArgs? paging = null, HttpRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get all accounts.
    /// </summary>
    /// <param name="query">The <see cref="QueryArgs"/>.</param>
    /// <param name="paging">The <see cref="PagingArgs"/>.</param>
    /// <param name="requestOptions">The optional <see cref="HttpRequestOptions"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>A <see cref="HttpResult"/>.</returns>
    Task<HttpResult<AccountCollectionResult>> GetAccountsQueryAsync(QueryArgs? query = null, PagingArgs? paging = null, HttpRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get <see cref="AccountDetail"/>.
    /// </summary>
    /// <param name="accountId">The <see cref="Account"/> identifier.</param>
    /// <param name="requestOptions">The optional <see cref="HttpRequestOptions"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>A <see cref="HttpResult"/>.</returns>
    Task<HttpResult<AccountDetail?>> GetDetailAsync(string? accountId, HttpRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get <see cref="Account"/> <see cref="Balance"/>.
    /// </summary>
    /// <param name="accountId">The <see cref="Account"/> identifier.</param>
    /// <param name="requestOptions">The optional <see cref="HttpRequestOptions"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>A <see cref="HttpResult"/>.</returns>
    Task<HttpResult<Balance?>> GetBalanceAsync(string? accountId, HttpRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get <see cref="Account"/> statement (file).
    /// </summary>
    /// <param name="accountId">The <see cref="Account"/> identifier.</param>
    /// <param name="requestOptions">The optional <see cref="HttpRequestOptions"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>A <see cref="HttpResult"/>.</returns>
    Task<HttpResult> GetStatementAsync(string? accountId, HttpRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);
}