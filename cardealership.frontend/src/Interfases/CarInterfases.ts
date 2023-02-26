export interface ICreateCarDto {
    name: string;
    pow?: number;
    long?: number;
    price?: number;
}

export interface ICarDetails {
    id?: string;
    name?: string | undefined;
    pow?: number;
    long?: number;
    price?: number;
    creationDate?: Date;
    editDate?: Date | undefined;
}

export interface ICarList {
    cars?: ICarLookupDto[]
}

export interface ICarLookupDto {
    id?: string;
    name?: string | undefined;
}

export interface IProblemDetails {
    type?: string | undefined;
    title?: string | undefined;
    status?: number | undefined;
    detail?: string | undefined;
    instance?: string | undefined;
}

export interface IUpdateCarDto {
    id?: string;
    name?: string | undefined;
    pow?: number;
    long?: number;
    price?: number;
}