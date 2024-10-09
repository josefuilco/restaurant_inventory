export interface INotificationService {
	notify(title: string, message: string): Promise<void>;
}