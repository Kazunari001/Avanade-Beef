/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Business.Data
{
    /// <summary>
    /// Provides the <b>ReferenceData</b> data access.
    /// </summary>
    public partial interface IReferenceDataData
    {
        /// <summary>
        /// Gets all the <see cref="RefDataNamespace.Country"/> items.
        /// </summary>
        /// <returns>The <see cref="RefDataNamespace.CountryCollection"/>.</returns>
        Task<RefDataNamespace.CountryCollection> CountryGetAllAsync();

        /// <summary>
        /// Gets all the <see cref="RefDataNamespace.USState"/> items.
        /// </summary>
        /// <returns>The <see cref="RefDataNamespace.USStateCollection"/>.</returns>
        Task<RefDataNamespace.USStateCollection> USStateGetAllAsync();

        /// <summary>
        /// Gets all the <see cref="RefDataNamespace.Gender"/> items.
        /// </summary>
        /// <returns>The <see cref="RefDataNamespace.GenderCollection"/>.</returns>
        Task<RefDataNamespace.GenderCollection> GenderGetAllAsync();

        /// <summary>
        /// Gets all the <see cref="RefDataNamespace.EyeColor"/> items.
        /// </summary>
        /// <returns>The <see cref="RefDataNamespace.EyeColorCollection"/>.</returns>
        Task<RefDataNamespace.EyeColorCollection> EyeColorGetAllAsync();

        /// <summary>
        /// Gets all the <see cref="RefDataNamespace.PowerSource"/> items.
        /// </summary>
        /// <returns>The <see cref="RefDataNamespace.PowerSourceCollection"/>.</returns>
        Task<RefDataNamespace.PowerSourceCollection> PowerSourceGetAllAsync();

        /// <summary>
        /// Gets all the <see cref="RefDataNamespace.Company"/> items.
        /// </summary>
        /// <returns>The <see cref="RefDataNamespace.CompanyCollection"/>.</returns>
        Task<RefDataNamespace.CompanyCollection> CompanyGetAllAsync();

        /// <summary>
        /// Gets all the <see cref="RefDataNamespace.Status"/> items.
        /// </summary>
        /// <returns>The <see cref="RefDataNamespace.StatusCollection"/>.</returns>
        Task<RefDataNamespace.StatusCollection> StatusGetAllAsync();
    }
}

#pragma warning restore
#nullable restore