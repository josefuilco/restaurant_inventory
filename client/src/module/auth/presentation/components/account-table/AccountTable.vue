<script setup lang="ts">
import { cloneObject } from '@/lib/clone-object/cloneObject';
import { GetAccounts } from '@/module/auth/application/use-cases/GetAccounts';
import { ApiUserRepository } from '@/module/auth/infrastructure/repository/ApiUserRepository';
import type { UserInfo } from '@/module/common/domain/model/UserInfo';
import { PiniaUserStoreService } from '@/module/common/infrastructure/service/PiniaUserStoreService';
import { useUserStore } from '@/module/common/infrastructure/store/UserStore';
import { defineAsyncComponent, nextTick, ref, watch } from 'vue';
import ButtonsTopBar from '../topbar/ButtonsTopBar.vue';
const DataTable = defineAsyncComponent(() => import('@/module/common/presentation/components/table/DataTable.vue'));

interface Props {
	roleFilter: number;
}

const props = defineProps<Props>();
const userStore = useUserStore();
const rows = ref<UserInfo[]>([])
const userSelected = ref<number>(0);

const columns = ['N°', 'Nombre de Cuenta', 'Correo', 'Fecha de Creación', 'Role'];
const nameFilter = {
	role: ['Administrador', 'Empleado']
};

watch(
	() => userStore.accounts,
	(accounts) => {
		if (!accounts) return;
		rows.value = cloneObject(accounts);
	},
	{ immediate: true }
);

watch(
	() => props.roleFilter,
	(filter) => {
		const condition = filter == 1 || filter == 2;
		if (!condition) {
			rows.value = userStore.getAccounts;
			return;
		}
		const newRows = cloneObject(userStore.accounts!.filter(f => f["role"] == filter));
		rows.value = newRows;
	},
	{ immediate: true }
);

async function setupAccounts() {
	await GetAccounts(PiniaUserStoreService, ApiUserRepository);
}

function handleCheck(obj: object) {
	userSelected.value = (obj as UserInfo)["id"];
}
await setupAccounts();
</script>

<template>
	<div id="account-table">
		<ButtonsTopBar :user-id="userSelected" />
		<Suspense>
			<DataTable :columns="columns" :rows="rows" :name-filter="nameFilter" @check="handleCheck"/>
		</Suspense>
	</div>
</template>

<style scoped lang="css">
#account-table {
	display: flex;
	flex-direction: column;
	justify-content: center;
	height: 100dvh;
	width: 80%;
	gap: 10px;
}
</style>