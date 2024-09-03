let observer = new MutationObserver((mutations) => {
  for (let mutation of mutations) {
    if (mutation.type === "childList") {
      SetListenerOnForm();

      for (let node of mutation.addedNodes) {
        if (!(node instanceof HTMLElement)) continue;

        if (node.matches("form#CreateFile")) {
          FileExtensionsGetter();
        }
        if (node.matches("div#FileCard")) {
          loadFileContent("api/AppFiles/Download");
        }
      }
    } else if (mutation.type === "characterData") {
      console.log("Text content was changed.");
    }
  }
});

let demoElem = document.getElementById("content");
if (demoElem) {
  observer.observe(demoElem, { childList: true, subtree: true });
}
