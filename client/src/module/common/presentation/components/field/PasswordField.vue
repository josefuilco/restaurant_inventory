<script setup lang="ts">
import { computed, ref } from 'vue';
import BaseField from './BaseField.vue';
import CloseEyeIcon from '../icon/CloseEyeIcon.vue';
import OpenEyeIcon from '../icon/OpenEyeIcon.vue';

interface Props {
	name: string;
}

defineProps<Props>();

const STATE = {
	visible: "text",
	hidden: "password"
}

const isPassword = ref(true);
const valueRef = ref("");

function handleInput(event: Event) {
	valueRef.value = (event.target as HTMLInputElement).value
}

function handleVisibility() {
	isPassword.value = !isPassword.value;
}

const changeVisibilityState = computed(() => {
	return isPassword.value ? STATE.hidden : STATE.visible
});
</script>

<template>
	<BaseField :type="changeVisibilityState" :name="name" :value="valueRef" @input="handleInput" >
		<slot />
		<div @click="handleVisibility">
			<CloseEyeIcon v-if="isPassword" />
			<OpenEyeIcon v-if="!isPassword" />
		</div>
	</BaseField>
</template>

<style scoped>
div svg {
	position: absolute;
	bottom: 4px;
	right: 10px;
	color: var(--first-color);
	height: 20px;
	width: 20px;
}
</style>