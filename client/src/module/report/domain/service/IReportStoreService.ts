import type { Report } from "../model/Report";

export interface IReportStoreService {
	saveReports(reports: Report[]): void;
}