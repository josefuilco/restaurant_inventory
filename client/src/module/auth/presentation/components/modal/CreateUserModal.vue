<script setup lang="ts">
import { CreateAccount } from '@/module/auth/application/use-cases/CreateAccount';
import { ensureUser } from '@/module/auth/domain/model/User';
import { ApiUserRepository } from '@/module/auth/infrastructure/repository/ApiUserRepository';
import { PiniaUserStoreService } from '@/module/common/infrastructure/service/PiniaUserStoreService';
import OptionField from '@/module/common/presentation/components/field/OptionField.vue';
import PasswordField from '@/module/common/presentation/components/field/PasswordField.vue';
import TextField from '@/module/common/presentation/components/field/TextField.vue';
import BaseModal from '@/module/common/presentation/components/modal/BaseModal.vue';

interface Props {
	isActive: boolean;
	onComeBack(state: boolean): void;
}

defineProps<Props>();

const Roles: Select[] = [
	{
		id: 1,
		value: 'Administrador'
	},
	{
		id: 2,
		value: 'Empleado'
	}
]

async function handleSubmit(event: Event) {
	event.preventDefault();
	const formElem = (event.target as HTMLFormElement);
	const formData = new FormData(formElem);
	const formObj = Object.fromEntries(formData);
	if (formObj["password"] != formObj["confirm-password"]) {
		console.error("Contraseñas diferentes");
		return;
	}
	const newUser = ensureUser(
		String(formObj["username"]),
		String(formObj["password"]),
		String(formObj["email"]),
		Number(formObj["user-role"]),
	);
	await CreateAccount(newUser, PiniaUserStoreService, ApiUserRepository);
}
</script>

<template>
	<BaseModal
		:is-active="isActive"
		@come-back="onComeBack"
		@submit="handleSubmit"
	>
		<TextField name="username">Nombre de usuario</TextField>
		<PasswordField name="password">Contraseña</PasswordField>
		<PasswordField name="confirm-password">Confirmar contraseña</PasswordField>
		<TextField name="email">Correo electronico</TextField>
		<OptionField name="user-role" id="role" :values="Roles">Rol</OptionField>
	</BaseModal>
</template>