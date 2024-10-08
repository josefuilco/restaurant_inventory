import { defineStore } from "pinia";
import type { Report } from "../../domain/model/Report";

interface State {
	reports: Report[] | undefined;
}

export const useReportStore = defineStore('report', {
	state: (): State => ({
		reports: undefined
	}),
	getters: {
		getReports(state) {
			return state.reports;
		}
	},
	actions: {
		setReports(reports: Report[]) {
			this.reports = reports;
		}
	}
});