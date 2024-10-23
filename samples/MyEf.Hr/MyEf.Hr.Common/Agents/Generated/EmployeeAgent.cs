/*
 * This file is automatically generated; any changes will be lost.
 */

namespace MyEf.Hr.Common.Agents;

/// <summary>
/// Provides the <see cref="Employee"/> HTTP agent.
/// </summary>
/// <param name="client">The underlying <see cref="HttpClient"/>.</param>
/// <param name="jsonSerializer">The optional <see cref="IJsonSerializer"/>.</param>
/// <param name="executionContext">The optional <see cref="CoreEx.ExecutionContext"/>.</param>
public partial class EmployeeAgent(HttpClient client, IJsonSerializer? jsonSerializer = null, CoreEx.ExecutionContext? executionContext = null) : TypedHttpClientBase<EmployeeAgent>(client, jsonSerializer, executionContext), IEmployeeAgent
{
    /// <inheritdoc/>
    public Task<HttpResult<Employee?>> GetAsync(Guid id, HttpRequestOptions? requestOptions = null, CancellationToken cancellationToken = default)
        => GetAsync<Employee?>("employees/{id}", requestOptions, [new HttpArg<Guid>("id", id)], cancellationToken);

    /// <inheritdoc/>
    public Task<HttpResult<Employee>> CreateAsync(Employee value, HttpRequestOptions? requestOptions = null, CancellationToken cancellationToken = default)
        => PostAsync<Employee, Employee>("employees", value, requestOptions, cancellationToken: cancellationToken);

    /// <inheritdoc/>
    public Task<HttpResult<Employee>> UpdateAsync(Employee value, Guid id, HttpRequestOptions? requestOptions = null, CancellationToken cancellationToken = default)
        => PutAsync<Employee, Employee>("employees/{id}", value, requestOptions, [new HttpArg<Guid>("id", id)], cancellationToken);

    /// <inheritdoc/>
    public Task<HttpResult<Employee>> PatchAsync(HttpPatchOption patchOption, string value, Guid id, HttpRequestOptions? requestOptions = null, CancellationToken cancellationToken = default)
        => PatchAsync<Employee>("employees/{id}", patchOption, value, requestOptions, [new HttpArg<Guid>("id", id)], cancellationToken);

    /// <inheritdoc/>
    public Task<HttpResult> DeleteAsync(Guid id, HttpRequestOptions? requestOptions = null, CancellationToken cancellationToken = default)
        => DeleteAsync("employees/{id}", requestOptions, [new HttpArg<Guid>("id", id)], cancellationToken);

    /// <inheritdoc/>
    public Task<HttpResult<EmployeeBaseCollectionResult>> GetByArgsAsync(EmployeeArgs? args, PagingArgs? paging = null, HttpRequestOptions? requestOptions = null, CancellationToken cancellationToken = default)
        => GetAsync<EmployeeBaseCollectionResult>("employees", requestOptions.IncludePaging(paging), [new HttpArg<EmployeeArgs?>("args", args, HttpArgType.FromUriUseProperties)], cancellationToken);

    /// <inheritdoc/>
    public Task<HttpResult<EmployeeBaseCollectionResult>> GetByQueryAsync(QueryArgs? query = null, PagingArgs? paging = null, HttpRequestOptions? requestOptions = null, CancellationToken cancellationToken = default)
        => GetAsync<EmployeeBaseCollectionResult>("employees/query", requestOptions: requestOptions.IncludeQuery(query).IncludePaging(paging), cancellationToken: cancellationToken);

    /// <inheritdoc/>
    public Task<HttpResult<Employee>> TerminateAsync(TerminationDetail value, Guid id, HttpRequestOptions? requestOptions = null, CancellationToken cancellationToken = default)
        => PostAsync<TerminationDetail, Employee>("employees/{id}/terminate", value, requestOptions, [new HttpArg<Guid>("id", id)], cancellationToken);
}