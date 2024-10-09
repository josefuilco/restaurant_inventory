<script setup lang="ts">
import { cloneObject } from '@/lib/clone-object/cloneObject';
import { GetProviders } from '@/module/inventory/application/use-case/GetProviders';
import { ensureProvider, type Provider } from '@/module/inventory/domain/entity/Provider';
import { ApiProviderRepository } from '@/module/inventory/infrastructure/repository/ApiProviderRepository';
import { PiniaProviderStoreService } from '@/module/inventory/infrastructure/service/PiniaProviderStoreService';
import { useProviderStore } from '@/module/inventory/infrastructure/store/ProviderStore';
import { defineAsyncComponent, ref, watch } from 'vue';
import ProviderTopBar from '../topbar/ProviderTopBar.vue';

const DataTable = defineAsyncComponent(() => import('@/module/common/presentation/components/table/DataTable.vue'));

const providerStore = useProviderStore();
const rows = ref<Provider[]>([]);
const COLUMNS = [
	'N°',
	'Nombre del Proveedor',
	'Celular'
];
const provider = ref<Provider>(ensureProvider(
	0,
	'',
	''
));

watch(
	() => providerStore.getProviders,
	(providers) => {
		if (!providers) return;
		rows.value = cloneObject(providers);
	},
	{ immediate: true }
)

function handleCheck(obj: object) {
	provider.value = (obj as Provider)
}

async function setupTable() {
	await GetProviders(PiniaProviderStoreService, ApiProviderRepository);
}

await setupTable();
</script>

<template>
	<div id="provider-table">
		<ProviderTopBar :provider="cloneObject(provider)" />
		<DataTable
		:columns="COLUMNS"
		:rows="rows"
		@check="handleCheck" 
		/>
	</div>
</template>

<style scoped>
#provider-table {
	display: flex;
	flex-direction: column;
	gap: 10px;
	width: 70%;
}
</style>