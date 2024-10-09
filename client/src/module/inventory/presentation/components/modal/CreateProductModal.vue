<script setup lang="ts">
import OptionField from '@/module/common/presentation/components/field/OptionField.vue';
import TextField from '@/module/common/presentation/components/field/TextField.vue';
import BaseModal from '@/module/common/presentation/components/modal/BaseModal.vue';
import { GetProviders } from '@/module/inventory/application/use-case/GetProviders';
import { Categories } from '@/module/inventory/domain/constant/Categories';
import { ApiProviderRepository } from '@/module/inventory/infrastructure/repository/ApiProviderRepository';
import { PiniaProviderStoreService } from '@/module/inventory/infrastructure/service/PiniaProviderStoreService';
import { useProviderStore } from '@/module/inventory/infrastructure/store/ProviderStore';
import { ref, watch } from 'vue';

interface Props {
	isActive: boolean;
	onComeBack(state: boolean): void;
	onSubmit(event: Event): void;
}

defineProps<Props>();

const providerStore = useProviderStore();
const providerSelect = ref<Select[]>([]);
const categorySelect = ref<Select[]>([]);

watch(
	() => providerStore.getProviders,
	async (providers) => {
		if (!providers) {
			await GetProviders(PiniaProviderStoreService, ApiProviderRepository);
			return;
		}
		providerSelect.value = [];
		providers.forEach(provider => {
			providerSelect.value.push({
				id: provider.id,
				value: provider.name
			});
		})
	},
	{ immediate: true }
)

function setupCategories() {
	Categories.forEach((category, index) => {
		if (index == 0) return;
		categorySelect.value.push({
			id: index,
			value: category
		});
	})
}

setupCategories();
</script>

<template>
	<BaseModal :is-active="isActive" @come-back="onComeBack" @submit="onSubmit">
		<TextField name="name">Nombre de producto</TextField>
		<TextField name="price">Precio de producto</TextField>
		<TextField name="quantity">Cantidad</TextField>
		<TextField name="minimal_quantity">Cantidad Minima</TextField>
		<OptionField name="proveedor" :values="providerSelect">Proveedores</OptionField>
		<OptionField name="categoria" :values="categorySelect">Categorias</OptionField>
	</BaseModal>
</template>