/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable

namespace Beef.Demo.Business;

/// <summary>
/// Defines the <see cref="Robot"/> business functionality.
/// </summary>
public partial interface IRobotManager
{
    /// <summary>
    /// Gets the specified <see cref="Robot"/>.
    /// </summary>
    /// <param name="id">The <see cref="Robot"/> identifier.</param>
    /// <returns>The selected <see cref="Robot"/> where found.</returns>
    Task<Result<Robot?>> GetAsync(Guid id);

    /// <summary>
    /// Creates a new <see cref="Robot"/>.
    /// </summary>
    /// <param name="value">The <see cref="Robot"/>.</param>
    /// <returns>The created <see cref="Robot"/>.</returns>
    Task<Result<Robot>> CreateAsync(Robot value);

    /// <summary>
    /// Updates an existing <see cref="Robot"/>.
    /// </summary>
    /// <param name="value">The <see cref="Robot"/>.</param>
    /// <param name="id">The <see cref="Robot"/> identifier.</param>
    /// <returns>The updated <see cref="Robot"/>.</returns>
    Task<Result<Robot>> UpdateAsync(Robot value, Guid id);

    /// <summary>
    /// Deletes the specified <see cref="Robot"/>.
    /// </summary>
    /// <param name="id">The <see cref="Robot"/> identifier.</param>
    Task<Result> DeleteAsync(Guid id);

    /// <summary>
    /// Gets the <see cref="RobotCollectionResult"/> that contains the items that match the selection criteria.
    /// </summary>
    /// <param name="args">The Args (see <see cref="Entities.RobotArgs"/>).</param>
    /// <param name="paging">The <see cref="PagingArgs"/>.</param>
    /// <returns>The <see cref="RobotCollectionResult"/>.</returns>
    Task<Result<RobotCollectionResult>> GetByArgsAsync(RobotArgs? args, PagingArgs? paging);

    /// <summary>
    /// Raises a <see cref="Robot.PowerSource"/> change event.
    /// </summary>
    /// <param name="id">The <see cref="Robot"/> identifier.</param>
    /// <param name="powerSource">The Power Source (see <see cref="RefDataNamespace.PowerSource"/>).</param>
    Task<Result> RaisePowerSourceChangeAsync(Guid id, RefDataNamespace.PowerSource? powerSource);
}

#pragma warning restore
#nullable restore