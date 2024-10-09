import type { Provider } from "../../domain/entity/Provider";
import type { IProviderRepository } from "../../domain/repository/IProviderRepository";
import type { IProviderStoreService } from "../../domain/service/IProviderStoreService";
import { GetProviders } from "./GetProviders";

export const CreateProvider = async (provider: Provider, storeService: IProviderStoreService, repository: IProviderRepository) => {
	await repository.AddProvider(provider);
	await GetProviders(storeService, repository);
}