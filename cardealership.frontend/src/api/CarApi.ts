import { ClientBase } from './ClientBase';

/* tslint:disable */
/* eslint-disable */

export class Client /*extends ClientBase*/ {

    constructor() {
        //super();
    }

    /**
     * @return Success
     */
    /*getAll(version: string): Promise<CarList> {
        let url_ = this.baseUrl + '/api/{version}/Car';
        if (version === undefined || version === null)
            throw new Error("The parameter 'version' must be defined.");
        url_ = url_.replace('{version}', encodeURIComponent('' + version));
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
                const req: any =  this.processGetAll(_response)
                return req;
                //return this.processGetAll(_response);
            });
    }*/

    /*protected processGetAll(response: Response): Promise<CarList> {
        const status = response.status;
        console.log('response:: ', response)
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
                        : <CarList>(
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
                        : <ProblemDetails>(
                              JSON.parse(_responseText, this.jsonParseReviver)
                          );
                return throwException(
                    'Unauthorized',
                    status,
                    _responseText,
                    _headers,
                    result401
                );
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
                return throwException(
                    'An unexpected server error occurred.',
                    status,
                    _responseText,
                    _headers
                );
            });
        }
        console.log('Promise.resolve<CarListVm>(<any>null)')
        return Promise.resolve<CarList>(<any>null);
    }*/

    /**
     * @param body (optional)
     * @return Success
     */
    /*create(version: string, body: CreateCarDto | undefined): Promise<string> {
        let url_ = this.baseUrl + '/api/{version}/Car';
        if (version === undefined || version === null)
            throw new Error("The parameter 'version' must be defined.");
        url_ = url_.replace('{version}', encodeURIComponent('' + version));
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
        if (status === 201) {
            return response.text().then((_responseText) => {
                let result201: any = null;
                result201 =
                    _responseText === ''
                        ? null
                        : <string>(
                            JSON.parse(_responseText, this.jsonParseReviver)
                        );
                return result201;
            });
        } else if (status === 401) {
            return response.text().then((_responseText) => {
                let result401: any = null;
                result401 =
                    _responseText === ''
                        ? null
                        : <ProblemDetails>(
                            JSON.parse(_responseText, this.jsonParseReviver)
                        );
                return throwException(
                    'Unauthorized',
                    status,
                    _responseText,
                    _headers,
                    result401
                );
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
                return throwException(
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
     * @param body (optional)
     * @return Success
     */
    /*update(version: string, body: UpdateCarDto | undefined): Promise<void> {
        let url_ = this.baseUrl + '/api/{version}/Car';
        if (version === undefined || version === null)
            throw new Error("The parameter 'version' must be defined.");
        url_ = url_.replace('{version}', encodeURIComponent('' + version));
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
                        : <ProblemDetails>(
                              JSON.parse(_responseText, this.jsonParseReviver)
                          );
                return throwException(
                    'Unauthorized',
                    status,
                    _responseText,
                    _headers,
                    result401
                );
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
                return throwException(
                    'An unexpected server error occurred.',
                    status,
                    _responseText,
                    _headers
                );
            });
        }
        return Promise.resolve<void>(<any>null);
    }*/

    /**
     * @return Success
     */
    /*get(id: string, version: string): Promise<CarDetails> {
        let url_ = this.baseUrl + '/api/{version}/Car/{id}';
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace('{id}', encodeURIComponent('' + id));
        if (version === undefined || version === null)
            throw new Error("The parameter 'version' must be defined.");
        url_ = url_.replace('{version}', encodeURIComponent('' + version));
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
                return this.processGet(_response);
            });
    }

    protected processGet(response: Response): Promise<CarDetails> {
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
                        : <CarDetails>(
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
                        : <ProblemDetails>(
                              JSON.parse(_responseText, this.jsonParseReviver)
                          );
                return throwException(
                    'Unauthorized',
                    status,
                    _responseText,
                    _headers,
                    result401
                );
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
                return throwException(
                    'An unexpected server error occurred.',
                    status,
                    _responseText,
                    _headers
                );
            });
        }
        return Promise.resolve<CarDetails>(<any>null);
    }*/

    /**
     * @return Success
     */
    /*delete(id: string, version: string): Promise<void> {
        let url_ = this.baseUrl + '/api/{version}/Car/{id}';
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace('{id}', encodeURIComponent('' + id));
        if (version === undefined || version === null)
            throw new Error("The parameter 'version' must be defined.");
        url_ = url_.replace('{version}', encodeURIComponent('' + version));
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
                        : <ProblemDetails>(
                              JSON.parse(_responseText, this.jsonParseReviver)
                          );
                return throwException(
                    'Unauthorized',
                    status,
                    _responseText,
                    _headers,
                    result401
                );
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
                return throwException(
                    'An unexpected server error occurred.',
                    status,
                    _responseText,
                    _headers
                );
            });
        }
        return Promise.resolve<void>(<any>null);
    }*/
}






