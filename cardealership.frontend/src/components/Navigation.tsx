import React from 'react';
import {Link} from "react-router-dom";
import authProvider from "../auth/auth-provider";
import userManager, {
    loadUser,
    signinRedirect,
    signoutRedirect
} from '../auth/user-service'

/**
 * Гавигация по сайту м авторизация
 * @constructor
 */
export function Navigation() {
    //const btnBgClassName = authProvider ? 'bg-yellow-400' : 'bg-blue-400'
    const btnBgClassName = 'bg-yellow-400'
    const btnClasses = ['py-2 px-4 border bg-cyan-500']
    return (
        <nav className="h-[50px] flex justify-between px-5 bg-gray-500 text-white items-center">
            <span className="font-bold">Автосалон</span>
            <span>
                <button
                    className={btnClasses.join(' ')}
                    onClick={signinRedirect}
                    >
                        Войти
                </button>
                <b
                    className="px-3"
                >
                    Имя пользователя</b>
                <button
                    className={btnClasses.join(' ')}
                    onClick={signoutRedirect}
                >
                        Выйти
                </button>
                <Link to="/cars" className="mr-2 px-2">Автомобили</Link>
                <Link to="/">О программе</Link>
            </span>
        </nav>
    );
};