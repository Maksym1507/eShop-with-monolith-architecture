import React, { FC } from "react";
import "./App.css";
import { Navigate, Route, Routes } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import NavBarComponent from "./components/Navbar/NavBarComponent";
import CartComponent from "./pages/Cart/CartComponent";
import NoMatchComponent from "./pages/NoMatch/NoMatchComponent";
import { ProductStore } from "./stores/Product.store";
import { Cart } from "./stores/Cart.store";
import { UserStore } from "./stores/User.store";
import LoginComponent from "./pages/Auth/LoginComponent";
import { observer } from "mobx-react-lite";
import AccountComponent from "./pages/Account/AccountComponent";
import OrderHistory from "./pages/Order/OrderHistoryComponent";
import OrderComponent from "./pages/Order/OrderComponent";
import SignUpComponent from "./pages/Auth/SignUpComponent";
import ProductComponent from "./pages/Product/ProductComponent";
import ProductDetailsComponent from "./pages/Product/ProductDetailsComponent";
import UpdateProductComponent from "./pages/UpdateProduct/UpdateProductComponent";
import CreateProductComponent from "./pages/CreateProduct/CreateProductComponent";

export const myProducts = new ProductStore();
export const myCart = new Cart();
export const myUserStore = new UserStore();

const App: FC = observer(() => {
  return (
    <div className="App">
      <Routes>
        <Route path="/" element={<NavBarComponent />}>
          <Route index element={<Navigate replace to="pizza" />} />
          <Route
            path="pizza"
            element={<ProductComponent categoryId={1} />}
          ></Route>
          <Route
            path="roll"
            element={<ProductComponent categoryId={2} />}
          ></Route>
          <Route path="pizza/:id" element={<ProductDetailsComponent />} />
          <Route path="roll/:id" element={<ProductDetailsComponent />} />
          <Route
            path="pizza/:id/updateProduct"
            element={<UpdateProductComponent />}
          />
          <Route
            path="roll/:id/updateProduct"
            element={<UpdateProductComponent />}
          />
          <Route path="createProduct" element={<CreateProductComponent />} />
          <Route path="cart" element={<CartComponent />} />
          <Route path="register" element={<SignUpComponent />} />
          <Route path="login" element={<LoginComponent />} />
          {myUserStore.isAutificated && (
            <>
              <Route path="do-order" element={<OrderComponent />} />
              <Route path="orders" element={<OrderHistory />} />
              <Route path="cabinet" element={<AccountComponent />} />
            </>
          )}
          :
          {
            <>
              <Route
                path="do-order"
                element={<Navigate replace to="/login" />}
              />
              <Route path="orders" element={<Navigate replace to="/login" />} />
              <Route
                path="cabinet"
                element={<Navigate replace to="/login" />}
              />
            </>
          }
        </Route>
        <Route path="*" element={<NoMatchComponent />} />
      </Routes>
    </div>
  );
});

export default App;
