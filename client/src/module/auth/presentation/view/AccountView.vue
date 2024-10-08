<script setup lang="ts">
import AsideFilter from '@/module/common/presentation/components/filter/AsideFilter.vue';
import AccountTable from '../components/account-table/AccountTable.vue';
import { ref } from 'vue';

const roleFilter = ref(0);

const Filters = ['Todos los usuarios', 'Administrador', 'Empleado'];

function getFilter(id: number) {
	roleFilter.value = id;
}
</script>

<template>
	<main id="account-view">
		<AsideFilter
			name-filter="Tipo de Cuenta"
			:value-filter="Filters"
			@click="getFilter"
		/>
		<section id="accounts-view">
			<AccountTable :role-filter="roleFilter"/>
		</section>
	</main>
</template>

<style lang="css">
#account-view {
	display: grid;
	grid-template-columns: 25% 75%;
}

#accounts-view {
	display: flex;
	grid-column: 2;
	align-items: center;
	justify-content: center;
}
</style>