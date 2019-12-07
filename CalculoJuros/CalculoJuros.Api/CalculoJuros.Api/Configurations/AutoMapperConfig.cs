using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculoJuros.Api.Configurations
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            var types = typeof(Program).Assembly.GetTypes();

            var autoMapperProfiles = types
                            .Where(x => x.IsSubclassOf(typeof(Profile)))
                            .Select(Activator.CreateInstance)
                            .OfType<Profile>()
                            .ToList();

            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(autoMapperProfiles);
            });
        }
    }
}
