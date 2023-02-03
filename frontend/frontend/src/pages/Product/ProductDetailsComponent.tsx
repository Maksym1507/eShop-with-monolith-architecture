import { observer } from "mobx-react-lite";
import { FC, useEffect, useState } from "react";
import { Button } from "react-bootstrap";
import { Link, useNavigate, useParams } from "react-router-dom";
import { myCart, myProducts } from "../../App";
import { config } from "../../constants/api-constants";
import CartItemModel from "../../models/CartItemModel";
import Product from "../../models/ProductModel";
import { ErrorResponse } from "../../responses/ErrorResponse";
import { SuccessResponse } from "../../responses/SuccessResponse";

const ProductDetailsComponent: FC = observer(() => {
  const { id } = useParams();
  const navigate = useNavigate();

  const [product, setProduct] = useState<Product>();

  useEffect(() => {
    (async () => {
      if (id) {
        setProduct(await myProducts.getSingleProduct(config.productUrl, +id));
      }
    })();
  }, [id]);

  function handleClick() {
    debugger;
    (async () => {
      await myProducts.deleteProduct(config.productUrl, product!.id, navigate);
    })();
  }

  if (product) {
    if (product.id) {
      return (
        <>
          <section className="my-4">
            <div className="container px-4 px-lg-5">
              <div className="row gx-4 gx-lg-5">
                <div className="col-md-4">
                  <img
                    className="card-img-top mb-5 mb-md-0"
                    src={product.img}
                    alt={product.title}
                  />
                </div>
                <div className="col-md-6">
                  <h1 className="display-4 fw-bolder mb-2">{product.title}</h1>
                  <div className="fs-5 mb-2">
                    <span>{product.price} ₴</span>
                  </div>
                  <p className="mb-3">Ingredients: {product.consist}</p>
                  <div className="d-flex mb-2">Weight: {product.weight}g</div>
                  <div className="d-flex">
                    <button
                      onClick={() =>
                        myCart.addItem({
                          id: product.id,
                          product: product,
                          price: product.price,
                          count: 1,
                        } as CartItemModel)
                      }
                      className="btn btn-outline-dark flex-shrink-0"
                    >
                      Add to cart
                    </button>
                    <Button
                      onClick={() => {
                        navigate(-1);
                      }}
                      className="ms-3 btn-info"
                    >
                      Back to shop
                    </Button>
                    <Link className="text-decoration-none" to="updateProduct">
                      <img
                        className="mt-1 ms-3"
                        width={25}
                        height={25}
                        src="https://cdn-icons-png.flaticon.com/512/84/84380.png"
                        alt="edit"
                      />{" "}
                    </Link>
                    <img
                      className="ms-3 mt-1"
                      width={25}
                      height={25}
                      src="https://img.icons8.com/ios-glyphs/512/trash.png"
                      alt="delete"
                      onClick={handleClick}
                    />
                  </div>
                </div>
              </div>
            </div>
          </section>
        </>
      );
    }
  }
  return (
    <div className="container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          <h2>Product not found</h2>

          <p>
            <Link to="/pizza">Go to catalog</Link>
          </p>
        </div>
      </div>
    </div>
  );
});

export default ProductDetailsComponent;
