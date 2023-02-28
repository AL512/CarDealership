export class Client{

    constructor() {
    }

    /**
     * @param body (optional)
     * @return Success
     */
    /*update(version: string, body: UpdateCarDto | undefined): Promise<void> {
        let url_ = this.baseUrl + '/api/{version}/CarListItem';
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

}






