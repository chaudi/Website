async function fetchAsync(url) {
    var response = await fetch(url);
    var data = await response.json();
    return data;
}
//# sourceMappingURL=server.js.map