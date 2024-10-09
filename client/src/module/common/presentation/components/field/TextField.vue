<script setup lang="ts">
import BaseField from './BaseField.vue';

interface Props {
	name: string;
	value?: string;
}

defineProps<Props>();
</script>

<template>
	<BaseField type="text" :name="name" :value="value">
		<slot />
	</BaseField>
</template>