import React, {useContext} from "react";
import {ICarDetails, ICarLookupDto, ICreateCarDto} from "../../Interfases/CarInterfases";
import {DialogModalContext} from "../../context/DialogCarModalContext";
import {Modal} from "../Modal";
import {DeleteCar} from "./DeleteCar";
import {NavLink} from 'react-router-dom';

interface ICarProps {
    car: ICarLookupDto
}

/**
 * Отображение информации об автомобиле
 * @param car
 * @constructor
 */
export function CarListItem({car}: ICarProps) {
    let {modal, open: openModal, close: closeModal} =  useContext(DialogModalContext)
    const  deleteHandler = (car: ICarLookupDto) => {
        closeModal()
        //addCar(car)
    }

    return(
        <div
            className="border py-2 px-4 rounded flex flex-col items-center mb-2"
        >
            <div className="columns-2">
                <div>
                    <NavLink
                        className="ext-white hover:text-blue-500"
                        to={`/cars/${car.id}`}
                    >
                        {car.name}
                    </NavLink>
                </div>

                {modal &&
                    <Modal title="Удалить автомобиль"
                           onClose={closeModal}>
                        <DeleteCar onDelete={deleteHandler}  car={car}/>
                    </Modal>
                }
                {/* TODO : Если роль позволит, то отображаем кнопку "удалить"*/}
                {<div
                    className="items-right">
                    <button
                        className="py-2 px-4 border bg-red-400"
                        onClick={openModal}
                    >
                        Удалить
                    </button>
                </div>}
            </div>
        </div>
    )
}