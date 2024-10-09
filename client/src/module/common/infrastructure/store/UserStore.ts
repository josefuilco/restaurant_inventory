import { defineStore } from "pinia";
import type { UserInfo } from "../../domain/model/UserInfo";

interface State {
	currentUser: UserInfo | undefined;
	accounts: UserInfo[] | undefined;
}

export const useUserStore = defineStore("user", {
	state: (): State => ({
		currentUser: undefined,
		accounts: undefined
	}),
	getters: {
		getInfo: (state): UserInfo => {
			return state.currentUser!;
		},
		getAccounts: (state): UserInfo[] => {
			return state.accounts!;
		}
	},
	actions: {
		setInfo(userInfo: UserInfo): void {
			this.currentUser = userInfo;
		},
		setAccounts(usersInfo: UserInfo[]): void {
			this.accounts = usersInfo;
		}
	}
});