<script setup lang="ts">
import BaseButton from '@/module/common/presentation/components/button/BaseButton.vue';
import { useProviderStore } from '@/module/inventory/infrastructure/store/ProviderStore';
import { ref, watch } from 'vue';
import CreateProviderModal from '../modal/CreateProviderModal.vue';
import { extractForm } from '@/lib/extract-form/extractForm';
import { CreateProvider } from '@/module/inventory/application/use-case/CreateProvider';
import { ensureProvider } from '@/module/inventory/domain/entity/Provider';
import { PiniaProviderStoreService } from '@/module/inventory/infrastructure/service/PiniaProviderStoreService';
import { ApiProviderRepository } from '@/module/inventory/infrastructure/repository/ApiProviderRepository';

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
	await CreateProvider(
		ensureProvider(
			0,
			String(form["name"]),
			String(form["cellphone"])
		),
		PiniaProviderStoreService,
		ApiProviderRepository
	)
}
</script>

<template>
	<BaseButton type="button" @click="handleModal">
		Registrar
	</BaseButton>
	<CreateProviderModal :is-active="isActive" @come-back="handleComeBack" @submit="handleSubmit" />
</template>