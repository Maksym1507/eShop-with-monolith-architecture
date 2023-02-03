import React, { useEffect, useState } from "react";
import { Button } from "react-bootstrap";
import ProductDto from "../../dtos/ProductDto";
import addProduct from "../../httpMethods/addProduct";
import { ErrorResponse } from "../../responses/ErrorResponse";
import { SuccessResponse } from "../../responses/SuccessResponse";

const CreateProductComponent = () => {
  const [formData, setFormData] = useState<ProductDto>({categoryId: 1 } as ProductDto);
  const [isCreated, setIsCreated] = useState<SuccessResponse | ErrorResponse>();

  const options = [
    { key: 1, value: "pizza" },
    { key: 2, value: "roll" },
  ];

  useEffect(() => {
    if (isCreated) {
      if ((isCreated as SuccessResponse).succesedMessage) {
        alert((isCreated as SuccessResponse).succesedMessage);
        setFormData({} as ProductDto);
        console.log(formData);
      }

      if ((isCreated as ErrorResponse).message) {
        alert((isCreated as ErrorResponse).message);
      }
    }
  }, [isCreated]);

  function handleSubmit(e: any) {
    e.preventDefault();
    (async () => {
      setIsCreated(
        await addProduct({
          title: formData.title,
          img: formData.img,
          price: formData.price,
          weight: formData.weight,
          consist: formData.consist,
          categoryId: formData.categoryId,
        })
      );
    })();
  }

  function handleChange(e: any) {
    if (e.target.value === "pizza") {
      return setFormData({ ...formData, [e.target.name]: 1 });
    }

    if (e.target.value === "roll") {
      return setFormData({ ...formData, [e.target.name]: 2 });
    }

    setFormData({ ...formData, [e.target.name]: e.target.value });

    console.log(formData);
  }

  return (
    <div>
      <div className="container h-100">
        <div className="row d-flex justify-content-center align-items-center h-100">
          <div className="col-12 col-md-9 col-lg-7 col-xl-6">
            <h2 className="text-uppercase text-center mb-4">Create product</h2>

            <form className="login-form" onSubmit={(e) => handleSubmit(e)}>
              <div className="form-outline">
                <label className="d-flex mb-1 ms-1">Title</label>
                <input
                  className="form-control mb-4"
                  type="text"
                  placeholder="Title"
                  value={formData.title || ""}
                  name="title"
                  onChange={(e) => handleChange(e)}
                />
              </div>

              <div className="form-outline">
                <label className="d-flex mb-1 ms-1">Img</label>
                <input
                  className="form-control mb-4"
                  type="text"
                  placeholder="Img"
                  value={formData.img || ""}
                  name="img"
                  onChange={(e) => handleChange(e)}
                />
              </div>

              <div className="form-outline">
                <label className="d-flex mb-1 ms-1">Weight</label>
                <input
                  className="form-control mb-4"
                  type="number"
                  placeholder="Weight"
                  value={formData.weight || ""}
                  name="weight"
                  onChange={(e) => handleChange(e)}
                />
              </div>
              <div className="form-outline">
                <label className="d-flex mb-1 ms-1">Category</label>
                <select
                  defaultValue={options[0].value}
                  className="form-select mb-4"
                  id="categoryId"
                  name="categoryId"
                  onChange={(e) => handleChange(e)}
                >
                  {options.map((option: any) => (
                    <option key={option.key} value={option.value}>
                      {option.value}
                    </option>
                  ))}
                </select>
              </div>
              <div className="form-outline mb-4">
                <label className="d-flex mb-1 ms-1">Price</label>
                <input
                  className="form-control"
                  type="number"
                  placeholder="Price"
                  value={formData.price || ""}
                  name="price"
                  onChange={(e) => handleChange(e)}
                />
              </div>

              <div className="form-outline mb-4">
                <label className="d-flex mb-1 ms-1">Consist</label>
                <input
                  className="form-control"
                  type="text"
                  placeholder="Consist"
                  value={formData.consist || ""}
                  name="consist"
                  onChange={(e) => handleChange(e)}
                />
              </div>
              <div className="d-flex justify-content-center">
                <Button className="btn-success" type="submit">
                  Create
                </Button>
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  );
};

export default CreateProductComponent;
