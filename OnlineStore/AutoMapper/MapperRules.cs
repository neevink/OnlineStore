using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;
using OnlineStore.DataModels;
using OnlineStore.ViewModels;

namespace OnlineStore.AutoMapper
{
    /// <summary>
    /// Правила (профайл) для автомаппера
    /// </summary>
    public class MapperRules : Profile
    {
        public MapperRules()
        {
            CreateMap<Product, ProductViewModel>();
        }
    }
}