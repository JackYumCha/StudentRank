import { Component } from '@angular/core';
import { ProxyService } from './services/mvc-api/services/AzureMLProxy.Controllers.Proxy.Service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  results: {score: number, rank: number}[] = [];

  constructor(private proxyService: ProxyService){

  }

  score: number = 80;
  click(){
    this.proxyService.Infer({
    Inputs: {
        input1: {
          ColumnNames: [
            "rank",
            "score"
          ],
          Values: [
            [
              "0",
              `${this.score}`
            ]
          ]
        }
      },
      GlobalParameters: {}
    }).subscribe(
      response =>{
        console.log(response.Results.output1.value.Values);
        this.results.push({
          score: this.score,
          rank: Number(response.Results.output1.value.Values[0][2])
        })
      }
    );
  }
}