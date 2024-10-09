import type { Product } from "../entity/Product";

export interface IProductStoreService {
	saveProducts(products: Product[]): void;
}