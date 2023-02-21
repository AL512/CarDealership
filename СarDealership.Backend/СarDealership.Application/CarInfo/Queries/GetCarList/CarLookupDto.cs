using AutoMapper;
using System;
using СarDealership.Application.Common.Mappings;
using СarDealership.Domain.CarInfo;

namespace СarDealership.Application.CarInfo.Queries.GetCarList
{
    /// <summary>
    /// Элемент списка автомобилей(DTO)
    /// </summary>
    public class CarLookupDto : IMapWith<Car>
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
        /// Маппинг
        /// </summary>
        /// <param name="profile">Профиль маппинга</param>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Car, CarLookupDto>()
                .ForMember(carDto => carDto.Id,
                    opt => opt.MapFrom(car => car.Id))
                .ForMember(carDto => carDto.Name,
                    opt => opt.MapFrom(car => car.Name));
        }
    }
}
