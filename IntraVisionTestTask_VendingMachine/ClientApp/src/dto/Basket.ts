import { Drink } from "./Drink";
import { Coin } from "./Coin";

export class Basket {
    drinks: Drink[];
    coins: Coin[];
    change: number;
}