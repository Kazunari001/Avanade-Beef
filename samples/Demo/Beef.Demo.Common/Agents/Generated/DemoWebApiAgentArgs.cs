/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable

using Beef.WebApi;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Beef.Demo.Common.Agents
{
    /// <summary>
    /// Defines an application-based (domain) <see cref="IWebApiAgentArgs"/>.
    /// </summary>
    public interface IDemoWebApiAgentArgs : IWebApiAgentArgs { }

    /// <summary>
    /// Provides an application-based (domain) <see cref="IDemoWebApiAgentArgs"/> (see <see cref="IWebApiAgentArgs"/>).
    /// </summary>
    public class DemoWebApiAgentArgs : WebApiAgentArgs, IDemoWebApiAgentArgs 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DemoWebApiAgentArgs"/> class.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        /// <param name="beforeRequest">The optional <see cref="WebApiAgentArgs.BeforeRequest"/> action.</param>
        /// <param name="beforeRequestAsync">The optional <see cref="WebApiAgentArgs.BeforeRequestAsync"/> asynchronous function.</param>
        public DemoWebApiAgentArgs(HttpClient httpClient, Action<HttpRequestMessage>? beforeRequest = null, Func<HttpRequestMessage, Task>? beforeRequestAsync = null) : base(httpClient, beforeRequest, beforeRequestAsync) { }
    }
}

#pragma warning restore
#nullable restore