<script setup lang="ts">
import { computed } from 'vue';

interface Props {
	id: string;
	name: string;
	isCheckbox?: boolean;
	onCheck?(event: Event): void; 
}

const props = defineProps<Props>();

const type = computed(() => {
	return props.isCheckbox ? "checkbox" : "radio";
})
</script>

<template>
	<div>
		<input :type="type" :name="name" :id="id" @change="onCheck">
		<label :for="id"><slot/></label>
	</div>
</template>

<style scoped>
input[type="radio"],
input[type="checkbox"] {
	position: absolute;
	opacity: 0;
	cursor: pointer;
}

label {
	position: relative;
	padding-left: 30px;
	cursor: pointer;
	user-select: none;
	font-size: 14px;
	color: #4a4a4a;
}

label:before {
	content: "";
	position: absolute;
	left: 0;
	top: 0;
	width: 20px;
	height: 20px;
	border: 2px solid #ccc;
	border-radius: 4px;
	background-color: #fff;
	transition: background-color 0.3s, border-color 0.3s;
}

input:checked + label:before {
	background-color: var(--first-color);
	border-color: var(--first-color);
}
</style>