import type { IProviderRepository } from "../../domain/repository/IProviderRepository";
import type { IProviderStoreService } from "../../domain/service/IProviderStoreService";
import { GetProviders } from "./GetProviders";

export const DeleteProvider = async (providerId: number, storeService: IProviderStoreService, repository: IProviderRepository) => {
	await repository.RemoveProvider(providerId);
	await GetProviders(storeService, repository);
}