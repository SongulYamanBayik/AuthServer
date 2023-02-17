using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Service
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<DtoMapper>(); //başka profile dan miras alan classlar varsa bu şekilde ekleyeceksin
                });
                return config.CreateMapper();
            }); //ihtiyacım olduğunda ayağa kalksın. proje derlenince ayağa kalkıp bellekte beklemesin.

        public static IMapper Mapper => lazy.Value; //propertinin sadece get hali. 
    }
}
