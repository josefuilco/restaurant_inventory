import { DataProvider } from "@/data/DataProvider";
import type { IUserInfoRepository } from "../../domain/repository/IUserInfoRepository";

const dataProvider = DataProvider.getInstance();

export const ApiUserInfoRepository: IUserInfoRepository = {
	async findByToken(token) {
		const { data } = await dataProvider.get(`User/${token}`);
		return {
			id: data["id"],
			name: data["name"],
			email: data["email"],
			creationDate: data["creation_date"],
			role: data["role"]
		}
	},
}