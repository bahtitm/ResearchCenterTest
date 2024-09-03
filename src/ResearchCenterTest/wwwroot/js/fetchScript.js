
// const host = "https://localhost:7083/";
function submitFormPost(urn, formId) {
//debugger
  const form = document.getElementById(formId);
  const formData = new FormData(form);
  const hasFile = Array.from(formData.values()).some(
    (value) => value instanceof File && value.name
  );

  if (hasFile) {
    fetch(`${host}${urn}`, {
      method: "POST",
      body: formData,
    })
      .then((response) => response.json())
      .then((data) => {
        console.log("Success:", data);
      })
      .catch((error) => {
        console.error("Error:", error);
      });
  } else {
    const data = Object.fromEntries(formData.entries());

    const jsonData = JSON.stringify(data);

    fetch(`${host}${urn}`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: jsonData,
    })
      .then((response) => response.json())
      .then((data) => {
        console.log("Success:", data);
      })
      .catch((error) => {
        console.error("Error:", error);
      });
  }
  //document.location.href = "/";
}
function RemoveEntity(urn, Id) {
  //const host = "https://localhost:7083"; // window.location;

  fetch(`${host}${urn}/${Id}`, {
    method: "DELETE",
    headers: {
      "Content-Type": "application/json",
    },
  })
    .then((response) => response.json())
    .then((data) => {
      console.log("Success:", data);
    })
    .catch((error) => {
      console.error("Error:", error);
    });

  document.location.href = "/";
}
function updateNameRequest(urn, name, id) {
  const data = { name: name, id: id };

  const jsonData = JSON.stringify(data);

  //const host = "https://localhost:7083"; 

  fetch(`${host}${urn}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: jsonData,
  })
    .then((response) => response.json())
    .then((data) => {
      console.log("Success:", data);
    })
    .catch((error) => {
      console.error("Error:", error);
    });

  document.location.href = "/";
}

function downloadFileFech(urn, id) {
 // const host = "https://localhost:7083";
  fetch(`${host}${urn}/${id}`)
    .then((response) => {
      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }

      const contentDisposition = response.headers.get("Content-Disposition");
      console.log(contentDisposition);
      let fileName = "downloaded-file";

      if (contentDisposition) {
        const match = contentDisposition.match(/filename="?(.+)"?/);

        if (match && match[1]) {
          fileName = match[1].split(";")[0];
        }
      }

      return response.blob().then((blob) => ({ blob, fileName }));
    })
    .then(({ blob, fileName }) => {
      const url = window.URL.createObjectURL(blob);
      const a = document.createElement("a");
      a.href = url;
      a.download = fileName;
      document.body.appendChild(a);
      a.click();
      a.remove();
      window.URL.revokeObjectURL(url);
    })
    .catch((error) => {
      console.error("Download error:", error);
    });
}
