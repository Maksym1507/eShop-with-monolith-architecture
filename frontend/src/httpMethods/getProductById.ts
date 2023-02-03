import Product from "../models/ProductModel";

const getProductById = async (url: string, id: number): Promise<Product> => {
  const result = await fetch(`${url}/${id}`);

  return await result.json();
};

export default getProductById;
