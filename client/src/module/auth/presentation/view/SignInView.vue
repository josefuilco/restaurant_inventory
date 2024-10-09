<script setup lang="ts">
import AppIcon from '@/module/common/presentation/components/icon/AppIcon.vue';
import SignInForm from '../components/form/SignInForm.vue';
</script>

<template>
	<section class="sign-in">
		<div class="sign-in__logo"><AppIcon/><span>Inventario Galindo</span></div>
		<h1 class="sign-in__title">Inicia Sesión en tu Cuenta</h1>
		<p class="sign-in__subtitle">¡Bienvenido! Ingresa los datos de tu cuenta</p>
		<SignInForm />
	</section>
	<section class="sign-in-information">
		<!-- TODO: Add information about app -->
	</section>
</template>

<style>
#app {
	display: grid;
	grid-template-columns: repeat(2, 50%);
}

.sign-in,
.sign-in-information {
	height: 100%;
	width: 100%;
}

.sign-in {
	display: flex;
	flex-direction: column;
	align-items: start;
	justify-content: center;

	--sign-in-side-margin: 20%;
	--sign-in-title-margin: 10px 20%;
}

.sign-in__logo {
	display: flex;
	color: var(--first-color);
	flex-direction: row;
	align-items: center;
	gap: 6px;
	margin: 10px var(--sign-in-side-margin);
	font-weight: 700;
}

.sign-in__subtitle {
	margin: 0 var(--sign-in-side-margin);
}

.sign-in__title {
	font-size: 1.3rem;
	margin: var(--sign-in-title-margin);
}

.sign-in-information {
	background-color: var(--first-color);
	grid-column: 2;
}

@media (width < 1100px) {
	.sign-in {
		--sign-in-side-margin: 10%;
		--sign-in-title-margin: 10px 10%;
	}
}

@media (width < 720px) {
	#app {
		grid-template-columns: 1;
	}

	.sign-in {
		grid-column-start: 1;
		grid-column-end: 3;
		--sign-in-side-margin: 15%;
		--sign-in-title-margin: 10px 15%;
	}

	.sign-in-information {
		display: none;
	}
}
</style>