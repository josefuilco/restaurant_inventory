<script setup lang="ts">
import BaseButton from '@/module/common/presentation/components/button/BaseButton.vue';
import ModifyProductModal from '../modal/ModifyProductModal.vue';
import { PiniaProductStoreService } from '@/module/inventory/infrastructure/service/PiniaProductStoreService';
import { ApiProductRepository } from '@/module/inventory/infrastructure/repository/ApiProductRepository';
import { ensureProductCreationModel } from '@/module/inventory/domain/model/ProductCreationModel';
import { UpdateProduct } from '@/module/inventory/application/use-case/UpdateProduct';
import { useProductStore } from '@/module/inventory/infrastructure/store/ProductStore';
import { useUserStore } from '@/module/common/infrastructure/store/UserStore';
import { ref, watch } from 'vue';
import { extractForm } from '@/lib/extract-form/extractForm';
import type { Product } from '@/module/inventory/domain/entity/Product';
import { UpdateStock } from '@/module/inventory/application/use-case/UpdateStock';
import { WebNotificationService } from '@/module/inventory/infrastructure/service/WebNotificationService';

interface Props {
	product: Product;
	isDisable: boolean;
}

const props = defineProps<Props>();
const isActive = ref(false);
const onlyStock = ref(false);
const productStore = useProductStore();
const userStore = useUserStore();

watch(
	() => productStore.getProducts,
	() => {
		isActive.value = false;
	},
	{ immediate: true }
)

function handleModal() {
	isActive.value = true;
}

function handleComeBack(state: boolean) {
	isActive.value = state;
	onlyStock.value = false;
}

async function handleSubmit(event: Event) {
	event.preventDefault();
	const form = extractForm(event);
	if (!onlyStock.value) {
		await UpdateProduct(
			props.product.id,
			ensureProductCreationModel(
				String(form['name']),
				Number(form['price']),
				Number(form['quantity']),
				Number(form['minimal_quantity']),
				Number(form['proveedor']),
				Number(form['categoria']),
				userStore.currentUser!.id
			),
			PiniaProductStoreService,
			ApiProductRepository,
			WebNotificationService
		);
		return;
	}
	await UpdateStock(
		props.product.id,
		Number(form['quantity']),
		userStore.currentUser!.id,
		PiniaProductStoreService,
		ApiProductRepository,
		WebNotificationService
	);
}

function handleCheck() {
	onlyStock.value = !onlyStock.value
}
</script>

<template>
	<BaseButton type="button" @click="handleModal" :is-disable="isDisable">
		Modificar
	</BaseButton>
	<ModifyProductModal
		:is-active="isActive"
		:product="product"
		:only-stock="onlyStock"
		@come-back="handleComeBack"
		@submit="handleSubmit"
		@check="handleCheck"
	/>
</template>

<style scoped>
button {
	background-color: rgb(233, 163, 0);

	&:hover {
		background-color: rgb(192, 134, 0);
	}
}
</style>