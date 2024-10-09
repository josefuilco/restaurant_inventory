<script setup lang="ts">
import type { Provider } from '@/module/inventory/domain/entity/Provider';
import CreateProviderButton from '../button/CreateProviderButton.vue';
import DeleteProviderButton from '../button/DeleteProviderButton.vue';
import UpdateProviderButton from '../button/UpdateProviderButton.vue';
import { useProviderStore } from '@/module/inventory/infrastructure/store/ProviderStore';
import { ref, watch } from 'vue';

interface Props {
	provider: Provider;
}

const props = defineProps<Props>();
const providerStore = useProviderStore();
const isDisable = ref(true);

watch(
	() => props.provider.id,
	(id) => {
		if (id === 0) return;
		isDisable.value = false;
	},
	{ immediate: true }
)

watch(
	() => providerStore.getProviders,
	() => {
		isDisable.value = true;
	},
	{ immediate: true }
)
</script>

<template>
	<div id="provider-topbar">
		<CreateProviderButton />
		<UpdateProviderButton :provider="provider" :is-disable="isDisable" />
		<DeleteProviderButton :provider="provider" :is-disable="isDisable" />
	</div>
</template>

<style scoped>
#provider-topbar {
	display: flex;
	flex-direction: row;
	justify-content: flex-end;
	height: auto;
	width: 100%;
	gap: 10px;
}
</style>