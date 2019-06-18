getPartial = async (url) => {
    try {
        const response = await fetch(url);
        const html = await response.text();
        document.getElementById('partialScreen').innerHTML = html;
    } catch (error) {
        document.getElementById('partialScreen').innerHTML = error;
    }
}