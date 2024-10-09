<script setup lang="ts">
import TextField from '@/module/common/presentation/components/field/TextField.vue';
import BaseModal from '@/module/common/presentation/components/modal/BaseModal.vue';

interface Props {
	isActive: boolean;
	onComeBack(state: boolean): void;
	onSubmit(event: Event): void;
}

defineProps<Props>();
</script>

<template>
	<BaseModal :is-active="isActive" @come-back="onComeBack" @submit="onSubmit">
		<TextField name="name">Nombre del proveedor</TextField>
		<TextField name="cellphone">Numero de celular</TextField>
	</BaseModal>
</template>