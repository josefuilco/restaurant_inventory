import type { IReportStoreService } from "../../domain/service/IReportStoreService";
import { useReportStore } from "../store/ReportStore";

const reportStore = useReportStore();

export const PiniaReportStoreService: IReportStoreService = {
	saveReports(reports) {
		reportStore.setReports(reports);
	},
}