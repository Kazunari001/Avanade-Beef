/*
 * This file is automatically generated; any changes will be lost.
 */

#nullable enable
#pragma warning disable

namespace Beef.Demo.Common.Agents;

/// <summary>
/// Defines the <see cref="Robot"/> HTTP agent.
/// </summary>
public partial interface IRobotAgent
{
    /// <summary>
    /// Get the R-O-B-O-T.
    /// </summary>
    /// <param name="id">The <see cref="Robot"/> identifier.</param>
    /// <param name="requestOptions">The optional <see cref="HttpRequestOptions"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>A <see cref="HttpResult"/>.</returns>
    Task<HttpResult<Robot?>> GetAsync(Guid id, HttpRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new <see cref="Robot"/>.
    /// </summary>
    /// <param name="value">The <see cref="Robot"/>.</param>
    /// <param name="requestOptions">The optional <see cref="HttpRequestOptions"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>A <see cref="HttpResult"/>.</returns>
    Task<HttpResult<Robot>> CreateAsync(Robot value, HttpRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing <see cref="Robot"/>.
    /// </summary>
    /// <param name="value">The <see cref="Robot"/>.</param>
    /// <param name="id">The <see cref="Robot"/> identifier.</param>
    /// <param name="requestOptions">The optional <see cref="HttpRequestOptions"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>A <see cref="HttpResult"/>.</returns>
    Task<HttpResult<Robot>> UpdateAsync(Robot value, Guid id, HttpRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Patches an existing <see cref="Robot"/>.
    /// </summary>
    /// <param name="patchOption">The <see cref="HttpPatchOption"/>.</param>
    /// <param name="value">The <see cref="string"/> that contains the patch content for the <see cref="Robot"/>.</param>
    /// <param name="id">The <see cref="Robot"/> identifier.</param>
    /// <param name="requestOptions">The optional <see cref="HttpRequestOptions"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>A <see cref="HttpResult"/>.</returns>
    Task<HttpResult<Robot>> PatchAsync(HttpPatchOption patchOption, string value, Guid id, HttpRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes the specified <see cref="Robot"/>.
    /// </summary>
    /// <param name="id">The <see cref="Robot"/> identifier.</param>
    /// <param name="requestOptions">The optional <see cref="HttpRequestOptions"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>A <see cref="HttpResult"/>.</returns>
    Task<HttpResult> DeleteAsync(Guid id, HttpRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the <see cref="RobotCollectionResult"/> that contains the items that match the selection criteria.
    /// </summary>
    /// <param name="args">The Args (see <see cref="RobotArgs"/>).</param>
    /// <param name="paging">The <see cref="PagingArgs"/>.</param>
    /// <param name="requestOptions">The optional <see cref="HttpRequestOptions"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>A <see cref="HttpResult"/>.</returns>
    Task<HttpResult<RobotCollectionResult>> GetByArgsAsync(RobotArgs? args, PagingArgs? paging = null, HttpRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Raises a <see cref="Robot.PowerSource"/> change event.
    /// </summary>
    /// <param name="id">The <see cref="Robot"/> identifier.</param>
    /// <param name="powerSource">The Power Source.</param>
    /// <param name="requestOptions">The optional <see cref="HttpRequestOptions"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>A <see cref="HttpResult"/>.</returns>
    Task<HttpResult> RaisePowerSourceChangeAsync(Guid id, string? powerSource, HttpRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);
}

#pragma warning restore
#nullable restore