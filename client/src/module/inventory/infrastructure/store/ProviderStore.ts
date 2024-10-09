import { defineStore } from "pinia";
import type { Provider } from "../../domain/entity/Provider";

interface State {
	providers: Provider[] | undefined;
}

export const useProviderStore = defineStore('provider', {
	state: (): State => ({
		providers: undefined
	}),
	getters: {
		getProviders(state) {
			return state.providers;
		}
	},
	actions: {
		setProviders(providers: Provider[]) {
			this.providers = providers;
		}
	}
})