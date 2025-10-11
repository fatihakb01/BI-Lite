import api from "./axios";
import type { Product } from "../features/products/productTypes";

export const getProducts = async (): Promise<Product[]> => {
  const res = await api.get("/product");
  console.log(res.data.isActive)
  return res.data;
};

export const createProduct = async (data: Product) => {
  const res = await api.post("/product", data);
  return res.data;
};
