<script setup lang="ts">
import OptionField from '@/module/common/presentation/components/field/OptionField.vue';
import TextField from '@/module/common/presentation/components/field/TextField.vue';
import BaseModal from '@/module/common/presentation/components/modal/BaseModal.vue';
import { FoodType } from '@/module/food/domain/constant/FoodType';
import { ensureFoodInformation, type FoodInformation } from '@/module/food/domain/model/FoodInformation';
import { ref, watch } from 'vue';

interface Props {
	isActive: boolean;
	food?: FoodInformation;
	onComeBack(state: boolean): void;
	onSubmit(event: Event): void;
}

const props = defineProps<Props>();
const select: Select[] = [];
const foodRef = ref<FoodInformation>(ensureFoodInformation(
	0,
	'',
	0,
	0,
	''
));

watch(
	() => props.food,
	(food) => {
		if (!food) return;
		foodRef.value = food;
	}		
)

function setupSelect() {
	FoodType.forEach((type, index) => {
		if (index == 0) return;
		select.push({
			id: index,
			value: type
		})
	});
}

setupSelect();
</script>

<template>
	<BaseModal :is-active="isActive" @come-back="onComeBack" @submit="onSubmit">
		<TextField name="name" :value="foodRef.name">Nombre de Comida</TextField>
		<TextField name="price" :value="foodRef.price.toString()">Precio</TextField>
		<TextField name="amount" :value="foodRef.amount.toString()">Cantidad</TextField>
		<OptionField name="type" :values="select">Tipo</OptionField>
	</BaseModal>
</template>