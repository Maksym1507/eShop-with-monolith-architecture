import { ErrorResponse } from "../responses/ErrorResponse";
import { SuccessResponse } from "../responses/SuccessResponse";

const deleteProduct = async (
  url: string,
  id: number
): Promise<SuccessResponse | ErrorResponse> => {
  const requestOptions = {
    method: "DELETE",
    headers: { "Content-Type": "application/json" },
  };
  const result = await fetch(`${url}/${id}`, requestOptions);

  return await result.json();
};

export default deleteProduct;
