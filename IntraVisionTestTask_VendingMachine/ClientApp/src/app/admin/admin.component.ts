import { Component } from '@angular/core';
import { Drink } from 'src/dto/Drink';
import { Coin } from 'src/dto/Coin';
import { DrinkHttpService } from 'src/httpServices/drinkHttpService';
import { CoinHttpService } from 'src/httpServices/coinHttpService';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  providers: [DrinkHttpService, CoinHttpService]
})
export class AdminComponent {
  public drinks: Drink[] = [];
  public coins: Coin[] = [];
  public totalCoins: number = 0;
  public changingDrink: Drink = new Drink();
  public changingMoney: Coin = new Coin();

  constructor(private _drinkService: DrinkHttpService, private _coinService: CoinHttpService ) {
    this.loadDrinks();
    this.loadMoneys();
  }

  public addDrink(): void {
    this._drinkService.save(new Drink()).subscribe(value => {
      this.drinks.push(value);
    });
  }

  public saveDrink(drink: Drink): void {
    this._drinkService.save(drink).subscribe(value => {
      drink = value;
      this.changingDrink = new Drink();
    });
  }

  public removeDrink(id:number): void {
    this._drinkService.remove(id).subscribe(v => {
      this.loadDrinks();
    });
  }

  public undoDrink(drink: Drink): void {
    drink.id = this.changingDrink.id;
    drink.count = this.changingDrink.count;
    drink.price = this.changingDrink.price;
    drink.imageSrc = this.changingDrink.imageSrc;
    this.changingDrink = new Drink();
  }

  public selectChanchingDrink(drink: Drink): void {
    this.changingDrink.id = drink.id;
    this.changingDrink.count = drink.count;
    this.changingDrink.price = drink.price;
    this.changingDrink.imageSrc = drink.imageSrc;
  }

  public removeMoney(): void {

  }

  public addMoney(): void {
    this._coinService.save(new Coin()).subscribe(value => {
      this.coins.push(value);
    })
  }

  public undoMoney(money: Coin): void {
    money.id = this.changingMoney.id;
    money.denomination = this.changingMoney.denomination;
    money.count = this.changingMoney.count;
    money.isAvailable = this.changingMoney.isAvailable;
    this.changingMoney = new Coin();
  }

  public selectChanchingMoney(money: Coin): void {
    this.changingMoney.id = money.id;
    this.changingMoney.denomination = money.denomination;
    this.changingMoney.count = money.count;
    this.changingMoney.isAvailable = money.isAvailable;
  }

  public saveMoney(money: Coin): void {
    this._coinService.save(money).subscribe(v => {
      this.changingMoney = new Coin();
    });
  }

  private loadDrinks(): void {
    this._drinkService.get().subscribe(values => {
      this.drinks = values;
    });
  }

  private loadMoneys(): void {
    this._coinService.get().subscribe(values => {
      this.coins = values;
      this.coins.forEach(m => {
        this.totalCoins += m.denomination * m.count;
      });
    })
  }
}
