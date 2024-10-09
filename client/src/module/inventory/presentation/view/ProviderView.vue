<script setup lang="ts">
import { defineAsyncComponent } from 'vue';

const ProviderTable = defineAsyncComponent(() => import('../components/table/ProviderTable.vue'));
</script>

<template>
	<main id="provider-view">
		<Suspense>
			<ProviderTable />
		</Suspense>
	</main>
</template>

<style>
#provider-view {
	display: grid;
	grid-template-columns: 100%;
	align-content: center;
	justify-items: center;
}
</style>