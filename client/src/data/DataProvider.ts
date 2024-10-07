export class DataProvider {
	private static instance?: DataProvider;
	private readonly api: string;

	private constructor() {
		this.api = import.meta.env.VITE_API_BACKEND;
	}

	public static getInstance(): DataProvider {
		if (DataProvider.instance == undefined) {
			DataProvider.instance = new DataProvider();
		}
		return DataProvider.instance;
	}

	private path(route: string) {
		return `${this.api}/${route}`;
	}

	private config(method: string, body?: object): RequestInit {
		return {
			method,
			headers: {
				'Content-Type': 'application/json'
			},
			body: JSON.stringify(body)
		}
	}

	public async get(route: string): Promise<any> {
		const response = await fetch(this.path(route), this.config('GET'));
		return await response.json();
	}

	public async post(route: string, body: object): Promise<any> {
		const response = await fetch(this.path(route), this.config('POST', body));
		return await response.json();
	}

	public async put(route: string, body?: object): Promise<any> {
		const response = await fetch(this.path(route), this.config('POST', body));
		return await response.json();
	}

	public async del(route: string, body?: object): Promise<any> {
		const response = await fetch(this.path(route), this.config('DELETE', body));
		return await response.json();
	}
}