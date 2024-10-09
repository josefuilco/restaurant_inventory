<script setup lang="ts">
import { ref, watch } from 'vue';
import DeleteProductButton from '../button/DeleteProductButton.vue';
import UpdateProductButton from '../button/UpdateProductButton.vue';
import CreateProductButton from '../button/CreateProductButton.vue';
import type { Product } from '@/module/inventory/domain/entity/Product';
import { useProductStore } from '@/module/inventory/infrastructure/store/ProductStore';
import { cloneObject } from '@/lib/clone-object/cloneObject';

interface Props {
	product: Product;
}

const props = defineProps<Props>();
const productStore = useProductStore();
const isDisable = ref(true);

watch(
	() => props.product.id,
	(id) => {
		if (id === 0) return;
		isDisable.value = false;
	},
	{ immediate: true }
)

watch(
	() => productStore.getProducts,
	() => {
		isDisable.value = true;
	},
	{ immediate: true }
)
</script>

<template>
	<div id="provider-topbar">
		<CreateProductButton />
		<UpdateProductButton :product="cloneObject(product)" :is-disable="isDisable"/>
		<DeleteProductButton :product="cloneObject(product)" :is-disable="isDisable"/>
	</div>
</template>

<style scoped>
#provider-topbar {
	display: flex;
	flex-direction: row;
	justify-content: flex-end;
	height: auto;
	width: 100%;
	gap: 10px;
}
</style>