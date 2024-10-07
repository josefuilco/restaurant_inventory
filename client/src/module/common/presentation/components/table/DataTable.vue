<script setup lang="ts">
import CheckBox from '../checkbox/CheckBox.vue';

interface Props {
	columns: string[];
	rows: object[];
}

defineProps<Props>();
</script>

<template>
	<div class="table-container">
		<table class="project-table">
			<thead>
				<tr>
					<th><div></div></th>
					<th v-for="(column, index) in columns" :key="index">
						{{ column }}
					</th>
				</tr>
			</thead>
			<tbody>
				<tr v-for="(row, index) in rows" :key="index">
					<td><CheckBox name="data-table" id="data-table"/> </td>
					<td v-for="(value, index) in row" :key="index">
						{{ value }}
					</td>
				</tr>
			</tbody>
		</table>
	</div> 
</template>

<style scoped lang="css">
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
	
}

thead {
	background-color: var(--auxiliar-color);
}

th, td {
	border-bottom: 1px solid var(--text-color);
	padding: 10px 8px;
	text-align: center;
}
</style>