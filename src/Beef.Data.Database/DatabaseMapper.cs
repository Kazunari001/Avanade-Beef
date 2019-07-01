﻿// Copyright (c) Avanade. Licensed under the MIT License. See https://github.com/Avanade/Beef

using Beef.Entities;
using Beef.Mapper;
using Beef.Reflection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Beef.Data.Database
{
    /// <summary>
    /// Enables core <b>Database</b> property mapping capabilities.
    /// </summary>
    public interface IDatabaseMapper : IEntityMapperBase
    {
        /// <summary>
        /// Gets the unique key and adds to the <see cref="DatabaseParameters"/> from an entity <paramref name="value"/>.
        /// </summary>
        /// <param name="parameters">The <see cref="DatabaseParameters"/>.</param>
        /// <param name="operationType">The single <see cref="Mapper.OperationTypes"/> that indicates that a <see cref="Mapper.OperationTypes.Create"/> is being performed;
        /// therefore any key properties marked as <see cref="PropertyMapperCustomBase{TSrce, TSrceProperty}.IsUniqueKeyAutoGeneratedOnCreate"/> have a parameter direction of 
        /// <see cref="ParameterDirection.Output"/> versus <see cref="ParameterDirection.Input"/>.</param>
        /// <param name="value">The entity value.</param>
        void GetKeyParams(DatabaseParameters parameters, OperationTypes operationType, object value);

        /// <summary>
        /// Gets the unique key and adds to the <see cref="DatabaseParameters"/>.
        /// </summary>
        /// <param name="parameters">The <see cref="DatabaseParameters"/>.</param>
        /// <param name="operationType">The single <see cref="Mapper.OperationTypes"/> that indicates that a <see cref="Mapper.OperationTypes.Create"/> is being performed;
        /// therefore any key properties marked as <see cref="PropertyMapperCustomBase{TSrce, TSrceProperty}.IsUniqueKeyAutoGeneratedOnCreate"/> have a parameter direction of 
        /// <see cref="ParameterDirection.Output"/> versus <see cref="ParameterDirection.Input"/>.</param>
        /// <param name="keys">The unique key values.</param>
        void GetKeyParams(DatabaseParameters parameters, OperationTypes operationType, params IComparable[] keys);

        /// <summary>
        /// Updates the <see cref="DatabaseParameters"/> mapping values from the source entity <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The entity value.</param>
        /// <param name="parameters">The <see cref="DatabaseParameters"/>.</param>
        /// <param name="operationType">The single <see cref="Mapper.OperationTypes"/> being performed to enable selection.</param>
        /// <param name="data">An optional (additional) data object.</param>
        void MapToDb(object value, DatabaseParameters parameters, OperationTypes operationType, object data);

        /// <summary>
        /// Creates a source entity mapping values from the <see cref="DatabaseParameters"/>.
        /// </summary>
        /// <param name="dr">The <see cref="DatabaseParameters"/>.</param>
        /// <returns>An object instance populated from the <see cref="DatabaseParameters"/>.</returns>
        /// <param name="operationType">The single <see cref="Mapper.OperationTypes"/> being performed to enable selection.</param>
        /// <param name="data">An optional (additional) data object.</param>
        object MapFromDb(DatabaseRecord dr, OperationTypes operationType, object data);
    }

    /// <summary>
    /// Enables the <b>Database</b> entity <see cref="Type"/> mapping capabilities.
    /// </summary>
    /// <typeparam name="TSrce">The source entity <see cref="Type"/>.</typeparam>
    public interface IDatabaseMapper<TSrce> : IEntitySrceMapper<TSrce>, IDatabaseMapper where TSrce : class, new()
    {
        /// <summary>
        /// Updates the <see cref="DatabaseParameters"/> mapping values from the source entity <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The entity value.</param>
        /// <param name="parameters">The <see cref="DatabaseParameters"/>.</param>
        /// <param name="operationType">The single <see cref="Mapper.OperationTypes"/> being performed to enable selection.</param>
        /// <param name="data">An optional (additional) data object.</param>
        void MapToDb(TSrce value, DatabaseParameters parameters, OperationTypes operationType, object data);

        /// <summary>
        /// Creates a source entity mapping values from the <see cref="DatabaseParameters"/>.
        /// </summary>
        /// <param name="dr">The <see cref="DatabaseParameters"/>.</param>
        /// <returns>A <typeparamref name="TSrce"/> instance populated from the <see cref="DatabaseParameters"/>.</returns>
        /// <param name="operationType">The single <see cref="Mapper.OperationTypes"/> being performed to enable selection.</param>
        /// <param name="data">An optional (additional) data object.</param>
        new TSrce MapFromDb(DatabaseRecord dr, OperationTypes operationType, object data);
    }

    /// <summary>
    /// Provides entity mapping capabilities to and from the <see cref="DatabaseBase">database</see>.
    /// </summary>
    /// <typeparam name="TSrce">The source entity <see cref="Type"/>.</typeparam>
    public class DatabaseMapper<TSrce> : EntitySrceMapper<TSrce>, IDatabaseMapper<TSrce> where TSrce : class, new()
    {
        /// <summary>
        /// Creates an <see cref="DatabaseMapper{TSrce}"/> where properties are added manually.
        /// </summary>
        /// <returns></returns>
        public static DatabaseMapper<TSrce> Create()
        {
            return new DatabaseMapper<TSrce>();
        }

        /// <summary>
        /// Adds a <see cref="DatabasePropertyMapper{TSrce, TSrceProperty}"/> to the mapper.
        /// </summary>
        /// <typeparam name="TSrceProperty">The source property <see cref="Type"/>.</typeparam>
        /// <param name="srcePropertyExpression">The <see cref="Expression"/> to reference the source entity property.</param>
        /// <param name="columnName">The database column name.</param>
        /// <param name="operationTypes">The <see cref="Mapper.OperationTypes"/> selection to enable inclusion or exclusion of property (default to <see cref="OperationTypes.Any"/>).</param>
        /// <returns>The <see cref="DatabasePropertyMapper{TEntity, TProperty}"/>.</returns>
        public DatabasePropertyMapper<TSrce, TSrceProperty> Property<TSrceProperty>(Expression<Func<TSrce, TSrceProperty>> srcePropertyExpression, string columnName = null, OperationTypes operationTypes = OperationTypes.Any)
        {
            if (srcePropertyExpression == null)
                throw new ArgumentNullException(nameof(srcePropertyExpression));

            DatabasePropertyMapper<TSrce, TSrceProperty> mapping = new DatabasePropertyMapper<TSrce, TSrceProperty>(srcePropertyExpression, columnName, operationTypes);
            AddPropertyMapper<TSrceProperty>(mapping);
            return mapping;
        }

        /// <summary>
        /// Adds (or gets) a <see cref="DatabasePropertyMapper{TSrce, TSrceProperty}"/>.
        /// </summary>
        /// <typeparam name="TSrceProperty">The source property <see cref="Type"/>.</typeparam>
        /// <param name="srcePropertyExpression">The <see cref="Expression"/> to reference the source entity property.</param>
        /// <param name="columnName">The database column name.</param>
        /// <param name="operationTypes">The <see cref="Mapper.OperationTypes"/> selection to enable inclusion or exclusion of property (default to <see cref="OperationTypes.Any"/>).</param>
        /// <param name="property">An <see cref="Action"/> enabling access to the created <see cref="DatabasePropertyMapper{TSrce, TSrceProperty}"/>.</param>
        /// <returns>The <see cref="DatabaseMapper{TEntity}"/>.</returns>
        public DatabaseMapper<TSrce> HasProperty<TSrceProperty>(Expression<Func<TSrce, TSrceProperty>> srcePropertyExpression, string columnName = null, OperationTypes operationTypes = OperationTypes.Any, Action<DatabasePropertyMapper<TSrce, TSrceProperty>> property = null)
        {
            if (srcePropertyExpression == null)
                throw new ArgumentNullException(nameof(srcePropertyExpression));

            var spe = PropertyExpression<TSrce, TSrceProperty>.Create(srcePropertyExpression);
            var px = GetBySrcePropertyName(spe.Name);
            if (px != null && px.DestPropertyName != columnName)
                throw new ArgumentException($"Source property '{srcePropertyExpression.Name}' mapping already exists with a different destination column name");

            DatabasePropertyMapper<TSrce, TSrceProperty> p = null;
            if (px == null)
                p = Property(srcePropertyExpression, columnName, operationTypes);
            else
                p = (DatabasePropertyMapper<TSrce, TSrceProperty>)px;

            property?.Invoke(p);
            return this;
        }

        /// <summary>
        /// Inherits the properties from the selected <paramref name="inheritMapper"/>.
        /// </summary>
        /// <param name="inheritMapper">The <see cref="IDatabaseMapper"/> to inherit from.</param>
        public void InheritPropertiesFrom<T>(IDatabaseMapper<T> inheritMapper) where T : class, new()
        {
            if (inheritMapper == null)
                throw new ArgumentNullException(nameof(inheritMapper));

            if (!SrceType.GetTypeInfo().IsSubclassOf(typeof(T)))
                throw new ArgumentException($"Type {typeof(T).Name} must inherit from {SrceType.Name}.");

            var pe = Expression.Parameter(SrceType, "x");
            var type = typeof(DatabaseMapper<>).MakeGenericType(SrceType);

            foreach (var p in inheritMapper.Mappings.OfType<IDatabasePropertyMapper>())
            {
                var lex = Expression.Lambda(Expression.Property(pe, p.SrcePropertyName), pe);
                var pmap = (IDatabasePropertyMapper)type
                    .GetMethod("Property", BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                    .MakeGenericMethod(p.SrcePropertyType)
                    .Invoke(this, new object[] { lex, p.DestPropertyName, p.OperationTypes });

                if (p.IsUniqueKey)
                    pmap.SetUniqueKey(p.IsUniqueKeyAutoGeneratedOnCreate);

                pmap.DestDbType = p.DestDbType;
                pmap.SetConverter(p.Converter);
                pmap.SetMapper(p.Mapper);
            }
        }

        /// <summary>
        /// Updates the <see cref="DatabaseParameters"/> mapping values from the source entity <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The entity value.</param>
        /// <param name="parameters">The <see cref="DatabaseParameters"/>.</param>
        /// <param name="operationType">The single <see cref="Mapper.OperationTypes"/> being performed to enable selection.</param>
        /// <param name="data">An optional (additional) data object.</param>
        public void MapToDb(TSrce value, DatabaseParameters parameters, OperationTypes operationType = OperationTypes.Unspecified, object data = null)
        {
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));

            foreach (IDatabasePropertyMapper<TSrce> map in Mappings)
            {
                if (map.OperationTypes.HasFlag(operationType) && map.MapSrceToDestWhen(value))
                    map.SetDestValue(value, parameters, operationType);
            }

            OnMapToDb(value, parameters, operationType, data);
        }

        /// <summary>
        /// Updates the <see cref="DatabaseParameters"/> mapping values from the source entity <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The entity value.</param>
        /// <param name="parameters">The <see cref="DatabaseParameters"/>.</param>
        /// <param name="operationType">The single <see cref="Mapper.OperationTypes"/> being performed to enable selection.</param>
        /// <param name="data">An optional (additional) data object.</param>
        void IDatabaseMapper.MapToDb(object value, DatabaseParameters parameters, OperationTypes operationType, object data)
        {
            MapToDb((TSrce)value, parameters, operationType, data);
        }

        /// <summary>
        /// Extension opportunity when performing a <see cref="MapToDb(TSrce, DatabaseParameters, OperationTypes, object)"/>.
        /// </summary>
        /// <param name="value">The entity value.</param>
        /// <param name="parameters">The <see cref="DatabaseParameters"/>.</param>
        /// <param name="operationType">The single <see cref="Mapper.OperationTypes"/> being performed to enable selection.</param>
        /// <param name="data">An optional (additional) data object.</param>
        protected virtual void OnMapToDb(TSrce value, DatabaseParameters parameters, OperationTypes operationType, object data) { }

        /// <summary>
        /// Creates a source entity mapping values from the <see cref="DatabaseParameters"/>.
        /// </summary>
        /// <param name="dr">The <see cref="DatabaseParameters"/>.</param>
        /// <param name="operationType">The single <see cref="Mapper.OperationTypes"/> being performed to enable selection.</param>
        /// <param name="data">An optional (additional) data object.</param>
        /// <returns>A <typeparamref name="TSrce"/> instance populated from the <see cref="DatabaseParameters"/>.</returns>
        public TSrce MapFromDb(DatabaseRecord dr, OperationTypes operationType = OperationTypes.Unspecified, object data = null)
        {
            if (dr == null)
                throw new ArgumentNullException(nameof(dr));

            TSrce value = new TSrce();

            foreach (IDatabasePropertyMapper<TSrce> map in Mappings)
            {
                if (map.OperationTypes.HasFlag(operationType) && map.MapDestToSrceWhen(dr))
                    map.SetSrceValue(value, dr, operationType);
            }

            value = OnMapFromDb(value, dr, operationType, data);

            if (value != null && MapFromDbNullWhenIsInitial && value is ICleanUp ic && ic.IsInitial)
                return null;

            return value;
        }

        /// <summary>
        /// Creates a source entity mapping values from the <see cref="DatabaseParameters"/>.
        /// </summary>
        /// <param name="dr">The <see cref="DatabaseParameters"/>.</param>
        /// <param name="operationType">The single <see cref="Mapper.OperationTypes"/> being performed to enable selection.</param>
        /// <param name="data">An optional (additional) data object.</param>
        /// <returns>An object instance populated from the <see cref="DatabaseParameters"/>.</returns>
        object IDatabaseMapper.MapFromDb(DatabaseRecord dr, OperationTypes operationType, object data)
        {
            return MapFromDb(dr, operationType, data);
        }

        /// <summary>
        /// Extension opportunity when performing a <see cref="MapFromDb(DatabaseRecord, OperationTypes, object)"/>.
        /// </summary>
        /// <param name="value">The entity value.</param>
        /// <param name="dr">The <see cref="DatabaseRecord"/>.</param>
        /// <param name="operationType">The single <see cref="Mapper.OperationTypes"/> being performed to enable selection.</param>
        /// <param name="data">An optional (additional) data object.</param>
        /// <returns>The entity value.</returns>
        protected virtual TSrce OnMapFromDb(TSrce value, DatabaseRecord dr, OperationTypes operationType, object data)
        {
            return value;
        }

        /// <summary>
        /// Indicates whether when performing a <see cref="MapFromDb(DatabaseRecord, OperationTypes, object)"/> and the result implements <see cref="ICleanUp"/> and <see cref="ICleanUp.IsInitial"/>
        /// is <c>true</c> then the result should be null, versus an initial instance value. Defaults to <c>true</c> which will result in a null where an initial instance value is created from a mapping.
        /// </summary>
        public bool MapFromDbNullWhenIsInitial { get; set; } = true;

        /// <summary>
        /// Provides an additional opportunity to perform an mapper configurations.
        /// </summary>
        /// <param name="additional">The action to invoke to perform the additional configurations.</param>
        /// <returns>The <see cref="DatabaseMapper{TEntity}"/>.</returns>
        public DatabaseMapper<TSrce> Additional(Action<DatabaseMapper<TSrce>> additional)
        {
            additional?.Invoke(this);
            return this;
        }

        /// <summary>
        /// Gets the database parameter name (for usage in stored procedures) based on the source property name.
        /// </summary>
        /// <param name="name">The source property name.</param>
        /// <returns>The database parameter name.</returns>
        public string GetParamName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            var map = (IDatabasePropertyMapper<TSrce>)GetBySrcePropertyName(name);
            if (map == null)
                throw new ArgumentException("Specified source property name does not exist.");

            return map.DestParameterName;
        }

        /// <summary>
        /// Gets the database parameter <see cref="System.Data.DbType"/> (for usage in stored procedures) based on the source property name.
        /// </summary>
        /// <param name="name">The source property name.</param>
        /// <returns>The database parameter <see cref="System.Data.DbType"/>.</returns>
        public DbType? GetParamDbType(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            var map = (IDatabasePropertyMapper<TSrce>)GetBySrcePropertyName(name);
            if (map == null)
                throw new ArgumentException("Specified source property name does not exist.");

            return map.DestDbType;
        }

        /// <summary>
        /// Gets the <see cref="IPropertySrceMapper{TSrce}"/> mapping by source property name (see <see cref="EntitySrceMapper{TSrce}.GetBySrcePropertyName"/>).
        /// </summary>
        /// <param name="sourcePropertyName">The source property name.</param>
        /// <returns>The <see cref="IPropertySrceMapper{TSrce}"/> where found; otherwise, <c>null</c>.</returns>
        public IDatabasePropertyMapper<TSrce> this[string sourcePropertyName]
        {
            get { return (IDatabasePropertyMapper<TSrce>)GetBySrcePropertyName(sourcePropertyName); }
        }

        /// <summary>
        /// Gets the unique key and adds to the <see cref="DatabaseParameters"/> from an entity <paramref name="value"/>.
        /// </summary>
        /// <param name="parameters">The <see cref="DatabaseParameters"/>.</param>
        /// <param name="operationType">The single <see cref="Mapper.OperationTypes"/> that indicates that a <see cref="Mapper.OperationTypes.Create"/> is being performed;
        /// therefore any key properties marked as <see cref="PropertyMapperCustomBase{TSrce, TSrceProperty}.IsUniqueKeyAutoGeneratedOnCreate"/> have a parameter direction of 
        /// <see cref="ParameterDirection.Output"/> versus <see cref="ParameterDirection.Input"/>.</param>
        /// <param name="value">The entity value.</param>
        void IDatabaseMapper.GetKeyParams(DatabaseParameters parameters, OperationTypes operationType, object value)
        {
            GetKeyParams(parameters, operationType, (TSrce)value);
        }

        /// <summary>
        /// Gets the unique key and adds to the <see cref="DatabaseParameters"/> from an entity <paramref name="value"/>.
        /// </summary>
        /// <param name="parameters">The <see cref="DatabaseParameters"/>.</param>
        /// <param name="operationType">The single <see cref="Mapper.OperationTypes"/> that indicates that a <see cref="Mapper.OperationTypes.Create"/> is being performed;
        /// therefore any key properties marked as <see cref="PropertyMapperCustomBase{TSrce, TSrceProperty}.IsUniqueKeyAutoGeneratedOnCreate"/> have a parameter direction of 
        /// <see cref="ParameterDirection.Output"/> versus <see cref="ParameterDirection.Input"/>.</param>
        /// <param name="value">The entity value.</param>
        public void GetKeyParams(DatabaseParameters parameters, OperationTypes operationType, TSrce value)
        {
            foreach (IDatabasePropertyMapper<TSrce> map in UniqueKey)
            {
                var dir = (operationType == OperationTypes.Create && map.IsUniqueKeyAutoGeneratedOnCreate) ? ParameterDirection.Output : ParameterDirection.Input;
                if (map.DestDbType.HasValue)
                    parameters.AddParameter(map.DestParameterName, (IComparable)map.GetSrceValue(value, operationType), map.DestDbType.Value, dir);
                else
                    parameters.AddParameter(map.DestParameterName, (IComparable)map.GetSrceValue(value, operationType), dir);
            }
        }

        /// <summary>
        /// Gets the unique key and adds to the <see cref="DatabaseParameters"/> for the listed key values.
        /// </summary>
        /// <param name="parameters">The <see cref="DatabaseParameters"/>.</param>
        /// <param name="operationType">The single <see cref="Mapper.OperationTypes"/> that indicates that a <see cref="Mapper.OperationTypes.Create"/> is being performed;
        /// therefore any key properties marked as <see cref="PropertyMapperCustomBase{TSrce, TSrceProperty}.IsUniqueKeyAutoGeneratedOnCreate"/> have a parameter direction of 
        /// <see cref="ParameterDirection.Output"/> versus <see cref="ParameterDirection.Input"/>.</param>
        /// <param name="keys">The unique key values.</param>
        public void GetKeyParams(DatabaseParameters parameters, OperationTypes operationType, params IComparable[] keys)
        {
            var uq = operationType == OperationTypes.Create ? UniqueKey.Where(x => !x.IsUniqueKeyAutoGeneratedOnCreate).ToArray() : UniqueKey;
            if (keys == null || keys.Length != uq.Length)
                throw new ArgumentException("The number of keys supplied must equal the number of properties identified as IsUniqueKey.", nameof(keys));

            for (int i = 0; i < keys.Length; i++)
            {
                var map = (IDatabasePropertyMapper)uq[i];
                var dir = (operationType == OperationTypes.Create && map.IsUniqueKeyAutoGeneratedOnCreate) ? ParameterDirection.Output : ParameterDirection.Input;
                if (map.DestDbType.HasValue)
                    parameters.AddParameter(map.DestParameterName, keys[0], map.DestDbType.Value, dir);
                else
                    parameters.AddParameter(map.DestParameterName, keys[0], dir);
            }
        }

        /// <summary>
        /// Adds the standard properties for <see cref="IETag"/> and <see cref="IChangeLog"/>.
        /// </summary>
        public void AddStandardProperties()
        {
            // Create the lambda expressions for the properties and add to the mapper where applicable.
            if (typeof(IETag).IsAssignableFrom(typeof(TSrce)) && GetBySrcePropertyName(nameof(IETag.ETag)) == null)
            {
                var spe = Expression.Parameter(SrceType, "x");
                var sex = Expression.Lambda(Expression.Property(spe, nameof(IETag.ETag)), spe);
                var pmap = (DatabasePropertyMapper<TSrce, string>)typeof(DatabaseMapper<TSrce>)
                    .GetMethod("Property")
                    .MakeGenericMethod(new Type[] { typeof(string) })
                    .Invoke(this, new object[] { sex, DatabaseColumns.RowVersionName, OperationTypes.AnyExceptCreate });

                pmap.SetConverter(DatabaseRowVersionConverter.Default);
            }

            if (typeof(IChangeLog).IsAssignableFrom(typeof(TSrce)) && GetBySrcePropertyName(nameof(IChangeLog.ChangeLog)) == null)
            {
                var spe = Expression.Parameter(SrceType, "x");
                var sex = Expression.Lambda(Expression.Property(spe, nameof(IChangeLog.ChangeLog)), spe);
                var pmap = (DatabasePropertyMapper<TSrce, ChangeLog>)typeof(DatabaseMapper<TSrce>)
                    .GetMethod("Property")
                    .MakeGenericMethod(new Type[] { typeof(ChangeLog) })
                    .Invoke(this, new object[] { sex, null, OperationTypes.Get });

                pmap.SetMapper(DatabaseChangeLogMapper.Default);
            }
        }

        #region CreateArgs

        /// <summary>
        /// Creates a <see cref="DatabaseArgs{T}"/>.
        /// </summary>
        /// <param name="storedProcedure">The stored procedure name.</param>
        /// <returns>A <see cref="DatabaseArgs{T}"/>.</returns>
        public DatabaseArgs<TSrce> CreateArgs(string storedProcedure)
        {
            return new DatabaseArgs<TSrce>(this, storedProcedure);
        }

        /// <summary>
        /// Creates a <see cref="DatabaseArgs{T}"/> with a <see cref="PagingArgs"/>.
        /// </summary>
        /// <param name="storedProcedure">The stored procedure name.</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        /// <returns>A <see cref="DatabaseArgs{T}"/>.</returns>
        public DatabaseArgs<TSrce> CreateArgs(string storedProcedure, PagingArgs paging)
        {
            return new DatabaseArgs<TSrce>(this, storedProcedure, paging);
        }

        /// <summary>
        /// Creates a <see cref="DatabaseArgs{T}"/> with a <see cref="PagingResult"/>.
        /// </summary>
        /// <param name="storedProcedure">The stored procedure name.</param>
        /// <param name="paging">The <see cref="PagingResult"/>.</param>
        /// <returns>A <see cref="DatabaseArgs{T}"/>.</returns>
        public DatabaseArgs<TSrce> CreateArgs(string storedProcedure, PagingResult paging)
        {
            return new DatabaseArgs<TSrce>(this, storedProcedure, paging);
        }

        #endregion

        #region CreateTvp

        /// <summary>
        /// Creates a <see cref="TableValuedParameter"/> for the <paramref name="list"/>.
        /// </summary>
        /// <param name="typeName">The SQL type name of the table-valued parameter.</param>
        /// <param name="list">The entity list.</param>
        /// <returns>The Table-Valued Parameter.</returns>
        public TableValuedParameter CreateTableValuedParameter(string typeName, IEnumerable<TSrce> list)
        {
            var dt = new DataTable();
            foreach (var pm in this.Mappings)
            {
                dt.Columns.Add(pm.DestPropertyName, pm.Converter == null ? pm.SrcePropertyType : pm.Converter.DestUnderlyingType);
            }

            if (list != null)
            {
                foreach (var val in list)
                {
                    var dr = dt.NewRow();
                    foreach (var pm in this.Mappings)
                    {
                        if (pm.Converter == null)
                            dr[pm.DestPropertyName] = pm.GetSrceValue(val, OperationTypes.Update);
                        else
                            dr[pm.DestPropertyName] = pm.Converter.ConvertToDest(pm.GetSrceValue(val, OperationTypes.Update));
                    }

                    dt.Rows.Add(dr);
                }
            }

            return new TableValuedParameter(Check.NotEmpty(typeName, nameof(typeName)), dt);
        }

        /// <summary>
        /// Adds the <paramref name="list"/> to an existing <see cref="TableValuedParameter"/> only updating the matched column names.
        /// </summary>
        /// <param name="tvp">The Table-Valued Parameter.</param>
        /// <param name="list">The entity list.</param>
        public void AddToTableValuedParameter(TableValuedParameter tvp, IEnumerable<TSrce> list)
        {
            Check.NotNull(tvp, nameof(tvp));
            if (list == null || tvp.Value.Columns.Count == 0)
                return;

            var dt = tvp.Value;
            foreach (var val in list)
            {
                var dr = dt.NewRow();
                foreach (var pm in this.Mappings)
                {
                    if (!dt.Columns.Contains(pm.DestPropertyName))
                        continue;

                    if (pm.Converter == null)
                        dr[pm.DestPropertyName] = pm.GetSrceValue(val, OperationTypes.Update) ?? DBNull.Value;
                    else
                        dr[pm.DestPropertyName] = pm.Converter.ConvertToDest(pm.GetSrceValue(val, OperationTypes.Update)) ?? DBNull.Value;
                }

                dt.Rows.Add(dr);
            }
        }

        #endregion
    }

    /// <summary>
    /// Provides <see cref="DatabaseMapper{TSrce}"/> with a singleton <see cref="Default"/>.
    /// </summary>
    /// <typeparam name="TSrce">The source entity <see cref="Type"/>.</typeparam>
    /// <typeparam name="TMapper">The mapper <see cref="Type"/>.</typeparam>
    public abstract class DatabaseMapper<TSrce, TMapper> : DatabaseMapper<TSrce>
        where TSrce : class, new()
        where TMapper : DatabaseMapper<TSrce, TMapper>, new()
    {
        private static readonly TMapper _default = new TMapper();

        /// <summary>
        /// Gets the current instance of the mapper.
        /// </summary>
        public static TMapper Default
        {
            get
            {
                if (_default == null)
                    throw new InvalidOperationException("An instance of this Mapper cannot be referenced as it is still being constructed; beware that you may have a circular reference within the constructor.");

                return _default;
            }
        }
    }
}