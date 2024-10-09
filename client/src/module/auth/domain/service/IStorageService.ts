export interface IStorageService {
	save(token: string): void;
	obtain(item: string): string | null;
}