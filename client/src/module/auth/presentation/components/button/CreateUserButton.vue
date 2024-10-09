<script setup lang="ts">
import BaseButton from '@/module/common/presentation/components/button/BaseButton.vue';
import { ref, watch } from 'vue';
import CreateUserModal from '../modal/CreateUserModal.vue';
import { useUserStore } from '@/module/common/infrastructure/store/UserStore';

const userStore = useUserStore();
const isActive = ref(false);

function changeStateModal() {
	isActive.value = true;
}

function handleComeBack(state: boolean) {
	isActive.value = state;
}

watch(
	() => userStore.accounts,
	() => {
		isActive.value = false;
	},
	{ immediate: true }
)
</script>

<template>
	<BaseButton @click="changeStateModal" type="button">
		Agregar
	</BaseButton>
	<CreateUserModal :is-active="isActive" @come-back="handleComeBack" />
</template>