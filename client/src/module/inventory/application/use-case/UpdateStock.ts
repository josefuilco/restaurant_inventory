import type { IProductRepository } from "../../domain/repository/IProductRepository";
import type { INotificationService } from "../../domain/service/INotificationService";
import type { IProductStoreService } from "../../domain/service/IProductStoreService";
import { GetProducts } from "./GetProducts";

export const UpdateStock = async (productId: number, quantity: number, userId: number, storeService: IProductStoreService, repository: IProductRepository, notificationService: INotificationService) => {
	await repository.UpdateStock(productId, quantity, userId);
	await GetProducts(storeService, repository, notificationService);
}