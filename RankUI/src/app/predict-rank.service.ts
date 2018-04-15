import {Injectable} from '@angular/core';
import {Http} from '@angular/http';

const predict_url = 'https://ussouthcentral.services.azureml.net/workspaces/98571941432749559c92acee0d315262/services/e95a065c1a2644e6a91f53f8e11966b9/execute?api-version=2.0&details=true';

@Injectable()
export class PredictRankService {
    constructor(private http: Http){

    }

    PredictRank(score: number){
        var query: IPredictObject = {
            Inputs: {
                input1:{
                    ColumnNames:[
                    "score"],
                    Values:[
                        [score]
                    ]
                }
            }
        };

        return this.http.post(predict_url, query,{
            headers:<any>{
                //'Content-Type': 'application/json',
                //'Accept':'application/json',
                'Authorization':'Bearer Ad9o0sBRdZ8Ly+sNLpBraZizBK0XR4APQ/DfW8PWucW1SW+6cbR3fReJ5BJUsS7z7+/bNCjkUni7ZDbBh4/2mQ=='
            }
        });
    }
}

export interface IPredictObject{
    Inputs: IPredictInput;
}

export interface IPredictInput{
    input1: IInputEntry
}

export interface IInputEntry{
    ColumnNames: string[];
    Values: (string|number)[][];
}