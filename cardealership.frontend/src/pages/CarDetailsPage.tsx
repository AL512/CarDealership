import React, {useContext} from 'react';
import {CarList} from "../components/cars/CarList";

import {Loader} from "../components/Loader";
import AuthProvider from "../auth/auth-provider";
import {ModalState} from "../context/DialogCarModalContext";
import {CarListItem} from "../components/cars/CarListItem";
import {Modal} from "../components/Modal";
import {CreateCar} from "../components/cars/CreateCar";
import {CarDetails, ICarDetailsProps} from "../components/cars/CarDetails";
import {ICarLookupDto} from "../Interfases/CarInterfases";
import userManager from "../auth/user-service";


/**
 * Отображение детального описания автомобиля
 * @constructor
 */
export function CarDetailsPage() {
    return (
        <div className="container mx-auto max-w-2xl pt-5">
            <AuthProvider userManager={userManager}>
                <CarDetails/>
            </AuthProvider>
        </div>
    );
};