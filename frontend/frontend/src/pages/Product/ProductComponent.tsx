import React, { useEffect, useState } from "react";
import { config } from "../../constants/api-constants";
import getProducts from "../../httpMethods/getProducts";
import ProductModel from "../../models/ProductModel";
import PaginationComponent from "./components/PaginationComponent";
import CardProductComponent from "./components/CardProductComponent";

type Props = {
  categoryId: number;
};

const ProductComponent = (props: Props) => {
  const limit: number = 6;
  const [currentPage, setCurrentPage] = useState(1);
  const [products, setProducts] = useState<ProductModel[]>([]);
  const [productsOnPage, setProductsOnPage] = useState<ProductModel[]>([]);
  const [sortType, setSortType] = useState<string>("asc");
  const [totalPages, setTotalPages] = useState(0);

  const getTotalPages = (totalCount: number, limit: number) => {
    return Math.ceil(totalCount / limit);
  };

  useEffect(() => {
    (async () => {
      setProducts(
        await getProducts(config.productUrl, props.categoryId, null, null, null)
      );
    })();

    setCurrentPage(1);
    setSortType("asc");
  }, [props.categoryId]);

  useEffect(() => {
    setTotalPages(getTotalPages(products.length, limit));
  }, [products]);

  useEffect(() => {
    (async () => {
      setProductsOnPage(
        await getProducts(
          config.productUrl,
          props.categoryId,
          limit,
          currentPage,
          sortType
        )
      );
    })();
  }, [totalPages, currentPage, sortType]);

  return (
    <>
      <div className="container-sm">
        <div className="d-flex justify-content-start ms-5 mt-2 mb-2">
          <select
            value={sortType}
            onChange={(event) => setSortType(event.target.value)}
          >
            <option disabled value="">
              Sort by title
            </option>
            <option value="asc">Ascending</option>
            <option value="desc">Descending</option>
          </select>
        </div>

        <div className="row row-cols-1 row-cols-md-3 g-4 mb-5">
          {productsOnPage.map((product) => (
            <CardProductComponent
              key={product.id}
              id={product.id}
              title={product.title}
              img={product.img}
              price={product.price}
              weight={product.weight}
              consist={product.consist}
              categoryId={product.categoryId}
            />
          ))}
        </div>
      </div>
      <PaginationComponent
        totalPages={totalPages}
        currentPage={currentPage}
        setCurrentPage={setCurrentPage}
        limit={limit}
      />
    </>
  );
};

export default ProductComponent;
