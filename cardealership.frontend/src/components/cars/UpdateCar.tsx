import React, {useState} from 'react';
import {IUpdateCarDto, ICarLookupDto, ICarDetails} from "../../Interfases/CarInterfases";
import {ApiObject, ClientBase} from "../../api/ClientBase";
import {ErrorMessage} from "../ErrorMessage";

interface IUpdateCarProps {
    onUpdate: (car: IUpdateCarDto) => void
    car: ICarDetails
}

export function UpdateCar(onUpdate: IUpdateCarProps) {
    const [error, setError] = useState('')

    const [updateName, setUpdateName] = useState(onUpdate.car.name !== undefined ? onUpdate.car.name : '')
    const [updatePow, setUpdatePow] = useState(onUpdate.car.pow !== undefined ? onUpdate.car.pow : 0)
    const [updateLong, setUpdateLong] = useState(onUpdate.car.long!== undefined ? onUpdate.car.long : 0)
    const [updatePrice, setUpdatePrice] = useState(onUpdate.car.price!== undefined ? onUpdate.car.price : 0)

    const changeNameHandler = (event: React.ChangeEvent<HTMLInputElement>) => {
        setUpdateName(event.currentTarget.value)
    }

    const changePowHandler = (event: React.ChangeEvent<HTMLInputElement>) => {
        setUpdatePow(event.currentTarget.value as unknown as number)
    }

    const changeLongHandler = (event: React.ChangeEvent<HTMLInputElement>) => {
        setUpdateLong(event.currentTarget.value as unknown as number)
    }

    const changePriceHandler = (event: React.ChangeEvent<HTMLInputElement>) => {
        setUpdatePrice(event.currentTarget.value as unknown as number)
    }

    /**
     * Флаг подтверждения обновления
     */
    let updateFlag: boolean = false;

    /**
     * Вызов api функции удаления автомобиля
     * @param car
     */
    async function updateCar(car: IUpdateCarDto) {
        const client = new ClientBase();
        await client.update<IUpdateCarDto>( '1.0',  ApiObject.Car, car);
        console.log('Car is update');
    }

    const submitHandler = async (event: React.FormEvent) => {
        setError('')
        event.preventDefault()
        if(updateName.trim().length === 0) {
            setError('Введите корректное название автомобиля')
            return
        }
        if(updatePow <= 0) {
            setError('Мощность двигателя не может быть отрицательной')
            return
        }
        if(updateLong <= 0) {
            setError('Длянна кузова не может быть отрицательной')
            return
        }
        if(updatePrice <= 0) {
            setError('Стоимость не может быть отрицательной')
            return
        }
        if(updateFlag) {
            const updateCarItem: ICarDetails = {
                id: onUpdate.car.id,
                name: updateName,
                pow: updatePow,
                long: updateLong,
                price: updatePrice
            }
            await updateCar(updateCarItem);
        }
        onUpdate.onUpdate(onUpdate.car)

    }

    return (
        <form onSubmit={submitHandler}>
            <p>
                <label>Название:</label><br />
                <input
                    type="text"
                    className="border py-2 px-4 mb-2 w-full outline-0"
                    placeholder="Название автомобиля..."
                    value={updateName}
                    onChange={changeNameHandler}
                />
            </p>
            <p>
                <label>Мощность двигателя:</label><br />
                <input
                    type="number"
                    className="border py-2 px-4 mb-2 w-full outline-0"
                    placeholder="Мощность двигателя..."
                    value={updatePow}
                    onChange={changePowHandler}
                />
            </p>
            <p>
                <label>Длинна кузова:</label><br />
                <input
                    type="number"
                    className="border py-2 px-4 mb-2 w-full outline-0"
                    placeholder="Длинна кузова..."
                    value={updateLong}
                    onChange={changeLongHandler}
                />
            </p>
            <p>
                <label>Стоимость:</label><br />
                <input
                    type="number"
                    className="border py-2 px-4 mb-2 w-full outline-0"
                    placeholder="Стоимость..."
                    value={updatePrice}
                    onChange={changePriceHandler}
                />
            </p>
            { error && <ErrorMessage error={error} />}
            <button
                type="submit"
                className="py-2 px-4 border bg-yellow-400 hover:text-white"
                onClick={() => updateFlag = true}
            >
                Сохранить
            </button>
            <button
                type="submit"
                className="py-2 px-4 border bg-cyan-700 hover:text-white"
                onClick={() => {updateFlag = false;}}
            >
                Отмена
            </button>
        </form>
    )
};