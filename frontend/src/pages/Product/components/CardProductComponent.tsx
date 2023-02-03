import { Button, Card } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import { myCart } from "../../../App";
import { config } from "../../../constants/api-constants";
import getProductById from "../../../httpMethods/getProductById";
import CartItemModel from "../../../models/CartItemModel";
import ProductModel from "../../../models/ProductModel";

function CardProductComponent(props: ProductModel) {
  const navigation = useNavigate();
  return (
    <div className="col">
      <Card className="mt-1 ms-4 h-100">
        <Card.Img
          variant="top"
          src={props.img}
          alt={props.title}
          onClick={async () => {
            navigation(
              `${(await getProductById(config.productUrl, props.id)).id}`
            );
          }}
        />
        <Card.Body>
          <Card.Title>{props.title}</Card.Title>
          <Card.Text>{props.price} ₴</Card.Text>
          <Button
            className="btn-info d-flex"
            onClick={() =>
              myCart.addItem({
                id: props.id,
                product: props,
                price: props.price,
                count: 1,
              } as CartItemModel)
            }
          >
            Add to cart
          </Button>
        </Card.Body>
      </Card>
    </div>
  );
}

export default CardProductComponent;
