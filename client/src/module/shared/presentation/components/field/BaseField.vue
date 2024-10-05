<script setup lang="ts">
import type { InputTypeHTMLAttribute } from 'vue';

interface Props {
	type: InputTypeHTMLAttribute;
}
defineProps<Props>();
</script>

<template>
	<div>
		<input :type="type">
	</div>
</template>

<style scoped lang="css">
</style>