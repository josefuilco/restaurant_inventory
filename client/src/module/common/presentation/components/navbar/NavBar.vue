<script setup lang="ts">
import router from '@/router';
import AppIcon from '../icon/AppIcon.vue';
import { ref, watch } from 'vue';

interface Props {
	isAdmin: boolean;
}

const props = defineProps<Props>();
const currentRoute = ref<string | undefined>(
	router.currentRoute.value.name?.toString()
);

watch(
	() => router.currentRoute.value.name,
	(route) => {
		currentRoute.value = route?.toString();
	},
	{ immediate: true }
)

function handleCloseSession() {
	globalThis.localStorage.removeItem('token');
	globalThis.location.href = '/';
}
</script>

<template>
	<aside>
		<div>
			<AppIcon />
			<h1>Inventario Galindo</h1>
		</div>
		<nav :datatype="currentRoute">
			<RouterLink :to="{name: 'food'}">Comidas</RouterLink>
			<RouterLink :to="{name: 'provider'}">Proveedores</RouterLink>
			<RouterLink :to="{name: 'product'}">Productos</RouterLink>
			<RouterLink v-if="isAdmin" :to="{name: 'accounts'}">Cuentas</RouterLink>
			<RouterLink v-if="isAdmin" :to="{name: 'report'}">Reportes</RouterLink>
			<RouterLink :to="{name: 'configuration'}">Configuración</RouterLink>
			<a @click="handleCloseSession">Cerrar Sesión</a>
		</nav>
	</aside>
</template>

<style scoped lang="css">
aside {
	display: flex;
	flex-direction: column;
	align-items: flex-end;
	grid-column: 1;
	width: 100%;
	background-color: var(--seventh-color);
	--standard-width: 80%;
}

aside > div {
	display: flex;
	margin: 50px 0;
	color: var(--first-color);
	align-items: center;
	gap: 6px;
	width: var(--standard-width);
	> h1 {
		font-size: 1.05rem;
	}
}

nav {
	display: flex;
	flex-direction: column;
	gap: 20px;
	width: var(--standard-width);

	> a {
		color: var(--ancor-color);
		cursor: pointer;
		padding: 10px 6px;
		transition: 0.2s;
	}
}

nav[datatype="configuration"] > a:nth-last-child(2) {
	background-color: var(--bg-color);
	color: var(--first-color);
	font-weight: 600;
	border-left: 3px solid var(--first-color);
}

nav[datatype="food"] > a:first-child,
nav[datatype="provider"] > a:nth-child(2),
nav[datatype="product"] > a:nth-child(3),
nav[datatype="accounts"] > a:nth-child(4),
nav[datatype="report"] > a:nth-child(5) {
	background-color: var(--sixth-color);
	color: var(--first-color);
	font-weight: 600;
	border-left: 3px solid var(--first-color);
}

nav > a:hover {
	background-color: var(--bg-color);
	color: var(--first-color);
	font-weight: 600;
	border-left: 3px solid var(--first-color);
}

nav > a:last-child:hover {
	background-color: var(--bg-color);
	color: var(--red-color);
	font-weight: 600;
	border-left: 3px solid var(--red-color);
}
</style>