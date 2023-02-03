import AuthResponse from "../responses/AuthResponse";
import { config } from "../constants/api-constants";
import { ErrorResponse } from "../responses/ErrorResponse";

const loginUser = async (
  userEmail: string,
  userPassword: string
): Promise<AuthResponse | ErrorResponse> => {
  const requestOptions = {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({
      email: userEmail,
      password: userPassword,
    }),
  };

  const result: Response = await fetch(config.loginUrl, requestOptions);

  return await result.json();
};

export default loginUser;
