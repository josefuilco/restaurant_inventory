import type { Product } from "../entity/Product";
import type { ProductCreationModel } from "../model/ProductCreationModel";

export interface IProductRepository {
	GetProducts(): Promise<Product[]>;
	AddProduct(product: ProductCreationModel): Promise<void>;
	UpdateProduct(productId: number, product: ProductCreationModel): Promise<void>;
	UpdateStock(productId: number, quantity: number, userId: number): Promise<void>;
	RemoveProduct(productId: number, userId: number): Promise<void>;
}