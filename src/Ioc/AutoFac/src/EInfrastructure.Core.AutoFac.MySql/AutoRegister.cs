﻿// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;
using Autofac;
using EInfrastructure.Core.Configuration.Ioc;
using Microsoft.Extensions.DependencyInjection;

namespace EInfrastructure.Core.AutoFac.MySql
{
    /// <summary>
    ///
    /// </summary>
    public class AutoRegister : EInfrastructure.Core.AutoFac.AutoRegister
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="services"></param>
        /// <param name="action"></param>
        /// <param name="typeFinder"></param>
        /// <param name="assemblies"></param>
        /// <returns></returns>
        public override IServiceProvider Use(IServiceCollection services,
            Action<ContainerBuilder> action = null, Assembly[] assemblies = null, ITypeFinder typeFinder = null)
        {
            return base.Use(services, this.CreateContainerBuilder(action, null, assemblies, typeFinder));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="action"></param>
        /// <param name="containerBuilder"></param>
        /// <param name="assemblies"></param>
        /// <param name="typeFinder"></param>
        /// <returns></returns>
        public override ContainerBuilderBase CreateContainerBuilder(Action<ContainerBuilder> action,
            ContainerBuilder containerBuilder = null, Assembly[] assemblies = null,
            ITypeFinder typeFinder = null)
        {
            return base.CreateContainerBuilder(builder =>
            {
                builder.RegisterMySqlRepositoryModule();
                action?.Invoke(builder);
            }, containerBuilder, assemblies, typeFinder);
        }
    }
}