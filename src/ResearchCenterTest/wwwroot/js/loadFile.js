function loadFileContent(urn) {
  //const host = "https://localhost:7083/";

  var queryString = window.location.hash;

  const match = queryString.match(/id=(\d+)/);
  const id = match ? match[1] : null;

  fetch(`${host}${urn}/${id}`)
    .then((response) => response.arrayBuffer())
    .then((data) => {
      const decoder = new TextDecoder("utf-8");
      const text = decoder.decode(new Uint8Array(data));
      document.getElementById("FileCard").textContent = text;
    })
    .catch((error) => console.error("Error fetching the file:", error));
}
