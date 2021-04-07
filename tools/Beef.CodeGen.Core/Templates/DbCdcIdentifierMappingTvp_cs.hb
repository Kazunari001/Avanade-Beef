﻿{{! Copyright (c) Avanade. Licensed under the MIT License. See https://github.com/Avanade/Beef }}
/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable

using System.Collections.Generic;
using System.Data;
using Beef.Data.Database;
using Beef.Data.Database.Cdc;

namespace {{Root.NamespaceCdc}}.Data
{
    /// <summary>
    /// Provides the <see cref="CdcIdentifierMapping"/> data mapper.
    /// </summary>
    public class CdcIdentifierMappingDbMapper : CdcIdentifierMappingDbMapperBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CdcIdentifierMappingDbMapper"/> class.
        /// </summary>
        public CdcIdentifierMappingDbMapper() : base("[{{Root.CdcSchema}}].[udt{{Root.CdcIdentifierMappingTableName}}List]") { }
    }
}

#pragma warning restore
#nullable restore