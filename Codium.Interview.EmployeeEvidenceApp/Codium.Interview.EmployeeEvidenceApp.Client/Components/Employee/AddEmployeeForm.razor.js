export function formatDate(input) {
    const date = new Date(input.value);
    const year = date.getFullYear();
    const month = ('0' + (date.getMonth() + 1)).slice(-2);
    const day = ('0' + date.getDate()).slice(-2);
    input.value = `${year}/${month}/${day}`;
}

export function setMinDate(input) {
    const today = new Date();
    const minYear = today.getFullYear() - 100;
    const minDate = new Date(minYear, 0, 1);
    input.min = minDate.toISOString().split('T')[0];
}