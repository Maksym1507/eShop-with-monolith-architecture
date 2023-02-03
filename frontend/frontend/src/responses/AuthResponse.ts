import UserResponse from "./UserResponse";

interface AuthResponse {
  accessToken: string,
  user: UserResponse
}

export default AuthResponse;
