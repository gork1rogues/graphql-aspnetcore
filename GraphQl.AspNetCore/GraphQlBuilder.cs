﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQl.AspNetCore
{
    public class GraphQlBuilder : IGraphQlBuilder
    {
        private readonly IServiceCollection _services;

        public GraphQlBuilder(IServiceCollection services)
        {
            _services = services;
        }

        public IGraphQlBuilder AddSchema(string name, Action<SchemaConfiguration> configure)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var schema = new SchemaConfiguration(name);
            configure(schema);

            _services.AddSingleton<ISchemaProvider>(schema);

            return this;
        }

        internal IGraphQlBuilder AddSchema(SchemaConfiguration schema)
        {
            _services.AddSingleton<ISchemaProvider>(schema);

            return this;
        }

        public IGraphQlBuilder AddGraphTypes()
        {
            throw new NotImplementedException();
        }
    }
}
