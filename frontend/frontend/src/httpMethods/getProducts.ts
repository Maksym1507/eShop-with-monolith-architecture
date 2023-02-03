import ProductModel from "../models/ProductModel";

const getProducts = async (
  url: string,
  categoryId: number,
  limit: number | null,
  page: number | null,
  sort: string | null
): Promise<ProductModel[]> => {

  let result;

  if (page !== 0 && limit !== 0 && sort !== null) {
    result = await fetch(
      `${url}?categoryId=${categoryId}&page=${page}&limit=${limit}&order=${sort}`
    );
  } else {
    result = await fetch(`${url}?categoryId=${categoryId}`);
  }
  
  return await result.json();
};

export default getProducts;
