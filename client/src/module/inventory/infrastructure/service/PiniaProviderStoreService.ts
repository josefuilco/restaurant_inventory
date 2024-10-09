import type { IProviderStoreService } from "../../domain/service/IProviderStoreService";
import { useProviderStore } from "../store/ProviderStore";

const providerStore = useProviderStore();
export const PiniaProviderStoreService: IProviderStoreService = {
	saveProviders(providers) {
		providerStore.setProviders(providers);
	},
}