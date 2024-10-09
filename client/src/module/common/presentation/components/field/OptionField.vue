<script setup lang="ts">
interface Props {
	name: string;
	values: Select[];
}

defineProps<Props>();
</script>

<template>
	<div class="option-field">
		<select :name="name" :id="name">
			<option v-for="(value, index) in values" :value="value.id" :key="index">{{ value.value }}</option>
		</select>
		<label :for="name"><slot/></label>
	</div>
</template>

<style lang="css" scoped>
.option-field {
	position: relative;
	display: flex;
	flex-direction: column-reverse;
	height: auto;
}

.option-field label {
	color: var(--text-color);
	transition: 0.5s;
	user-select: none;
}

.option-field select {
	padding: 8px;
	font-size: 0.9rem;
	border: 1px solid var(--first-color);
	border-radius: 4px;
	background-color: var(--third-color);
}

.option-field select:focus {
	outline: none;
}

select:focus + label,
select:valid + label {
	font-weight: 700;
}
</style>