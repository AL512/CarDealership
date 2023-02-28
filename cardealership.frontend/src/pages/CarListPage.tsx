import React, {useContext} from 'react';
import userManager, {signinRedirect} from "../auth/user-service";
import AuthProvider from "../auth/auth-provider";
import {CarList} from "../components/cars/CarList";
import {Loader} from "../components/Loader";
import {CarListItem} from "../components/cars/CarListItem";
import {ModalContext} from "../context/ModalCarContext";
import {Modal} from "../components/Modal";
import {CreateCar} from "../components/cars/CreateCar";
import {ICreateCarDto} from "../Interfases/CarInterfases";
import {ModalState} from "../context/DialogCarModalContext";


/**
 * Отображение списка автомобилей
 * @constructor
 */
export function CarListPage() {
    const {cars, loading, addCar } = CarList()
    const {modal, open: openModal, close: closeModal} =  useContext(ModalContext)
    const  createHandler = (car: ICreateCarDto) => {
        closeModal()
        addCar(car)
        // TODO : Не срабатывает createHandler при создании авто
    }
    return (
        <div className="container mx-auto max-w-2xl pt-5">
            {loading && <Loader />}
            <AuthProvider userManager={userManager}>
                {!loading &&
                    <button
                        className="py-2 px-4 border bg-cyan-500 mb-2"
                        onClick={openModal}
                    >
                        Добавить автомобиль
                    </button>
                }
                {cars?.map(car =>
                    <ModalState key={car.id}>
                        <CarListItem car={car}/>
                    </ModalState>
                )}
                { modal &&
                    <Modal title="Создать автомобиль"  onClose={closeModal}>
                        <CreateCar onCreate={createHandler} />
                    </Modal>
                }

            </AuthProvider>
        </div>
    );
}