import { observer } from "mobx-react-lite";
import { FC, useEffect, useState } from "react";
import { Navigate, useNavigate } from "react-router-dom";
import { myUserStore } from "../../App";
import RegisterDto from "../../dtos/RegisterDto";
import { ErrorResponse } from "../../responses/ErrorResponse";
import RegisterResponse from "../../responses/RegisterResponse";

export const SignUpComponent: FC = observer(() => {
  const [register, setRegister] = useState<RegisterResponse | ErrorResponse>();

  const navigate = useNavigate();

  const [formData, setFormData] = useState<RegisterDto>(
    {} as RegisterDto
  );

  useEffect(() => {
    if (register) {
      if ((register as RegisterResponse).succesedMessage) {
        alert(`${(register as RegisterResponse).succesedMessage}`);
        navigate("/login");
      } else if (register as ErrorResponse) {
        alert(`${(register as ErrorResponse).message}. Try again`);
      }
    }
  }, [register]);

  function handleSubmit(e: any) {
    e.preventDefault();

    (async () => {
      setRegister(await myUserStore.userRegister(formData));
    })();
  }

  function handleChange(e: any) {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  }

  if (!myUserStore.isAutificated) {
    return (
      <div>
        <div className="container h-100">
          <div className="row d-flex justify-content-center align-items-center h-100">
            <div className="col-12 col-md-9 col-lg-7 col-xl-6">
              <h2 className="text-uppercase text-center mb-4">Sign up</h2>

              <form className="login-form" onSubmit={(e) => handleSubmit(e)}>
                <div className="form-outline">
                  <input
                    className="form-control mb-4"
                    type="text"
                    placeholder="Name"
                    value={formData.name}
                    name="name"
                    onChange={(e) => handleChange(e)}
                  />
                </div>

                <div className="form-outline">
                  <input
                    className="form-control mb-4"
                    type="text"
                    placeholder="LastName"
                    value={formData.lastName}
                    name="lastName"
                    onChange={(e) => handleChange(e)}
                  />
                </div>

                <div className="form-outline">
                  <input
                    className="form-control mb-4"
                    type="tel"
                    placeholder="Phone number"
                    value={formData.phoneNumber}
                    name="phoneNumber"
                    onChange={(e) => handleChange(e)}
                  />
                </div>

                <div className="form-outline mb-4">
                  <input
                    className="form-control"
                    type="email"
                    placeholder="Email"
                    value={formData.email}
                    name="email"
                    onChange={(e) => handleChange(e)}
                  />
                </div>

                <div className="form-outline mb-4">
                  <input
                    className="form-control"
                    type="password"
                    placeholder="Password"
                    value={formData.password}
                    name="password"
                    onChange={(e) => handleChange(e)}
                  />
                </div>

                <div className="form-outline mb-4">
                  <input
                    className="form-control"
                    type="password"
                    placeholder="Confirm password"
                    value={formData.confirmPassword}
                    name="confirmPassword"
                    onChange={(e) => handleChange(e)}
                  />
                </div>

                <div className="d-flex justify-content-center">
                  <button className="login-btn" type="submit">
                    Sign Up
                  </button>
                </div>

                <p className="text-center text-muted mt-3 mb-0">
                  Have already an account?{" "}
                  <span
                    className="text-primary cursor-pointer"
                    onClick={() => navigate("/login")}
                  >
                    Sign in here
                  </span>
                </p>
              </form>
            </div>
          </div>
        </div>
      </div>
    );
  }
  return <Navigate to="/pizza" />;
});

export default SignUpComponent;
