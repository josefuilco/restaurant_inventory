<script setup lang="ts">
import BaseButton from '../button/BaseButton.vue';

interface Props {
	isActive: boolean;
	onComeBack(state: boolean): void;
	onSubmit(event: Event): void;
}

defineProps<Props>()
</script>

<template>
	<section v-if="isActive" class="modal">
		<form class="modal__container" @submit="onSubmit">
			<slot />
			<div class="modal__buttons">
				<BaseButton @click="onComeBack(false)" type="button">
					Descartar
				</BaseButton>
				<BaseButton type="submit">
					Aceptar
				</BaseButton>
			</div>
		</form>
	</section>
</template>

<style scoped lang="css">
.modal,
.modal__container,
.modal__buttons {
	display: flex;
	z-index: 2;
}

.modal {
	align-items: center;
	justify-content: center;
	position: fixed;
	top: 0;
	left: 0;
	height: 100dvh;
	width: 100dvw;
	background-color: rgba(0, 0, 0, 0.40);
}

.modal__container {
	flex-direction: column;
	height: auto;
	width: auto;
	padding: 20px;
	background-color: var(--bg-color);
	border-radius: var(--border-radius);
	gap: 20px;
}

.modal__buttons {
	flex-direction: row;
	gap: 6px;

	button {
		width: 120px;
	}

	button[type="button"] {
		background-color: var(--red-color);

		&:hover {
			background-color: var(--bold-red-color);
		}
	}
}
</style>