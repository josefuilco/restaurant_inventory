<script setup lang="ts">
interface Props {
	type: "reset" | "submit" | "button";
}
defineProps<Props>();
</script>

<template>
	<button :type="type">
		<slot/>
	</button>
</template>

<style scoped lang="css">
button {
	
}
</style>