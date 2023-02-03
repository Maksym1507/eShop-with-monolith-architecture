import { makeAutoObservable } from "mobx";
import CartItemModel from "../models/CartItemModel";

export class Cart {
  items: CartItemModel[] = [];
  totalSum: number = 0;
  constructor() {
    makeAutoObservable(this);
    if (localStorage.getItem("cart")) {
      this.items = JSON.parse(localStorage.getItem("cart") || "");
    } else localStorage.setItem("cart", JSON.stringify(this.items));

    if (localStorage.getItem("totalSum")) {
      this.totalSum = JSON.parse(localStorage.getItem("totalSum") || "");
    } else localStorage.setItem("totalSum", JSON.stringify(this.totalSum));
  }

  addItem(item: CartItemModel) {
    console.log(this.items);

    const isFound = this.items.findIndex(
      (x) => x.product.id === item.product.id
    );
    if (isFound !== -1) {
      this.items[isFound].count++;
      this.totalSum += item.count * item.price;
    }

    if (isFound === -1) {
      this.items.push(item);
      this.totalSum += item.price;
    }

    console.log(this.items);

    localStorage.setItem("cart", JSON.stringify(this.items));
    localStorage.setItem("totalSum", JSON.stringify(this.totalSum));
  }

  deleteItem(id: number) {
    const isFound = this.items.findIndex((x) => x.product.id === id);

    if (isFound !== -1) {
      this.totalSum -= this.items[isFound].count * this.items[isFound].price;
      this.items.splice(isFound, 1);

      localStorage.setItem("cart", JSON.stringify(this.items));
      localStorage.setItem("totalSum", JSON.stringify(this.totalSum));
    }
  }

  increaseItemCount(id: number) {
    const isFound = this.items.findIndex((x) => x.product.id === id);

    this.items[isFound].count++;
    this.totalSum += this.items[isFound].price;

    localStorage.setItem("cart", JSON.stringify(this.items));
    localStorage.setItem("totalSum", JSON.stringify(this.totalSum));
  }

  decreaseItemCount(id: number) {
    const isFound = this.items.findIndex((x) => x.product.id === id);

    if (this.items[isFound].count === 1) {
      this.deleteItem(id);
    }

    if (this.items[isFound].count !== 1) {
      this.items[isFound].count -= 1;
      this.totalSum -= this.items[isFound].price;
    }

    localStorage.setItem("cart", JSON.stringify(this.items));
    localStorage.setItem("totalSum", JSON.stringify(this.totalSum));
  }
}
