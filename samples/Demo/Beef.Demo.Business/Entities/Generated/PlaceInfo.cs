/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable

namespace Beef.Demo.Business.Entities
{
    /// <summary>
    /// Represents the Place Info entity.
    /// </summary>
    public partial class PlaceInfo : EntityBase<PlaceInfo>
    {
        private string? _name;
        private string? _postCode;

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string? Name { get => _name; set => SetValue(ref _name, value); }

        /// <summary>
        /// Gets or sets the Post Code.
        /// </summary>
        public string? PostCode { get => _postCode; set => SetValue(ref _postCode, value); }

        /// <inheritdoc/>
        protected override IEnumerable<IPropertyValue> GetPropertyValues()
        {
            yield return CreateProperty(Name, v => Name = v);
            yield return CreateProperty(PostCode, v => PostCode = v);
        }
    }

    /// <summary>
    /// Represents the <see cref="PlaceInfo"/> collection.
    /// </summary>
    public partial class PlaceInfoCollection : EntityBaseCollection<PlaceInfo, PlaceInfoCollection>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlaceInfoCollection"/> class.
        /// </summary>
        public PlaceInfoCollection() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaceInfoCollection"/> class with a <paramref name="collection"/> of items to add.
        /// </summary>
        /// <param name="collection">A collection containing items to add.</param>
        public PlaceInfoCollection(IEnumerable<PlaceInfo> collection) => AddRange(collection);
    }
}

#pragma warning restore
#nullable restore