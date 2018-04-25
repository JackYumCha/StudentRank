/** 
 * Auto Generated Code
 * Please do not modify this file manually 
 * Assembly Name: "RankAPI"
 * Source Type: "E:\database practice\StudentRank\RankAPI\RankAPI\bin\Debug\netcoreapp2.0\RankAPI.dll"
 * Generated At: 2018-04-22 16:26:43.218
 */
import { AzureMLRankRequest } from '../datatypes/RankAPI.Dtos.AzureMLRankRequest';
import { AzureMLRankResponse } from '../datatypes/RankAPI.Dtos.AzureMLRankResponse';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
@Injectable()
export class ProxyService {
	constructor(private $httpClient: HttpClient) {{}}
	public $baseURL: string = '<RankAPI>';
	public Infer(azureMLRankRequest: AzureMLRankRequest): Observable<AzureMLRankResponse> {
		return this.$httpClient.post<AzureMLRankResponse>(this.$baseURL + 'Proxy/Infer', azureMLRankRequest, {});
	}
}
