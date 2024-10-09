<script setup lang="ts">
import BaseButton from '@/module/common/presentation/components/button/BaseButton.vue';
import DatePicker from '../date-picker/DatePicker.vue';
import OptionField from '@/module/common/presentation/components/field/OptionField.vue';
import { extractForm } from '@/lib/extract-form/extractForm';
import { GetReports } from '@/module/report/application/use-case/GetReports';
import { PiniaReportStoreService } from '@/module/report/infrastructure/service/PiniaReportStoreService';
import { ApiReportRepository } from '@/module/report/infrastructure/repository/ApiReportRepository';
import { ref, watch } from 'vue';
import { useProductStore } from '@/module/inventory/infrastructure/store/ProductStore';
import { GetProducts } from '@/module/inventory/application/use-case/GetProducts';
import { PiniaProductStoreService } from '@/module/inventory/infrastructure/service/PiniaProductStoreService';
import { ApiProductRepository } from '@/module/inventory/infrastructure/repository/ApiProductRepository';
import { WebNotificationService } from '@/module/inventory/infrastructure/service/WebNotificationService';

const productStore = useProductStore();
const productsSelected = ref<Select[]>([
	{
		id: 0,
		value: "Todos"
	}
]);

watch(
	() => productStore.getProducts,
	async (products) => {
		if (!products) {
			await GetProducts(PiniaProductStoreService, ApiProductRepository, WebNotificationService);
			return;
		}
		productsSelected.value = [
			{
				id: 0,
				value: 'Todos'
			}
		];
		products.forEach(product => {
			console.log(product);
			productsSelected.value.push(
				{
					id: product.id,
					value: product.name
				}
			);
		});
	},
	{ immediate: true }
);

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
			:values="productsSelected"
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