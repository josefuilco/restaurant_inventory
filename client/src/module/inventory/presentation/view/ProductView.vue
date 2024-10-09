<script setup lang="ts">
import AsideFilter from '@/module/common/presentation/components/filter/AsideFilter.vue';
import ProductTable from '../components/table/ProductTable.vue';
import { Categories } from '../../domain/constant/Categories';
import { useProductStore } from '../../infrastructure/store/ProductStore';

const productStore = useProductStore();

function getFilter(id: number) {
	productStore.setFilter(id);
}
</script>

<template>
	<main id="product-view">
		<AsideFilter name-filter="categorias" :value-filter="Categories" @click="getFilter"/>
		<ProductTable />
	</main>
</template>

<style lang="css">
#product-view {
	display: grid;
	grid-template-columns: 25% 75%;
	align-content: center;
	justify-items: center;
}

#product-view > aside {
	height: 100dvh;
	width: 100%;
}
</style>