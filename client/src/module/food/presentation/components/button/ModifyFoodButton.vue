<script setup lang="ts">
import BaseButton from '@/module/common/presentation/components/button/BaseButton.vue';
import FoodModal from '../modal/FoodModal.vue';
import { ref, watch } from 'vue';
import { useFoodStore } from '@/module/food/infrastructure/store/FoodStore';
import type { FoodInformation } from '@/module/food/domain/model/FoodInformation';
import { cloneObject } from '@/lib/clone-object/cloneObject';
import { extractForm } from '@/lib/extract-form/extractForm';
import { UpdateFood } from '@/module/food/application/use-case/UpdateFood';
import { ensureFoodCreationModel } from '@/module/food/domain/model/FoodCreationModel';
import { PiniaFoodStoreService } from '@/module/food/infrastructure/service/PiniaFoodStoreService';
import { ApiFoodRepository } from '@/module/food/infrastructure/repository/ApiFoodRepository';

interface Props {
	isDisable: boolean;
	food: FoodInformation;
}

const props = defineProps<Props>();
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
	await UpdateFood(
		props.food.id,
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
	<BaseButton type="button" @click="handleModal" :is-disable="isDisable">
		Modificar
	</BaseButton>
	<FoodModal :is-active="isActive" @come-back="handleComeBack" @submit="handleSubmit" :food="cloneObject(food)"/>
</template>

<style scoped>
button {
	background-color: rgb(233, 163, 0);

	&:hover {
		background-color: rgb(192, 134, 0);
	}
}
</style>