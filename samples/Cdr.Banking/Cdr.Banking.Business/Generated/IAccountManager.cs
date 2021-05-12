/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Beef;
using Beef.Entities;
using Cdr.Banking.Common.Entities;
using RefDataNamespace = Cdr.Banking.Common.Entities;

namespace Cdr.Banking.Business
{
    /// <summary>
    /// Defines the <see cref="Account"/> business functionality.
    /// </summary>
    public partial interface IAccountManager
    {
        /// <summary>
        /// Get all accounts.
        /// </summary>
        /// <param name="args">The Args (see <see cref="Entities.AccountArgs"/>).</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        /// <returns>The <see cref="AccountCollectionResult"/>.</returns>
        Task<AccountCollectionResult> GetAccountsAsync(AccountArgs? args, PagingArgs? paging);

        /// <summary>
        /// Get <see cref="AccountDetail"/>.
        /// </summary>
        /// <param name="accountId">The <see cref="Account"/> identifier.</param>
        /// <returns>The selected <see cref="AccountDetail"/> where found.</returns>
        Task<AccountDetail?> GetDetailAsync(string? accountId);

        /// <summary>
        /// Get <see cref="Account"/> <see cref="Balance"/>.
        /// </summary>
        /// <param name="accountId">The <see cref="Account"/> identifier.</param>
        /// <returns>The selected <see cref="Balance"/> where found.</returns>
        Task<Balance?> GetBalanceAsync(string? accountId);
    }
}

#pragma warning restore
#nullable restore