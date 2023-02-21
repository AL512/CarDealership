using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using СarDealership.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using СarDealership.Application.Common.Exceptions;
using СarDealership.Domain.CarInfo;
using СarDealership.Application.CarInfo.Queries.GetCarDetails;

namespace СarDealership.Application.CarInfo.Queries.GetCarDetails
{
    /// <summary>
    /// Обработчик детального запроса автомобиля
    /// </summary>
    public class GetCarDetailsQueryHandler : IRequestHandler<GetCarDetailsQuery, CarDetails>
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
        /// Обработчик детального запроса автомобиля
        /// </summary>
        /// <param name="dbContext">Контекст БД</param>
        /// <param name="mapper">Маппер</param>
        public GetCarDetailsQueryHandler(IСarDealershipDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        /// <summary>
        /// Логика обработки запроса
        /// </summary>
        /// <param name="request">Ответ на запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Детальная информация об автомобиле</returns>
        public async Task<CarDetails> Handle(GetCarDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Cars
                .FirstOrDefaultAsync(car =>
                car.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Car), request.Id);
            }

            return _mapper.Map<CarDetails>(entity);
        }
    }
}
