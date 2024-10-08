<script setup lang="ts">
import BaseButton from '../button/BaseButton.vue';

interface Props {
	isActive: boolean;
	onComeBack(state: boolean): void;
	onAccept(event: Event): void;
}

defineProps<Props>()
</script>

<template>
	<section v-if="isActive" class="security-modal">
		<h1>¿Estas seguro?</h1>
		<div class="security-modal__container">
			<h1>¿Estas seguro?</h1>
			<div class="security-modal__buttons">
				<BaseButton @click="onComeBack(false)" class="discart-button" type="button">
					No
				</BaseButton>
				<BaseButton @click="onAccept" type="button">
					Si
				</BaseButton>
			</div>
		</div>
	</section>
</template>

<style scoped lang="css">
.security-modal,
.security-modal__container,
.security-modal__buttons {
	display: flex;
	z-index: 2;
}

.security-modal {
	align-items: center;
	justify-content: center;
	position: fixed;
	top: 0;
	left: 0;
	height: 100dvh;
	width: 100dvw;
	background-color: rgba(0, 0, 0, 0.40);
}

.security-modal__container {
	flex-direction: column;
	height: auto;
	width: auto;
	padding: 20px;
	background-color: var(--bg-color);
	border-radius: var(--border-radius);
	gap: 20px;
	align-items: center;
	h1 {
		font-size: 1.5rem;
	}
}

.security-modal__buttons {
	flex-direction: row;
	gap: 6px;

	button {
		width: 120px;
	}

	.discart-button {
		background-color: var(--red-color);

		&:hover {
			background-color: var(--bold-red-color);
		}
	}
}
</style>