import {Injectable} from '@angular/core';
import {Http,Headers,Response, Request, RequestOptions} from '@angular/http';
import {Observable} from 'rxjs';
import 'rxjs/add/operator/map';

@Injectable()
export class AuthenticationService {
    constructor(private _http:Http){ }

        login(username:string,password:string): Observable<boolean>{
            let url="localhost:5480/token";
            let body="username="+username+"&password="+password+"&grant_type=password";
            let headers=new Headers({'Content-Type':'application/x-www-form-urlencoded'});
            let options=new RequestOptions({headers:headers});
            return this._http.post(url,body,options)
            .map((response)=>{ 
                let result:any=response.json();

                localStorage.setItem("User", username);
                localStorage.setItem("Token","Bearer "+result.access_token);
                return true;
            })
        }
    }