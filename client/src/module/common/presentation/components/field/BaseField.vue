<script setup lang="ts">
import type { InputTypeHTMLAttribute, Ref } from 'vue';

interface Props {
	name: string;
	type: InputTypeHTMLAttribute;
	value?: string;
	onInput?(event?: Event): void;
}

defineProps<Props>();
</script>

<template>
	<div class="base-field">
		<input :type="type" :name="name" :id="name" :value="value" @input="onInput" required/>
		<label :for="name"><slot /></label>
	</div>
</template>

<style scoped lang="css">
.base-field {
	position: relative;
	display: flex;
	flex-direction: column-reverse;
	height: auto;
}

label {
	left: 0.5rem;
	top: 0.3rem;
	color: var(--label-color);
	transition: 0.5s;
	user-select: none;
}

input {
	outline: none;
	height: 2rem;
	border-radius: var(--border-radius);
	border: 1px solid var(--first-color);
	background-color: var(--third-color);
	padding: 0px 10px;
}

input:focus + label,
input:valid + label {
	top: -1.8rem;
	left: 0;
	font-weight: 700;
}

input[type="password"]::-ms-reveal,
input[type="password"]::-ms-clear {
  display: none;
}
</style>