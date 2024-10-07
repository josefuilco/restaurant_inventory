import type { UserInfo } from "@/module/common/domain/model/UserInfo";

export interface IUserRepository {
	getAccounts(): Promise<UserInfo>;
}