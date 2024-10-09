<script setup lang="ts">
import { useFoodStore } from '@/module/food/infrastructure/store/FoodStore';
import CreateFoodButton from '../button/CreateFoodButton.vue';
import DeleteFoodButton from '../button/DeleteFoodButton.vue';
import ModifyFoodButton from '../button/ModifyFoodButton.vue';
import { ref, watch } from 'vue';
import type { FoodInformation } from '@/module/food/domain/model/FoodInformation';

interface Props {
	food: FoodInformation;
}

const props = defineProps<Props>();
const foodStore = useFoodStore();
const isDisable = ref(true);

watch(
	() => props.food.id,
	(id) => {
		if (id === 0) return;
		isDisable.value = false;
	},
	{ immediate: true }
)

watch(
	() => foodStore.foods,
	() => {
		isDisable.value = true;
	},
	{ immediate: true }
)
</script>

<template>
	<section>
		<CreateFoodButton/>
		<ModifyFoodButton :is-disable="isDisable" :food="food"/>
		<DeleteFoodButton :is-disable="isDisable" :food-id="food.id"/>
	</section>
</template>

<style scoped>
section {
	align-self: flex-end;
	display: flex;
	flex-direction: row;
	height: auto;
	gap: 10px;
}
</style>