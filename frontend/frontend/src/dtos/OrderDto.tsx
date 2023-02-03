import CartItemModel from "../models/CartItemModel";

interface OrderDto {
  userId: string;
  cartItems: CartItemModel[];
  name: string;
  lastName: string;
  phoneNumber: string;
  email: string;
  country: string;
  region: string;
  city: string;
  address: string;
  index: string;
  totalSum: number;
};

export default OrderDto;