import type { Report } from "../model/Report";

export interface IReportRepository {
	findHistory(productId: number, from: string, to: string): Promise<Report[]>;
}