/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable

namespace Beef.Demo.Common.Entities;

/// <summary>
/// Represents the Company entity.
/// </summary>
public partial class Company : ReferenceDataBase<Guid>
{
    /// <summary>
    /// Gets or sets the External Code.
    /// </summary>
    public string? ExternalCode { get; set; }
}

/// <summary>
/// Represents the <c>Company</c> collection.
/// </summary>
public partial class CompanyCollection : List<Company> { }


#pragma warning restore
#nullable restore