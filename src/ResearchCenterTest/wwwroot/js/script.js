document.addEventListener("DOMContentLoaded", function () {
  loadContent();

  window.addEventListener("hashchange", loadContent);
});
function loadContent() {
  const hash = location.hash || "#home";
  var parts = hash.split("?");

  fetchContent(parts[0].substring(1));
}

function fetchContent(page) {
  fetch(`Pages/${page}.html`)
    .then((response) => response.text())
    .then((data) => {
      document.getElementById("content").innerHTML = data;
    })
    .catch((error) => {
      console.error("Error loading content:", error);
      document.getElementById("content").innerHTML = "<p>Page not found.</p>";
    });
}
