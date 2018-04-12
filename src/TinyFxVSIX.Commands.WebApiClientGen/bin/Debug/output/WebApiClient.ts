import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
export namespace DemoWebApi_DemoData_Client {
    export enum AddressType { Postal, Residential }

    export enum Days {
        Sat = 1,
        Sun = 2,
        Mon = 3,
        Tue = 4,
        Wed = 5,
        
        /** 
         * Thursday
         */
        Thu = 6,
        Fri = 7
    }

    export interface PhoneNumber {
        fullNumber?: string;
        phoneType?: DemoWebApi_DemoData_Client.PhoneType;
    }


    /** 
     * Phone type
     * Tel, Mobile, Skyp and Fax
     */
    export enum PhoneType {
        
        /** 
         * Land line
         */
        Tel,
        
        /** 
         * Mobile phone
         */
        Mobile,
        Skype,
        Fax
    }

    export interface Address {
        id?: string;
        street1?: string;
        street2?: string;
        city?: string;
        state?: string;
        postalCode?: string;
        country?: string;
        type?: DemoWebApi_DemoData_Client.AddressType;
        location?: any;
    }


    /** 
     * Base class of company and person
     */
    export interface Entity {
        id?: string;

        /** 
         * Name of the entity.
         */
        name: string;

        /** 
         * Multiple addresses
         */
        addresses?: Array<DemoWebApi_DemoData_Client.Address>;
        phoneNumbers?: Array<DemoWebApi_DemoData_Client.PhoneNumber>;
    }

    export interface Person extends DemoWebApi_DemoData_Client.Entity {
        surname?: string;
        givenName?: string;

        /** 
         * Date of Birth.
         * This is optional.
         */
        dob?: Date;
    }

    export interface Company extends DemoWebApi_DemoData_Client.Entity {

        /** 
         * BusinessNumber to be serialized as BusinessNum
         */
        BusinessNum?: string;
        businessNumberType?: string;
        textMatrix?: Array<Array<string>>;
        int2DJagged?: Array<Array<number>>;
        int2D?: number[][];
        lines?: Array<string>;
    }

    export interface MyPeopleDic {
        dic?: {[id: string]: DemoWebApi_DemoData_Client.Person };
        anotherDic?: {[id: string]: string };
        intDic?: {[id: number]: string };
    }

}

export namespace DemoWebApi_Controllers_Client {

    /** 
     * This class is used to carry the result of various file uploads.
     */
    export interface FileResult {

        /** 
         * Gets or sets the local path of the file saved on the server.
         */
        fileNames?: Array<string>;

        /** 
         * Gets or sets the submitter as indicated in the HTML form used to upload the data.
         */
        submitter?: string;
    }


    /** 
     * Complex hero type
     */
    export interface Hero {
        id?: number;
        name?: string;
    }

}

export namespace DemoWebApi_Controllers_Client {
    @Injectable()
    export class Account {
        constructor(@Inject('baseUri') private baseUri: string = location.protocol + '//' + location.hostname + (location.port ? ':' + location.port : '') + '/', private http: HttpClient){
        }

        /** 
         * GET Account/GetUserInfo
         * @return {any} 
         */
        getUserInfo(): Observable<Response>{
            return this.http.get<Response>(this.baseUri + 'Account/GetUserInfo');
        }

        /** 
         * POST Account/Logout
         * @return {any} 
         */
        logout(): Observable<Response>{
            return this.http.post<Response>(this.baseUri + 'Account/Logout', JSON.stringify(null), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * GET Account/GetManageInfo?returnUrl={returnUrl}&generateState={generateState}
         * @param {string} returnUrl 
         * @param {boolean} generateState 
         * @return {any} 
         */
        getManageInfo(returnUrl: string, generateState: boolean): Observable<Response>{
            return this.http.get<Response>(this.baseUri + 'Account/GetManageInfo?returnUrl='+encodeURIComponent(returnUrl)+'&generateState='+generateState);
        }

        /** 
         * POST Account/ChangePassword
         * @param {any} model 
         * @return {any} 
         */
        changePassword(model: any): Observable<Response>{
            return this.http.post<Response>(this.baseUri + 'Account/ChangePassword', JSON.stringify(model), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * POST Account/SetPassword
         * @param {any} model 
         * @return {any} 
         */
        setPassword(model: any): Observable<Response>{
            return this.http.post<Response>(this.baseUri + 'Account/SetPassword', JSON.stringify(model), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * POST Account/AddExternalLogin
         * @param {any} model 
         * @return {any} 
         */
        addExternalLogin(model: any): Observable<Response>{
            return this.http.post<Response>(this.baseUri + 'Account/AddExternalLogin', JSON.stringify(model), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * POST Account/RemoveLogin
         * @param {any} model 
         * @return {any} 
         */
        removeLogin(model: any): Observable<Response>{
            return this.http.post<Response>(this.baseUri + 'Account/RemoveLogin', JSON.stringify(model), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * GET Account/GetExternalLogin?provider={provider}&error={error}
         * @param {string} provider 
         * @param {string} error 
         * @return {any} 
         */
        getExternalLogin(provider: string, error: string): Observable<Response>{
            return this.http.get<Response>(this.baseUri + 'Account/GetExternalLogin?provider='+encodeURIComponent(provider)+'&error='+encodeURIComponent(error));
        }

        /** 
         * GET Account/GetExternalLogins?returnUrl={returnUrl}&generateState={generateState}
         * @param {string} returnUrl 
         * @param {boolean} generateState 
         * @return {Array<any>} 
         */
        getExternalLogins(returnUrl: string, generateState: boolean): Observable<Array<any>>{
            return this.http.get<Array<any>>(this.baseUri + 'Account/GetExternalLogins?returnUrl='+encodeURIComponent(returnUrl)+'&generateState='+generateState);
        }

        /** 
         * POST Account/Register
         * @param {any} model 
         * @return {any} 
         */
        register(model: any): Observable<Response>{
            return this.http.post<Response>(this.baseUri + 'Account/Register', JSON.stringify(model), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * POST Account/RegisterExternal
         * @param {any} model 
         * @return {any} 
         */
        registerExternal(model: any): Observable<Response>{
            return this.http.post<Response>(this.baseUri + 'Account/RegisterExternal', JSON.stringify(model), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }
    }

    @Injectable()
    export class FileUpload {
        constructor(@Inject('baseUri') private baseUri: string = location.protocol + '//' + location.hostname + (location.port ? ':' + location.port : '') + '/', private http: HttpClient){
        }

        /** 
         * POST FileUpload/UploadFile
         * @return {DemoWebApi_Controllers_Client.FileResult} 
         */
        uploadFile(): Observable<DemoWebApi_Controllers_Client.FileResult>{
            return this.http.post<DemoWebApi_Controllers_Client.FileResult>(this.baseUri + 'FileUpload/UploadFile', JSON.stringify(null), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }
    }

    @Injectable()
    export class Values {
        constructor(@Inject('baseUri') private baseUri: string = location.protocol + '//' + location.hostname + (location.port ? ':' + location.port : '') + '/', private http: HttpClient){
        }

        /** 
         * GET Values/Get
         * @return {Array<string>} 
         */
        get(): Observable<Array<string>>{
            return this.http.get<Array<string>>(this.baseUri + 'Values/Get');
        }

        /** 
         * GET Values/Get?id={id}&name={name}
         * @param {number} id 
         * @param {string} name 
         * @return {string} 
         */
        getByIdAndName(id: number, name: string): Observable<string>{
            return this.http.get<string>(this.baseUri + 'Values/Get?id='+id+'&name='+encodeURIComponent(name));
        }

        /** 
         * GET Values/Get?name={name}
         * @param {string} name 
         * @return {string} 
         */
        getByName(name: string): Observable<string>{
            return this.http.get<string>(this.baseUri + 'Values/Get?name='+encodeURIComponent(name));
        }

        /** 
         * POST Values/Post
         * @param {string} value 
         * @return {string} 
         */
        post(value: string): Observable<string>{
            return this.http.post<string>(this.baseUri + 'Values/Post', JSON.stringify(value), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * PUT Values/Put?id={id}
         * @param {number} id 
         * @param {string} value 
         * @return {void} 
         */
        put(id: number, value: string): Observable<Response>{
            return this.http.put<Response>(this.baseUri + 'Values/Put?id='+id, JSON.stringify(value), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * DELETE Values/Delete?id={id}
         * @param {number} id 
         * @return {void} 
         */
        delete(id: number): Observable<Response>{
            return this.http.delete<Response>(this.baseUri + 'Values/Delete?id='+id);
        }
    }

    @Injectable()
    export class Heroes {
        constructor(@Inject('baseUri') private baseUri: string = location.protocol + '//' + location.hostname + (location.port ? ':' + location.port : '') + '/', private http: HttpClient){
        }

        /** 
         * Get all heroes.
         * GET Heroes/Get
         * @return {Array<DemoWebApi_Controllers_Client.Hero>} 
         */
        get(): Observable<Array<DemoWebApi_Controllers_Client.Hero>>{
            return this.http.get<Array<DemoWebApi_Controllers_Client.Hero>>(this.baseUri + 'Heroes/Get');
        }

        /** 
         * Get a hero.
         * GET Heroes/Get?id={id}
         * @param {number} id 
         * @return {DemoWebApi_Controllers_Client.Hero} 
         */
        getById(id: number): Observable<DemoWebApi_Controllers_Client.Hero>{
            return this.http.get<DemoWebApi_Controllers_Client.Hero>(this.baseUri + 'Heroes/Get?id='+id);
        }

        /** 
         * DELETE Heroes/Delete?id={id}
         * @param {number} id 
         * @return {void} 
         */
        delete(id: number): Observable<Response>{
            return this.http.delete<Response>(this.baseUri + 'Heroes/Delete?id='+id);
        }

        /** 
         * Add a hero
         * POST Heroes/Post?name={name}
         * @param {string} name 
         * @return {DemoWebApi_Controllers_Client.Hero} 
         */
        post(name: string): Observable<DemoWebApi_Controllers_Client.Hero>{
            return this.http.post<DemoWebApi_Controllers_Client.Hero>(this.baseUri + 'Heroes/Post?name='+encodeURIComponent(name), JSON.stringify(null), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * Update hero.
         * PUT Heroes/Put
         * @param {DemoWebApi_Controllers_Client.Hero} hero 
         * @return {DemoWebApi_Controllers_Client.Hero} 
         */
        put(hero: DemoWebApi_Controllers_Client.Hero): Observable<DemoWebApi_Controllers_Client.Hero>{
            return this.http.put<DemoWebApi_Controllers_Client.Hero>(this.baseUri + 'Heroes/Put', JSON.stringify(hero), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * Search heroes
         * GET Heroes/Search?name={name}
         * @param {string} name keyword contained in hero name.
         * @return {Array<DemoWebApi_Controllers_Client.Hero>} Hero array matching the keyword.
         */
        search(name: string): Observable<Array<DemoWebApi_Controllers_Client.Hero>>{
            return this.http.get<Array<DemoWebApi_Controllers_Client.Hero>>(this.baseUri + 'Heroes/Search?name='+encodeURIComponent(name));
        }
    }

    @Injectable()
    export class Entities {
        constructor(@Inject('baseUri') private baseUri: string = location.protocol + '//' + location.hostname + (location.port ? ':' + location.port : '') + '/', private http: HttpClient){
        }

        /** 
         * Get a person
         * so to know the person
         * GET Entities/GetPerson?id={id}
         * @param {number} id unique id of that guy
         * @return {DemoWebApi_DemoData_Client.Person} person in db
         */
        getPerson(id: number): Observable<DemoWebApi_DemoData_Client.Person>{
            return this.http.get<DemoWebApi_DemoData_Client.Person>(this.baseUri + 'Entities/GetPerson?id='+id);
        }

        /** 
         * POST Entities/CreatePerson
         * @param {DemoWebApi_DemoData_Client.Person} p 
         * @return {number} 
         */
        createPerson(p: DemoWebApi_DemoData_Client.Person): Observable<number>{
            return this.http.post<number>(this.baseUri + 'Entities/CreatePerson', JSON.stringify(p), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * PUT Entities/UpdatePerson
         * @param {DemoWebApi_DemoData_Client.Person} person 
         * @return {void} 
         */
        updatePerson(person: DemoWebApi_DemoData_Client.Person): Observable<Response>{
            return this.http.put<Response>(this.baseUri + 'Entities/UpdatePerson', JSON.stringify(person), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * PUT Entities/LinkPerson?id={id}&relationship={relationship}
         * @param {number} id 
         * @param {string} relationship 
         * @param {DemoWebApi_DemoData_Client.Person} person 
         * @return {boolean} 
         */
        linkPerson(id: number, relationship: string, person: DemoWebApi_DemoData_Client.Person): Observable<boolean>{
            return this.http.put<boolean>(this.baseUri + 'Entities/LinkPerson?id='+id+'&relationship='+encodeURIComponent(relationship), JSON.stringify(person), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * DELETE Entities/Delete?id={id}
         * @param {number} id 
         * @return {void} 
         */
        delete(id: number): Observable<Response>{
            return this.http.delete<Response>(this.baseUri + 'Entities/Delete?id='+id);
        }

        /** 
         * GET Entities/GetCompany?id={id}
         * @param {number} id 
         * @return {DemoWebApi_DemoData_Client.Company} 
         */
        getCompany(id: number): Observable<DemoWebApi_DemoData_Client.Company>{
            return this.http.get<DemoWebApi_DemoData_Client.Company>(this.baseUri + 'Entities/GetCompany?id='+id);
        }

        /** 
         * GET Entities/GetPersonNotFound?id={id}
         * @param {number} id 
         * @return {DemoWebApi_DemoData_Client.Person} 
         */
        getPersonNotFound(id: number): Observable<DemoWebApi_DemoData_Client.Person>{
            return this.http.get<DemoWebApi_DemoData_Client.Person>(this.baseUri + 'Entities/GetPersonNotFound?id='+id);
        }

        /** 
         * GET Entities/GetPersonActionNotFound?id={id}
         * @param {number} id 
         * @return {DemoWebApi_DemoData_Client.Person} 
         */
        getPersonActionNotFound(id: number): Observable<DemoWebApi_DemoData_Client.Person>{
            return this.http.get<DemoWebApi_DemoData_Client.Person>(this.baseUri + 'Entities/GetPersonActionNotFound?id='+id);
        }
    }

    @Injectable()
    export class SuperDemo {
        constructor(@Inject('baseUri') private baseUri: string = location.protocol + '//' + location.hostname + (location.port ? ':' + location.port : '') + '/', private http: HttpClient){
        }

        /** 
         * GET SuperDemo/GetIntSquareAsync?d={d}
         * @param {number} d 
         * @return {number} 
         */
        getIntSquare(d: number): Observable<number>{
            return this.http.get<number>(this.baseUri + 'SuperDemo/GetIntSquareAsync?d='+d);
        }

        /** 
         * GET SuperDemo/GetDecimalSquare?d={d}
         * @param {number} d 
         * @return {number} 
         */
        getDecimalSquare(d: number): Observable<number>{
            return this.http.get<number>(this.baseUri + 'SuperDemo/GetDecimalSquare?d='+d);
        }

        /** 
         * GET SuperDemo/GetDateTime?hasValue={hasValue}
         * @param {boolean} hasValue 
         * @return {Date} 
         */
        getDateTime(hasValue: boolean): Observable<Date>{
            return this.http.get<Date>(this.baseUri + 'SuperDemo/GetDateTime?hasValue='+hasValue);
        }

        /** 
         * GET SuperDemo/GetNextYear?dt={dt}
         * @param {Date} dt 
         * @return {Date} 
         */
        getNextYear(dt: Date): Observable<Date>{
            return this.http.get<Date>(this.baseUri + 'SuperDemo/GetNextYear?dt='+dt);
        }

        /** 
         * GET SuperDemo/GetNextHour?dt={dt}
         * @param {Date} dt 
         * @return {Date} 
         */
        getNextHour(dt: Date): Observable<Date>{
            return this.http.get<Date>(this.baseUri + 'SuperDemo/GetNextHour?dt='+dt);
        }

        /** 
         * POST SuperDemo/PostNextYear
         * @param {Date} dt 
         * @return {Date} 
         */
        postNextYear(dt: Date): Observable<Date>{
            return this.http.post<Date>(this.baseUri + 'SuperDemo/PostNextYear', JSON.stringify(dt), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * GET SuperDemo/GetDateTimeOffset
         * @return {Date} 
         */
        getDateTimeOffset(): Observable<Date>{
            return this.http.get<Date>(this.baseUri + 'SuperDemo/GetDateTimeOffset');
        }

        /** 
         * DateTime and DateTimeOffset may not be represented well in URL, so must put them into the POST body.
         * POST SuperDemo/PostDateTimeOffset
         * @param {Date} d 
         * @return {boolean} 
         */
        postDateTimeOffset(d: Date): Observable<boolean>{
            return this.http.post<boolean>(this.baseUri + 'SuperDemo/PostDateTimeOffset', JSON.stringify(d), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * POST SuperDemo/PostDateTimeOffsetNullable
         * @param {Date} d 
         * @return {boolean} 
         */
        postDateTimeOffsetNullable(d: Date): Observable<boolean>{
            return this.http.post<boolean>(this.baseUri + 'SuperDemo/PostDateTimeOffsetNullable', JSON.stringify(d), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * GET SuperDemo/GetNullableDecimal?hasValue={hasValue}
         * @param {boolean} hasValue 
         * @return {number} 
         */
        getNullableDecimal(hasValue: boolean): Observable<number>{
            return this.http.get<number>(this.baseUri + 'SuperDemo/GetNullableDecimal?hasValue='+hasValue);
        }

        /** 
         * GET SuperDemo/GetFloatZero
         * @return {number} 
         */
        getFloatZero(): Observable<number>{
            return this.http.get<number>(this.baseUri + 'SuperDemo/GetFloatZero');
        }

        /** 
         * GET SuperDemo/GetDoubleZero
         * @return {number} 
         */
        getDoubleZero(): Observable<number>{
            return this.http.get<number>(this.baseUri + 'SuperDemo/GetDoubleZero');
        }

        /** 
         * GET SuperDemo/GetDecimalZero
         * @return {number} 
         */
        getDecimalZero(): Observable<number>{
            return this.http.get<number>(this.baseUri + 'SuperDemo/GetDecimalZero');
        }

        /** 
         * GET SuperDemo/GetNullString
         * @return {string} 
         */
        getNullString(): Observable<string>{
            return this.http.get<string>(this.baseUri + 'SuperDemo/GetNullString');
        }

        /** 
         * GET SuperDemo/GetEmptyString
         * @return {string} 
         */
        getEmptyString(): Observable<string>{
            return this.http.get<string>(this.baseUri + 'SuperDemo/GetEmptyString');
        }

        /** 
         * GET SuperDemo/GetNullPerson
         * @return {DemoWebApi_DemoData_Client.Person} 
         */
        getNullPerson(): Observable<DemoWebApi_DemoData_Client.Person>{
            return this.http.get<DemoWebApi_DemoData_Client.Person>(this.baseUri + 'SuperDemo/GetNullPerson');
        }

        /** 
         * GET SuperDemo/GetTextStream
         * @return {any} 
         */
        getTextStream(): Observable<Response>{
            return this.http.get<Response>(this.baseUri + 'SuperDemo/GetTextStream');
        }

        /** 
         * GET SuperDemo/GetByteArray
         * @return {Array<number>} 
         */
        getByteArray(): Observable<Array<number>>{
            return this.http.get<Array<number>>(this.baseUri + 'SuperDemo/GetByteArray');
        }

        /** 
         * GET SuperDemo/GetActionResult
         * @return {any} 
         */
        getActionResult(): Observable<Response>{
            return this.http.get<Response>(this.baseUri + 'SuperDemo/GetActionResult');
        }

        /** 
         * GET SuperDemo/GetActionStringResult
         * @return {string} 
         */
        getActionStringResult(): Observable<string>{
            return this.http.get<string>(this.baseUri + 'SuperDemo/GetActionStringResult');
        }

        /** 
         * GET SuperDemo/Getbyte
         * @return {number} 
         */
        getbyte(): Observable<number>{
            return this.http.get<number>(this.baseUri + 'SuperDemo/Getbyte');
        }

        /** 
         * GET SuperDemo/Getsbyte
         * @return {number} 
         */
        getsbyte(): Observable<number>{
            return this.http.get<number>(this.baseUri + 'SuperDemo/Getsbyte');
        }

        /** 
         * GET SuperDemo/GetShort
         * @return {number} 
         */
        getShort(): Observable<number>{
            return this.http.get<number>(this.baseUri + 'SuperDemo/GetShort');
        }

        /** 
         * GET SuperDemo/GetUShort
         * @return {number} 
         */
        getUShort(): Observable<number>{
            return this.http.get<number>(this.baseUri + 'SuperDemo/GetUShort');
        }

        /** 
         * GET SuperDemo/GetUint
         * @return {number} 
         */
        getUint(): Observable<number>{
            return this.http.get<number>(this.baseUri + 'SuperDemo/GetUint');
        }

        /** 
         * GET SuperDemo/Getulong
         * @return {number} 
         */
        getulong(): Observable<number>{
            return this.http.get<number>(this.baseUri + 'SuperDemo/Getulong');
        }

        /** 
         * GET SuperDemo/Getdouble
         * @return {number} 
         */
        getdouble(): Observable<number>{
            return this.http.get<number>(this.baseUri + 'SuperDemo/Getdouble');
        }

        /** 
         * GET SuperDemo/GetDecimal
         * @return {number} 
         */
        getDecimal(): Observable<number>{
            return this.http.get<number>(this.baseUri + 'SuperDemo/GetDecimal');
        }

        /** 
         * GET SuperDemo/GetChar
         * @return {string} 
         */
        getChar(): Observable<string>{
            return this.http.get<string>(this.baseUri + 'SuperDemo/GetChar');
        }

        /** 
         * GET SuperDemo/GetBool
         * @return {boolean} 
         */
        getBool(): Observable<boolean>{
            return this.http.get<boolean>(this.baseUri + 'SuperDemo/GetBool');
        }

        /** 
         * GET SuperDemo/GetInt2D
         * @return {number[][]} 
         */
        getInt2D(): Observable<number[][]>{
            return this.http.get<number[][]>(this.baseUri + 'SuperDemo/GetInt2D');
        }

        /** 
         * GET SuperDemo/GetInt2DJagged
         * @return {Array<Array<number>>} 
         */
        getInt2DJagged(): Observable<Array<Array<number>>>{
            return this.http.get<Array<Array<number>>>(this.baseUri + 'SuperDemo/GetInt2DJagged');
        }

        /** 
         * POST SuperDemo/PostInt2D
         * @param {number[][]} a 
         * @return {boolean} 
         */
        postInt2D(a: number[][]): Observable<boolean>{
            return this.http.post<boolean>(this.baseUri + 'SuperDemo/PostInt2D', JSON.stringify(a), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * POST SuperDemo/PostInt2DJagged
         * @param {Array<Array<number>>} a 
         * @return {boolean} 
         */
        postInt2DJagged(a: Array<Array<number>>): Observable<boolean>{
            return this.http.post<boolean>(this.baseUri + 'SuperDemo/PostInt2DJagged', JSON.stringify(a), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * POST SuperDemo/PostIntArray
         * @param {Array<number>} a 
         * @return {boolean} 
         */
        postIntArray(a: Array<number>): Observable<boolean>{
            return this.http.post<boolean>(this.baseUri + 'SuperDemo/PostIntArray', JSON.stringify(a), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * GET SuperDemo/GetIntArray
         * @return {Array<number>} 
         */
        getIntArray(): Observable<Array<number>>{
            return this.http.get<Array<number>>(this.baseUri + 'SuperDemo/GetIntArray');
        }

        /** 
         * GET SuperDemo/GetAnonymousDynamic
         * @return {any} 
         */
        getAnonymousDynamic(): Observable<Response>{
            return this.http.get<Response>(this.baseUri + 'SuperDemo/GetAnonymousDynamic');
        }

        /** 
         * GET SuperDemo/GetAnonymousObject
         * @return {any} 
         */
        getAnonymousObject(): Observable<Response>{
            return this.http.get<Response>(this.baseUri + 'SuperDemo/GetAnonymousObject');
        }

        /** 
         * POST SuperDemo/PostAnonymousObject
         * @param {any} obj 
         * @return {any} 
         */
        postAnonymousObject(obj: any): Observable<Response>{
            return this.http.post<Response>(this.baseUri + 'SuperDemo/PostAnonymousObject', JSON.stringify(obj), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * GET SuperDemo/GetDictionary
         * @return {{[id: string]: string }} 
         */
        getDictionary(): Observable<{[id: string]: string }>{
            return this.http.get<{[id: string]: string }>(this.baseUri + 'SuperDemo/GetDictionary');
        }

        /** 
         * GET SuperDemo/GetDictionaryOfPeople
         * @return {{[id: string]: DemoWebApi_DemoData_Client.Person }} 
         */
        getDictionaryOfPeople(): Observable<{[id: string]: DemoWebApi_DemoData_Client.Person }>{
            return this.http.get<{[id: string]: DemoWebApi_DemoData_Client.Person }>(this.baseUri + 'SuperDemo/GetDictionaryOfPeople');
        }

        /** 
         * POST SuperDemo/PostDictionary
         * @param {{[id: string]: DemoWebApi_DemoData_Client.Person }} dic 
         * @return {number} 
         */
        postDictionary(dic: {[id: string]: DemoWebApi_DemoData_Client.Person }): Observable<number>{
            return this.http.post<number>(this.baseUri + 'SuperDemo/PostDictionary', JSON.stringify(dic), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * GET SuperDemo/GetKeyhValuePair
         * @return {{key: string, value: DemoWebApi_DemoData_Client.Person }} 
         */
        getKeyhValuePair(): Observable<{key: string, value: DemoWebApi_DemoData_Client.Person }>{
            return this.http.get<{key: string, value: DemoWebApi_DemoData_Client.Person }>(this.baseUri + 'SuperDemo/GetKeyhValuePair');
        }

        /** 
         * GET SuperDemo/GetICollection
         * @return {Array<DemoWebApi_DemoData_Client.Person>} 
         */
        getICollection(): Observable<Array<DemoWebApi_DemoData_Client.Person>>{
            return this.http.get<Array<DemoWebApi_DemoData_Client.Person>>(this.baseUri + 'SuperDemo/GetICollection');
        }

        /** 
         * GET SuperDemo/GetIList
         * @return {Array<DemoWebApi_DemoData_Client.Person>} 
         */
        getIList(): Observable<Array<DemoWebApi_DemoData_Client.Person>>{
            return this.http.get<Array<DemoWebApi_DemoData_Client.Person>>(this.baseUri + 'SuperDemo/GetIList');
        }

        /** 
         * GET SuperDemo/GetIReadOnlyList
         * @return {Array<DemoWebApi_DemoData_Client.Person>} 
         */
        getIReadOnlyList(): Observable<Array<DemoWebApi_DemoData_Client.Person>>{
            return this.http.get<Array<DemoWebApi_DemoData_Client.Person>>(this.baseUri + 'SuperDemo/GetIReadOnlyList');
        }

        /** 
         * GET SuperDemo/GetIReadOnlyCollection
         * @return {Array<DemoWebApi_DemoData_Client.Person>} 
         */
        getIReadOnlyCollection(): Observable<Array<DemoWebApi_DemoData_Client.Person>>{
            return this.http.get<Array<DemoWebApi_DemoData_Client.Person>>(this.baseUri + 'SuperDemo/GetIReadOnlyCollection');
        }

        /** 
         * GET SuperDemo/GetList
         * @return {Array<DemoWebApi_DemoData_Client.Person>} 
         */
        getList(): Observable<Array<DemoWebApi_DemoData_Client.Person>>{
            return this.http.get<Array<DemoWebApi_DemoData_Client.Person>>(this.baseUri + 'SuperDemo/GetList');
        }

        /** 
         * GET SuperDemo/GetCollection
         * @return {Array<DemoWebApi_DemoData_Client.Person>} 
         */
        getCollection(): Observable<Array<DemoWebApi_DemoData_Client.Person>>{
            return this.http.get<Array<DemoWebApi_DemoData_Client.Person>>(this.baseUri + 'SuperDemo/GetCollection');
        }

        /** 
         * POST SuperDemo/PostICollection
         * @param {Array<DemoWebApi_DemoData_Client.Person>} list 
         * @return {number} 
         */
        postICollection(list: Array<DemoWebApi_DemoData_Client.Person>): Observable<number>{
            return this.http.post<number>(this.baseUri + 'SuperDemo/PostICollection', JSON.stringify(list), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * POST SuperDemo/PostIList
         * @param {Array<DemoWebApi_DemoData_Client.Person>} list 
         * @return {number} 
         */
        postIList(list: Array<DemoWebApi_DemoData_Client.Person>): Observable<number>{
            return this.http.post<number>(this.baseUri + 'SuperDemo/PostIList', JSON.stringify(list), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * POST SuperDemo/PostIReadOnlyList
         * @param {Array<DemoWebApi_DemoData_Client.Person>} list 
         * @return {number} 
         */
        postIReadOnlyList(list: Array<DemoWebApi_DemoData_Client.Person>): Observable<number>{
            return this.http.post<number>(this.baseUri + 'SuperDemo/PostIReadOnlyList', JSON.stringify(list), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * POST SuperDemo/PostIReadOnlyCollection
         * @param {Array<DemoWebApi_DemoData_Client.Person>} list 
         * @return {number} 
         */
        postIReadOnlyCollection(list: Array<DemoWebApi_DemoData_Client.Person>): Observable<number>{
            return this.http.post<number>(this.baseUri + 'SuperDemo/PostIReadOnlyCollection', JSON.stringify(list), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * POST SuperDemo/PostList
         * @param {Array<DemoWebApi_DemoData_Client.Person>} list 
         * @return {number} 
         */
        postList(list: Array<DemoWebApi_DemoData_Client.Person>): Observable<number>{
            return this.http.post<number>(this.baseUri + 'SuperDemo/PostList', JSON.stringify(list), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * POST SuperDemo/PostCollection
         * @param {Array<DemoWebApi_DemoData_Client.Person>} list 
         * @return {number} 
         */
        postCollection(list: Array<DemoWebApi_DemoData_Client.Person>): Observable<number>{
            return this.http.post<number>(this.baseUri + 'SuperDemo/PostCollection', JSON.stringify(list), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * POST SuperDemo/PostWithQueryButEmptyBody?s={s}&i={i}
         * @param {string} s 
         * @param {number} i 
         * @return {{item1:string, item2:number}} 
         */
        postWithQueryButEmptyBody(s: string, i: number): Observable<{item1:string, item2:number}>{
            return this.http.post<{item1:string, item2:number}>(this.baseUri + 'SuperDemo/PostWithQueryButEmptyBody?s='+encodeURIComponent(s)+'&i='+i, JSON.stringify(null), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }
    }

    @Injectable()
    export class Tuple {
        constructor(@Inject('baseUri') private baseUri: string = location.protocol + '//' + location.hostname + (location.port ? ':' + location.port : '') + '/', private http: HttpClient){
        }

        /** 
         * POST Tuple/LinkPersonCompany1
         * @param {{item1:DemoWebApi_DemoData_Client.Person, item2:DemoWebApi_DemoData_Client.Company}} peopleAndCompany 
         * @return {DemoWebApi_DemoData_Client.Person} 
         */
        linkPersonCompany1(peopleAndCompany: {item1:DemoWebApi_DemoData_Client.Person, item2:DemoWebApi_DemoData_Client.Company}): Observable<DemoWebApi_DemoData_Client.Person>{
            return this.http.post<DemoWebApi_DemoData_Client.Person>(this.baseUri + 'Tuple/LinkPersonCompany1', JSON.stringify(peopleAndCompany), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * POST Tuple/LinkPeopleCompany2
         * @param {{item1:DemoWebApi_DemoData_Client.Person, item2:DemoWebApi_DemoData_Client.Company}} peopleAndCompany 
         * @return {DemoWebApi_DemoData_Client.Person} 
         */
        linkPeopleCompany2(peopleAndCompany: {item1:DemoWebApi_DemoData_Client.Person, item2:DemoWebApi_DemoData_Client.Company}): Observable<DemoWebApi_DemoData_Client.Person>{
            return this.http.post<DemoWebApi_DemoData_Client.Person>(this.baseUri + 'Tuple/LinkPeopleCompany2', JSON.stringify(peopleAndCompany), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * POST Tuple/LinkPeopleCompany3
         * @param {{item1:DemoWebApi_DemoData_Client.Person, item2:DemoWebApi_DemoData_Client.Person, item3:DemoWebApi_DemoData_Client.Company}} peopleAndCompany 
         * @return {DemoWebApi_DemoData_Client.Person} 
         */
        linkPeopleCompany3(peopleAndCompany: {item1:DemoWebApi_DemoData_Client.Person, item2:DemoWebApi_DemoData_Client.Person, item3:DemoWebApi_DemoData_Client.Company}): Observable<DemoWebApi_DemoData_Client.Person>{
            return this.http.post<DemoWebApi_DemoData_Client.Person>(this.baseUri + 'Tuple/LinkPeopleCompany3', JSON.stringify(peopleAndCompany), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * POST Tuple/LinkPeopleCompany4
         * @param {{item1:DemoWebApi_DemoData_Client.Person, item2:DemoWebApi_DemoData_Client.Person, item3:DemoWebApi_DemoData_Client.Person, item4:DemoWebApi_DemoData_Client.Company}} peopleAndCompany 
         * @return {DemoWebApi_DemoData_Client.Person} 
         */
        linkPeopleCompany4(peopleAndCompany: {item1:DemoWebApi_DemoData_Client.Person, item2:DemoWebApi_DemoData_Client.Person, item3:DemoWebApi_DemoData_Client.Person, item4:DemoWebApi_DemoData_Client.Company}): Observable<DemoWebApi_DemoData_Client.Person>{
            return this.http.post<DemoWebApi_DemoData_Client.Person>(this.baseUri + 'Tuple/LinkPeopleCompany4', JSON.stringify(peopleAndCompany), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * GET Tuple/GetPeopleCompany4
         * @return {{item1:DemoWebApi_DemoData_Client.Person, item2:DemoWebApi_DemoData_Client.Person, item3:DemoWebApi_DemoData_Client.Person, item4:DemoWebApi_DemoData_Client.Company}} 
         */
        getPeopleCompany4(): Observable<{item1:DemoWebApi_DemoData_Client.Person, item2:DemoWebApi_DemoData_Client.Person, item3:DemoWebApi_DemoData_Client.Person, item4:DemoWebApi_DemoData_Client.Company}>{
            return this.http.get<{item1:DemoWebApi_DemoData_Client.Person, item2:DemoWebApi_DemoData_Client.Person, item3:DemoWebApi_DemoData_Client.Person, item4:DemoWebApi_DemoData_Client.Company}>(this.baseUri + 'Tuple/GetPeopleCompany4');
        }

        /** 
         * POST Tuple/LinkPeopleCompany5
         * @param {{item1:DemoWebApi_DemoData_Client.Person, item2:DemoWebApi_DemoData_Client.Person, item3:DemoWebApi_DemoData_Client.Person, item4:DemoWebApi_DemoData_Client.Person, item5:DemoWebApi_DemoData_Client.Company}} peopleAndCompany 
         * @return {DemoWebApi_DemoData_Client.Person} 
         */
        linkPeopleCompany5(peopleAndCompany: {item1:DemoWebApi_DemoData_Client.Person, item2:DemoWebApi_DemoData_Client.Person, item3:DemoWebApi_DemoData_Client.Person, item4:DemoWebApi_DemoData_Client.Person, item5:DemoWebApi_DemoData_Client.Company}): Observable<DemoWebApi_DemoData_Client.Person>{
            return this.http.post<DemoWebApi_DemoData_Client.Person>(this.baseUri + 'Tuple/LinkPeopleCompany5', JSON.stringify(peopleAndCompany), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * GET Tuple/GetPeopleCompany5
         * @return {{item1:DemoWebApi_DemoData_Client.Person, item2:DemoWebApi_DemoData_Client.Person, item3:DemoWebApi_DemoData_Client.Person, item4:DemoWebApi_DemoData_Client.Person, item5:DemoWebApi_DemoData_Client.Company}} 
         */
        getPeopleCompany5(): Observable<{item1:DemoWebApi_DemoData_Client.Person, item2:DemoWebApi_DemoData_Client.Person, item3:DemoWebApi_DemoData_Client.Person, item4:DemoWebApi_DemoData_Client.Person, item5:DemoWebApi_DemoData_Client.Company}>{
            return this.http.get<{item1:DemoWebApi_DemoData_Client.Person, item2:DemoWebApi_DemoData_Client.Person, item3:DemoWebApi_DemoData_Client.Person, item4:DemoWebApi_DemoData_Client.Person, item5:DemoWebApi_DemoData_Client.Company}>(this.baseUri + 'Tuple/GetPeopleCompany5');
        }

        /** 
         * POST Tuple/LinkPeopleCompany6
         * @param {{item1:DemoWebApi_DemoData_Client.Person, item2:DemoWebApi_DemoData_Client.Person, item3:DemoWebApi_DemoData_Client.Person, item4:DemoWebApi_DemoData_Client.Person, item5:DemoWebApi_DemoData_Client.Person, item6:DemoWebApi_DemoData_Client.Company}} peopleAndCompany 
         * @return {DemoWebApi_DemoData_Client.Person} 
         */
        linkPeopleCompany6(peopleAndCompany: {item1:DemoWebApi_DemoData_Client.Person, item2:DemoWebApi_DemoData_Client.Person, item3:DemoWebApi_DemoData_Client.Person, item4:DemoWebApi_DemoData_Client.Person, item5:DemoWebApi_DemoData_Client.Person, item6:DemoWebApi_DemoData_Client.Company}): Observable<DemoWebApi_DemoData_Client.Person>{
            return this.http.post<DemoWebApi_DemoData_Client.Person>(this.baseUri + 'Tuple/LinkPeopleCompany6', JSON.stringify(peopleAndCompany), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * POST Tuple/LinkPeopleCompany7
         * @param {{item1:DemoWebApi_DemoData_Client.Person, item2:DemoWebApi_DemoData_Client.Person, item3:DemoWebApi_DemoData_Client.Person, item4:DemoWebApi_DemoData_Client.Person, item5:DemoWebApi_DemoData_Client.Person, item6:DemoWebApi_DemoData_Client.Person, item7:DemoWebApi_DemoData_Client.Company}} peopleAndCompany 
         * @return {DemoWebApi_DemoData_Client.Person} 
         */
        linkPeopleCompany7(peopleAndCompany: {item1:DemoWebApi_DemoData_Client.Person, item2:DemoWebApi_DemoData_Client.Person, item3:DemoWebApi_DemoData_Client.Person, item4:DemoWebApi_DemoData_Client.Person, item5:DemoWebApi_DemoData_Client.Person, item6:DemoWebApi_DemoData_Client.Person, item7:DemoWebApi_DemoData_Client.Company}): Observable<DemoWebApi_DemoData_Client.Person>{
            return this.http.post<DemoWebApi_DemoData_Client.Person>(this.baseUri + 'Tuple/LinkPeopleCompany7', JSON.stringify(peopleAndCompany), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * POST Tuple/LinkPeopleCompany8
         * @param {{item1:DemoWebApi_DemoData_Client.Person, item2:DemoWebApi_DemoData_Client.Person, item3:DemoWebApi_DemoData_Client.Person, item4:DemoWebApi_DemoData_Client.Person, item5:DemoWebApi_DemoData_Client.Person, item6:DemoWebApi_DemoData_Client.Person, item7:DemoWebApi_DemoData_Client.Person, rest:DemoWebApi_DemoData_Client.Company}} peopleAndCompany 
         * @return {DemoWebApi_DemoData_Client.Person} 
         */
        linkPeopleCompany8(peopleAndCompany: {item1:DemoWebApi_DemoData_Client.Person, item2:DemoWebApi_DemoData_Client.Person, item3:DemoWebApi_DemoData_Client.Person, item4:DemoWebApi_DemoData_Client.Person, item5:DemoWebApi_DemoData_Client.Person, item6:DemoWebApi_DemoData_Client.Person, item7:DemoWebApi_DemoData_Client.Person, rest:DemoWebApi_DemoData_Client.Company}): Observable<DemoWebApi_DemoData_Client.Person>{
            return this.http.post<DemoWebApi_DemoData_Client.Person>(this.baseUri + 'Tuple/LinkPeopleCompany8', JSON.stringify(peopleAndCompany), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * GET Tuple/GetTuple1
         * @return {{item1:number}} 
         */
        getTuple1(): Observable<{item1:number}>{
            return this.http.get<{item1:number}>(this.baseUri + 'Tuple/GetTuple1');
        }

        /** 
         * POST Tuple/PostTuple1
         * @param {{item1:number}} tuple 
         * @return {number} 
         */
        postTuple1(tuple: {item1:number}): Observable<number>{
            return this.http.post<number>(this.baseUri + 'Tuple/PostTuple1', JSON.stringify(tuple), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * GET Tuple/GetTuple2
         * @return {{item1:string, item2:number}} 
         */
        getTuple2(): Observable<{item1:string, item2:number}>{
            return this.http.get<{item1:string, item2:number}>(this.baseUri + 'Tuple/GetTuple2');
        }

        /** 
         * POST Tuple/PostTuple2
         * @param {{item1:string, item2:number}} tuple 
         * @return {string} 
         */
        postTuple2(tuple: {item1:string, item2:number}): Observable<string>{
            return this.http.post<string>(this.baseUri + 'Tuple/PostTuple2', JSON.stringify(tuple), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * GET Tuple/GetTuple3
         * @return {{item1:string, item2:string, item3:number}} 
         */
        getTuple3(): Observable<{item1:string, item2:string, item3:number}>{
            return this.http.get<{item1:string, item2:string, item3:number}>(this.baseUri + 'Tuple/GetTuple3');
        }

        /** 
         * POST Tuple/PostTuple3
         * @param {{item1:string, item2:string, item3:number}} tuple 
         * @return {string} 
         */
        postTuple3(tuple: {item1:string, item2:string, item3:number}): Observable<string>{
            return this.http.post<string>(this.baseUri + 'Tuple/PostTuple3', JSON.stringify(tuple), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * GET Tuple/GetTuple4
         * @return {{item1:string, item2:string, item3:string, item4:number}} 
         */
        getTuple4(): Observable<{item1:string, item2:string, item3:string, item4:number}>{
            return this.http.get<{item1:string, item2:string, item3:string, item4:number}>(this.baseUri + 'Tuple/GetTuple4');
        }

        /** 
         * POST Tuple/PostTuple4
         * @param {{item1:string, item2:string, item3:string, item4:number}} tuple 
         * @return {string} 
         */
        postTuple4(tuple: {item1:string, item2:string, item3:string, item4:number}): Observable<string>{
            return this.http.post<string>(this.baseUri + 'Tuple/PostTuple4', JSON.stringify(tuple), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * GET Tuple/GetTuple5
         * @return {{item1:string, item2:string, item3:string, item4:string, item5:number}} 
         */
        getTuple5(): Observable<{item1:string, item2:string, item3:string, item4:string, item5:number}>{
            return this.http.get<{item1:string, item2:string, item3:string, item4:string, item5:number}>(this.baseUri + 'Tuple/GetTuple5');
        }

        /** 
         * POST Tuple/PostTuple5
         * @param {{item1:string, item2:string, item3:string, item4:string, item5:number}} tuple 
         * @return {string} 
         */
        postTuple5(tuple: {item1:string, item2:string, item3:string, item4:string, item5:number}): Observable<string>{
            return this.http.post<string>(this.baseUri + 'Tuple/PostTuple5', JSON.stringify(tuple), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * GET Tuple/GetTuple6
         * @return {{item1:string, item2:string, item3:string, item4:string, item5:string, item6:number}} 
         */
        getTuple6(): Observable<{item1:string, item2:string, item3:string, item4:string, item5:string, item6:number}>{
            return this.http.get<{item1:string, item2:string, item3:string, item4:string, item5:string, item6:number}>(this.baseUri + 'Tuple/GetTuple6');
        }

        /** 
         * POST Tuple/PostTuple6
         * @param {{item1:string, item2:string, item3:string, item4:string, item5:string, item6:number}} tuple 
         * @return {string} 
         */
        postTuple6(tuple: {item1:string, item2:string, item3:string, item4:string, item5:string, item6:number}): Observable<string>{
            return this.http.post<string>(this.baseUri + 'Tuple/PostTuple6', JSON.stringify(tuple), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * GET Tuple/GetTuple7
         * @return {{item1:string, item2:string, item3:string, item4:string, item5:string, item6:number, item7:number}} 
         */
        getTuple7(): Observable<{item1:string, item2:string, item3:string, item4:string, item5:string, item6:number, item7:number}>{
            return this.http.get<{item1:string, item2:string, item3:string, item4:string, item5:string, item6:number, item7:number}>(this.baseUri + 'Tuple/GetTuple7');
        }

        /** 
         * POST Tuple/PostTuple7
         * @param {{item1:string, item2:string, item3:string, item4:string, item5:string, item6:number, item7:number}} tuple 
         * @return {string} 
         */
        postTuple7(tuple: {item1:string, item2:string, item3:string, item4:string, item5:string, item6:number, item7:number}): Observable<string>{
            return this.http.post<string>(this.baseUri + 'Tuple/PostTuple7', JSON.stringify(tuple), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }

        /** 
         * GET Tuple/GetTuple8
         * @return {{item1:string, item2:string, item3:string, item4:string, item5:string, item6:string, item7:number, rest:{item1:string, item2:string, item3:string}}} 
         */
        getTuple8(): Observable<{item1:string, item2:string, item3:string, item4:string, item5:string, item6:string, item7:number, rest:{item1:string, item2:string, item3:string}}>{
            return this.http.get<{item1:string, item2:string, item3:string, item4:string, item5:string, item6:string, item7:number, rest:{item1:string, item2:string, item3:string}}>(this.baseUri + 'Tuple/GetTuple8');
        }

        /** 
         * POST Tuple/PostTuple8
         * @param {{item1:string, item2:string, item3:string, item4:string, item5:string, item6:string, item7:string, rest:{item1:string, item2:string, item3:string}}} tuple 
         * @return {string} 
         */
        postTuple8(tuple: {item1:string, item2:string, item3:string, item4:string, item5:string, item6:string, item7:string, rest:{item1:string, item2:string, item3:string}}): Observable<string>{
            return this.http.post<string>(this.baseUri + 'Tuple/PostTuple8', JSON.stringify(tuple), { headers: new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8' }) });
        }
    }

}

