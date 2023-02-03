import { observer } from "mobx-react-lite";
import React, { FC, useEffect, useState } from "react";
import { Button, Form } from "react-bootstrap";
import { useForm } from "react-hook-form";
import { Navigate, useNavigate } from "react-router-dom";
import { myUserStore } from "../../App";
import AuthResponse from "../../responses/AuthResponse";
import { ErrorResponse } from "../../responses/ErrorResponse";

export const LoginComponent: FC = observer(() => {
  const [value, setValue] = useState<AuthResponse | ErrorResponse>();
  const navigate = useNavigate();

  const {
    register,
    formState: { errors, isValid },
    handleSubmit,
  } = useForm({ mode: "onBlur" });
  const [formData, setFormData] = useState({
    email: "",
    password: "",
  });

  useEffect(() => {
    debugger;
    if (value) {
      if ((value as AuthResponse).user) {
        myUserStore.user = (value as AuthResponse).user;
        localStorage.setItem("user", JSON.stringify(myUserStore.user));
        localStorage.setItem(
          "token",
          JSON.stringify((value as AuthResponse).accessToken)
        );
        alert("You are log in");
        myUserStore.init(true);
        navigate("/cart");
      } else if (value as Error) {
        alert(`${(value as Error).message}. Try again`);
      }
    }
  }, [value]);

  function onSubmit(e: any) {
    (async () => {
      setValue(await myUserStore.userLogin(formData.email, formData.password));
    })();
  }

  const handleChangeEmail = (event: any) => {
    setFormData({
      email: event.target.value,
      password: formData.password,
    });
  };

  const handleChangePassword = (event: any) => {
    setFormData({
      email: formData.email,
      password: event.target.value,
    });
  };

  if (!myUserStore.isAutificated) {
    return (
      <div className="container">
        <div className="row min-vh-100">
          <div className="col d-flex flex-column justify-content-center align-items-center">
            <Form
              noValidate
              className="ms-3 mb-3 pt-3 pb-3 bg-dark rounded border border-dark text-light"
              style={{ width: "24rem", height: "24rem" }}
              onSubmit={handleSubmit(onSubmit)}
            >
              <h2 className=" text-center">Sign in</h2>
              <Form.Group className="mb-3" controlId="formBasicEmail">
                <Form.Label className="d-flex text-light ms-4">
                  Email address
                </Form.Label>
                <Form.Control
                  className="ms-4"
                  style={{ width: "21rem" }}
                  type="email"
                  placeholder="Enter email"
                  {...register("email", {
                    required: "Email can not be empty",
                    pattern: {
                      value: /^[a-zA-Z0-9].+@[a-zA-Z0-9]+\.[A-Za-z]+$/,
                      message: "Invalid email format",
                    },
                  })}
                  onChange={(e) => handleChangeEmail(e)}
                />
                <div style={{ height: 20 }}>
                  {errors?.email && (
                    <p className="text-danger">
                      {errors?.email?.message?.toString()}
                    </p>
                  )}
                </div>
              </Form.Group>

              <Form.Group className="mb-4" controlId="formBasicPassword">
                <Form.Label className="d-flex text-light ms-4">
                  Password
                </Form.Label>
                <Form.Control
                  className="ms-4"
                  style={{ width: "21rem" }}
                  type="password"
                  placeholder="Password"
                  autoComplete="on"
                  {...register("password", {
                    required: "Password can not be empty",
                  })}
                  onChange={(e) => handleChangePassword(e)}
                />
                <div style={{ height: 20 }}>
                  {errors?.password && (
                    <p className="text-danger">
                      {errors?.password?.message?.toString()}
                    </p>
                  )}
                </div>
              </Form.Group>
              <Button
                className="ms-3"
                style={{ width: "7rem" }}
                variant="primary"
                type="submit"
                disabled={!isValid}
              >
                Sign in
              </Button>
              <p className="small fw-bold mt-2 pt-1 mb-0">
                Don't have an account?{" "}
                <span
                  className="text-info cursor-pointer"
                  onClick={() => navigate("/register")}
                >
                  Sign up
                </span>
              </p>
            </Form>
          </div>
        </div>
      </div>
    );
  }
  return <Navigate to="/pizza" />;
});

export default LoginComponent;
