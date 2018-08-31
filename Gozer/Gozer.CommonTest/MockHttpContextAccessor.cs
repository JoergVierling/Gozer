// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.IO;
using Gozer.CommonTest;
using Gozer.Configuration.DependencyInjection.Options;
using Gozer.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication;

namespace IdentityServer4.UnitTests.Common
{
    public class MockHttpContextAccessor : IHttpContextAccessor
    {
        private HttpContext _context = new DefaultHttpContext();
        public MockServiceSheldManager ServiceSheldManager { get; set; } = new MockServiceSheldManager();

        public MockHttpContextAccessor(GozerServerOptions options = null)
        {
            options = options ?? new GozerServerOptions();

            var services = new ServiceCollection();
            services.AddSingleton(options);
            services.AddSingleton<IServiceSheldManager>(ServiceSheldManager);

            _context.RequestServices = services.BuildServiceProvider();
            _context.Response.Body = new MemoryStream();

        }

        public HttpContext HttpContext
        {
            get { return _context; }

            set { _context = value; }
        }
    }
}