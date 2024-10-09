import { DataProvider } from "@/data/DataProvider";
import type { IProviderRepository } from "../../domain/repository/IProviderRepository";
import { ensureProvider, type Provider } from "../../domain/entity/Provider";

const dataProvider = DataProvider.getInstance();
export const ApiProviderRepository: IProviderRepository = {
	async AddProvider(provider) {
		const { message } = await dataProvider.post('Provider/create', {
			"name": provider.name,
  			"cellphone": provider.cellphone
		});
		console.info(message);
	},
	async GetProviders() {
		const providers: Provider[] = [];
		const { data } = await dataProvider.get('Provider/list');
		data.forEach((provider: any) => {
			providers.push(ensureProvider(
				Number(provider.id),
				String(provider.name),
				String(provider.cellphone)
			))
		});
		return providers;
	},
	async UpdateProvider(provider) {
		const { message } = await dataProvider.put('Provider/update', {
			"id": provider.id,
  			"cellphone": provider.cellphone
		});
		console.info(message);
	},
	async RemoveProvider(providerId) {
		const { message } = await dataProvider.put(`Provider/remove/${providerId}`);
		console.info(message);
	},
}