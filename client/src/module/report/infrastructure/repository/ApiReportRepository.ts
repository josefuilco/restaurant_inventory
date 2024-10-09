import { DataProvider } from "@/data/DataProvider";
import type { IReportRepository } from "../../domain/repository/IReportRepository";
import { ensureReport, type Report } from "../../domain/model/Report";
import { simpleDateFormat } from "@/lib/date-format/simpleDateFormat";

const dataProvider = DataProvider.getInstance();
export const ApiReportRepository: IReportRepository = {
	async findHistory(productId, from, to) {
		const reports: Report[] = [];
		const { data }: { data: any[] } = await dataProvider.post('History', {
			"product_id": productId,
			"from": from,
			"to": to
		})
		console.log(data)
		data.forEach((history: any) => {
			reports.push(ensureReport(
				Number(history["id"]),
				Number(history["current_amount"]),
				Number(history["latest_amount"]),
				Number(history["total_amount_diference"]),
				simpleDateFormat(String(history["history_date"])),
				String(history["product_name"]),
				String(history["user_name"]),
				String(history["operation_name"]),
				String(history["description"])
			));
		});
		return reports;
	},
}