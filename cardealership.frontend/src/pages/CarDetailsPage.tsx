import React from 'react';
import AuthProvider from "../auth/auth-provider";
import {CarDetails} from "../components/cars/CarDetails";
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