/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable

namespace Beef.Demo.Business.Entities
{
    /// <summary>
    /// Represents the other <see cref="Person"/> without <see cref="EntityBase"/> capabilities entity.
    /// </summary>
    public partial class PersonOther : IIdentifier<Guid>, IETag, IChangeLog
    {
        private Guid _id;
        private string? _firstName;
        private string? _lastName;
        private string? _etag;
        private ChangeLog? _changeLog;

        /// <summary>
        /// Gets or sets the <see cref="Person"/> identifier.
        /// </summary>
        public Guid Id { get => _id; set => _id = value; }

        /// <summary>
        /// Gets or sets the First Name.
        /// </summary>
        public string? FirstName { get => _firstName; set => _firstName = value; }

        /// <summary>
        /// Gets or sets the Last Name.
        /// </summary>
        public string? LastName { get => _lastName; set => _lastName = value; }

        /// <summary>
        /// Gets or sets the ETag.
        /// </summary>
        [JsonPropertyName("etag")]
        public string? ETag { get => _etag; set => _etag = value; }

        /// <summary>
        /// Gets or sets the Change Log (see <see cref="CoreEx.Entities.ChangeLog"/>).
        /// </summary>
        public ChangeLog? ChangeLog { get => _changeLog; set => _changeLog = value; }
    }

    /// <summary>
    /// Represents the <see cref="PersonOther"/> collection.
    /// </summary>
    public partial class PersonOtherCollection : List<PersonOther>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonOtherCollection"/> class.
        /// </summary>
        public PersonOtherCollection() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonOtherCollection"/> class with a <paramref name="collection"/> of items to add.
        /// </summary>
        /// <param name="collection">A collection containing items to add.</param>
        public PersonOtherCollection(IEnumerable<PersonOther> collection) => AddRange(collection);
    }
}

#pragma warning restore
#nullable restore