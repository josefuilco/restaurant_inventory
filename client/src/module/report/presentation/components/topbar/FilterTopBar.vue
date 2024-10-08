<script setup lang="ts">
import BaseButton from '@/module/common/presentation/components/button/BaseButton.vue';
import DatePicker from '../date-picker/DatePicker.vue';
import OptionField from '@/module/common/presentation/components/field/OptionField.vue';
import { extractForm } from '@/lib/extract-form/extractForm';
import { GetReports } from '@/module/report/application/use-case/GetReports';
import { PiniaReportStoreService } from '@/module/report/infrastructure/service/PiniaReportStoreService';
import { ApiReportRepository } from '@/module/report/infrastructure/repository/ApiReportRepository';


const products: Select[] = [
	{
		id: 0,
		value: 'Todos'
	},
	{
		id: 1,
		value: 'Leche'
	}
]

async function handleSubmit(event: Event) {
	event.preventDefault();
	const form = extractForm(event);
	await GetReports(
		Number(form["producto"]),
		String(form["from"]),
		String(form["to"]),
		PiniaReportStoreService,
		ApiReportRepository
	)
}
</script>

<template>
	<form class="filter-top-bar" @submit="handleSubmit">
		<OptionField
			name="producto"
			:values="products"
		>
			Producto:
		</OptionField>
		<DatePicker name="from">
			Desde:
		</DatePicker>
		<DatePicker name="to">
			Hasta:
		</DatePicker>
		<BaseButton type="submit">
			Buscar
		</BaseButton>
	</form>
</template>

<style scoped>
.filter-top-bar {
	display: flex;
	gap: 10px;
	margin-bottom: 20px;
	flex-wrap: wrap;
}

.filter-top-bar > button[type=submit] {
	height: 40px;
	align-self: flex-end;
}
</style>