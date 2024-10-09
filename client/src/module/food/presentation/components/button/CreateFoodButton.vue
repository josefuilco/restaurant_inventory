<script setup lang="ts">
import BaseButton from '@/module/common/presentation/components/button/BaseButton.vue';
import FoodModal from '../modal/FoodModal.vue';
import { PiniaFoodStoreService } from '@/module/food/infrastructure/service/PiniaFoodStoreService';
import { ApiFoodRepository } from '@/module/food/infrastructure/repository/ApiFoodRepository';
import { CreateFood } from '@/module/food/application/use-case/CreateFood';
import { ensureFoodCreationModel } from '@/module/food/domain/model/FoodCreationModel';
import { extractForm } from '@/lib/extract-form/extractForm';
import { ref, watch } from 'vue';
import { useFoodStore } from '@/module/food/infrastructure/store/FoodStore';

const isActive = ref(false);
const foodStore = useFoodStore();

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

async function handleSubmit(event: Event) {
	event.preventDefault()
	const form = extractForm(event);
	await CreateFood(
		ensureFoodCreationModel(
			String(form["name"]),
			Number(form["price"]),
			Number(form["amount"]),
			Number(form["type"])
		),
		PiniaFoodStoreService,
		ApiFoodRepository
	);
}
</script>

<template>
	<BaseButton type="button" @click="handleModal">Crear</BaseButton>
	<FoodModal :is-active="isActive" @submit="handleSubmit" @come-back="handleComeBack" />
</template>