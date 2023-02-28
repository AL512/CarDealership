import React, {useState} from 'react';
import {ICarLookupDto, ICreateCarDto} from "../../Interfases/CarInterfases";
import {ApiObject, ClientBase} from "../../api/ClientBase";
import {ErrorMessage} from "../ErrorMessage";

interface DeleteCarProps {
    onDelete: (car: ICarLookupDto) => void
    car: ICarLookupDto
}

/**
 * Удаление автомобиля
 * @param onDelete
 * @constructor
 */
export function DeleteCar(onDelete: DeleteCarProps) {
    const [error, setError] = useState('')

    /**
     * Флаг подтверждения удаления
     */
    let dialogResult: boolean = false;

    /**
     * Вызов api функции удаления автомобиля
     * @param car
     */
    async function deleteCar(car: ICarLookupDto) {
        const client = new ClientBase();
        await client.delete( '1.0',  ApiObject.Car, car.id);
        console.log('CarListItem is delete');
    }

    const submitHandler = async (event: React.FormEvent) => {
        event.preventDefault()
        if(dialogResult) {
            const responce = deleteCar(onDelete.car);
            console.log(responce)
        }
        onDelete.onDelete(onDelete.car)
    }

    return (
        <form onSubmit={submitHandler}>
            <p>
                {`Вы уверенны, что хотите удалить автомобиль "${onDelete.car.name}"?`}
            </p>
            { error && <ErrorMessage error={error} />}
            <button
                type="submit"
                className="py-2 px-4 border bg-red-400 hover:text-white"
                onClick={() => dialogResult = true}
            >
                Да
            </button>
            <button
                type="submit"
                className="py-2 px-4 border bg-cyan-700 hover:text-white"
                onClick={() => {dialogResult = false;}}
            >
                Отмена
            </button>
        </form>
    )
};