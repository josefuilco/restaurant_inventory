import type { ProductCreationModel } from "../../domain/model/ProductCreationModel";
import type { IProductRepository } from "../../domain/repository/IProductRepository";
import type { INotificationService } from "../../domain/service/INotificationService";
import type { IProductStoreService } from "../../domain/service/IProductStoreService";
import { GetProducts } from "./GetProducts";

export const CreateProduct = async (product: ProductCreationModel, storeService: IProductStoreService, repository: IProductRepository, notificationService: INotificationService) => {
	await repository.AddProduct(product);
	await GetProducts(storeService, repository, notificationService)
}