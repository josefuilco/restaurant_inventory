export function extractForm(event: Event) {
	const formElem = (event.target as HTMLFormElement);
	const formData = new FormData(formElem);
	const formObj = Object.fromEntries(formData);
	return formObj;	
}