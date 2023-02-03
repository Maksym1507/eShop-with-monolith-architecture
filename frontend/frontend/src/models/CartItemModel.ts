import ProductModel from "./ProductModel"

 interface CartItemModel {
  product: ProductModel,
  count: number,
  price: number
};

export default CartItemModel