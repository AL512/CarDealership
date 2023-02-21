using AutoMapper;
using System;
using СarDealership.Application.Interfaces;
using СarDealership.Application.Common.Mappings;
using СarDealership.Persistence;
using Xunit;

namespace СarDealership.Tests.Common
{
    /// <summary>
    /// Вспомогательный класс проверки запросов
    /// </summary>
    public class QueryTestFixture : IDisposable
    {
        /// <summary>
        /// Контекст БД
        /// </summary>
        public СarDealershipDbContext Context;
        /// <summary>
        /// Маппер
        /// </summary>
        public IMapper Mapper;
        /// <summary>
        /// Вспомогательный класс проверки запросов
        /// </summary>
        public QueryTestFixture()
        {
            Context = CarsContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IСarDealershipDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }
        /// <summary>
        /// Освобождает ресурс
        /// </summary>
        public void Dispose()
        {
            CarsContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
