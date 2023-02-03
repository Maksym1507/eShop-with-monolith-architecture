import { config } from "../constants/api-constants";
import ProductDto from "../dtos/ProductDto";
import { ErrorResponse } from "../responses/ErrorResponse";
import { SuccessResponse } from "../responses/SuccessResponse";

const updateProduct = async (
  productToUpdate: ProductDto,
  id: number
): Promise<SuccessResponse | ErrorResponse> => {
  const requestOptions = {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(productToUpdate),
  };

  const result: Response = await fetch(
    `${config.productUrl}/${id}`,
    requestOptions
  );

  return await result.json();
};

export default updateProduct;
