<script setup lang="ts">
import AsideFilter from '@/module/common/presentation/components/filter/AsideFilter.vue';
import DataTable from '@/module/common/presentation/components/table/DataTable.vue';
import { ref } from 'vue';

const roleFilter = ref(0);
const Filters = ['Todos los usuarios', 'Administrador', 'Empleado'];

const columns = ['Nombre de Cuenta', 'Correo', 'Fecha de Creación', 'Role'];
const rows = [
	{
		name: 'jose',
		email: 'jfuilco@gmail.com',
		date: 'Oct 24',
		role: 'Administrador'
	}
]

function getFilter(id: number) {
	roleFilter.value = id;
}
</script>

<template>
	<AsideFilter
		name-filter="Tipo de Cuenta"
		:value-filter="Filters"
		@click="getFilter"
	/>
	<section id="table-view">
		<DataTable :columns="columns" :rows="rows"/>
	</section>
</template>

<style lang="css">
#system-view {
	display: grid;
	grid-template-columns: 25% 75%;
}

#accounts-view {
	grid-column: 2;

}
</style>