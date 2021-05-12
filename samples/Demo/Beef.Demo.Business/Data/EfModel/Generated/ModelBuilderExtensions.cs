/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable

using Microsoft.EntityFrameworkCore;
using System;

namespace Beef.Demo.Business.Data.EfModel
{
    /// <summary>
    /// Represents extension methods for the <see cref="ModelBuilder"/>.
    /// </summary>
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Adds all the generated models to the <see cref="ModelBuilder"/>.
        /// </summary>
        /// <param name="modelBuilder">The <see cref="ModelBuilder"/>.</param>
        public static void AddGeneratedModels(this ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
                throw new ArgumentNullException(nameof(modelBuilder));

            Table.AddToModel(modelBuilder);
            EyeColor.AddToModel(modelBuilder);
            Status.AddToModel(modelBuilder);
            Person.AddToModel(modelBuilder);
            Contact.AddToModel(modelBuilder);
        }
    }
}

#pragma warning restore
#nullable restore