import type { UserInfo } from "../model/UserInfo";

export interface IUserStoreService {
	saveUserInfo(userInfo: UserInfo): void;
	getCurrentUserRole(): number;
}