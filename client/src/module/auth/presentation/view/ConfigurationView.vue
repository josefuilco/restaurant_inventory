<script setup lang="ts">
import { cloneObject } from '@/lib/clone-object/cloneObject';
import { ensureUserInfo } from '@/module/common/domain/model/UserInfo';
import { useUserStore } from '@/module/common/infrastructure/store/UserStore';
import { computed, ref, watch } from 'vue';
import ChangePasswordForm from '../components/form/ChangePasswordForm.vue';
import { simpleDateFormat } from '@/lib/date-format/simpleDateFormat';


const userStore = useUserStore();
const currentUser = ref(ensureUserInfo(
	0,
	"",
	"",
	"",
	2
));

const role = computed(() => {
	return currentUser.value.role === 1 ? 'Administrador' : 'Empleado';
})

watch(
	() => userStore.currentUser,
	(user) => {
		if (!user) return;
		currentUser.value = cloneObject(user);
	},
	{ immediate: true}
);
</script>

<template>
	<main id="configuration-view">
		<div>
			<h1>Configuración de la cuenta</h1>
			<section id="general-user-info">
				<div><h2>Nombre: </h2><span>{{ currentUser.name }}</span></div>
				<div><h2>Correo: </h2><span>{{ currentUser.email }}</span></div>
				<div><h2>Registro: </h2><span>{{ simpleDateFormat(currentUser.creationDate) }}</span></div>
				<div><h2>Role: </h2><span>{{ role }}</span></div>
			</section>
			<ChangePasswordForm :user-id="currentUser.id"/>
		</div>
	</main>
</template>

<style>
#configuration-view {
	--margin-info: 5%;
	display: grid;
	grid-template-columns: 100%;
	align-content: center;
	justify-items: center;

	> div {
		height: auto;
		width: 70%;
		min-width: 300px;
		max-width: 600px;
		background-color: var(--sixth-color);
		border-radius: var(--border-radius);
		box-shadow: 0px 10px 10px 1px rgba(0, 0, 0, 0.06);

		> h1 {
			color: var(--text-color);
			margin: 5% 0 0 5%;
			font-size: 1.2rem;
		}
	}
}

#general-user-info {
	display: flex;
	margin: var(--margin-info);
	width: calc(100% - var(--margin-info) *2);
	border-bottom: 1px dashed var(--text-color);
	flex-wrap: wrap;
	gap: 20px;
	padding: 0 0 30px 0;
}
</style>