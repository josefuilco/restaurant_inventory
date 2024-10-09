import type { IProviderRepository } from "../../domain/repository/IProviderRepository";
import type { IProviderStoreService } from "../../domain/service/IProviderStoreService";

export const GetProviders = async (storeService: IProviderStoreService, repository: IProviderRepository) => {
	const providers = await repository.GetProviders();
	storeService.saveProviders(providers);
}