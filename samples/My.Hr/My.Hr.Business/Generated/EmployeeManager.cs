/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CoreEx;
using CoreEx.Business;
using CoreEx.Entities;
using CoreEx.Validation;
using My.Hr.Business.Entities;
using My.Hr.Business.DataSvc;
using My.Hr.Business.Validation;
using RefDataNamespace = My.Hr.Business.Entities;

namespace My.Hr.Business
{
    /// <summary>
    /// Provides the <see cref="Employee"/> business functionality.
    /// </summary>
    public partial class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeDataSvc _dataService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeManager"/> class.
        /// </summary>
        /// <param name="dataService">The <see cref="IEmployeeDataSvc"/>.</param>
        public EmployeeManager(IEmployeeDataSvc dataService)
            { _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService)); EmployeeManagerCtor(); }

        partial void EmployeeManagerCtor(); // Enables additional functionality to be added to the constructor.

        /// <summary>
        /// Gets the specified <see cref="Employee"/>.
        /// </summary>
        /// <param name="id">The <see cref="Employee"/> identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
        /// <returns>The selected <see cref="Employee"/> where found.</returns>
        public Task<Employee?> GetAsync(Guid id, CancellationToken cancellationToken = default) => ManagerInvoker.Current.InvokeAsync(this, async __ct =>
        {
            Cleaner.CleanUp(id);
            (await id.Validate(nameof(id)).Mandatory().ValidateAsync(__ct).ConfigureAwait(false)).ThrowOnError();
            return Cleaner.Clean(await _dataService.GetAsync(id, __ct).ConfigureAwait(false));
        }, BusinessInvokerArgs.Read, cancellationToken);

        /// <summary>
        /// Creates a new <see cref="Employee"/>.
        /// </summary>
        /// <param name="value">The <see cref="Employee"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
        /// <returns>The created <see cref="Employee"/>.</returns>
        public Task<Employee> CreateAsync(Employee value, CancellationToken cancellationToken = default) => ManagerInvoker.Current.InvokeAsync(this, async __ct =>
        {
            Cleaner.CleanUp(value.EnsureValue());
            (await value.Validate().Entity().With<IValidatorEx<Employee>>().ValidateAsync(__ct).ConfigureAwait(false)).ThrowOnError();
            return Cleaner.Clean(await _dataService.CreateAsync(value, __ct).ConfigureAwait(false));
        }, BusinessInvokerArgs.Create, cancellationToken);

        /// <summary>
        /// Updates an existing <see cref="Employee"/>.
        /// </summary>
        /// <param name="value">The <see cref="Employee"/>.</param>
        /// <param name="id">The <see cref="Employee"/> identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
        /// <returns>The updated <see cref="Employee"/>.</returns>
        public Task<Employee> UpdateAsync(Employee value, Guid id, CancellationToken cancellationToken = default) => ManagerInvoker.Current.InvokeAsync(this, async __ct =>
        {
            value.EnsureValue().Id = id;
            Cleaner.CleanUp(value);
            (await value.Validate().Entity().With<IValidatorEx<Employee>>().ValidateAsync(__ct).ConfigureAwait(false)).ThrowOnError();
            return Cleaner.Clean(await _dataService.UpdateAsync(value, __ct).ConfigureAwait(false));
        }, BusinessInvokerArgs.Update, cancellationToken);

        /// <summary>
        /// Deletes the specified <see cref="Employee"/>.
        /// </summary>
        /// <param name="id">The Id.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default) => ManagerInvoker.Current.InvokeAsync(this, async __ct =>
        {
            Cleaner.CleanUp(id);
            (await id.Validate(nameof(id)).Mandatory().Common(EmployeeValidator.CanDelete).ValidateAsync(__ct).ConfigureAwait(false)).ThrowOnError();
            await _dataService.DeleteAsync(id, __ct).ConfigureAwait(false);
        }, BusinessInvokerArgs.Delete, cancellationToken);

        /// <summary>
        /// Gets the <see cref="EmployeeBaseCollectionResult"/> that contains the items that match the selection criteria.
        /// </summary>
        /// <param name="args">The Args (see <see cref="Entities.EmployeeArgs"/>).</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="EmployeeBaseCollectionResult"/>.</returns>
        public Task<EmployeeBaseCollectionResult> GetByArgsAsync(EmployeeArgs? args, PagingArgs? paging, CancellationToken cancellationToken = default) => ManagerInvoker.Current.InvokeAsync(this, async __ct =>
        {
            Cleaner.CleanUp(args);
            (await args.Validate(nameof(args)).Entity().With<IValidatorEx<EmployeeArgs>>().ValidateAsync(__ct).ConfigureAwait(false)).ThrowOnError();
            return Cleaner.Clean(await _dataService.GetByArgsAsync(args, paging, __ct).ConfigureAwait(false));
        }, BusinessInvokerArgs.Read, cancellationToken);

        /// <summary>
        /// Terminates an existing <see cref="Employee"/>.
        /// </summary>
        /// <param name="value">The <see cref="TerminationDetail"/>.</param>
        /// <param name="id">The <see cref="Employee"/> identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
        /// <returns>The updated <see cref="Employee"/>.</returns>
        public Task<Employee> TerminateAsync(TerminationDetail value, Guid id, CancellationToken cancellationToken = default) => ManagerInvoker.Current.InvokeAsync(this, async __ct =>
        {
            Cleaner.CleanUp(value.EnsureValue(), id);
            (await value.Validate().Entity().With<IValidatorEx<TerminationDetail>>().ValidateAsync(__ct).ConfigureAwait(false)).ThrowOnError();
            return Cleaner.Clean(await _dataService.TerminateAsync(value, id, __ct).ConfigureAwait(false));
        }, BusinessInvokerArgs.Update, cancellationToken);
    }
}

#pragma warning restore
#nullable restore