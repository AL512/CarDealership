import React, { FC, ReactElement, useRef, useEffect, useState } from 'react';
import { CreateCarDto, Client, CarLookupDto } from '../api/CarApi';
import { FormControl } from 'react-bootstrap';

export function useCarList() {

    const apiClient = new Client('https://localhost:44397');

    const [cars, setCars] = useState<CarLookupDto[]>([]);
    const [loading, setLoading] = useState(false)

    function addCar(car: CarLookupDto) {
        setCars(prev => [...prev, car])
        console.log(['addCar', cars])
    }

    //async function fetchCarList() {
    //const CarList: FC<{}> = (): ReactElement => {
        //let textInput = useRef(null);


    async function getCars() {
        setLoading(true)
        const carList = await apiClient.getAll('1.0');
        setCars(carList.cars? carList.cars : [])
        setLoading(false)
    }

        useEffect(() => {
            setTimeout(getCars, 500);
        }, []);

        /*const handleKeyPress = (event: React.KeyboardEvent<HTMLInputElement>) => {
            if (event.key === 'Enter') {
                const car: CreateCarDto = {
                    name: event.currentTarget.value,
                };
                createCar(car);
                event.currentTarget.value = '';
                setTimeout(getCars, 500);
            }
        };*/
        return {cars, loading, addCar}
        /*return (
            <div>
                Cars
                <div>
                    <FormControl ref={textInput} onKeyPress={handleKeyPress} />
                </div>
                <section>
                    {Cars?.map((car) => (
                        <div>{car.name}</div>
                    ))}
                </section>
            </div>
        );*/
    //};
}