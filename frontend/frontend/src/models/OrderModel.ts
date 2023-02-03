interface OrderModel {
  id: number;
  userId: string;
  name: string;
  lastName: string;
  phoneNumber: string;
  email: string;
  country: string;
  region: string;
  city: string;
  address: string;
  index: string;
  createdAt: string;
  totalSum: number;
};

export default OrderModel;