import { DataProvider } from "@/data/DataProvider";
import type { IAuthRepository } from "../../domain/repository/IAuthRepository";

interface Response {
	message: string;
	data: any;
}

const dataProvider = DataProvider.getInstance();

export const ApiAuthRepository: IAuthRepository = {
	async signInAsync(username, password) {
		const res: Response = await dataProvider.post('Auth/sign-in', {
			username,
			password
		});
		console.info(`Info Backend: ${res.message}`)
		return res.data;
	},
}