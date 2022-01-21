/*
 * This file is automatically generated; any changes will be lost. 
 */
 
#nullable enable
#pragma warning disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Beef;
using Beef.AspNetCore.WebApi;
using Beef.Entities;
using Beef.RefData;
using My.Hr.Common.Entities;
using RefDataNamespace = My.Hr.Business.Entities;

namespace My.Hr.Api.Controllers
{
    /// <summary>
    /// Provides the <b>ReferenceData</b> Web API functionality.
    /// </summary>
    public partial class ReferenceDataController : ControllerBase
    {
        /// <summary> 
        /// Gets all of the <see cref="RefDataNamespace.Gender"/> reference data items that match the specified criteria.
        /// </summary>
        /// <param name="codes">The reference data code list.</param>
        /// <param name="text">The reference data text (including wildcards).</param>
        /// <returns>A RefDataNamespace.Gender collection.</returns>
        [HttpGet()]
        [Route("ref/genders")]
        [ProducesResponseType(typeof(IEnumerable<RefDataNamespace.Gender>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult GenderGetAll(List<string>? codes = default, string? text = default) => new WebApiGet<ReferenceDataFilterResult<RefDataNamespace.Gender>>(this, 
            async () => await ReferenceDataFilterer.ApplyFilterAsync<RefDataNamespace.GenderCollection, RefDataNamespace.Gender>(RefDataNamespace.ReferenceData.Current.Gender, codes, text, includeInactive: this.IncludeInactive()).ConfigureAwait(false),
            operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NoContent);

        /// <summary> 
        /// Gets all of the <see cref="RefDataNamespace.TerminationReason"/> reference data items that match the specified criteria.
        /// </summary>
        /// <param name="codes">The reference data code list.</param>
        /// <param name="text">The reference data text (including wildcards).</param>
        /// <returns>A RefDataNamespace.TerminationReason collection.</returns>
        [HttpGet()]
        [Route("ref/terminationReasons")]
        [ProducesResponseType(typeof(IEnumerable<RefDataNamespace.TerminationReason>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult TerminationReasonGetAll(List<string>? codes = default, string? text = default) => new WebApiGet<ReferenceDataFilterResult<RefDataNamespace.TerminationReason>>(this, 
            async () => await ReferenceDataFilterer.ApplyFilterAsync<RefDataNamespace.TerminationReasonCollection, RefDataNamespace.TerminationReason>(RefDataNamespace.ReferenceData.Current.TerminationReason, codes, text, includeInactive: this.IncludeInactive()).ConfigureAwait(false),
            operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NoContent);

        /// <summary> 
        /// Gets all of the <see cref="RefDataNamespace.RelationshipType"/> reference data items that match the specified criteria.
        /// </summary>
        /// <param name="codes">The reference data code list.</param>
        /// <param name="text">The reference data text (including wildcards).</param>
        /// <returns>A RefDataNamespace.RelationshipType collection.</returns>
        [HttpGet()]
        [Route("ref/relationshipTypes")]
        [ProducesResponseType(typeof(IEnumerable<RefDataNamespace.RelationshipType>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult RelationshipTypeGetAll(List<string>? codes = default, string? text = default) => new WebApiGet<ReferenceDataFilterResult<RefDataNamespace.RelationshipType>>(this, 
            async () => await ReferenceDataFilterer.ApplyFilterAsync<RefDataNamespace.RelationshipTypeCollection, RefDataNamespace.RelationshipType>(RefDataNamespace.ReferenceData.Current.RelationshipType, codes, text, includeInactive: this.IncludeInactive()).ConfigureAwait(false),
            operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NoContent);

        /// <summary> 
        /// Gets all of the <see cref="RefDataNamespace.USState"/> reference data items that match the specified criteria.
        /// </summary>
        /// <param name="codes">The reference data code list.</param>
        /// <param name="text">The reference data text (including wildcards).</param>
        /// <returns>A RefDataNamespace.USState collection.</returns>
        [HttpGet()]
        [Route("ref/usStates")]
        [ProducesResponseType(typeof(IEnumerable<RefDataNamespace.USState>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult USStateGetAll(List<string>? codes = default, string? text = default) => new WebApiGet<ReferenceDataFilterResult<RefDataNamespace.USState>>(this, 
            async () => await ReferenceDataFilterer.ApplyFilterAsync<RefDataNamespace.USStateCollection, RefDataNamespace.USState>(RefDataNamespace.ReferenceData.Current.USState, codes, text, includeInactive: this.IncludeInactive()).ConfigureAwait(false),
            operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NoContent);

        /// <summary> 
        /// Gets all of the <see cref="RefDataNamespace.PerformanceOutcome"/> reference data items that match the specified criteria.
        /// </summary>
        /// <param name="codes">The reference data code list.</param>
        /// <param name="text">The reference data text (including wildcards).</param>
        /// <returns>A RefDataNamespace.PerformanceOutcome collection.</returns>
        [HttpGet()]
        [Route("ref/performanceOutcomes")]
        [ProducesResponseType(typeof(IEnumerable<RefDataNamespace.PerformanceOutcome>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult PerformanceOutcomeGetAll(List<string>? codes = default, string? text = default) => new WebApiGet<ReferenceDataFilterResult<RefDataNamespace.PerformanceOutcome>>(this, 
            async () => await ReferenceDataFilterer.ApplyFilterAsync<RefDataNamespace.PerformanceOutcomeCollection, RefDataNamespace.PerformanceOutcome>(RefDataNamespace.ReferenceData.Current.PerformanceOutcome, codes, text, includeInactive: this.IncludeInactive()).ConfigureAwait(false),
            operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NoContent);

        /// <summary>
        /// Gets the reference data entries for the specified entities and codes from the query string; e.g: ref?entity=codeX,codeY&amp;entity2=codeZ&amp;entity3
        /// </summary>
        /// <returns>A <see cref="ReferenceDataMultiCollection"/>.</returns>
        [HttpGet()]
        [Route("ref")]
        [ProducesResponseType(typeof(ReferenceDataMultiCollection), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult GetNamed()
        {
            return new WebApiGet<ReferenceDataMultiCollection>(this, async () =>
            {
                var coll = new ReferenceDataMultiCollection();
                var inactive = this.IncludeInactive();
                var refSelection = this.ReferenceDataSelection();

                var names = refSelection.Select(x => x.Key).ToArray();
                await RefDataNamespace.ReferenceData.Current.PrefetchAsync(names).ConfigureAwait(false);

                foreach (var q in refSelection)
                {
                    switch (q.Key)
                    {
                        case var s when string.Compare(s, nameof(RefDataNamespace.Gender), StringComparison.InvariantCultureIgnoreCase) == 0: coll.Add(new ReferenceDataMultiItem(nameof(RefDataNamespace.Gender), await ReferenceDataFilterer.ApplyFilterAsync<RefDataNamespace.GenderCollection, RefDataNamespace.Gender>(RefDataNamespace.ReferenceData.Current.Gender, q.Value, includeInactive: inactive).ConfigureAwait(false))); break;
                        case var s when string.Compare(s, nameof(RefDataNamespace.TerminationReason), StringComparison.InvariantCultureIgnoreCase) == 0: coll.Add(new ReferenceDataMultiItem(nameof(RefDataNamespace.TerminationReason), await ReferenceDataFilterer.ApplyFilterAsync<RefDataNamespace.TerminationReasonCollection, RefDataNamespace.TerminationReason>(RefDataNamespace.ReferenceData.Current.TerminationReason, q.Value, includeInactive: inactive).ConfigureAwait(false))); break;
                        case var s when string.Compare(s, nameof(RefDataNamespace.RelationshipType), StringComparison.InvariantCultureIgnoreCase) == 0: coll.Add(new ReferenceDataMultiItem(nameof(RefDataNamespace.RelationshipType), await ReferenceDataFilterer.ApplyFilterAsync<RefDataNamespace.RelationshipTypeCollection, RefDataNamespace.RelationshipType>(RefDataNamespace.ReferenceData.Current.RelationshipType, q.Value, includeInactive: inactive).ConfigureAwait(false))); break;
                        case var s when string.Compare(s, nameof(RefDataNamespace.USState), StringComparison.InvariantCultureIgnoreCase) == 0: coll.Add(new ReferenceDataMultiItem(nameof(RefDataNamespace.USState), await ReferenceDataFilterer.ApplyFilterAsync<RefDataNamespace.USStateCollection, RefDataNamespace.USState>(RefDataNamespace.ReferenceData.Current.USState, q.Value, includeInactive: inactive).ConfigureAwait(false))); break;
                        case var s when string.Compare(s, nameof(RefDataNamespace.PerformanceOutcome), StringComparison.InvariantCultureIgnoreCase) == 0: coll.Add(new ReferenceDataMultiItem(nameof(RefDataNamespace.PerformanceOutcome), await ReferenceDataFilterer.ApplyFilterAsync<RefDataNamespace.PerformanceOutcomeCollection, RefDataNamespace.PerformanceOutcome>(RefDataNamespace.ReferenceData.Current.PerformanceOutcome, q.Value, includeInactive: inactive).ConfigureAwait(false))); break;
                    }
                }
                
                return coll;
            }, operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NoContent);
        }
    }
}

#pragma warning restore
#nullable restore