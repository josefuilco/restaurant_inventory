<script setup lang="ts">
import { DeleteAccount } from '@/module/auth/application/use-cases/DeleteAccount';
import { ApiUserRepository } from '@/module/auth/infrastructure/repository/ApiUserRepository';
import { PiniaUserStoreService } from '@/module/common/infrastructure/service/PiniaUserStoreService';
import { useUserStore } from '@/module/common/infrastructure/store/UserStore';
import BaseButton from '@/module/common/presentation/components/button/BaseButton.vue';
import SecurityModal from '@/module/common/presentation/components/modal/SecurityModal.vue';
import { ref, watch } from 'vue';

interface Props {
	userId: number;
	isDisable: boolean;
}

const props = defineProps<Props>();
const userStore = useUserStore();
const isActive = ref(false);

watch(
	() => userStore.accounts,
	() => {
		isActive.value = false;
	},
	{ immediate: true }
)

function handleModal() {
	isActive.value = true;
}

function handleComeBack(state: boolean) {
	isActive.value = state;
}

async function handleAccept() {
	await DeleteAccount(props.userId, PiniaUserStoreService, ApiUserRepository);
}
</script>

<template>
	<BaseButton type="button" @click="handleModal" :is-disable="isDisable">
		Borrar
	</BaseButton>
	<SecurityModal :is-active="isActive" @come-back="handleComeBack" @accept="handleAccept" />
</template>

<style scoped lang="css">
button {
	background-color: var(--red-color);

	&:hover {
		background-color: var(--bold-red-color);
	}
}
</style>

