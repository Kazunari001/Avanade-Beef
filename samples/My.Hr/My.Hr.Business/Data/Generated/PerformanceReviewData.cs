/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beef;
using Beef.Business;
using Beef.Data.Database;
using Beef.Data.EntityFrameworkCore;
using Beef.Entities;
using Beef.Events;
using Beef.Mapper;
using Beef.Mapper.Converters;
using My.Hr.Business.Entities;
using RefDataNamespace = My.Hr.Business.Entities;

namespace My.Hr.Business.Data
{
    /// <summary>
    /// Provides the <see cref="PerformanceReview"/> data access.
    /// </summary>
    public partial class PerformanceReviewData : IPerformanceReviewData
    {
        private readonly IEfDb _ef;
        private readonly AutoMapper.IMapper _mapper;
        private readonly IEventPublisher _evtPub;

        private Func<IQueryable<EfModel.PerformanceReview>, Guid, EfDbArgs, IQueryable<EfModel.PerformanceReview>>? _getByEmployeeIdOnQuery;

        /// <summary>
        /// Initializes a new instance of the <see cref="PerformanceReviewData"/> class.
        /// </summary>
        /// <param name="ef">The <see cref="IEfDb"/>.</param>
        /// <param name="mapper">The <see cref="AutoMapper.IMapper"/>.</param>
        /// <param name="evtPub">The <see cref="IEventPublisher"/>.</param>
        public PerformanceReviewData(IEfDb ef, AutoMapper.IMapper mapper, IEventPublisher evtPub)
            { _ef = Check.NotNull(ef, nameof(ef)); _mapper = Check.NotNull(mapper, nameof(mapper)); _evtPub = Check.NotNull(evtPub, nameof(evtPub)); PerformanceReviewDataCtor(); }

        partial void PerformanceReviewDataCtor(); // Enables additional functionality to be added to the constructor.

        /// <summary>
        /// Gets the specified <see cref="PerformanceReview"/>.
        /// </summary>
        /// <param name="id">The <see cref="Employee"/> identifier.</param>
        /// <returns>The selected <see cref="PerformanceReview"/> where found.</returns>
        public Task<PerformanceReview?> GetAsync(Guid id) => DataInvoker.Current.InvokeAsync(this, async () =>
        {
            var __dataArgs = EfDbArgs.Create(_mapper);
            return await _ef.GetAsync<PerformanceReview, EfModel.PerformanceReview>(__dataArgs, id).ConfigureAwait(false);
        });

        /// <summary>
        /// Gets the <see cref="PerformanceReviewCollectionResult"/> that contains the items that match the selection criteria.
        /// </summary>
        /// <param name="employeeId">The <see cref="Employee.Id"/>.</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        /// <returns>The <see cref="PerformanceReviewCollectionResult"/>.</returns>
        public Task<PerformanceReviewCollectionResult> GetByEmployeeIdAsync(Guid employeeId, PagingArgs? paging) => DataInvoker.Current.InvokeAsync(this, async () =>
        {
            PerformanceReviewCollectionResult __result = new PerformanceReviewCollectionResult(paging);
            var __dataArgs = EfDbArgs.Create(_mapper, __result.Paging!);
            __result.Result = _ef.Query<PerformanceReview, EfModel.PerformanceReview>(__dataArgs, q => _getByEmployeeIdOnQuery?.Invoke(q, employeeId, __dataArgs) ?? q).SelectQuery<PerformanceReviewCollection>();
            return await Task.FromResult(__result).ConfigureAwait(false);
        });

        /// <summary>
        /// Creates a new <see cref="PerformanceReview"/>.
        /// </summary>
        /// <param name="value">The <see cref="PerformanceReview"/>.</param>
        /// <returns>The created <see cref="PerformanceReview"/>.</returns>
        public Task<PerformanceReview> CreateAsync(PerformanceReview value) => _ef.EventOutboxInvoker.InvokeAsync(this, async () =>
        {
            var __dataArgs = EfDbArgs.Create(_mapper);
            var __result = await _ef.CreateAsync<PerformanceReview, EfModel.PerformanceReview>(__dataArgs, Check.NotNull(value, nameof(value))).ConfigureAwait(false);
            _evtPub.PublishValue(__result, new Uri($"my/hr/performancereview/{_evtPub.FormatKey(__result)}", UriKind.Relative), $"my.hr.performancereview", "created");
            return __result;
        });

        /// <summary>
        /// Updates an existing <see cref="PerformanceReview"/>.
        /// </summary>
        /// <param name="value">The <see cref="PerformanceReview"/>.</param>
        /// <returns>The updated <see cref="PerformanceReview"/>.</returns>
        public Task<PerformanceReview> UpdateAsync(PerformanceReview value) => _ef.EventOutboxInvoker.InvokeAsync(this, async () =>
        {
            var __dataArgs = EfDbArgs.Create(_mapper);
            var __result = await _ef.UpdateAsync<PerformanceReview, EfModel.PerformanceReview>(__dataArgs, Check.NotNull(value, nameof(value))).ConfigureAwait(false);
            _evtPub.PublishValue(__result, new Uri($"my/hr/performancereview/{_evtPub.FormatKey(__result)}", UriKind.Relative), $"my.hr.performancereview", "updated");
            return __result;
        });

        /// <summary>
        /// Deletes the specified <see cref="PerformanceReview"/>.
        /// </summary>
        /// <param name="id">The <see cref="Employee"/> identifier.</param>
        public Task DeleteAsync(Guid id) => _ef.EventOutboxInvoker.InvokeAsync(this, async () =>
        {
            var __dataArgs = EfDbArgs.Create(_mapper);
            await _ef.DeleteAsync<PerformanceReview, EfModel.PerformanceReview>(__dataArgs, id).ConfigureAwait(false);
            _evtPub.PublishValue(new PerformanceReview { Id = id }, new Uri($"my/hr/performancereview/{_evtPub.FormatKey(id)}", UriKind.Relative), $"my.hr.performancereview", "deleted", id);
        });

        /// <summary>
        /// Provides the <see cref="PerformanceReview"/> and Entity Framework <see cref="EfModel.PerformanceReview"/> <i>AutoMapper</i> mapping.
        /// </summary>
        public partial class EfMapperProfile : AutoMapper.Profile
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="EfMapperProfile"/> class.
            /// </summary>
            public EfMapperProfile()
            {
                var s2d = CreateMap<PerformanceReview, EfModel.PerformanceReview>();
                s2d.ForMember(d => d.PerformanceReviewId, o => o.MapFrom(s => s.Id));
                s2d.ForMember(d => d.EmployeeId, o => o.OperationTypes(OperationTypes.AnyExceptUpdate).MapFrom(s => s.EmployeeId));
                s2d.ForMember(d => d.Date, o => o.MapFrom(s => s.Date));
                s2d.ForMember(d => d.PerformanceOutcomeCode, o => o.MapFrom(s => s.OutcomeSid));
                s2d.ForMember(d => d.Reviewer, o => o.MapFrom(s => s.Reviewer));
                s2d.ForMember(d => d.Notes, o => o.MapFrom(s => s.Notes));
                s2d.ForMember(d => d.RowVersion, o => o.ConvertUsing(DatabaseRowVersionConverter.Default.ToDest, s => s.ETag));
                s2d.ForMember(d => d.CreatedBy, o => o.OperationTypes(OperationTypes.AnyExceptUpdate).MapFrom(s => s.ChangeLog.CreatedBy));
                s2d.ForMember(d => d.CreatedDate, o => o.OperationTypes(OperationTypes.AnyExceptUpdate).MapFrom(s => s.ChangeLog.CreatedDate));
                s2d.ForMember(d => d.UpdatedBy, o => o.OperationTypes(OperationTypes.AnyExceptCreate).MapFrom(s => s.ChangeLog.UpdatedBy));
                s2d.ForMember(d => d.UpdatedDate, o => o.OperationTypes(OperationTypes.AnyExceptCreate).MapFrom(s => s.ChangeLog.UpdatedDate));

                var d2s = CreateMap<EfModel.PerformanceReview, PerformanceReview>();
                d2s.ForMember(s => s.Id, o => o.MapFrom(d => d.PerformanceReviewId));
                d2s.ForMember(s => s.EmployeeId, o => o.OperationTypes(OperationTypes.AnyExceptUpdate).MapFrom(d => d.EmployeeId));
                d2s.ForMember(s => s.Date, o => o.MapFrom(d => d.Date));
                d2s.ForMember(s => s.OutcomeSid, o => o.MapFrom(d => d.PerformanceOutcomeCode));
                d2s.ForMember(s => s.Reviewer, o => o.MapFrom(d => d.Reviewer));
                d2s.ForMember(s => s.Notes, o => o.MapFrom(d => d.Notes));
                d2s.ForMember(s => s.ETag, o => o.ConvertUsing(DatabaseRowVersionConverter.Default.ToSrce, d => d.RowVersion));
                d2s.ForPath(s => s.ChangeLog.CreatedBy, o => o.OperationTypes(OperationTypes.AnyExceptUpdate).MapFrom(d => d.CreatedBy));
                d2s.ForPath(s => s.ChangeLog.CreatedDate, o => o.OperationTypes(OperationTypes.AnyExceptUpdate).MapFrom(d => d.CreatedDate));
                d2s.ForPath(s => s.ChangeLog.UpdatedBy, o => o.OperationTypes(OperationTypes.AnyExceptCreate).MapFrom(d => d.UpdatedBy));
                d2s.ForPath(s => s.ChangeLog.UpdatedDate, o => o.OperationTypes(OperationTypes.AnyExceptCreate).MapFrom(d => d.UpdatedDate));

                EfMapperProfileCtor(s2d, d2s);
            }

            partial void EfMapperProfileCtor(AutoMapper.IMappingExpression<PerformanceReview, EfModel.PerformanceReview> s2d, AutoMapper.IMappingExpression<EfModel.PerformanceReview, PerformanceReview> d2s); // Enables the constructor to be extended.
        }
    }
}

#pragma warning restore
#nullable restore