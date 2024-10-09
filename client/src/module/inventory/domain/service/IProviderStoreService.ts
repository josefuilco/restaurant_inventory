import type { Provider } from "../entity/Provider";

export interface IProviderStoreService {
	saveProviders(providers: Provider[]): void;
}