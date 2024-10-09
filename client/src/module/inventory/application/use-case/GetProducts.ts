import type { IProductRepository } from "../../domain/repository/IProductRepository";
import type { INotificationService } from "../../domain/service/INotificationService";
import type { IProductStoreService } from "../../domain/service/IProductStoreService";

export const GetProducts = async (storeService: IProductStoreService, repository: IProductRepository, notificationService: INotificationService) => {
	const products = await repository.GetProducts();
	products.forEach(async product => {
		if (!product) return;
		if (product.quantity <= product.minimal_quantity) {
			await notificationService.notify(
				`Nos estamos quedando sin ${product.name}`,
				`Tenemos que comprar mas de este producto.\nLa diferencia actual es de ${product.minimal_quantity - product.quantity}.`
			);
		}
	});
	storeService.saveProducts(products);
}