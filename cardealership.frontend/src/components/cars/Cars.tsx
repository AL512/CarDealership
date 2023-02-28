import React from 'react';
import {Outlet} from "react-router-dom";

/**
 * Родительская страница для отображение автомобилей
 * @constructor
 */
export function Cars() {
    return (
        <>
            <div
                className="border py-2 px-4 rounded flex flex-col items-center mb-2"
            >
                <h1
                    style={{fontWeight: 'bold'}}
                >
                    Автомобили</h1>
                <Outlet />
            </div>
            <div>
                <i
                    className="px-5"
                >
                    вся информация является ознакомительной</i>
            </div>
        </>
    );
};