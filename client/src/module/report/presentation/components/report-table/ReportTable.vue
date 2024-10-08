<script setup lang="ts">
import FilterTopBar from '../topbar/FilterTopBar.vue';
import { defineAsyncComponent, ref, watch } from 'vue';
import { useReportStore } from '@/module/report/infrastructure/store/ReportStore';
import type { Report } from '@/module/report/domain/model/Report';
import { GetReports } from '@/module/report/application/use-case/GetReports';
import { PiniaReportStoreService } from '@/module/report/infrastructure/service/PiniaReportStoreService';
import { ApiReportRepository } from '@/module/report/infrastructure/repository/ApiReportRepository';
import { cloneObject } from '@/lib/clone-object/cloneObject';
const DataTable = defineAsyncComponent(() => import('@/module/common/presentation/components/table/DataTable.vue'));

const reportStore = useReportStore();
const rows = ref<Report[]>([]);
const COLUMNS = [
	'N°',
	'Cantidad Actual',
	'Cantidad Anterior',
	'Diferencia de Cantidades',
	'Fecha de Historial',
	'Nombre del Producto',
	'Usuario Ejecutor',
	'Operación',
	'Descripción'
];

watch(
	() => reportStore.getReports,
	(reports) => {
		if (!reports) return;
		rows.value = cloneObject(reports);
	}
)

async function setupTable() {
	await GetReports(0, '2024-01-08', '2024-10-08', PiniaReportStoreService, ApiReportRepository);
}

await setupTable();
</script>

<template>
	<div id="report-table">
		<FilterTopBar />
		<DataTable
		:columns="COLUMNS"
		:rows="rows"
		@check="() => {}" 
		/>
	</div>
</template>

<style scoped>
#report-table {
	width: 70%;
}
</style>
