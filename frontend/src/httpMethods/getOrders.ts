import { ErrorResponse } from "../responses/ErrorResponse";
import OrderResponse from "../responses/OrderResponse";

const getOrders = async (
  url: string,
  userId: string
): Promise<OrderResponse[] | ErrorResponse> => {
  const requestOptions = {
    method: "GET",
    headers: {
      Accept: "application/json",
      Authorization:
        "Bearer " + JSON.parse(localStorage.getItem("token") || ""), // передача токена в заголовке
    },
  };

  const result = await fetch(`${url}/${userId}`, requestOptions);

  return await result.json();
};

export default getOrders;
