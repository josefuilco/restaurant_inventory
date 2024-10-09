import type { Provider } from "../entity/Provider";

export interface IProviderRepository {
	GetProviders(): Promise<Provider[]>;
	AddProvider(provider: Provider): Promise<void>;
	UpdateProvider(provider: Provider): Promise<void>;
	RemoveProvider(providerId: number): Promise<void>;
}