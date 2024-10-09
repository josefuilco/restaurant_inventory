<script setup lang="ts">
import { extractForm } from '@/lib/extract-form/extractForm';
import { ChangePasswordAccount } from '@/module/auth/application/use-cases/ChangePasswordAccount';
import { ApiUserRepository } from '@/module/auth/infrastructure/repository/ApiUserRepository';
import BaseButton from '@/module/common/presentation/components/button/BaseButton.vue';
import PasswordField from '@/module/common/presentation/components/field/PasswordField.vue';

interface Props {
	userId: number;
}

const props = defineProps<Props>();

async function handleSubmit(event: Event) {
	event.preventDefault();
	const form = extractForm(event);
	try {
		const changed =  await ChangePasswordAccount(
			props.userId,
			String(form["old-password"]),
			String(form["new-password"]),
			ApiUserRepository
		);
		if (changed) {
			globalThis.localStorage.removeItem('token');
			globalThis.location.href = '/';
		}
	} catch {
		console.error('Contraseña actual incorrecta.');
	}
}
</script>

<template>
	<form id="change-password" @submit="handleSubmit">
		<PasswordField name="old-password">Contraseña Actual</PasswordField>
		<PasswordField name="new-password">Contraseña Actual</PasswordField>
		<BaseButton type="submit">Cambiar</BaseButton>
	</form>
</template>

<style scoped>
#change-password {
	display: flex;
	flex-wrap: wrap;
	gap: 10px;
	margin: var(--margin-info);
	width: calc(100% - var(--margin-info) *2);

	& > div {
		width: 40%;
	}
}

@media (width < 720px) {
	#change-password {
		display: flex;
		flex-direction: column;
		flex-wrap: nowrap;
		gap: 15px;
		margin: var(--margin-info);
		width: calc(100% - var(--margin-info) *2);
	
		& > div {
			width: 100%;
		}
	}
}
</style>