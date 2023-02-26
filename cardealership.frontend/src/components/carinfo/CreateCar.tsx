import React, {useState} from 'react';
import {CreateCarDto} from "../../api/CarApi";
import {ErrorMessage} from "../ErrorMessage";
import {Client} from '../../api/CarApi'
interface CreateCarProps {
    onCreate: (car: CreateCarDto) => void
}

/**
 * Создание автомобиля
 * @param onCreate
 * @constructor
 */
export function CreateCar({onCreate}: CreateCarProps)  {
    const [value, setValue] = useState('')
    const [error, setError] = useState('')

    async function createCar(Car: CreateCarDto) {
        const client = new Client();
        await client.create('1.0', Car);
        console.log('Car is created');
    }

    const submitHandler = async (event: React.FormEvent) => {
        setError('')
        event.preventDefault()
        if(value.trim().length === 0) {
            setError('Введите корректное название автомобиля')
            return
        }
        const car: CreateCarDto = {
            name: value,
        };
        const responce = createCar(car);

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