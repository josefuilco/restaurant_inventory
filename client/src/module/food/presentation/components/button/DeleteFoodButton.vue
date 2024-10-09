<script setup lang="ts">
import BaseButton from '@/module/common/presentation/components/button/BaseButton.vue';
import SecurityModal from '@/module/common/presentation/components/modal/SecurityModal.vue';
import { DeleteFood } from '@/module/food/application/use-case/DeleteFood';
import { ApiFoodRepository } from '@/module/food/infrastructure/repository/ApiFoodRepository';
import { PiniaFoodStoreService } from '@/module/food/infrastructure/service/PiniaFoodStoreService';
import { useFoodStore } from '@/module/food/infrastructure/store/FoodStore';
import { ref, watch } from 'vue';

interface Props {
	foodId: number;
	isDisable: boolean;
}

const props = defineProps<Props>();
const foodStore = useFoodStore();
const isActive = ref(false);

watch(
	() => foodStore.foods,
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
	await DeleteFood(props.foodId, PiniaFoodStoreService, ApiFoodRepository);
}
</script>

<template>
	<BaseButton type="button" @click="handleModal" :is-disable="isDisable">Borrar</BaseButton>
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