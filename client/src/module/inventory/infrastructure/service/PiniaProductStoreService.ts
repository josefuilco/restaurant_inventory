import type { IProductStoreService } from "../../domain/service/IProductStoreService";
import { useProductStore } from "../store/ProductStore";

const productStore = useProductStore();
export const PiniaProductStoreService: IProductStoreService = {
	saveProducts(products) {
		productStore.setProducts(products);
	},
}