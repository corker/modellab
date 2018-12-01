﻿using System;
using System.Collections.Generic;
using ModelLab.DependencyInjection;

namespace ModelLab
{
    public class ServiceRegistryBuilder : IBuildServiceProviders
    {
        private readonly List<Tuple<Type, ICreateServices>> _collections;

        public ServiceRegistryBuilder()
        {
            _collections = new List<Tuple<Type, ICreateServices>>();
        }

        public IProvideServices Build()
        {
            return new ServiceRegistry(_collections);
        }

        public IBuildServiceProviders Register(Type type, ICreateServices services)
        {
            var tuple = new Tuple<Type, ICreateServices>(type, services);
            _collections.Add(tuple);
            return this;
        }
    }
}