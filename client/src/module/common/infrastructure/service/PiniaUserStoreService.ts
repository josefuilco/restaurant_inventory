import type { IUserStoreService } from "../../domain/service/IUserStoreService";
import { useUserStore } from "../store/UserStore";

const userStore = useUserStore();

export const PiniaUserStoreService: IUserStoreService = {
	saveUserInfo(userInfo) {
		userStore.setInfo(userInfo);
	},
	getCurrentUserRole() {
		return userStore.getInfo.role;
	},
	saveAccounts(accounts) {
		userStore.setAccounts(accounts);
	},
	getAccounts() {
		return userStore.getAccounts
	},
}