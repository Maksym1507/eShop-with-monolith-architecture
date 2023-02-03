import { config } from "../constants/api-constants";
import ProductDto from "../dtos/ProductDto";
import { ErrorResponse } from "../responses/ErrorResponse";
import { SuccessResponse } from "../responses/SuccessResponse";

const addProduct = async (
  productToUpdate: ProductDto
): Promise<SuccessResponse | ErrorResponse> => {
  const requestOptions = {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(productToUpdate),
  };

  const result: Response = await fetch(
    `${config.productUrl}`,
    requestOptions
  );

  return await result.json();
};

export default addProduct;