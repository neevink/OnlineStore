using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;
using OnlineStore.AutoMapper;

namespace OnlineStore.AutoMapper
{
    /// <summary>
    /// Глобальные настройки конфигурации автомаппера для этого приложения
    /// </summary>
    public class MapperGlobalConfiguration
    {
        /// <summary>
        /// Получть настройки автомаппера
        /// </summary>
        /// <returns>Глобальные насткойки автомаппера</returns>
        public static MapperConfiguration Get()
        {
            return new MapperConfiguration(x => x.AddProfile(new MapperRules()));
        }

    }
}