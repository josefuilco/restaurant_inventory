<script setup lang="ts">
import BaseButton from '@/module/common/presentation/components/button/BaseButton.vue';
import CreateProductModal from '../modal/CreateProductModal.vue';
import { ref, watch } from 'vue';
import { useProductStore } from '@/module/inventory/infrastructure/store/ProductStore';
import { extractForm } from '@/lib/extract-form/extractForm';
import { CreateProduct } from '@/module/inventory/application/use-case/CreateProduct';
import { ensureProductCreationModel } from '@/module/inventory/domain/model/ProductCreationModel';
import { PiniaProductStoreService } from '@/module/inventory/infrastructure/service/PiniaProductStoreService';
import { ApiProductRepository } from '@/module/inventory/infrastructure/repository/ApiProductRepository';
import { useUserStore } from '@/module/common/infrastructure/store/UserStore';
import { WebNotificationService } from '@/module/inventory/infrastructure/service/WebNotificationService';

const isActive = ref(false);
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
}

async function handleSubmit(event: Event) {
	event.preventDefault();
	const form = extractForm(event);
	await CreateProduct(ensureProductCreationModel(
		String(form['name']),
		Number(form['price']),
		Number(form['quantity']),
		Number(form['minimal_quantity']),
		Number(form['proveedor']),
		Number(form['categoria']),
		userStore.currentUser!.id
	), PiniaProductStoreService, ApiProductRepository, WebNotificationService);
}
</script>

<template>
	<BaseButton type="button" @click="handleModal">
		Registrar
	</BaseButton>
	<CreateProductModal :is-active="isActive" @come-back="handleComeBack" @submit="handleSubmit" />
</template>