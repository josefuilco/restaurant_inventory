import type { IReportRepository } from "../../domain/repository/IReportRepository";
import type { IReportStoreService } from "../../domain/service/IReportStoreService";

export const GetReports = async (productId: number, from: string, to: string, storeService: IReportStoreService, repository: IReportRepository) => {
	const reports = await repository.findHistory(productId, from, to);
	storeService.saveReports(reports);
}