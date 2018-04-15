import { PredictRankService } from './predict-rank.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  constructor(private predictService: PredictRankService){

  }

  score: number = 80;
  click(){
    this.predictService.PredictRank(this.score).subscribe(
      response =>{
        console.log(response.toString());
      }
    );
  }
}