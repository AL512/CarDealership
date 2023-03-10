import React, {useEffect, useState} from 'react';
import {ICarList, ICarLookupDto} from '../../Interfases/CarInterfases';
import {ApiObject, ClientBase} from "../../api/ClientBase";

/**
 * Спмсок автомобилей
 * @constructor
 */
export function CarList() {
    /**
     * API клиен
     */
    const apiClient = new ClientBase();

    /**
     * Состояние списка автомобилей
     */
    const [cars, setCars] = useState<ICarLookupDto[]>([]);
    /**
     * Состояние загрузки
     */
    const [loading, setLoading] = useState(false)

    /**
     * Добавление автомобиля в список
     * @param car
     */
    function addCar(car: ICarLookupDto) {
        setCars(prev => [...prev, car])
    }
    /**
     * Удаление автомобиля в список
     * @param car
     */
    function removeCar(car: ICarLookupDto) {
        const index = cars.indexOf(car)
        if (index !== -1) {
            setCars(cars.filter((element) => {
                return element.id !== car.id
            }));
            delete cars[index]
        }
    }

    /**
     * Получить список автомобилей
     */
    async function getCars() {
        setLoading(true)
        const carList = await apiClient.getAll<ICarList>('1.0', ApiObject.Car);
        setCars(carList.cars? carList.cars : [])
        setLoading(false)
    }

        useEffect(() => {
            setTimeout(getCars, 500);
        }, []);
        return {cars, loading, addCar, removeCar}
}