using Microsoft.Extensions.DependencyInjection;
using NLayerBusiness.Abstracts;
using NLayerDataAccess.Abstracts;
using NLayerDataAccess.Concretes.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerBusiness.Concretes.DependencyResolvers.ServiceCollections
{
    public static class ServiceCollectionExtensions
    {
        public static void MyCollections(this IServiceCollection services)
        {
            services.AddSingleton<IAbilityService, AbilityManager>();
            services.AddSingleton<IAbilityDal, EfAbilityDal>();
        }
    }
}


