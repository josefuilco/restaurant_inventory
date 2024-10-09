<script setup lang="ts">
import CheckBox from '@/module/common/presentation/components/checkbox/CheckBox.vue';
import OptionField from '@/module/common/presentation/components/field/OptionField.vue';
import TextField from '@/module/common/presentation/components/field/TextField.vue';
import BaseModal from '@/module/common/presentation/components/modal/BaseModal.vue';
import { GetProviders } from '@/module/inventory/application/use-case/GetProviders';
import { Categories } from '@/module/inventory/domain/constant/Categories';
import type { Product } from '@/module/inventory/domain/entity/Product';
import { ApiProviderRepository } from '@/module/inventory/infrastructure/repository/ApiProviderRepository';
import { PiniaProviderStoreService } from '@/module/inventory/infrastructure/service/PiniaProviderStoreService';
import { useProviderStore } from '@/module/inventory/infrastructure/store/ProviderStore';
import { ref, watch } from 'vue';

interface Props {
	product: Product;
	isActive: boolean;
	onlyStock: boolean;
	onCheck(event: Event): void;
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
		<CheckBox name="only-stock" id="only-stock" :is-checkbox="true" @check="onCheck">Solo cambiar stock</CheckBox>
		<TextField v-if="!onlyStock" name="name" :value="product.name">Nombre de producto</TextField>
		<TextField v-if="!onlyStock" name="price" :value="String(product.price)">Precio de producto</TextField>
		<TextField name="quantity" :value="String(product.quantity)">Cantidad</TextField>
		<TextField v-if="!onlyStock" name="minimal_quantity" :value="String(product.minimal_quantity)">Cantidad Minima</TextField>
		<OptionField v-if="!onlyStock" name="proveedor" :values="providerSelect">Proveedores</OptionField>
		<OptionField v-if="!onlyStock" name="categoria" :values="categorySelect">Categorias</OptionField>
	</BaseModal>
</template>