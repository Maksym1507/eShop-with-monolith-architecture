import { Button, Card } from "react-bootstrap";
import { Link } from "react-router-dom";
import { myCart, myProducts } from "../../App";

export function getRollDetailsById(id: string): JSX.Element {
  if (id) {
    debugger;
    const index = myProducts.products.findIndex((x: any) => x.id === id);
    if (index !== -1) {
      return (
        <>
          <h2>Product details</h2>
          <div
            style={{ width: "40rem", height: "36rem" }}
            className="container"
          >
            <Card.Body>
              <div className="justify-content-center">
                <Card.Img
                  src={myProducts.products[index].img}
                  alt={myProducts.products[index].title}
                />
                <br />
                {myProducts.products[index].title}
                <br />
                {myProducts.products[index].price} uah
                <br />
                <Button
                  className="btn-info mt-2 me-3"
                  // onClick={() =>
                  //   myCart.addItem({
                  //     id: myProducts.products[index].id,
                  //     img: myProducts.products[index].img,
                  //     title: myProducts.products[index].title,
                  //     price: myProducts.products[index].price,
                  //     count: 1,
                  //   } as ItemsCart)
                  // }
                >
                  Add to cart
                </Button>
                <img
                  width={20}
                  height={20}
                  src="https://cdn.icon-icons.com/icons2/692/PNG/512/seo-social-web-network-internet_262_icon-icons.com_61518.png"
                  alt="delete"
                  className="mt-1"
                  // onClick={() =>
                  //   myProducts.deleteProduct(myProducts.products[index].id)
                  // }
                />
                <Link
                  to="/pizza"
                  className="mt-3 me-2 d-flex justify-content-end"
                >
                  Go to catalog
                </Link>
              </div>
            </Card.Body>
          </div>
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
            <Link to="/api/pizza">Go to pizza</Link>
          </p>
        </div>
      </div>
    </div>
  );
}
