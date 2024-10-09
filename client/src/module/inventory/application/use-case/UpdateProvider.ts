import type { Provider } from "../../domain/entity/Provider";
import type { IProviderRepository } from "../../domain/repository/IProviderRepository";
import type { IProviderStoreService } from "../../domain/service/IProviderStoreService";
import { GetProviders } from "./GetProviders";

export const UpdateProvider = async (provider: Provider, storeService: IProviderStoreService, repository: IProviderRepository) => {
	await repository.UpdateProvider(provider);
	await GetProviders(storeService, repository);
}