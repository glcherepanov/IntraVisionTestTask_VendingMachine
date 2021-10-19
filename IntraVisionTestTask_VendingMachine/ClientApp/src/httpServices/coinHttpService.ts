import { HttpService } from './HttpService';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Coin } from 'src/dto/Coin';
import { HttpParams } from '@angular/common/http';

@Injectable()
export class CoinHttpService {
    private readonly _httpService: HttpService;

    public constructor(httpService: HttpService) {
        this._httpService = httpService;
    }

    public get(): Observable<Coin[]> {
        return this._httpService.get<Coin[]>('api/coin');
    }

    public save(money: Coin): Observable<Coin> {
        return this._httpService.post<Coin, Coin>('api/coin/save', money);
    }

    public remove(id: number): Observable<void> {
        const params: HttpParams = new HttpParams()
            .set('id', id.toString());
        return this._httpService.post('api/coin/remove', params);
    }
}