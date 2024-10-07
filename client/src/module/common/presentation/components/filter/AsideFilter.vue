<script setup lang="ts">
import { ref } from 'vue';
import BaseButton from '../button/BaseButton.vue';
import CheckBox from '../checkbox/CheckBox.vue';

interface Props {
	nameFilter: string;
	valueFilter: string[];
	onClick(id: number): void;
}

const idRef = ref(0);

defineProps<Props>();

function handleCheck(id: number) {
	idRef.value = id;
}
</script>

<template>
	<aside>
		<h2>{{ nameFilter }}</h2>
		<div>
			<CheckBox
				v-for="(value, index) in valueFilter"
				:name="nameFilter.toLowerCase().replace(' ', '_')"
				:id="value"
				:key="index"
				@check="handleCheck(index)">
				{{ value }}
			</CheckBox>
		</div>
		<BaseButton type="button" @click="onClick(idRef)">
			Aplicar Filtro
		</BaseButton>
	</aside>
</template>

<style scoped lang="css">
aside {
	display: flex;
	flex-direction: column;
	align-items: center;
	gap: 30px;
	background-color: var(--sixth-color);
	--standard--width: 80%;

	> h2 {
		margin-top: 20px;
		font-size: 1.1rem;
		color: var(--first-color);
		width: var(--standard--width);
	}

	> div {
		display: flex;
		flex-direction: column;
		gap: 20px;
		width: var(--standard--width);
	}
	
	> button {
		width: var(--standard--width);
	}
}

label {
	user-select: none;
}
</style>