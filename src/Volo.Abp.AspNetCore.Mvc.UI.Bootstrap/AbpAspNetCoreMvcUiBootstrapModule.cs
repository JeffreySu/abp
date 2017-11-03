﻿using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.Bundling;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.VirtualFileSystem.Embedded;

namespace Volo.Abp.AspNetCore.Mvc.UI.Bootstrap
{
    [DependsOn(typeof(AbpAspNetCoreMvcUiModule))]
    public class AbpAspNetCoreMvcUiBootstrapModule : AbpModule
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddAssemblyOf<AbpAspNetCoreMvcUiBootstrapModule>();
            
            services.Configure<VirtualFileSystemOptions>(options =>
            {
                options.FileSets.Add(
                    new EmbeddedFileSet(
                        "/",
                        GetType().GetTypeInfo().Assembly,
                        "Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.wwwroot"
                        )
                    );

                options.FileSets.Add(
                    new EmbeddedFileSet(
                        "/Views/",
                        GetType().GetTypeInfo().Assembly,
                        "Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.Views"
                        )
                    );
            });

            services.Configure<BundlingOptions>(options =>
            {
                options.StyleBundles.Add("GlobalStyles", new[]
                {
                    "/libs/bootstrap/css/bootstrap.min.css"
                });

                options.ScriptBundles.Add("GlobalScripts", new[]
                {
                    //TODO: Split jQuery to it's own nuget package!

                    "/libs/jquery/jquery-3.1.1.min.js",
                    "/libs/tether/js/tether.min.js",
                    "/libs/bootstrap/js/bootstrap.min.js",
                    "/libs/abp/abp-jquery.js?_v" + DateTime.Now.Ticks //TODO: Move this to Volo.Abp.AspNetCore.Mvc.UI.. or to new jQuery package?
                });
            });
        }
    }
}
