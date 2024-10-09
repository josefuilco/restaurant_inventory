<script setup lang="ts">
import { useUserStore } from '@/module/common/infrastructure/store/UserStore';
import BaseButton from '@/module/common/presentation/components/button/BaseButton.vue';
import SecurityModal from '@/module/common/presentation/components/modal/SecurityModal.vue';
import { DeleteProduct } from '@/module/inventory/application/use-case/DeleteProduct';
import type { Product } from '@/module/inventory/domain/entity/Product';
import { ApiProductRepository } from '@/module/inventory/infrastructure/repository/ApiProductRepository';
import { PiniaProductStoreService } from '@/module/inventory/infrastructure/service/PiniaProductStoreService';
import { WebNotificationService } from '@/module/inventory/infrastructure/service/WebNotificationService';
import { useProductStore } from '@/module/inventory/infrastructure/store/ProductStore';
import { ref, watch } from 'vue';

interface Props {
	product: Product;
	isDisable: boolean;
}

const props = defineProps<Props>();
const productStore = useProductStore();
const userStore = useUserStore();
const isActive = ref(false);

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

async function handleAccept() {
	await DeleteProduct(props.product.id, userStore.getInfo.id, PiniaProductStoreService, ApiProductRepository, WebNotificationService);
}
</script>

<template>
	<BaseButton type="button" @click="handleModal" :is-disable="isDisable">
		Eliminar
	</BaseButton>
	<SecurityModal :is-active="isActive" @come-back="handleComeBack" @accept="handleAccept" />
</template>

<style scoped>
button {
	background-color: var(--red-color);

	&:hover {
		background-color: var(--bold-red-color);
	}
}
</style>