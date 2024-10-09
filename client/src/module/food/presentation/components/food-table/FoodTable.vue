<script setup lang="ts">
import ButtonTopBar from '../topbar/ButtonTopBar.vue';
import { defineAsyncComponent, ref, watch } from 'vue';
import { ensureFoodInformation, type FoodInformation } from '@/module/food/domain/model/FoodInformation';
import { useFoodStore } from '@/module/food/infrastructure/store/FoodStore';
import { GetFoods } from '@/module/food/application/use-case/GetFoods';
import { PiniaFoodStoreService } from '@/module/food/infrastructure/service/PiniaFoodStoreService';
import { ApiFoodRepository } from '@/module/food/infrastructure/repository/ApiFoodRepository';
import { cloneObject } from '@/lib/clone-object/cloneObject';
import { FoodType } from '@/module/food/domain/constant/FoodType';

const DataTable = defineAsyncComponent(() => import('@/module/common/presentation/components/table/DataTable.vue'));

const foodStore = useFoodStore();
const COLUMNS = [
	'N°',
	'Nombre de Comida',
	'Precio',
	'Cantidad Maxima de Producción',
	'Tipo'
];

const rows = ref<FoodInformation[]>([]);
const food = ref<FoodInformation>(ensureFoodInformation(
	0,
	'',
	0,
	0,
	''
));

watch(
	() => foodStore.foods,
	(foods) => {
		if (!foods) return;
		rows.value = cloneObject(foods);
	},
	{ immediate: true }
)

watch(
	() => foodStore.filter,
	(filter) => {
		if (!foodStore.getFoods) return;
		if (filter == 0) {
			rows.value = foodStore.getFoods;
			return;
		}
		const newRows = cloneObject(foodStore.getFoods!.filter(f => FoodType.indexOf(f.type) == filter));
		rows.value = newRows;
	},
	{ immediate: true }
)

function handleCheck(obj: object) {
	food.value = (obj as FoodInformation);
}

async function setupFoods() {
	await GetFoods(PiniaFoodStoreService, ApiFoodRepository);
}

setupFoods();
</script>

<template>
	<div id="food-table">
		<ButtonTopBar :food="food" />
		<DataTable
		:columns="COLUMNS"
		:rows="rows"
		@check="handleCheck" 
		/>
	</div>
</template>

<style scoped>
#food-table {
	display: flex;
	flex-direction: column;
	justify-content: center;
	height: auto;
	width: 80%;
	gap: 10px;
}
</style>