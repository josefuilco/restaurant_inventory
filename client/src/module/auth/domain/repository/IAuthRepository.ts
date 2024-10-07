export interface IAuthRepository {
	signInAsync(username: string, password: string): Promise<string>;
}