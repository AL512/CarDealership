import {ApiException} from './ApiException'
import {
    IProblemDetails,
}
    from '../Interfases/CarInterfases'

export enum ApiObject {
    /**
     * Автомобиль
     */
    Car = "Car",
    /**
     * Марка автомобиля
     */
    Brand = "Brand",
    /**
     * Страна производитель
     */
    Country = "Country",
    /**
     * Заказ
     */
    Order = "Order"
};

/**
 * Базовый класс клиента
 */
export class ClientBase {
    protected  baseUrl?: string;
    protected http: {
        fetch(url: RequestInfo, init?: RequestInit): Promise<Response>;
    };

    protected jsonParseReviver: ((key: string, value: any) => any) | undefined =
        undefined;

    constructor(baseUrl: string = 'https://localhost:44397',
        http?: {
            fetch(url: RequestInfo, init?: RequestInit): Promise<Response>;
        }
    ) {
        this.http = http ? http : <any>window;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : '';
    }

    /**
     * Добавление токена доступа
     * @param options
     * @protected
     */
    protected transformOptions(options: RequestInit) {
        const token = localStorage.getItem('token');
        options.headers = {
            ...options.headers,
            Authorization: 'Bearer ' + token,
        };
        return Promise.resolve(options);
    }

    /**
     * Получить список объектов
     * @param version Версия api функции
     * @param apiObject Тип объекта
     */
    getAll<TList>(version: string, apiObject: ApiObject): Promise<TList> {
        let url_ = this.baseUrl + '/api/{version}/{apiObject}';
        if (version === undefined || version === null)
            throw new Error("The parameter 'version' must be defined.");
        url_ = url_.replace('{version}', encodeURIComponent('' + version));
        url_ = url_.replace('{apiObject}', encodeURIComponent('' + apiObject));
        url_ = url_.replace(/[?&]$/, '');

        let options_ = <RequestInit>{
            method: 'GET',
            headers: {
                Accept: 'application/json',
            },
        };

        return this.transformOptions(options_)
            .then((transformedOptions_) => {
                return this.http.fetch(url_, transformedOptions_);
            })
            .then((_response: Response) => {
                return this.processGetAll<TList>(_response);
            });
    }

    protected processGetAll<TList>(response: Response): Promise<TList> {
        const status = response.status;
        let _headers: any = {};
        if (response.headers && response.headers.forEach) {
            response.headers.forEach((v: any, k: any) => (_headers[k] = v));
        }
        if (status === 200) {
            return response.text().then((_responseText) => {
                let result200: any = null;
                result200 =
                    _responseText === ''
                        ? null
                        : <TList>(
                            JSON.parse(_responseText, this.jsonParseReviver)
                        );
                return result200;
            });
        } else if (status === 401) {
            return response.text().then((_responseText) => {
                let result401: any = null;
                result401 =
                    _responseText === ''
                        ? null
                        : <IProblemDetails>(
                            JSON.parse(_responseText, this.jsonParseReviver)
                        );
                return this.throwException(
                    'Unauthorized',
                    status,
                    _responseText,
                    _headers,
                    result401
                );
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
                return this.throwException(
                    'An unexpected server error occurred.',
                    status,
                    _responseText,
                    _headers
                );
            });
        }
        console.log('Promise.resolve<CarListVm>(<any>null)')
        return Promise.resolve<TList>(<any>null);
    }

    /**
     * Создать объект
     * @param version Версия api функции
     * @param body Обьект для создания
     * @param apiObject Тип объекта
     */
    create<TCreate>(version: string, body: TCreate | undefined, apiObject: ApiObject): Promise<string> {
        let url_ = this.baseUrl + '/api/{version}/{apiObject}';
        if (version === undefined || version === null)
            throw new Error("The parameter 'version' must be defined.");
        url_ = url_.replace('{version}', encodeURIComponent('' + version));
        url_ = url_.replace('{apiObject}', encodeURIComponent('' + apiObject));
        url_ = url_.replace(/[?&]$/, '');

        const content_ = JSON.stringify(body);

        let options_ = <RequestInit>{
            body: content_,
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                Accept: 'application/json',
            },
        };

        return this.transformOptions(options_)
            .then((transformedOptions_) => {
                return this.http.fetch(url_, transformedOptions_);
            })
            .then((_response: Response) => {
                return this.processCreate(_response);
            });
    }

    protected processCreate(response: Response): Promise<string> {
        const status = response.status;
        let _headers: any = {};
        if (response.headers && response.headers.forEach) {
            response.headers.forEach((v: any, k: any) => (_headers[k] = v));
        }
        if (status === 200) {
            return response.text().then((_responseText) => {
                let result200: any = null;
                result200 =
                    _responseText === ''
                        ? null
                        : <string>(
                            JSON.parse(_responseText, this.jsonParseReviver)
                        );
                console.log('result200::', result200)
                return result200;
            });
        } else if (status === 401) {
            return response.text().then((_responseText) => {
                let result401: any = null;
                result401 =
                    _responseText === ''
                        ? null
                        : <IProblemDetails>(
                            JSON.parse(_responseText, this.jsonParseReviver)
                        );
                return this.throwException(
                    'Unauthorized',
                    status,
                    _responseText,
                    _headers,
                    result401
                );
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
                return this.throwException(
                    'An unexpected server error occurred.',
                    status,
                    _responseText,
                    _headers
                );
            });
        }
        return Promise.resolve<string>(<any>null);
    }

    /**
     * Удалить объект
     * @param version
     * @param apiObject
     * @param id
     */
    delete(version: string, apiObject: ApiObject, id?: string): Promise<void> {
        let url_ = this.baseUrl + '/api/{version}/{apiObject}/{id}';
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace('{id}', encodeURIComponent('' + id));
        if (version === undefined || version === null)
            throw new Error("The parameter 'version' must be defined.");
        url_ = url_.replace('{version}', encodeURIComponent('' + version));
        url_ = url_.replace('{apiObject}', encodeURIComponent('' + apiObject));
        url_ = url_.replace(/[?&]$/, '');

        let options_ = <RequestInit>{
            method: 'DELETE',
            headers: {},
        };

        return this.transformOptions(options_)
            .then((transformedOptions_) => {
                return this.http.fetch(url_, transformedOptions_);
            })
            .then((_response: Response) => {
                return this.processDelete(_response);
            });
    }

    protected processDelete(response: Response): Promise<void> {
        const status = response.status;
        let _headers: any = {};
        if (response.headers && response.headers.forEach) {
            response.headers.forEach((v: any, k: any) => (_headers[k] = v));
        }
        if (status === 204) {
            return response.text().then((_responseText) => {
                return;
            });
        } else if (status === 401) {
            return response.text().then((_responseText) => {
                let result401: any = null;
                result401 =
                    _responseText === ''
                        ? null
                        : <IProblemDetails>(
                            JSON.parse(_responseText, this.jsonParseReviver)
                        );
                return this.throwException(
                    'Unauthorized',
                    status,
                    _responseText,
                    _headers,
                    result401
                );
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
                return this.throwException(
                    'An unexpected server error occurred.',
                    status,
                    _responseText,
                    _headers
                );
            });
        }
        return Promise.resolve<void>(<any>null);
    }

    /**
     * Получить объект по ИД
     * @param version
     * @param apiObject
     * @param id
     */
    get<TDetails>(version: string, apiObject: ApiObject, id?: string): Promise<TDetails> {
        let url_ = this.baseUrl + '/api/{version}/{apiObject}/{id}';
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace('{id}', encodeURIComponent('' + id));
        if (version === undefined || version === null)
            throw new Error("The parameter 'version' must be defined.");
        url_ = url_.replace('{version}', encodeURIComponent('' + version));
        url_ = url_.replace('{apiObject}', encodeURIComponent('' + apiObject));
        url_ = url_.replace(/[?&]$/, '');

        let options_ = <RequestInit>{
            method: 'GET',
            headers: {
                Accept: 'application/json',
            },
        };

        return this.transformOptions(options_)
            .then((transformedOptions_) => {
                return this.http.fetch(url_, transformedOptions_);
            })
            .then((_response: Response) => {
                return this.processGet<TDetails>(_response);
            });
    }

    protected processGet<TDetails>(response: Response): Promise<TDetails> {
        const status = response.status;
        let _headers: any = {};
        if (response.headers && response.headers.forEach) {
            response.headers.forEach((v: any, k: any) => (_headers[k] = v));
        }
        if (status === 200) {
            return response.text().then((_responseText) => {
                let result200: any = null;
                result200 =
                    _responseText === ''
                        ? null
                        : <TDetails>(
                            JSON.parse(_responseText, this.jsonParseReviver)
                        );
                return result200;
            });
        } else if (status === 401) {
            return response.text().then((_responseText) => {
                let result401: any = null;
                result401 =
                    _responseText === ''
                        ? null
                        : <IProblemDetails>(
                            JSON.parse(_responseText, this.jsonParseReviver)
                        );
                return this.throwException(
                    'Unauthorized',
                    status,
                    _responseText,
                    _headers,
                    result401
                );
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
                return this.throwException(
                    'An unexpected server error occurred.',
                    status,
                    _responseText,
                    _headers
                );
            });
        }
        return Promise.resolve<TDetails>(<any>null);
    }

    update<TUpdate>(version: string, apiObject: ApiObject, body: TUpdate, ): Promise<void> {
        let url_ = this.baseUrl + '/api/{version}/{apiObject}';
        if (version === undefined || version === null)
            throw new Error("The parameter 'version' must be defined.");
        url_ = url_.replace('{version}', encodeURIComponent('' + version));
        url_ = url_.replace('{apiObject}', encodeURIComponent('' + apiObject));
        url_ = url_.replace(/[?&]$/, '');

        const content_ = JSON.stringify(body);

        let options_ = <RequestInit>{
            body: content_,
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
        };

        return this.transformOptions(options_)
            .then((transformedOptions_) => {
                return this.http.fetch(url_, transformedOptions_);
            })
            .then((_response: Response) => {
                return this.processUpdate(_response);
            });
    }

    protected processUpdate(response: Response): Promise<void> {
        const status = response.status;
        let _headers: any = {};
        if (response.headers && response.headers.forEach) {
            response.headers.forEach((v: any, k: any) => (_headers[k] = v));
        }
        if (status === 204) {
            return response.text().then((_responseText) => {
                return;
            });
        } else if (status === 401) {
            return response.text().then((_responseText) => {
                let result401: any = null;
                result401 =
                    _responseText === ''
                        ? null
                        : <IProblemDetails>(
                            JSON.parse(_responseText, this.jsonParseReviver)
                        );
                return this.throwException(
                    'Unauthorized',
                    status,
                    _responseText,
                    _headers,
                    result401
                );
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
                return this.throwException(
                    'An unexpected server error occurred.',
                    status,
                    _responseText,
                    _headers
                );
            });
        }
        return Promise.resolve<void>(<any>null);
    }


    protected isApiException = true;

    static isApiException(obj: any): obj is ApiException {
        return obj.isApiException === true;
    }

    /**
     * Пользовательское исключение
     */
    protected throwException(
        message: string,
        status: number,
        response: string,
        headers: { [key: string]: any },
        result?: any
    ): any {
        if (result !== null && result !== undefined) throw result;
        else throw new ApiException(message, status, response, headers, null);
    }
}
