<script setup lang="ts">
import { defineAsyncComponent, ref } from 'vue';
import { saveUserInfoInStore } from '../../application/use-case/saveUserInfoInStore';
import { ApiUserInfoRepository } from '../../infrastructure/repository/ApiUserInfoRepository';
import { PiniaUserStoreService } from '../../infrastructure/service/PiniaUserStoreService';
import NavBar from '../components/navbar/NavBar.vue';

const isAdmin = ref<boolean>(false);

function setRole() {
	isAdmin.value = PiniaUserStoreService.getCurrentUserRole() == 1;
}

async function setAccount() {
	const token = window.localStorage.getItem('token')!;
	await saveUserInfoInStore(token, PiniaUserStoreService, ApiUserInfoRepository);
	setRole();
}

setAccount();
</script>

<template>
	<NavBar :is-admin="isAdmin"/>
	<main id="system-view">
		<RouterView />
	</main>
</template>

<style lang="css">
#app {
	display: grid;
	grid-template-columns: 20% 80%;
}
#system-view {
	height: 100dvh;
	grid-column: 2;
	background-color: var(--bg-color);
}
</style>