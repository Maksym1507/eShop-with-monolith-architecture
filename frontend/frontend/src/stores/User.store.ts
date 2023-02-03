import { makeAutoObservable } from "mobx";
import RegisterDto from "../dtos/RegisterDto";
import getUserById from "../httpMethods/getUserById";
import loginUser from "../httpMethods/loginUser";
import registerUser from "../httpMethods/registerUser";
import UserResponse from "../responses/UserResponse";

export class UserStore {
  isAutificated: boolean = false;
  user: UserResponse = {} as UserResponse;
  
  constructor() {
    makeAutoObservable(this);
    if (localStorage.getItem("user")) {
      this.user = JSON.parse(localStorage.getItem("user") || "");
      if (this.user.email) {
        this.isAutificated = true;
      }
    }
  }

  async userLogin(email: string, password: string) {
    return await loginUser(email, password);
  }

  async userRegister(registerUserModel: RegisterDto) {
    return await registerUser(registerUserModel);
  }

  userLogout() {
    this.isAutificated = false;
    this.user = {} as UserResponse;
    localStorage.removeItem("user");
    localStorage.removeItem("token");
    alert("You are log out");
  }

  public async getUser(id: string) {
    return await getUserById(id);
  }

  init(value: boolean) {
    this.isAutificated = value;
  }
}
