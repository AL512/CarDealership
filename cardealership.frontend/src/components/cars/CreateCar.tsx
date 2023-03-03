import React, {useState} from 'react';
import {ICarLookupDto, ICreateCarDto} from "../../Interfases/CarInterfases";
import {ErrorMessage} from "../ErrorMessage";
import {ApiObject, ClientBase} from "../../api/ClientBase";

interface ICreateCarProps {
    onCreate: (car: ICarLookupDto) => void
}

/**
 * Создание автомобиля
 * @param onCreate
 * @constructor
 */
export function CreateCar({onCreate}: ICreateCarProps)  {
    const [error, setError] = useState('')

    const [newName, setNewName] = useState('')
    const [newPow, setNewPow] = useState(0)
    const [newLong, setNewLong] = useState(0)
    const [newPrice, setNewPrice] = useState(0)

    /**
     * Созданет новый автомобиль
     * @param Car
     */
    async function createCar(Car: ICreateCarDto) {
        const client = new ClientBase();
        const responce = await client.create<ICreateCarDto>('1.0', Car, ApiObject.Car);
        console.log('Car is created');
        return responce;
    }

    const submitHandler = async (event: React.FormEvent) => {
        setError('')
        event.preventDefault()
        if(newName.trim().length === 0) {
            setError('Введите корректное название автомобиля')
            return
        }
        if(newPow <= 0) {
            setError('Мощность двигателя не может быть отрицательной')
            return
        }
        if(newLong <= 0) {
            setError('Длянна кузова не может быть отрицательной')
            return
        }
        if(newPrice <= 0) {
            setError('Стоимость не может быть отрицательной')
            return
        }

        const car: ICreateCarDto = {
            name: newName,
            pow: newPow,
            long: newLong,
            price: newPrice
        };
        const responce: string = await createCar(car);
        const carLookup: ICarLookupDto = {
            id: responce,
            name: newName,
        };
        onCreate(carLookup);
    }
    const changeNameHandler = (event: React.ChangeEvent<HTMLInputElement>) => {
        setNewName(event.currentTarget.value)
    }

    const changePowHandler = (event: React.ChangeEvent<HTMLInputElement>) => {
        setNewPow(event.currentTarget.value as unknown as number)
    }

    const changeLongHandler = (event: React.ChangeEvent<HTMLInputElement>) => {
        setNewLong(event.currentTarget.value as unknown as number)
    }

    const changePriceHandler = (event: React.ChangeEvent<HTMLInputElement>) => {
        setNewPrice(event.currentTarget.value as unknown as number)
    }

    return (
        <form onSubmit={submitHandler}>
            <p>
                <label>Название:</label><br />
                <input
                    type="text"
                    className="border py-2 px-4 mb-2 w-full outline-0"
                    placeholder="Название автомобиля..."
                    value={newName}
                    onChange={changeNameHandler}
                />
            </p>
            <p>
                <label>Мощность двигателя:</label><br />
                <input
                    type="number"
                    className="border py-2 px-4 mb-2 w-full outline-0"
                    placeholder="Мощность двигателя..."
                    value={newPow}
                    onChange={changePowHandler}
                />
            </p>
            <p>
                <label>Длинна кузова:</label><br />
                <input
                    type="number"
                    className="border py-2 px-4 mb-2 w-full outline-0"
                    placeholder="Длинна кузова..."
                    value={newLong}
                    onChange={changeLongHandler}
                />
            </p>
            <p>
                <label>Стоимость:</label><br />
                <input
                    type="number"
                    className="border py-2 px-4 mb-2 w-full outline-0"
                    placeholder="Стоимость..."
                    value={newPrice}
                    onChange={changePriceHandler}
                />
            </p>
            { error && <ErrorMessage error={error} />}
            <button type="submit" className="py-2 px-4 border bg-yellow-400 hover:text-white">Создать</button>
        </form>
    )
}