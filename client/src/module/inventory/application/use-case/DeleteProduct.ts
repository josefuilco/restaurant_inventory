import type { IProductRepository } from "../../domain/repository/IProductRepository";
import type { INotificationService } from "../../domain/service/INotificationService";
import type { IProductStoreService } from "../../domain/service/IProductStoreService";
import { GetProducts } from "./GetProducts";

export const DeleteProduct = async (productId: number, userId: number, storeService: IProductStoreService, repository: IProductRepository, notificationService: INotificationService) => {
	await repository.RemoveProduct(productId, userId);
	await GetProducts(storeService, repository, notificationService)
}