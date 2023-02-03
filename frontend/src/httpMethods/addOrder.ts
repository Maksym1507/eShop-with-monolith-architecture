import { config } from "../constants/api-constants";
import OrderDto from "../dtos/OrderDto";
import { ErrorResponse } from "../responses/ErrorResponse";
import { SuccessResponse } from "../responses/SuccessResponse";

const addOrder = async (
  url: string,
  order: OrderDto
): Promise<SuccessResponse | ErrorResponse> => {
  const requestOptions = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      Authorization:
        "Bearer " + JSON.parse(localStorage.getItem("token") || ""),
    },
    body: JSON.stringify(order),
  };

  const response = await fetch(config.orderUrl, requestOptions);
  return await response.json();
};

export default addOrder;
