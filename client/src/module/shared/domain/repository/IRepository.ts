export interface IRepository<Model> {
	AddAsync(model: Model): Promise<boolean>;
	GetAllAsync(): Promise<Array<Model>>;
	UpdateAsync(model: Model): Promise<boolean>;
	RemoveAsync(model: Model): Promise<boolean>;
}