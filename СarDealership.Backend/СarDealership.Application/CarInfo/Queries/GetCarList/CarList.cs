using System.Collections.Generic;
using СarDealership.Application.CarInfo.Queries.GetCarList;

namespace СarDealership.Application.CarInfo.Queries.GetCarList
{
    /// <summary>
    /// Список автомобилей
    /// </summary>
    public class CarList
    {
        /// <summary>
        /// Список автоvj,bktq
        /// </summary>
        public IList<CarLookupDto> Cars { get; set; }
    }
}
