import React, {createContext , useState} from "react";

interface IDialogModalContext {
    modal: boolean
    open: () => void
    close: () => void

}
// TODO: Разобраться с контекстом модальных окон и убрать дублирование кода
export const DialogModalContext = createContext<IDialogModalContext>({
    modal: false,
    open: () => {},
    close: () => {}
})

/**
 * Состояние модального окна
 * @param children
 * @constructor
 */
export  const ModalState = ({children} : {children : React.ReactNode}) => {
    const [modal, setModal] = useState(false)
    const open = () => setModal(true)
    const close = () => setModal(false)

    return(
        <DialogModalContext.Provider value={{modal, open, close}}>
            { children}
        </DialogModalContext.Provider>
    )
}