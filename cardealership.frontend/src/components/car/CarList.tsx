import React, {useEffect, useState} from 'react';
import {ICarList, ICarLookupDto} from '../../Interfases/CarInterfases';
import {ApiObject, ClientBase} from "../../api/ClientBase";

/**
 * Спмсок автомобилей
 * @constructor
 */
export function CarList() {
    /**
     *
     */
    const apiClient = new ClientBase();

    /**
     * Состояние списка автомобилей
     */
    const [cars, setCars] = useState<ICarLookupDto[]>([]);
    const [loading, setLoading] = useState(false)

    /**
     * Добавление автомобиля в список
     * @param car
     */
    function addCar(car: ICarLookupDto) {
        setCars(prev => [...prev, car])
        console.log(['addCar', cars])
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
        return {cars, loading, addCar}
}