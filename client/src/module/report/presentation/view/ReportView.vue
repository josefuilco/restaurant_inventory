<script setup lang="ts">
import { defineAsyncComponent } from 'vue';
const ReportTable = defineAsyncComponent(() => import('../components/report-table/ReportTable.vue'));
</script>

<template>
	<main id="report-view">
		<Suspense>
			<ReportTable />
		</Suspense>
	</main>
</template>

<style>
#report-view {
	display: grid;
	grid-template-columns: 100%;
	align-content: center;
	justify-items: center;
}
</style>