// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using EInfrastructure.Core.Config.Entities.Data;
using EInfrastructure.Core.Config.Entities.Ioc;
using Microsoft.EntityFrameworkCore;

namespace EInfrastructure.Core.SqlServer.Common
{
    /// <summary>
    ///
    /// </summary>
    internal class SpatialDimensionBaseQuery<TEntity, T>
        : ISpatialDimensionQuery<TEntity, T> where TEntity : class, IEntity<T>
        where T : IComparable
    {
        /// <summary>
        ///
        /// </summary>
        private DbContext Dbcontext;

        private readonly IExecute _execute;

        /// <summary>
        ///
        /// </summary>
        /// <param name="dbContext">上下文</param>
        /// <param name="execute"></param>
        public SpatialDimensionBaseQuery(DbContext dbContext, IExecute execute)
        {
            Dbcontext = dbContext;
            _execute = execute;
        }

        #region get list

        /// <summary>
        /// get list
        /// </summary>
        /// <param name="param"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual List<T> GetList<T>(SpatialDimensionParam param)
        {
            throw new NotImplementedException();
        }

        #endregion

        /// <summary>
        /// get list
        /// </summary>
        /// <param name="param"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual PageData<T> GetPageData<T>(SpatialDimensionPagingParam param)
        {
            throw new NotImplementedException();
        }

        #region get IQueryable

        /// <summary>
        /// get list
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> GetQueryable(SpatialDimensionParam param)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
