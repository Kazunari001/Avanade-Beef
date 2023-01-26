/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable

namespace MyEf.Hr.Business.Data
{
    /// <summary>
    /// Provides the <see cref="EmployeeBase"/> data access.
    /// </summary>
    public partial class EmployeeBaseData
    {

        /// <summary>
        /// Provides the <see cref="EmployeeBase"/> to Entity Framework <see cref="EfModel.Employee"/> mapping.
        /// </summary>
        public partial class EntityToModelEfMapper : Mapper<EmployeeBase, EfModel.Employee>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="EntityToModelEfMapper"/> class.
            /// </summary>
            public EntityToModelEfMapper()
            {
                Map((s, d) => d.EmployeeId = s.Id);
                Map((s, d) => d.Email = s.Email);
                Map((s, d) => d.FirstName = s.FirstName);
                Map((s, d) => d.LastName = s.LastName);
                Map((s, d) => d.GenderCode = s.GenderSid);
                Map((s, d) => d.Birthday = s.Birthday);
                Map((s, d) => d.StartDate = s.StartDate);
                Flatten(s => s.Termination);
                Map((s, d) => d.PhoneNo = s.PhoneNo);
                EntityToModelEfMapperCtor();
            }

            partial void EntityToModelEfMapperCtor(); // Enables the constructor to be extended.

            /// <inheritdoc/>
            public override bool IsSourceInitial(EmployeeBase s)
                => s.Id == default
                && s.Email == default
                && s.FirstName == default
                && s.LastName == default
                && s.GenderSid == default
                && s.Birthday == default
                && s.StartDate == default
                && s.Termination == default
                && s.PhoneNo == default;
        }

        /// <summary>
        /// Provides the Entity Framework <see cref="EfModel.Employee"/> to <see cref="EmployeeBase"/> mapping.
        /// </summary>
        public partial class ModelToEntityEfMapper : Mapper<EfModel.Employee, EmployeeBase>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ModelToEntityEfMapper"/> class.
            /// </summary>
            public ModelToEntityEfMapper()
            {
                Map((s, d) => d.Id = (Guid)s.EmployeeId);
                Map((s, d) => d.Email = (string?)s.Email);
                Map((s, d) => d.FirstName = (string?)s.FirstName);
                Map((s, d) => d.LastName = (string?)s.LastName);
                Map((s, d) => d.GenderSid = (string?)s.GenderCode);
                Map((s, d) => d.Birthday = (DateTime)s.Birthday);
                Map((s, d) => d.StartDate = (DateTime)s.StartDate);
                Expand<TerminationDetail>((d, v) => d.Termination = v);
                Map((s, d) => d.PhoneNo = (string?)s.PhoneNo);
                ModelToEntityEfMapperCtor();
            }

            partial void ModelToEntityEfMapperCtor(); // Enables the constructor to be extended.

            /// <inheritdoc/>
            public override bool IsSourceInitial(EfModel.Employee s)
                => s.EmployeeId == default
                && s.Email == default
                && s.FirstName == default
                && s.LastName == default
                && s.GenderCode == default
                && s.Birthday == default
                && s.StartDate == default
                && s.PhoneNo == default;
        }
    }
}

#pragma warning restore
#nullable restore