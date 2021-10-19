import { HttpService } from './HttpService';
import { Injectable } from '@angular/core';
import { HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Drink } from 'src/dto/Drink';
import { Coin } from 'src/dto/Coin';

@Injectable()
export class DrinkHttpService {
    private readonly _httpService: HttpService;

    public constructor(httpService: HttpService) {
        this._httpService = httpService;
    }

    public get(): Observable<Drink[]> {
        return this._httpService.get<Drink[]>('api/drink');
    }

    public save(drink: Drink): Observable<Drink> {
        return this._httpService.post<Drink, Drink>('api/drink/save', drink);
    }

    public remove(id: number): Observable<void> {
        const params: HttpParams = new HttpParams()
            .set('id', id.toString());
        return this._httpService.post('api/drink/remove', params);
    }
}