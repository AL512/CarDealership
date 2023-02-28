import React, {useState} from 'react';
import {ICreateCarDto} from "../../Interfases/CarInterfases";
import {ErrorMessage} from "../ErrorMessage";
import {ApiObject, ClientBase} from "../../api/ClientBase";

interface CreateCarProps {
    onCreate: (car: ICreateCarDto) => void
}

/**
 * Создание автомобиля
 * @param onCreate
 * @constructor
 */
export function CreateCar({onCreate}: CreateCarProps)  {
    const [value, setValue] = useState('')
    const [error, setError] = useState('')

    async function createCar(Car: ICreateCarDto) {
        const client = new ClientBase();
        await client.create<ICreateCarDto>('1.0', Car, ApiObject.Car);
        console.log('CarListItem is created');
    }

    const submitHandler = async (event: React.FormEvent) => {
        setError('')
        event.preventDefault()
        if(value.trim().length === 0) {
            setError('Введите корректное название автомобиля')
            return
        }
        const car: ICreateCarDto = {
            name: value,
        };
        const responce = createCar(car);
        // TODO: Вставить ИД из ответа
        onCreate(car);
    }
    const changeHandler = (event: React.ChangeEvent<HTMLInputElement>) => {
        setValue(event.currentTarget.value)
    }

    return (
        <form onSubmit={submitHandler}>
            <input
                type="text"
                className="border py-2 px-4 mb-2 w-full outline-0"
                placeholder="Название автомобиля..."
                value={value}
                onChange={changeHandler}
            />
            { error && <ErrorMessage error={error} />}
            <button type="submit" className="py-2 px-4 border bg-yellow-400 hover:text-white">Создать</button>
        </form>
    )
}