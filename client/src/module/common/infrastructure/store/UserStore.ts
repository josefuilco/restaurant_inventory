import { defineStore } from "pinia";
import type { UserInfo } from "../../domain/model/UserInfo";

interface State {
	currentUser: UserInfo | undefined;
}

export const useUserStore = defineStore("user", {
	state: (): State => ({
		currentUser: undefined
	}),
	getters: {
		getInfo: (state): UserInfo => {
			return state.currentUser!;
		}
	},
	actions: {
		setInfo(userInfo: UserInfo): void {
			this.currentUser = userInfo;
		}
	}
});