import config from '../config.json';

export const processImage = async (emailAddress, file) => {
    const formData = new FormData();
    formData.append('files', file);
    formData.append('emailAddress', emailAddress);

    const result = await fetch(`${config.apiBaseUrl}/images`, {
        method: 'POST',
        body: formData
    });

    if (!result.ok) { return; }

    const json = await result.text();
    console.log(json);
}