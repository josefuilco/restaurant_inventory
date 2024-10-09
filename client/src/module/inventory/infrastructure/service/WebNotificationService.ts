import type { INotificationService } from "../../domain/service/INotificationService";

export const WebNotificationService: INotificationService = {
	async notify(title, message) {
		const permission = await globalThis.Notification.requestPermission();
		if (permission != 'granted') return;
		new Notification(title, {
			body: message
		});
	},
}