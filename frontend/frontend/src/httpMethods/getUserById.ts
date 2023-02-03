import { config } from "../constants/api-constants";
import UserResponse from "../responses/UserResponse";

const getUserById = async (id: string): Promise<UserResponse> => {
  const requestOptions = {
    method: "GET",
    headers: {
      Accept: "application/json",
      Authorization:
        "Bearer " + JSON.parse(localStorage.getItem("token") || ""),
    },
  };

  const result = await fetch(`${config.userUrl}/${id}`, requestOptions);

  return await result.json();
};

export default getUserById;
