/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Beef;
using Beef.Business;
using Beef.Caching;
using Beef.Entities;
using Beef.Events;
using Beef.Demo.Business.Data;
using Beef.Demo.Common.Entities;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Business.DataSvc
{
    /// <summary>
    /// Provides the <see cref="Person"/> data repository services.
    /// </summary>
    public partial class PersonDataSvc : IPersonDataSvc
    {
        private readonly IPersonData _data;
        private readonly IEventPublisher _evtPub;
        private readonly IRequestCache _cache;

        #region Extensions

        private Func<Person, Task>? _createOnAfterAsync;
        private Func<Guid, Task>? _deleteOnAfterAsync;
        private Func<Person, Task>? _updateWithRollbackOnAfterAsync;
        private Func<PersonCollectionResult, PagingArgs?, Task>? _getAllOnAfterAsync;
        private Func<PersonCollectionResult, Task>? _getAll2OnAfterAsync;
        private Func<PersonCollectionResult, PersonArgs?, PagingArgs?, Task>? _getByArgsOnAfterAsync;
        private Func<PersonDetailCollectionResult, PersonArgs?, PagingArgs?, Task>? _getDetailByArgsOnAfterAsync;
        private Func<Person, Guid, Guid, Task>? _mergeOnAfterAsync;
        private Func<Task>? _markOnAfterAsync;
        private Func<MapCoordinates, MapArgs?, Task>? _mapOnAfterAsync;
        private Func<Person?, Task>? _getNoArgsOnAfterAsync;
        private Func<PersonDetail?, Guid, Task>? _getDetailOnAfterAsync;
        private Func<PersonDetail, Task>? _updateDetailOnAfterAsync;
        private Func<Person?, string?, List<string>?, Task>? _getNullOnAfterAsync;
        private Func<PersonCollectionResult, PersonArgs?, PagingArgs?, Task>? _getByArgsWithEfOnAfterAsync;
        private Func<Task>? _throwErrorOnAfterAsync;
        private Func<string?, Guid, Task>? _invokeApiViaAgentOnAfterAsync;
        private Func<Person?, Guid, Task>? _getWithEfOnAfterAsync;
        private Func<Person, Task>? _createWithEfOnAfterAsync;
        private Func<Person, Task>? _updateWithEfOnAfterAsync;
        private Func<Guid, Task>? _deleteWithEfOnAfterAsync;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonDataSvc"/> class.
        /// </summary>
        /// <param name="data">The <see cref="IPersonData"/>.</param>
        /// <param name="evtPub">The <see cref="IEventPublisher"/>.</param>
        /// <param name="cache">The <see cref="IRequestCache"/>.</param>
        public PersonDataSvc(IPersonData data, IEventPublisher evtPub, IRequestCache cache)
            { _data = Check.NotNull(data, nameof(data)); _evtPub = Check.NotNull(evtPub, nameof(evtPub)); _cache = Check.NotNull(cache, nameof(cache)); PersonDataSvcCtor(); }

        partial void PersonDataSvcCtor(); // Enables additional functionality to be added to the constructor.

        /// <summary>
        /// Creates a new <see cref="Person"/>.
        /// </summary>
        /// <param name="value">The <see cref="Person"/>.</param>
        /// <returns>The created <see cref="Person"/>.</returns>
        public Task<Person> CreateAsync(Person value)
        {
            return DataSvcInvoker.Current.InvokeAsync(this, async () =>
            {
                var __result = await _data.CreateAsync(Check.NotNull(value, nameof(value))).ConfigureAwait(false);
                await (_createOnAfterAsync?.Invoke(__result) ?? Task.CompletedTask).ConfigureAwait(false);
                await _evtPub.PublishValue(__result, new Uri($"/person/{_evtPub.FormatKey(__result)}", UriKind.Relative), $"Demo.Person.{_evtPub.FormatKey(__result)}", "Create").SendAsync().ConfigureAwait(false);
                return _cache.SetAndReturnValue(__result);
            }, new BusinessInvokerArgs { IncludeTransactionScope = true });
        }

        /// <summary>
        /// Deletes the specified <see cref="Person"/>.
        /// </summary>
        /// <param name="id">The <see cref="Person"/> identifier.</param>
        public Task DeleteAsync(Guid id)
        {
            return DataSvcInvoker.Current.InvokeAsync(this, async () =>
            {
                await _data.DeleteAsync(id).ConfigureAwait(false);
                await (_deleteOnAfterAsync?.Invoke(id) ?? Task.CompletedTask).ConfigureAwait(false);
                await _evtPub.PublishValue(new Person { Id = id }, new Uri($"/person/{_evtPub.FormatKey(id)}", UriKind.Relative), $"Demo.Person.{_evtPub.FormatKey(id)}", "Delete", id).SendAsync().ConfigureAwait(false);
                _cache.Remove<Person>(new UniqueKey(id));
            }, new BusinessInvokerArgs { IncludeTransactionScope = true });
        }

        /// <summary>
        /// Gets the specified <see cref="Person"/>.
        /// </summary>
        /// <param name="id">The <see cref="Person"/> identifier.</param>
        /// <returns>The selected <see cref="Person"/> where found.</returns>
        public Task<Person?> GetAsync(Guid id)
        {
            return DataSvcInvoker.Current.InvokeAsync(this, async () =>
            {
                var __key = new UniqueKey(id);
                if (_cache.TryGetValue(__key, out Person? __val))
                    return __val;

                var __result = await _data.GetAsync(id).ConfigureAwait(false);
                return _cache.SetAndReturnValue(__key, __result);
            });
        }

        /// <summary>
        /// Updates an existing <see cref="Person"/>.
        /// </summary>
        /// <param name="value">The <see cref="Person"/>.</param>
        /// <returns>The updated <see cref="Person"/>.</returns>
        public Task<Person> UpdateAsync(Person value)
        {
            return DataSvcInvoker.Current.InvokeAsync(this, async () =>
            {
                var __result = await _data.UpdateAsync(Check.NotNull(value, nameof(value))).ConfigureAwait(false);
                await _evtPub.PublishValue(__result, new Uri($"/person/{_evtPub.FormatKey(__result)}", UriKind.Relative), $"Demo.Person.{_evtPub.FormatKey(__result)}", "Update").SendAsync().ConfigureAwait(false);
                return _cache.SetAndReturnValue(__result);
            }, new BusinessInvokerArgs { IncludeTransactionScope = true });
        }

        /// <summary>
        /// Updates an existing <see cref="Person"/>.
        /// </summary>
        /// <param name="value">The <see cref="Person"/>.</param>
        /// <returns>The updated <see cref="Person"/>.</returns>
        public Task<Person> UpdateWithRollbackAsync(Person value)
        {
            return DataSvcInvoker.Current.InvokeAsync(this, async () =>
            {
                var __result = await _data.UpdateWithRollbackAsync(Check.NotNull(value, nameof(value))).ConfigureAwait(false);
                await (_updateWithRollbackOnAfterAsync?.Invoke(__result) ?? Task.CompletedTask).ConfigureAwait(false);
                await _evtPub.PublishValue(__result, new Uri($"/person/{_evtPub.FormatKey(__result)}", UriKind.Relative), $"Demo.Person.{_evtPub.FormatKey(__result)}", "Update").SendAsync().ConfigureAwait(false);
                return _cache.SetAndReturnValue(__result);
            }, new BusinessInvokerArgs { IncludeTransactionScope = true });
        }

        /// <summary>
        /// Gets the <see cref="PersonCollectionResult"/> that contains the items that match the selection criteria.
        /// </summary>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        /// <returns>The <see cref="PersonCollectionResult"/>.</returns>
        public Task<PersonCollectionResult> GetAllAsync(PagingArgs? paging)
        {
            return DataSvcInvoker.Current.InvokeAsync(this, async () =>
            {
                var __result = await _data.GetAllAsync(paging).ConfigureAwait(false);
                await (_getAllOnAfterAsync?.Invoke(__result, paging) ?? Task.CompletedTask).ConfigureAwait(false);
                return __result;
            });
        }

        /// <summary>
        /// Gets the <see cref="PersonCollectionResult"/> that contains the items that match the selection criteria.
        /// </summary>
        /// <returns>The <see cref="PersonCollectionResult"/>.</returns>
        public Task<PersonCollectionResult> GetAll2Async()
        {
            return DataSvcInvoker.Current.InvokeAsync(this, async () =>
            {
                var __result = await _data.GetAll2Async().ConfigureAwait(false);
                await (_getAll2OnAfterAsync?.Invoke(__result) ?? Task.CompletedTask).ConfigureAwait(false);
                return __result;
            });
        }

        /// <summary>
        /// Gets the <see cref="PersonCollectionResult"/> that contains the items that match the selection criteria.
        /// </summary>
        /// <param name="args">The Args (see <see cref="Entities.PersonArgs"/>).</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        /// <returns>The <see cref="PersonCollectionResult"/>.</returns>
        public Task<PersonCollectionResult> GetByArgsAsync(PersonArgs? args, PagingArgs? paging)
        {
            return DataSvcInvoker.Current.InvokeAsync(this, async () =>
            {
                var __result = await _data.GetByArgsAsync(args, paging).ConfigureAwait(false);
                await (_getByArgsOnAfterAsync?.Invoke(__result, args, paging) ?? Task.CompletedTask).ConfigureAwait(false);
                return __result;
            });
        }

        /// <summary>
        /// Gets the <see cref="PersonDetailCollectionResult"/> that contains the items that match the selection criteria.
        /// </summary>
        /// <param name="args">The Args (see <see cref="Entities.PersonArgs"/>).</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        /// <returns>The <see cref="PersonDetailCollectionResult"/>.</returns>
        public Task<PersonDetailCollectionResult> GetDetailByArgsAsync(PersonArgs? args, PagingArgs? paging)
        {
            return DataSvcInvoker.Current.InvokeAsync(this, async () =>
            {
                var __result = await _data.GetDetailByArgsAsync(args, paging).ConfigureAwait(false);
                await (_getDetailByArgsOnAfterAsync?.Invoke(__result, args, paging) ?? Task.CompletedTask).ConfigureAwait(false);
                return __result;
            });
        }

        /// <summary>
        /// Merge first <see cref="Person"/> into second.
        /// </summary>
        /// <param name="fromId">The from <see cref="Person"/> identifier.</param>
        /// <param name="toId">The to <see cref="Person"/> identifier.</param>
        /// <returns>A resultant <see cref="Person"/>.</returns>
        public Task<Person> MergeAsync(Guid fromId, Guid toId)
        {
            return DataSvcInvoker.Current.InvokeAsync(this, async () =>
            {
                var __result = await _data.MergeAsync(fromId, toId).ConfigureAwait(false);
                await (_mergeOnAfterAsync?.Invoke(__result, fromId, toId) ?? Task.CompletedTask).ConfigureAwait(false);
                await _evtPub.Publish(
                    _evtPub.CreateValueEvent(__result, new Uri($"/person/", UriKind.Relative), $"Demo.Person.{fromId}", "MergeFrom", fromId, toId),
                    _evtPub.CreateValueEvent(__result, new Uri($"/person/", UriKind.Relative), $"Demo.Person.{toId}", "MergeTo", fromId, toId)).SendAsync().ConfigureAwait(false);

                return __result;
            }, new BusinessInvokerArgs { IncludeTransactionScope = true });
        }

        /// <summary>
        /// Mark <see cref="Person"/>.
        /// </summary>
        public Task MarkAsync()
        {
            return DataSvcInvoker.Current.InvokeAsync(this, async () =>
            {
                await _data.MarkAsync().ConfigureAwait(false);
                await (_markOnAfterAsync?.Invoke() ?? Task.CompletedTask).ConfigureAwait(false);
                await _evtPub.SendAsync().ConfigureAwait(false);
            }, new BusinessInvokerArgs { IncludeTransactionScope = true });
        }

        /// <summary>
        /// Get <see cref="Person"/> at specified <see cref="MapCoordinates"/>.
        /// </summary>
        /// <param name="args">The Args (see <see cref="Entities.MapArgs"/>).</param>
        /// <returns>A resultant <see cref="MapCoordinates"/>.</returns>
        public Task<MapCoordinates> MapAsync(MapArgs? args)
        {
            return DataSvcInvoker.Current.InvokeAsync(this, async () =>
            {
                var __result = await _data.MapAsync(args).ConfigureAwait(false);
                await (_mapOnAfterAsync?.Invoke(__result, args) ?? Task.CompletedTask).ConfigureAwait(false);
                return __result;
            });
        }

        /// <summary>
        /// Get no arguments.
        /// </summary>
        /// <returns>The selected <see cref="Person"/> where found.</returns>
        public Task<Person?> GetNoArgsAsync()
        {
            return DataSvcInvoker.Current.InvokeAsync(this, async () =>
            {
                var __key = new UniqueKey();
                if (_cache.TryGetValue(__key, out Person? __val))
                    return __val;

                var __result = await _data.GetNoArgsAsync().ConfigureAwait(false);
                await (_getNoArgsOnAfterAsync?.Invoke(__result) ?? Task.CompletedTask).ConfigureAwait(false);
                return _cache.SetAndReturnValue(__key, __result);
            });
        }

        /// <summary>
        /// Gets the specified <see cref="PersonDetail"/>.
        /// </summary>
        /// <param name="id">The <see cref="Person"/> identifier.</param>
        /// <returns>The selected <see cref="PersonDetail"/> where found.</returns>
        public Task<PersonDetail?> GetDetailAsync(Guid id)
        {
            return DataSvcInvoker.Current.InvokeAsync(this, async () =>
            {
                var __key = new UniqueKey(id);
                if (_cache.TryGetValue(__key, out PersonDetail? __val))
                    return __val;

                var __result = await _data.GetDetailAsync(id).ConfigureAwait(false);
                await (_getDetailOnAfterAsync?.Invoke(__result, id) ?? Task.CompletedTask).ConfigureAwait(false);
                return _cache.SetAndReturnValue(__key, __result);
            });
        }

        /// <summary>
        /// Updates an existing <see cref="PersonDetail"/>.
        /// </summary>
        /// <param name="value">The <see cref="PersonDetail"/>.</param>
        /// <returns>The updated <see cref="PersonDetail"/>.</returns>
        public Task<PersonDetail> UpdateDetailAsync(PersonDetail value)
        {
            return DataSvcInvoker.Current.InvokeAsync(this, async () =>
            {
                var __result = await _data.UpdateDetailAsync(Check.NotNull(value, nameof(value))).ConfigureAwait(false);
                await (_updateDetailOnAfterAsync?.Invoke(__result) ?? Task.CompletedTask).ConfigureAwait(false);
                await _evtPub.PublishValue(__result, new Uri($"/person/{_evtPub.FormatKey(__result)}", UriKind.Relative), $"Demo.Person.{_evtPub.FormatKey(__result)}", "Update").SendAsync().ConfigureAwait(false);
                return _cache.SetAndReturnValue(__result);
            }, new BusinessInvokerArgs { IncludeTransactionScope = true });
        }

        /// <summary>
        /// Validate a DataSvc Custom generation.
        /// </summary>
        /// <returns>A resultant <see cref="int"/>.</returns>
        public Task<int> DataSvcCustomAsync()
            => DataSvcInvoker.Current.InvokeAsync(this, () => DataSvcCustomOnImplementationAsync());

        /// <summary>
        /// Get Null.
        /// </summary>
        /// <param name="name">The Name.</param>
        /// <param name="names">The Names.</param>
        /// <returns>A resultant <see cref="Person"/>.</returns>
        public Task<Person?> GetNullAsync(string? name, List<string>? names)
        {
            return DataSvcInvoker.Current.InvokeAsync(this, async () =>
            {
                var __result = await _data.GetNullAsync(name, names).ConfigureAwait(false);
                await (_getNullOnAfterAsync?.Invoke(__result, name, names) ?? Task.CompletedTask).ConfigureAwait(false);
                return __result;
            });
        }

        /// <summary>
        /// Validate when an Event is published but not sent.
        /// </summary>
        /// <param name="value">The <see cref="Person"/>.</param>
        /// <returns>The updated <see cref="Person"/>.</returns>
        public Task<Person> EventPublishNoSendAsync(Person value)
            => DataSvcInvoker.Current.InvokeAsync(this, () => EventPublishNoSendOnImplementationAsync(value), new BusinessInvokerArgs { IncludeTransactionScope = true });

        /// <summary>
        /// Gets the <see cref="PersonCollectionResult"/> that contains the items that match the selection criteria.
        /// </summary>
        /// <param name="args">The Args (see <see cref="Entities.PersonArgs"/>).</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        /// <returns>The <see cref="PersonCollectionResult"/>.</returns>
        public Task<PersonCollectionResult> GetByArgsWithEfAsync(PersonArgs? args, PagingArgs? paging)
        {
            return DataSvcInvoker.Current.InvokeAsync(this, async () =>
            {
                var __result = await _data.GetByArgsWithEfAsync(args, paging).ConfigureAwait(false);
                await (_getByArgsWithEfOnAfterAsync?.Invoke(__result, args, paging) ?? Task.CompletedTask).ConfigureAwait(false);
                return __result;
            });
        }

        /// <summary>
        /// Throw Error.
        /// </summary>
        public Task ThrowErrorAsync()
        {
            return DataSvcInvoker.Current.InvokeAsync(this, async () =>
            {
                await _data.ThrowErrorAsync().ConfigureAwait(false);
                await (_throwErrorOnAfterAsync?.Invoke() ?? Task.CompletedTask).ConfigureAwait(false);
            });
        }

        /// <summary>
        /// Invoke Api Via Agent.
        /// </summary>
        /// <param name="id">The <see cref="Person"/> identifier.</param>
        /// <returns>A resultant <see cref="string"/>.</returns>
        public Task<string?> InvokeApiViaAgentAsync(Guid id)
        {
            return DataSvcInvoker.Current.InvokeAsync(this, async () =>
            {
                var __result = await _data.InvokeApiViaAgentAsync(id).ConfigureAwait(false);
                await (_invokeApiViaAgentOnAfterAsync?.Invoke(__result, id) ?? Task.CompletedTask).ConfigureAwait(false);
                return __result;
            });
        }

        /// <summary>
        /// Gets the specified <see cref="Person"/>.
        /// </summary>
        /// <param name="id">The <see cref="Person"/> identifier.</param>
        /// <returns>The selected <see cref="Person"/> where found.</returns>
        public Task<Person?> GetWithEfAsync(Guid id)
        {
            return DataSvcInvoker.Current.InvokeAsync(this, async () =>
            {
                var __key = new UniqueKey(id);
                if (_cache.TryGetValue(__key, out Person? __val))
                    return __val;

                var __result = await _data.GetWithEfAsync(id).ConfigureAwait(false);
                await (_getWithEfOnAfterAsync?.Invoke(__result, id) ?? Task.CompletedTask).ConfigureAwait(false);
                return _cache.SetAndReturnValue(__key, __result);
            });
        }

        /// <summary>
        /// Creates a new <see cref="Person"/>.
        /// </summary>
        /// <param name="value">The <see cref="Person"/>.</param>
        /// <returns>The created <see cref="Person"/>.</returns>
        public Task<Person> CreateWithEfAsync(Person value)
        {
            return DataSvcInvoker.Current.InvokeAsync(this, async () =>
            {
                var __result = await _data.CreateWithEfAsync(Check.NotNull(value, nameof(value))).ConfigureAwait(false);
                await (_createWithEfOnAfterAsync?.Invoke(__result) ?? Task.CompletedTask).ConfigureAwait(false);
                return _cache.SetAndReturnValue(__result);
            });
        }

        /// <summary>
        /// Updates an existing <see cref="Person"/>.
        /// </summary>
        /// <param name="value">The <see cref="Person"/>.</param>
        /// <returns>The updated <see cref="Person"/>.</returns>
        public Task<Person> UpdateWithEfAsync(Person value)
        {
            return DataSvcInvoker.Current.InvokeAsync(this, async () =>
            {
                var __result = await _data.UpdateWithEfAsync(Check.NotNull(value, nameof(value))).ConfigureAwait(false);
                await (_updateWithEfOnAfterAsync?.Invoke(__result) ?? Task.CompletedTask).ConfigureAwait(false);
                await _evtPub.PublishValue(__result, new Uri($"/person/{_evtPub.FormatKey(__result)}", UriKind.Relative), $"Demo.Person.{_evtPub.FormatKey(__result)}", "Update").SendAsync().ConfigureAwait(false);
                return _cache.SetAndReturnValue(__result);
            }, new BusinessInvokerArgs { IncludeTransactionScope = true });
        }

        /// <summary>
        /// Deletes the specified <see cref="Person"/>.
        /// </summary>
        /// <param name="id">The <see cref="Person"/> identifier.</param>
        public Task DeleteWithEfAsync(Guid id)
        {
            return DataSvcInvoker.Current.InvokeAsync(this, async () =>
            {
                await _data.DeleteWithEfAsync(id).ConfigureAwait(false);
                await (_deleteWithEfOnAfterAsync?.Invoke(id) ?? Task.CompletedTask).ConfigureAwait(false);
                await _evtPub.PublishValue(new Person { Id = id }, new Uri($"/person/{_evtPub.FormatKey(id)}", UriKind.Relative), $"Demo.Person.{id}", "Delete", id).SendAsync().ConfigureAwait(false);
                _cache.Remove<Person>(new UniqueKey(id));
            }, new BusinessInvokerArgs { IncludeTransactionScope = true });
        }
    }
}

#pragma warning restore
#nullable restore