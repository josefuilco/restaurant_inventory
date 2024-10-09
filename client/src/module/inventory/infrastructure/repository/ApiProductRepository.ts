import { DataProvider } from "@/data/DataProvider";
import type { IProductRepository } from "../../domain/repository/IProductRepository";
import { ensureProduct, type Product } from "../../domain/entity/Product";

const dataProvider = DataProvider.getInstance();
export const ApiProductRepository: IProductRepository = {
	async AddProduct(product) {
		const { message } = await dataProvider.post('Product/create', {
			"name": product.name,
			"price": product.price,
			"quantity": product.quantity,
			"minimal_quantity": product.minimal_quantity,
			"provider_id": product.provider_id,
			"category_id": product.category_id,
			"user_id": product.user_id
		});
		console.info(message);
	},
	async GetProducts() {
		const products: Product[] = [];
		const { data } = await dataProvider.get('Product/list');
		data.forEach((product: any) => {
			products.push(ensureProduct(
				Number(product.id),
				String(product.name),
				Number(product.price),
				Number(product.quantity),
				Number(product.minimal_quantity),
				String(product.provider_name),
				String(product.category_name),
				String(product.measure_name)
			))
		});
		return products;
	},
	async UpdateProduct(productId, product) {
		const { message } = await dataProvider.put('Product/update', {
			"id": productId,
			"name": product.name,
			"price": product.price,
			"quantity": product.quantity,
			"minimal_quantity": product.minimal_quantity,
			"provider_id": product.provider_id,
			"category_id": product.category_id,
			"user_id": product.user_id
		});
		console.info(message);
	},
	async RemoveProduct(productId, userId) {
		const { message } = await dataProvider.put('Product/remove', {
			"product_id": productId,
			"user_id": userId
		});
		console.info(message);
	},
	async UpdateStock(productId, quantity, userId) {
		const { message } = await dataProvider.put('Product/update-stock', {
			"id": productId,
			"quantity": quantity,
			"user_id": userId
		});
		console.info(message);
	},
}