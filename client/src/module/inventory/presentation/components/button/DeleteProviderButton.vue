<script setup lang="ts">
import BaseButton from '@/module/common/presentation/components/button/BaseButton.vue';
import SecurityModal from '@/module/common/presentation/components/modal/SecurityModal.vue';
import { DeleteProvider } from '@/module/inventory/application/use-case/DeleteProvider';
import type { Provider } from '@/module/inventory/domain/entity/Provider';
import { ApiProviderRepository } from '@/module/inventory/infrastructure/repository/ApiProviderRepository';
import { PiniaProviderStoreService } from '@/module/inventory/infrastructure/service/PiniaProviderStoreService';
import { useProviderStore } from '@/module/inventory/infrastructure/store/ProviderStore';
import { ref, watch } from 'vue';

interface Props {
	provider: Provider;
	isDisable: boolean;
}

const props = defineProps<Props>();
const providerStore = useProviderStore();
const isActive = ref(false);

watch(
	() => providerStore.getProviders,
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
	await DeleteProvider(props.provider.id, PiniaProviderStoreService, ApiProviderRepository);
}
</script>

<template>
	<BaseButton type="button" @click="handleModal" :is-disable="isDisable">
		Eliminar
	</BaseButton>
	<SecurityModal :is-active="isActive" @come-back="handleComeBack" @accept="handleAccept" />
</template>

<style scoped>
button {
	background-color: var(--red-color);

	&:hover {
		background-color: var(--bold-red-color);
	}
}
</style>