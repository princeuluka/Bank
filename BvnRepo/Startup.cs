using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
//using Microsoft.OpenApi.Models

namespace BvnRepo
{
    public Class Startup
    {
      public Startup(IConfiguration configuration)
      {
        Configuration = configuration;
      } 

      public IConfiguration Configuration {get;} 

      public void ConfigureServices (IServiceCollection services)
      {
        services.AddControllers();
        services.AddSwaggerGen()
      }
    }
}