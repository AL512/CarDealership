using AutoMapper;
using System;
using СarDealership.Application.Common.Mappings;
using СarDealership.Application.CarInfo.Commands.UpdateCar;

namespace СarDealership.WebApi.Models
{
    public class UpdateCarDto : IMapWith<UpdateCarCommand>
    {
        /// <summary>
        /// ИД
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
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
        /// Маппинг модели автомобиля на команду создания
        /// </summary>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCarDto, UpdateCarCommand>()
                .ForMember(carCommand => carCommand.Id,
                    opt => opt.MapFrom(carDto => carDto.Id))
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
