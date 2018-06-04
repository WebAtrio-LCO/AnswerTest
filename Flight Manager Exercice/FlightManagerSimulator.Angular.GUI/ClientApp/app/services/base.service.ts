import { Injector } from '@angular/core';
import { Http, RequestOptions, Headers, Response } from '@angular/http';
import { Observable } from "rxjs/Observable";
/**
 * import for map function
 */
import 'rxjs/Rx';

/**
 * Base service class.
 */
export abstract class BaseService {
    protected readonly http: Http;
    protected readonly originUrl: string;

    /**
     * Creates an initialize the BaseService class.
     * @param injector Angular injector.
     */
    constructor(injector: Injector) {
        this.http = injector.get(Http);
        this.originUrl = injector.get('ORIGIN_URL');
    }

    /**
     * Process a GET operation on a given URL.
     * @param url
     */
    protected get<T>(url: string): Observable<T> {
        let finalUrl: string = this.originUrl + url;

        return this.http.get(finalUrl, this.buildRequestHeaders())
            .map(result => result.json() as T);
        //.catch(this.error);
    }

    /**
     * Process a POST operation with content on a given URL.
     * @param url
     * @param content
     */
    protected post<T>(url: string, content: any): Observable<T> {
        let contentJson: string = JSON.stringify(content);
        let finalUrl: string = this.originUrl + url;

        return this.http.post(finalUrl, contentJson, this.buildRequestHeaders())
            .map(result => result.json() as T);
        //.catch(this.error);
    }

    /**
     * Process a PUT operation with content on a given URL.
     * @param url
     * @param content
     */
    protected put<T>(url: string, content: any): Observable<T> {
        let contentJson: string = JSON.stringify(content);
        let finalUrl: string = this.originUrl + url;

        return this.http.put(finalUrl, contentJson, this.buildRequestHeaders())
            .map(result => result.json() as T);
        //.catch(this.error);
    }

    /**
     * Process a PUT operation with content on a given URL without any returned object
     * @param url
     * @param content
     */
    protected putWithoutReturn(url: string, content: any): Observable<Response> {
        let contentJson: string = JSON.stringify(content);
        let finalUrl: string = this.originUrl + url;

        return this.http.put(finalUrl, contentJson, this.buildRequestHeaders());
        //.catch(this.error);
    }

    /**
     * Process a DELETE operation on a given URL.
     * @param url
     * @param content
     */
    protected delete<T>(url: string, content: any): Observable<T> {
        let contentJson: string = JSON.stringify(content);
        let finalUrl: string = this.originUrl + url;
        let requestHeaders = this.buildRequestHeaders();
        requestHeaders.body = contentJson;

        return this.http.delete(finalUrl, requestHeaders)
            .map(result => result.json() as T);
        //.catch(this.error);
    }

    /**
     * Process a HEAD operation on a given URL.
     * @param url a string representation of the URL
     * @returns returns true if the ressource exists
     */
    protected head<T>(url: string): Observable<boolean> {
        let finalUrl: string = this.originUrl + url;

        return this.http.get(finalUrl, this.buildRequestHeaders())
            .map(result => result.json() as boolean);//.catch(e => { return false; });
    }

    /**
     * Builds and gets the request options
     */
    private buildRequestHeaders(): RequestOptions {
        return new RequestOptions({
            headers: new Headers({
                'Content-Type': 'application/json'
            })
        });
    }

    /**
     * Catch exception errors from API.
     * @param e
     */
    private error(e: any): void {
        alert(`Error ${e.status}: ${e._body}`);
        console.log(e);
    }
}