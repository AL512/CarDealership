using AutoMapper;
using СarDealership.Application.Common.Mappings;
using СarDealership.Application.CarInfo.Commands.CreateCar;
using System.ComponentModel.DataAnnotations;

namespace СarDealership.WebApi.Models
{
    /// <summary>
    /// ранспортная модель данных автомобиля
    /// </summary>
    public class CreateCarDto : IMapWith<CreateCarCommand>
    {

        /// <summary>
        /// Наименование
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Мощность двигателя
        /// </summary>
        public int Pow { get; set; }
        /// <summary>
        /// Длина кузова
        /// </summary>
        public int Long { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Маппинг модели дфнных автомобиля на команду создания
        /// </summary>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCarDto, CreateCarCommand>()
                .ForMember(carCommand => carCommand.Name, 
                    opt => opt.MapFrom(carDto => carDto.Name))
                .ForMember(carCommand => carCommand.Pow,
                    opt => opt.MapFrom(carDto => carDto.Pow))
                .ForMember(carCommand => carCommand.Long,
                    opt => opt.MapFrom(carDto => carDto.Long))
                .ForMember(carCommand => carCommand.Price,
                    opt => opt.MapFrom(carDto => carDto.Price));
        }
    }
}
