<script setup lang="ts">
import TextField from '@/module/common/presentation/components/field/TextField.vue';
import BaseModal from '@/module/common/presentation/components/modal/BaseModal.vue';
import type { Provider } from '@/module/inventory/domain/entity/Provider';

interface Props {
	provider: Provider;
	isActive: boolean;
	onComeBack(state: boolean): void;
	onSubmit(event: Event): void;
}

defineProps<Props>();
</script>

<template>
	<BaseModal :is-active="isActive" @come-back="onComeBack" @submit="onSubmit">
		<TextField name="cellphone" :value="provider.cellphone">Numero de Celular</TextField>
	</BaseModal>
</template>