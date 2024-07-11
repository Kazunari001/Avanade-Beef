/*
 * This file is automatically generated; any changes will be lost. 
 */

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using CoreEx.Entities;

namespace Cdr.Banking.Common.Entities
{
    /// <summary>
    /// Represents the <c>Balance</c> Purse entity.
    /// </summary>
    public partial class BalancePurse
    {
        /// <summary>
        /// Gets or sets the Amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the Currency.
        /// </summary>
        public string? Currency { get; set; }
    }

    /// <summary>
    /// Represents the <c>BalancePurse</c> collection.
    /// </summary>
    public partial class BalancePurseCollection : List<BalancePurse> { }
}