using Microsoft.Extensions.DependencyInjection;
using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.DataAccess.Concretes.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Business.Concretes.DependencyResolvers.ServiceCollections
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


