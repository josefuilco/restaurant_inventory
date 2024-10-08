import type { UserInfo } from "@/module/common/domain/model/UserInfo";
import type { User } from "../model/User";

export interface IUserRepository {
	getAccounts(): Promise<UserInfo[]>;
	addAccount(user: User): Promise<void>;
	changePasswordAccount(id: number, oldPassword: string, newPassword: string): Promise<void>;
	removeAccount(id: number): Promise<void>;
}