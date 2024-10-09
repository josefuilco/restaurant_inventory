<script setup lang="ts">
import AsideFilter from '@/module/common/presentation/components/filter/AsideFilter.vue';
import { FoodType } from '../../domain/constant/FoodType';
import FoodTable from '../components/food-table/FoodTable.vue';
import { useFoodStore } from '../../infrastructure/store/FoodStore';

const foodStore = useFoodStore();

function getFilter(id: number) {
	foodStore.setFilter(id);
}
</script>

<template>
	<main id="food-view">
		<AsideFilter name-filter="Tipo de Comida" :value-filter="FoodType" @click="getFilter" />
		<FoodTable />
	</main>
</template>

<style lang="css">
#food-view {
	display: grid;
	grid-template-columns: 25% 75%;
	align-content: center;
	justify-items: center;
}

#food-view > aside {
	height: 100dvh;
	width: 100%;
}
</style>