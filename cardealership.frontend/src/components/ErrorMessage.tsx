import React from "react";

interface  ErrorMessageProps {
    error: string
}

/**
 * Информирует об ошибке загрузки страницы
 * @param error
 * @constructor
 */
export function ErrorMessage({ error }: ErrorMessageProps){
    return(
        <p className={'text-center text-red-600'}>{error}</p>
    )
}