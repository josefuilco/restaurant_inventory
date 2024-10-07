<script setup lang="ts">
import { SignEdOnSystem } from '@/module/auth/application/use-cases/SignEdOnSystem';
import { SignInOnSystem } from '@/module/auth/application/use-cases/SignInOnSystem';
import { ensureAuth } from '@/module/auth/domain/model/Auth';
import { ApiAuthRepository } from '@/module/auth/infrastructure/repository/ApiAuthRepository';
import { LocalStorageService } from '@/module/auth/infrastructure/service/LocalStorageService';
import BaseButton from '@/module/common/presentation/components/button/BaseButton.vue';
import PasswordField from '@/module/common/presentation/components/field/PasswordField.vue';
import TextField from '@/module/common/presentation/components/field/TextField.vue';
import router from '@/router';

if (SignEdOnSystem(LocalStorageService)) {
	router.replace('/restaurant');
}

async function handleSubmit(event: Event) {
	event.preventDefault();
	const formElem = event.target as HTMLFormElement;
	const formData = new FormData(formElem);
	const formObj = Object.fromEntries(formData);
	try {
		await SignInOnSystem(
			ensureAuth(
				formObj['username'] as string,
				formObj['password'] as string
			),
			ApiAuthRepository,
			LocalStorageService
		);
		router.replace('/restaurant');
	} catch (err) {
		console.error(err);
	}
}
</script>

<template>
	<form @submit="handleSubmit">
		<TextField name="username">Nombre de Usuario</TextField>
		<PasswordField name="password">
			Contraseña
		</PasswordField>
		<BaseButton type="submit">
			Iniciar Sesión
		</BaseButton>
	</form>
</template>

<style scoped>
form {
	display: flex;
	flex-direction: column;
	justify-content: space-around;
	margin: 20px var(--sign-in-side-margin) 0;
	width: 60%;
	border-top: 1px dashed var(--text-color);
}

form div {
	margin: 20px 0 0 0;
}

form button {
	margin: 20px 0 0 0;
}

@media (width < 1100px) {
	form {
		width: 80%;
	}
	button {
		width: 100%;
	}
}

@media (width < 720px) {
	form {
		width: 70%;
	}
	button {
		width: 100%;
	}
}
</style>