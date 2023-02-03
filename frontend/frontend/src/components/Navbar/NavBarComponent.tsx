import { observer } from "mobx-react-lite";
import React, { FC } from "react";
import { Container, Nav, Navbar, NavDropdown } from "react-bootstrap";
import { Link, Outlet } from "react-router-dom";
import { myCart, myUserStore } from "../../App";

const NavBarComponent: FC = observer(() => {
  return (
    <>
      <Navbar sticky="top" bg="secondary" expand="lg" variant="dark">
        <Container fluid>
          <Navbar.Brand>Pizza Life</Navbar.Brand>
          <Navbar.Toggle aria-controls="navbarScroll" />
          <Navbar.Collapse id="navbarScroll">
            <Nav
              className="me-auto my-2 my-lg-0"
              style={{ maxHeight: "100px" }}
              navbarScroll
            >
              <NavDropdown title="Products" id="navbarScrollingDropdown">
                <Nav.Link
                  as={Link}
                  to="/pizza"
                  className="text-decoration-none text-black cursor-pointer"
                >
                  Pizza
                </Nav.Link>
                <NavDropdown.Divider />
                <Nav.Link
                  as={Link}
                  to="/roll"
                  className="text-decoration-none text-black cursor-pointer"
                >
                  Rolls
                </Nav.Link>
              </NavDropdown>
              <Nav.Link as={Link} to="/cart">
                <img
                  src="https://cdn-icons-png.flaticon.com/512/118/118089.png"
                  alt=""
                  width={20}
                  className="cursor-pointer"
                />
                <span className="ms-1">{myCart.items.length}</span>
              </Nav.Link>
              {myUserStore.isAutificated && (
                <Nav.Link className="" as={Link} to="orders">
                  <img
                    src="https://cdn-icons-png.flaticon.com/512/5885/5885642.png"
                    alt=""
                    width={25}
                    className="cursor-pointer"
                  />
                </Nav.Link>
              )}
            </Nav>
              {myUserStore.isAutificated && (
                <Nav.Link
                  className="text-white me-3"
                  onClick={() => {
                    myUserStore.userLogout();
                  }}
                >
                  Logout
                </Nav.Link>
              )}
              <Nav.Link className="" as={Link} to="/cabinet">
                <img
                  src="https://icons.veryicon.com/png/o/internet--web/prejudice/user-128.png"
                  alt=""
                  width={25}
                  className="cursor-pointer"
                />
              </Nav.Link>
          </Navbar.Collapse>
        </Container>
      </Navbar>
      <Outlet />
    </>
  );
});

export default NavBarComponent;
