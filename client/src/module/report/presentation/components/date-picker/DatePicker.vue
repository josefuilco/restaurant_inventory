<script setup lang="ts">
interface Props {
	name: string;
	onDate?(date: string): void;
}

const props = defineProps<Props>();

function handleDate(event: Event) {
	const value = (event.target as HTMLInputElement).value;
	if (props.onDate) props.onDate(value);
}
</script>

<template>
	<div class="date-picker">
		<input type="date" :name="name" id="datepicker" class="datepicker" @change="handleDate">
		<label for="datepicker"><slot/></label>
	</div>
</template>

<style scoped>
.date-picker {
	display: flex;
	flex-direction: column-reverse;
}

label {
	font-size: 14px;
	color: var(--text-color);
}

.datepicker {
	padding: 7px;
	border-radius: 5px;
	border: 1px solid #ccc;
	font-size: 16px;
	background-color: #fff;
	width: 100%;
	box-sizing: border-box;
	transition: border 0.3s;
	cursor: pointer;
}

.datepicker:focus {
	outline: none;
	border-color: var(--first-color);
	box-shadow: 0 0 5px var(--second-color);
}

.datepicker:focus + label,
.datepicker:valid + label {
	font-weight: 700;
}
</style>