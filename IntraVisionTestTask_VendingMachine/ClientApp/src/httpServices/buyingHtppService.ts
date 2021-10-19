import { HttpService } from './HttpService';
import { Injectable } from '@angular/core';
import { HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Drink } from 'src/dto/Drink';
import { Coin } from 'src/dto/Coin';
import { Basket } from 'src/dto/Basket';

@Injectable()
export class BuyingHttpService {
    private readonly _httpService: HttpService;

    public constructor(httpService: HttpService) {
        this._httpService = httpService;
    }

    public buy(basket: Basket): Observable<Coin[]> {
        return this._httpService.post<Basket, Coin[]>('api/buying', basket);
    }
}