/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using CoreEx.Entities;

namespace My.Hr.Common.Entities
{
    /// <summary>
    /// Represents the <see cref="Employee"/> base entity.
    /// </summary>
    public partial class EmployeeBase : IIdentifier<Guid>
    {
        /// <summary>
        /// Gets or sets the <see cref="Employee"/> identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Unique <see cref="Employee"/> Email.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the First Name.
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the Last Name.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Gets the corresponding <see cref="Gender"/> text (read-only where selected).
        /// </summary>
        public string? GenderText { get; set ; }

        /// <summary>
        /// Gets or sets the Gender.
        /// </summary>
        public string? Gender { get; set; }

        /// <summary>
        /// Gets or sets the Birthday.
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Gets or sets the Start Date.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the Termination.
        /// </summary>
        public TerminationDetail? Termination { get; set; }

        /// <summary>
        /// Gets or sets the Phone No.
        /// </summary>
        public string? PhoneNo { get; set; }
        
        /// <summary>
        /// Creates the primary <see cref="CompositeKey"/>.
        /// </summary>
        /// <returns>The primary <see cref="CompositeKey"/>.</returns>
        /// <param name="id">The <see cref="Id"/>.</param>
        public static CompositeKey CreatePrimaryKey(Guid id) => new CompositeKey(id);

        /// <summary>
        /// Gets the primary <see cref="CompositeKey"/> (consists of the following property(s): <see cref="Id"/>).
        /// </summary>
        [JsonIgnore]
        public CompositeKey PrimaryKey => CreatePrimaryKey(Id);
    }

    /// <summary>
    /// Represents the <see cref="EmployeeBase"/> collection.
    /// </summary>
    public partial class EmployeeBaseCollection : List<EmployeeBase> { }

    /// <summary>
    /// Represents the <see cref="EmployeeBase"/> collection result.
    /// </summary>
    public class EmployeeBaseCollectionResult : CollectionResult<EmployeeBaseCollection, EmployeeBase>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeBaseCollectionResult"/> class.
        /// </summary>
        public EmployeeBaseCollectionResult() { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeBaseCollectionResult"/> class with <paramref name="paging"/>.
        /// </summary>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        public EmployeeBaseCollectionResult(PagingArgs? paging) : base(paging) { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeBaseCollectionResult"/> class with a <paramref name="collection"/> of items to add.
        /// </summary>
        /// <param name="collection">A collection containing items to add.</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        public EmployeeBaseCollectionResult(IEnumerable<EmployeeBase> collection, PagingArgs? paging = null) : base(paging) => Collection.AddRange(collection);
    }
}

#pragma warning restore
#nullable restore