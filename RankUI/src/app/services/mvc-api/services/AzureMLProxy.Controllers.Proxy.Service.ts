/** 
 * Auto Generated Code
 * Please do not modify this file manually 
 * Assembly Name: "AzureMLProxy"
 * Source Type: "D:\GitHub\StudentRank\AzureMLProxy\AzureMLProxy\bin\Debug\netcoreapp2.0\AzureMLProxy.dll"
 * Generated At: 2018-04-20 02:57:58.406
 */
import { AzureMLRankRequest } from '../datatypes/AzureMLProxy.Dtos.AzureMLRankRequest';
import { AzureMLRankResponse } from '../datatypes/AzureMLProxy.Dtos.AzureMLRankResponse';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
@Injectable()
export class ProxyService {
	constructor(private $httpClient: HttpClient) {{}}
	public $baseURL: string = '<AzureMLProxy>';
	public Infer(azureMLRankRequest: AzureMLRankRequest): Observable<AzureMLRankResponse> {
		return this.$httpClient.post<AzureMLRankResponse>(this.$baseURL + 'Proxy/Infer', azureMLRankRequest, {});
	}
}
