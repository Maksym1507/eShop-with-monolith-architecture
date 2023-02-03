import Product from "../models/ProductModel";

interface OrderProductResponse {
  product: Product
  count: number;
  total: number;
};

export default OrderProductResponse;