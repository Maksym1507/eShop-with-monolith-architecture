import { runInAction, makeAutoObservable } from "mobx";
import Product from "../models/ProductModel";
import { myCart } from "../App";
import getProductById from "../httpMethods/getProductById";
import deleteProduct from "../httpMethods/deleteProduct";
import { SuccessResponse } from "../responses/SuccessResponse";
import { ErrorResponse } from "../responses/ErrorResponse";

export class ProductStore {
  products: Product[] = [];
  totalSum: number = 0;
  deleteMessage: SuccessResponse | ErrorResponse = {} as
    | SuccessResponse
    | {} as ErrorResponse;
  constructor() {
    makeAutoObservable(this);
  }

  async deleteProduct(url: string, id: number, navigation: Function) {
    if (window.confirm("Are you sure you want to delete this product?")) {
      this.deleteMessage = await deleteProduct(url, id);
    }

    if (this.deleteMessage as SuccessResponse) {
      const isFound = this.products.findIndex((x) => x.id === id);

      myCart.deleteItem(id);
      this.products.splice(isFound, 1);

      localStorage.setItem("products", JSON.stringify(this.products));
      alert((this.deleteMessage as SuccessResponse).succesedMessage);
      this.rebootDeleteMessage();
      navigation(-1);
    }

    if ((this.deleteMessage as ErrorResponse).message) {
      alert((this.deleteMessage as ErrorResponse).message);
      this.rebootDeleteMessage();
    }
  }

  async getSingleProduct(url: string, id: number) {
    return await getProductById(url, id);
  }

  rebootDeleteMessage() {
    runInAction(async () => {
      this.deleteMessage = {} as SuccessResponse | {} as ErrorResponse;
    });
  }
}
