import React, {useContext, useEffect, useState} from 'react';
import {ApiObject, ClientBase} from "../../api/ClientBase";
import {ICarDetails} from "../../Interfases/CarInterfases";
import {Loader} from "../Loader";
import {useParams} from "react-router-dom";
import {Modal} from "../Modal";
import {UpdateCar} from "./UpdateCar";
import {ModalContext} from "../../context/ModalCarContext";

/**
 * Получает детальное описание автомобиля
 * @param carLookup
 * @constructor
 */
export function CarDetails() {
    const params = useParams();
    const carId = params.id;
    /**
     *
     */
    const apiClient = new ClientBase();

    /**
     * Состояние детальной информации об автомобиле
     */
    const [car, setCar] = useState<ICarDetails>();

    const  updateHandler = () => {
        closeModal()
        getDetails();
    }

    /**
     * Модальное окно обновления детальной информации
     */
    let {modal, open: openModal, close: closeModal} =  useContext(ModalContext)

    /**
     * Состояние загрузки
     */
    const [loading, setLoading] = useState(false)

    /**
     * Детальное описание автомобиля
     */
    const [details, setDetails] = useState(false)

    /**
     * Получить детальное описание автомобиле
     */
    async function getDetails() {
        setLoading(true)
        console.log(car)
        const carDetails = await apiClient.get<ICarDetails>('1.0', ApiObject.Car, carId);
        setCar(carDetails)
        setLoading(false)
    }

    useEffect(() => {
        setTimeout(getDetails, 500);
    }, []);

    const btnBgClassName = details ? 'bg-yellow-400' : 'bg-blue-400'
    const btnClasses = ['py-2 px-4 border', btnBgClassName]

    return (
        <div
            className="border py-2 px-4 rounded flex flex-col items-center mb-2"
        >
            { loading && <Loader />}
            <p>{car?.name}</p>
            <p className="font-bold">{car?.price}</p>
            { details && <div>
                <p>Мощность двигателя: <span style={{fontWeight: 'bold'}}>{car?.pow}</span></p>
                <p>Длинна кузова: <span style={{fontWeight: 'bold'}}>{car?.long}</span></p>
            </div>}
            {car !== undefined &&
                <>
                    <button
                        className={btnClasses.join(' ')}
                        onClick={() => setDetails(prev => !prev)}
                    >
                        { details ? 'Скрыть детали' : 'Показать детали'}
                    </button>
                    <button
                        className="py-2 px-4 border bg-cyan-500 mb-2"
                        onClick={openModal}
                    >
                        Редактировать
                    </button>

                    {modal &&
                        <Modal title="Редактировать автомобиль"
                               onClose={closeModal}>
                            <UpdateCar onUpdate={updateHandler}  car={car}/>
                        </Modal>
                    }
                </>
            }


        </div>
    )
};