import React from 'react';
import userManager, {signinRedirect} from "../auth/user-service";
import AuthProvider from "../auth/auth-provider";
import CarList from "../carinfo/CarList";

/**
 * Отображение списка автомобилей
 * @constructor
 */
export function CarListPage() {
    return (
        <div className="container mx-auto max-w-2xl pt-5">
            <button onClick={() => signinRedirect()}>Войти</button>
            <AuthProvider userManager={userManager}>
                <CarList/>
            </AuthProvider>
        </div>
    );
};