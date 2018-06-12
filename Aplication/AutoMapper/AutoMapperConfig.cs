using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace Aplication.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(i =>
            {
                i.AddProfile<DomainToViewModelMappingProfile>();
                i.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}