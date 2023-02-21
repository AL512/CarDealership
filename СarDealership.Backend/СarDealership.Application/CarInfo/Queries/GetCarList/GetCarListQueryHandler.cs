using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using СarDealership.Application.Interfaces;

namespace СarDealership.Application.CarInfo.Queries.GetCarList
{
    /// <summary>
    /// Обработчик запроса списка автомобилей
    /// </summary>
    public class GetCarListQueryHandler : IRequestHandler<GetCarListQuery, CarList>
    {
        /// <summary>
        /// Контекст БД
        /// </summary>
        private readonly IСarDealershipDbContext _dbContext;
        /// <summary>
        /// Маппер
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Обработчик запроса списка автомобилей
        /// </summary>
        /// <param name="dbContext">Контекст БД</param>
        /// <param name="mapper">Маппер</param>
        public GetCarListQueryHandler(IСarDealershipDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        /// <summary>
        /// Логика обработки запроса списка
        /// </summary>
        /// <param name="request">Ответ на запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список автомобилей</returns>
        public async Task<CarList> Handle(GetCarListQuery request,
            CancellationToken cancellationToken)
        {
            var carsQuery = await _dbContext.Cars
                //.Where(car => car.UserId == request.UserId)
                .ProjectTo<CarLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new CarList { Cars = carsQuery };
        }
    }
}
