<script setup lang="ts">
import BaseButton from '@/module/common/presentation/components/button/BaseButton.vue';
import ChangeCellphoneModal from '../modal/ChangeCellphoneModal.vue';
import { ensureProvider, type Provider } from '@/module/inventory/domain/entity/Provider';
import { ref, watch } from 'vue';
import { useProviderStore } from '@/module/inventory/infrastructure/store/ProviderStore';
import { extractForm } from '@/lib/extract-form/extractForm';
import { UpdateProvider } from '@/module/inventory/application/use-case/UpdateProvider';
import { PiniaProviderStoreService } from '@/module/inventory/infrastructure/service/PiniaProviderStoreService';
import { ApiProviderRepository } from '@/module/inventory/infrastructure/repository/ApiProviderRepository';

interface Props {
	provider: Provider;
	isDisable: boolean;
}

const props = defineProps<Props>();
const isActive = ref(false);
const providerStore = useProviderStore();

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

async function handleSubmit(event: Event) {
	event.preventDefault();
	const form = extractForm(event);
	await UpdateProvider(
		ensureProvider(
			props.provider.id,
			props.provider.name,
			String(form["cellphone"])
		),
		PiniaProviderStoreService,
		ApiProviderRepository
	)
}

</script>

<template>
	<BaseButton type="button" @click="handleModal" :is-disable="isDisable">
		Modificar
	</BaseButton>
	<ChangeCellphoneModal :is-active="isActive" :provider="provider" @come-back="handleComeBack" @submit="handleSubmit" />
</template>

<style scoped>
button {
	background-color: rgb(233, 163, 0);

	&:hover {
		background-color: rgb(192, 134, 0);
	}
}
</style>