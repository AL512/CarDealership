import React, { FC, ReactElement, useRef, useEffect, useState } from 'react';
import { CreateCarDto, Client, CarLookupDto } from '../../api/CarApi';

/**
 * Спмсок автомобилей
 * @constructor
 */
export function CarList() {
    /**
     *
     */
    const apiClient = new Client();

    /**
     * Состояние списка автомобилей
     */
    const [cars, setCars] = useState<CarLookupDto[]>([]);
    const [loading, setLoading] = useState(false)

    /**
     * Добавление автомобиля в список
     * @param car
     */
    function addCar(car: CarLookupDto) {
        setCars(prev => [...prev, car])
        console.log(['addCar', cars])
    }

    /**
     * Получить список автомобилей
     */
    async function getCars() {
        setLoading(true)
        const carList = await apiClient.getAll('1.0');
        setCars(carList.cars? carList.cars : [])
        setLoading(false)
    }

        useEffect(() => {
            setTimeout(getCars, 500);
        }, []);
        return {cars, loading, addCar}
}