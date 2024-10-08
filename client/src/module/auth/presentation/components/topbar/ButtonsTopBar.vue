<script setup lang="ts">
import { ref, watch } from 'vue';
import CreateUserButton from '../button/CreateUserButton.vue';
import DeleteUserButton from '../button/DeleteUserButton.vue';
import { useUserStore } from '@/module/common/infrastructure/store/UserStore';

interface Props {
	userId: number;
}

const props = defineProps<Props>();
const userStore = useUserStore();
const isDisable = ref(true);

watch(
	() => props.userId,
	() => {
		if (props.userId === 0) return;
		isDisable.value = false;
	},
	{ immediate: true }
)

watch(
	() => userStore.accounts,
	() => {
		isDisable.value = true;
	},
	{ immediate: true }
)
</script>

<template>
	<section>
		<CreateUserButton />
		<DeleteUserButton :is-disable="isDisable" :user-id="props.userId" />
	</section>
</template>

<style scoped lang="css">
section {
	align-self: flex-end;
	display: flex;
	flex-direction: row;
	height: auto;
	gap: 10px;
}
</style>