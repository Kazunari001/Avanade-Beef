/*
 * This file is automatically generated; any changes will be lost.
 */

#nullable enable
#pragma warning disable

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Beef.Entities;
using Beef.WebApi;
using Newtonsoft.Json.Linq;
using Beef.Demo.Common.Entities;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Common.Agents
{
    /// <summary>
    /// Defines the <see cref="PostalInfo"/> Web API agent.
    /// </summary>
    public partial interface IPostalInfoAgent
    {
        /// <summary>
        /// Gets the specified <see cref="PostalInfo"/>.
        /// </summary>
        /// <param name="country">The Country.</param>
        /// <param name="state">The State.</param>
        /// <param name="city">The City.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        Task<WebApiAgentResult<PostalInfo?>> GetPostCodesAsync(string? country, string? state, string? city, WebApiRequestOptions? requestOptions = null);

        /// <summary>
        /// Creates a new <see cref="PostalInfo"/>.
        /// </summary>
        /// <param name="value">The <see cref="PostalInfo"/>.</param>
        /// <param name="country">The Country.</param>
        /// <param name="state">The State.</param>
        /// <param name="city">The City.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        Task<WebApiAgentResult<PostalInfo>> CreatePostCodesAsync(PostalInfo value, string? country, string? state, string? city, WebApiRequestOptions? requestOptions = null);

        /// <summary>
        /// Updates an existing <see cref="PostalInfo"/>.
        /// </summary>
        /// <param name="value">The <see cref="PostalInfo"/>.</param>
        /// <param name="country">The Country.</param>
        /// <param name="state">The State.</param>
        /// <param name="city">The City.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        Task<WebApiAgentResult<PostalInfo>> UpdatePostCodesAsync(PostalInfo value, string? country, string? state, string? city, WebApiRequestOptions? requestOptions = null);

        /// <summary>
        /// Patches an existing <see cref="PostalInfo"/>.
        /// </summary>
        /// <param name="patchOption">The <see cref="WebApiPatchOption"/>.</param>
        /// <param name="value">The <see cref="JToken"/> that contains the patch content for the <see cref="PostalInfo"/>.</param>
        /// <param name="country">The Country.</param>
        /// <param name="state">The State.</param>
        /// <param name="city">The City.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        Task<WebApiAgentResult<PostalInfo>> PatchPostCodesAsync(WebApiPatchOption patchOption, JToken value, string? country, string? state, string? city, WebApiRequestOptions? requestOptions = null);
    }

    /// <summary>
    /// Provides the <see cref="PostalInfo"/> Web API agent.
    /// </summary>
    public partial class PostalInfoAgent : WebApiAgentBase, IPostalInfoAgent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostalInfoAgent"/> class.
        /// </summary>
        /// <param name="args">The <see cref="IDemoWebApiAgentArgs"/>.</param>
        public PostalInfoAgent(IDemoWebApiAgentArgs args) : base(args) { }

        /// <summary>
        /// Gets the specified <see cref="PostalInfo"/>.
        /// </summary>
        /// <param name="country">The Country.</param>
        /// <param name="state">The State.</param>
        /// <param name="city">The City.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        public Task<WebApiAgentResult<PostalInfo?>> GetPostCodesAsync(string? country, string? state, string? city, WebApiRequestOptions? requestOptions = null) =>
            GetAsync<PostalInfo?>("api/v1/postal/{country}/{state}/{city}", requestOptions: requestOptions,
                args: new WebApiArg[] { new WebApiArg<string?>("country", country), new WebApiArg<string?>("state", state), new WebApiArg<string?>("city", city) });

        /// <summary>
        /// Creates a new <see cref="PostalInfo"/>.
        /// </summary>
        /// <param name="value">The <see cref="PostalInfo"/>.</param>
        /// <param name="country">The Country.</param>
        /// <param name="state">The State.</param>
        /// <param name="city">The City.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        public Task<WebApiAgentResult<PostalInfo>> CreatePostCodesAsync(PostalInfo value, string? country, string? state, string? city, WebApiRequestOptions? requestOptions = null) =>
            PostAsync<PostalInfo>("api/v1/postal/{country}/{state}/{city}", Beef.Check.NotNull(value, nameof(value)), requestOptions: requestOptions,
                args: new WebApiArg[] { new WebApiArg<string?>("country", country), new WebApiArg<string?>("state", state), new WebApiArg<string?>("city", city) });

        /// <summary>
        /// Updates an existing <see cref="PostalInfo"/>.
        /// </summary>
        /// <param name="value">The <see cref="PostalInfo"/>.</param>
        /// <param name="country">The Country.</param>
        /// <param name="state">The State.</param>
        /// <param name="city">The City.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        public Task<WebApiAgentResult<PostalInfo>> UpdatePostCodesAsync(PostalInfo value, string? country, string? state, string? city, WebApiRequestOptions? requestOptions = null) =>
            PutAsync<PostalInfo>("api/v1/postal/{country}/{state}/{city}", Beef.Check.NotNull(value, nameof(value)), requestOptions: requestOptions,
                args: new WebApiArg[] { new WebApiArg<string?>("country", country), new WebApiArg<string?>("state", state), new WebApiArg<string?>("city", city) });

        /// <summary>
        /// Patches an existing <see cref="PostalInfo"/>.
        /// </summary>
        /// <param name="patchOption">The <see cref="WebApiPatchOption"/>.</param>
        /// <param name="value">The <see cref="JToken"/> that contains the patch content for the <see cref="PostalInfo"/>.</param>
        /// <param name="country">The Country.</param>
        /// <param name="state">The State.</param>
        /// <param name="city">The City.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        public Task<WebApiAgentResult<PostalInfo>> PatchPostCodesAsync(WebApiPatchOption patchOption, JToken value, string? country, string? state, string? city, WebApiRequestOptions? requestOptions = null) =>
            PatchAsync<PostalInfo>("api/v1/postal/{country}/{state}/{city}", patchOption, Beef.Check.NotNull(value, nameof(value)), requestOptions: requestOptions,
                args: new WebApiArg[] { new WebApiArg<string?>("country", country), new WebApiArg<string?>("state", state), new WebApiArg<string?>("city", city) });
    }
}

#pragma warning restore
#nullable restore