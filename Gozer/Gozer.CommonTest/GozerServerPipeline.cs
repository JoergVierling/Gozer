using System;
using System.Collections.Generic;
using Gozer.Configuration.DependencyInjection.Options;
using Gozer.Contract;
using Gozer.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Gozer.CommonTest
{
    public class GozerServerPipeline
    {
        public const string BaseUrl = "https://server";

        public GozerServerOptions Options { get; set; }
        public List<Service> Services { get; set; } = new List<Service>();

        public void Initialize(string basePath = null, bool enableLogging = false)
        {
            var builder = new WebHostBuilder();
            builder.ConfigureServices(ConfigureServices);
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGozerServer(options => { Options = options; });
        }

        public void ConfigureApp(IApplicationBuilder app)
        {
            app.UseGozerServer();
        }
    }
}