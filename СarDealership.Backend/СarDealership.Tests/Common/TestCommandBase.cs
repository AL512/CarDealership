using System;
using СarDealership.Persistence;

namespace СarDealership.Tests.Common
{
    /// <summary>
    /// Создание контекста БД для тестирования команд
    /// </summary>
    public abstract class TestCommandBase : IDisposable
    {
        /// <summary>
        /// Контекст БД
        /// </summary>
        protected readonly СarDealershipDbContext Context;
        /// <summary>
        /// Создаёт контекст БД для тестирования команд
        /// </summary>
        public TestCommandBase()
        {
            Context = CarsContextFactory.Create();
        }
        /// <summary>
        /// Удаляем контекст БД для тестирования команд
        /// </summary>
        public void Dispose()
        {
            CarsContextFactory.Destroy(Context);
        }
    }
}
