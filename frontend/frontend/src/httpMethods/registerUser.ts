import RegisterDto from "../dtos/RegisterDto";
import { config } from "../constants/api-constants";
import { ErrorResponse } from "../responses/ErrorResponse";
import RegisterResponse from "../responses/RegisterResponse";

const registerUser = async (
  registerUserModel: RegisterDto
): Promise<RegisterResponse | ErrorResponse> => {
  const requestOptions = {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(registerUserModel),
  };

  const result: Response = await fetch(config.registerUrl, requestOptions);

  return await result.json();
};

export default registerUser;
