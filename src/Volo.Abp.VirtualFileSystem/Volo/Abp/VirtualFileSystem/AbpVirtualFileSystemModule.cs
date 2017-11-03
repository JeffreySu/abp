﻿using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Volo.Abp.VirtualFileSystem
{
    public class AbpVirtualFileSystemModule : AbpModule
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddAssemblyOf<AbpVirtualFileSystemModule>();
        }
    }
}
