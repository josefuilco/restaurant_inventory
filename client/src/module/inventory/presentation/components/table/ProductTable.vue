<script setup lang="ts">
import { cloneObject } from '@/lib/clone-object/cloneObject';
import { GetProducts } from '@/module/inventory/application/use-case/GetProducts';
import { Categories } from '@/module/inventory/domain/constant/Categories';
import { ensureProduct, type Product } from '@/module/inventory/domain/entity/Product';
import { ApiProductRepository } from '@/module/inventory/infrastructure/repository/ApiProductRepository';
import { PiniaProductStoreService } from '@/module/inventory/infrastructure/service/PiniaProductStoreService';
import { useProductStore } from '@/module/inventory/infrastructure/store/ProductStore';
import { defineAsyncComponent, ref, watch } from 'vue';
import ProductTopBar from '../topbar/ProductTopBar.vue';
import { WebNotificationService } from '@/module/inventory/infrastructure/service/WebNotificationService';

const DataTable = defineAsyncComponent(() => import('@/module/common/presentation/components/table/DataTable.vue'));

const productStore = useProductStore();
const COLUMNS = [
	'N°',
	'Nombre de Producto',
	'Precio',
	'Cantidad Actual',
	'Cantidad Minima',
	'Nombre del Proveedor',
	'Nombre de la Categoria',
	'Unidad de Medida'
];

const rows = ref<Product[]>([]);
const product = ref<Product>(ensureProduct(
	0,
	'',
	0,
	0,
	0,
	'',
	'',
	''
));

watch(
	() => productStore.getProducts,
	(products) => {
		if (!products) return;
		rows.value = cloneObject(products);
	},
	{ immediate: true }
)

watch(
	() => productStore.getFilter,
	(filter) => {
		if (!productStore.getProducts) return;
		if (filter == 0) {
			rows.value = productStore.getProducts;
			return;
		}
		const newRows = cloneObject(productStore.getProducts!.filter(f => Categories.indexOf(f.category_name) == filter));
		rows.value = newRows;
	},
	{ immediate: true }
)

function handleCheck(obj: object) {
	product.value = (obj as Product);
}

async function setupProducts() {
	await GetProducts(PiniaProductStoreService, ApiProductRepository, WebNotificationService);
}

setupProducts();
</script>

<template>
	<div id="product-table">
		<ProductTopBar :product="cloneObject(product)" />
		<DataTable
		:columns="COLUMNS"
		:rows="rows"
		@check="handleCheck" 
		/>
	</div>
</template>

<style scoped>
#product-table {
	display: flex;
	flex-direction: column;
	gap: 10px;
	justify-content: center;
	width: 80%;
}
</style>
