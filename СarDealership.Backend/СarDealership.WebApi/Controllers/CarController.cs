using AutoMapper;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using СarDealership.Application.CarInfo.Queries.GetCarList;
using СarDealership.Application.CarInfo.Queries.GetCarDetails;
using СarDealership.Application.CarInfo.Commands.CreateCar;
using СarDealership.Application.CarInfo.Commands.UpdateCar;
using СarDealership.Application.CarInfo.Commands.DeleteCar;
using СarDealership.WebApi.Models;

namespace СarDealership.WebApi.Controllers
{
    /// <summary>
    /// Контроллер для работы с автомобиляями
    /// </summary>
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class CarController : BaseController
    {
        /// <summary>
        /// Маппер
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Контроллер работы с автотомобилями
        /// </summary>
        /// <param name="mapper">Маппер</param>
        public CarController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Получить список автомобилей
        /// </summary>
        /// <returns>Список автомобилей</returns>
        /// <response code="200">Success</response>
        /// <response code="401">если пользователь не авторизован</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<CarList>> GetAll()
        {
            var query = new GetCarListQuery
            {
                UserId = UserId
                // TODO : Добавить проверку роли (CarController :: GetAll)
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Получить автомобиль по ИД
        /// </summary>
        /// <param name="id">ИД автомобиля</param>
        /// <returns>автомобиль</returns>
        /// <response code="200">Success</response>
        /// <response code="401">если пользователь не авторизован</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<CarDetails>> Get(Guid id)
        {
            var query = new GetCarDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Создать автомобиль
        /// </summary>
        /// <param name="createCarDto">Транспортная модель данных автомобиля</param>
        /// <returns>ИД автомобиля</returns>
        /// <response code="201">Success</response>
        /// <response code="401">если пользователь не авторизован</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCarDto createCarDto)
        {
            var command = _mapper.Map<CreateCarCommand>(createCarDto);
            command.UserId = UserId;
            var carId = await Mediator.Send(command);
            return Ok(carId);
        }

        /// <summary>
        /// Обновить автомобиль
        /// </summary>
        /// <param name="updateCarDto">Модель обновления автомобиля от клиента</param>
        /// <returns>Ничего не возвращаем</returns>
        /// <response code="204">Success</response>
        /// <response code="401">если пользователь не авторизован</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateCarDto updateCarDto)
        {
            var command = _mapper.Map<UpdateCarCommand>(updateCarDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Удалить автомобиль
        /// </summary>
        /// <param name="id">ИД автомобиля</param>
        /// <returns>Ничего не возвращаем</returns>
        /// <response code="204">Success</response>
        /// <response code="401">если пользователь не авторизован</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteCarCommand
            {
                Id = id,
                UserId = UserId
                // TODO : Можно ли удалять не свои записи? (CarController :: Delete)
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
