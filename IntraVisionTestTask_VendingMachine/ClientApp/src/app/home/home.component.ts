import { Component } from '@angular/core';
import { Basket } from 'src/dto/Basket';
import { Drink } from 'src/dto/Drink';
import { Coin } from 'src/dto/Coin';
import { BuyingHttpService } from 'src/httpServices/buyingHtppService';
import { DrinkHttpService } from 'src/httpServices/drinkHttpService';
import { CoinHttpService } from 'src/httpServices/coinHttpService';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [DrinkHttpService, CoinHttpService, BuyingHttpService]
})
export class HomeComponent {
  public drinks: Drink[] = [];
  public moneys: Coin[] = [];
  public depositedSum: number = 0;
  public selectedSum: number = 0;
  public selected: Drink[] = [];
  public change: Coin[] = [];
  public changeSum: number = 0;

  private deposited: Coin[] = [];

  constructor(private _drinkService: DrinkHttpService, private _moneyService: CoinHttpService, private _buyingService: BuyingHttpService) {
    this.loadDrinks();
    this.loadMoneys();
  }

  public addCurrent(money: Coin): void {
    this.deposited.push(money);
    this.depositedSum += money.denomination;
  }

  public select(drink: Drink): void {
    this.selected.push(drink);
    this.selectedSum += drink.price;
  }

  public buy(): void {
    const basket: Basket = new Basket();
    basket.drinks = this.selected;
    basket.coins = this.deposited;
    basket.change = this.depositedSum - this.selectedSum;
    this._buyingService.buy(basket).subscribe(v => {
      this.change = v;
      this.changeSum = basket.change;
    });
  }

  private loadDrinks(): void {
    this._drinkService.get().subscribe(values => {
      this.drinks = values;
    })
  }

  private loadMoneys(): void {
    this._moneyService.get().subscribe(values => {
      this.moneys = values;
    })
  }
}
