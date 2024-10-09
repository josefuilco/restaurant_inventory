export function cloneObject(obj: object) {
	return JSON.parse(JSON.stringify(obj));
}