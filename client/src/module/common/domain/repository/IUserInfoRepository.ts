import type { UserInfo } from "../model/UserInfo";

export interface IUserInfoRepository {
	findByToken(token: string): Promise<UserInfo>;
}