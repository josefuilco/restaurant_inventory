<script setup lang="ts">
import { ref, watch } from 'vue';
import CheckBox from '../checkbox/CheckBox.vue';
import { cloneObject } from '@/lib/clone-object/cloneObject';

interface Props {
	columns: string[];
	rows: object[] | undefined;
	nameFilter?: object; 
	onCheck(obj: object): void;
}

const props = defineProps<Props>();
const rowsRef = ref<object | undefined>(cloneObject(props.rows!));

function setupRows() {
	if (!rowsRef.value) return;
	if (!props.nameFilter) return;
	const rowTransformed: any[] = Object.values(rowsRef.value);
	const key = Object.keys(props.nameFilter)[0];
	rowTransformed.forEach(row => {
		const auxFilterName = row[key];
		row[key] = (props.nameFilter as any)[key][auxFilterName - 1];
	});
}

watch(
	() => props.rows,
	() => {
		if (!props.rows) return;
		rowsRef.value = cloneObject(props.rows);
		setupRows();
	}
);

setupRows();
</script>

<template>
	<section>
		<table>
			<thead>
				<tr>
					<th><div></div></th>
					<th v-for="(column, index) in columns" :key="index">
						{{ column }}
					</th>
				</tr>
			</thead>
			<tbody>
				<tr v-for="(row, index) in rowsRef" :key="index">
					<td><CheckBox name="data-table" :id="String(index)" @check="onCheck(rows![index])" :key="index" /> </td>
					<td v-for="(value, index) in row" :key="index">
						{{ value }}
					</td>
				</tr>
			</tbody>
		</table>
	</section> 
</template>

<style scoped lang="css">
section {
	display: flex;
	height: 80dvh;
	max-height: 50dvh;
	overflow: auto;
	align-items: flex-start;
	justify-content: flex-start;
}

th > div {
	--size-box: 20px;
	position: relative;
	height: var(--size-box);
	width: var(--size-box);
	border-radius: var(--border-radius);
	background-color: var(--first-color);

	&::before {
		position: absolute;
		top: calc(var(--size-box)/2 - 1px);
		left: calc(var(--size-box)/2 - 5px);
		content: "";
		height: 2px;
		width: 10px;
		background-color: rgb(255, 255, 255);
	}
}

table {
	border-collapse: collapse;
	width: 100%;
}

thead {
	background-color: var(--auxiliar-color);
}

th, td {
	border-bottom: 1px solid var(--text-color);
	padding: 10px 8px;
	font-size: 0.9rem;
	text-align: center;
}
</style>