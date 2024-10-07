<script setup lang="ts">
interface Props {
	type: "reset" | "submit" | "button";
	onClick?(event: Event): void;
}
defineProps<Props>();
</script>

<template>
	<button :type="type" @click="onClick">
		<slot/>
	</button>
</template>

<style scoped lang="css">
button {
	border: 0;
	background-color: var(--first-color);
	color: var(--third-color);
	padding: 0.65rem 0.8rem;
	border-radius: var(--border-radius);
	cursor: pointer;
	transition: 0.5s;

	&:hover {
		background-color: var(--bold-first-color);
	}
}
</style>