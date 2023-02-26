import React, {useState} from "react";
import {ICarDetails, ICarLookupDto} from "../../Interfases/CarInterfases";

interface CarProps {
    car: ICarLookupDto
}

/**
 * Отображение информации об автомобиле
 * @param car
 * @constructor
 */
export function Car({car}: CarProps) {
    return(
        <div
            className="border py-2 px-4 rounded flex flex-col items-center mb-2"
        >
            <p>{car.name}</p>

        </div>
    )
}