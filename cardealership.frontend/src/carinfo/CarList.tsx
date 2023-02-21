import React, { FC, ReactElement, useRef, useEffect, useState } from 'react';
import { CreateCarDto, Client, CarLookupDto } from '../api/api';
import { FormControl } from 'react-bootstrap';

const apiClient = new Client('https://localhost:44397');

async function createCar(Car: CreateCarDto) {
    await apiClient.create('1.0', Car);
    console.log('Car is created.');
}

const CarList: FC<{}> = (): ReactElement => {
    let textInput = useRef(null);
    const [Cars, setCars] = useState<CarLookupDto[] | undefined>(undefined);

    async function getCars() {
        const carListVm = await apiClient.getAll('1.0');
        console.log('CarList 0::', carListVm)
        setCars(carListVm.cars);
        console.log('CarList 1::', carListVm.cars)
    }

    useEffect(() => {
        setTimeout(getCars, 500);
    }, []);

    const handleKeyPress = (event: React.KeyboardEvent<HTMLInputElement>) => {
        if (event.key === 'Enter') {
            const car: CreateCarDto = {
                name: event.currentTarget.value,
            };
            createCar(car);
            event.currentTarget.value = '';
            setTimeout(getCars, 500);
        }
    };

    return (
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
    );
};
export default CarList;
