function SetListenerOnForm() {
  function handleFormChange(event) {
    event.preventDefault();

    if (event.currentTarget instanceof HTMLFormElement) {
      let selectedTreeNode = document.getElementsByClassName("selected");

      const formData = new FormData(event.currentTarget);
      const dataObject = {};
      formData.forEach((value, key) => {
        dataObject[key] = value;
      });
      if (selectedTreeNode) {
        if (selectedTreeNode[0].getAttribute("isFile") == "false") {
          if (this.elements.parentId)
            this.elements.parentId.value =
              selectedTreeNode[0].getAttribute("id");
          if (this.elements.folderId.value)
            this.elements.folderId.value =
              selectedTreeNode[0].getAttribute("id");
        }
      }
    } else {
      console.error("Event target is not a form element.");
    }
  }
  const folderForm = document.getElementById("CreateFolder");
  if (folderForm) {
    folderForm.addEventListener("change", handleFormChange);
  } else {
    console.error("Form element not found.");
  }
  const fileForm = document.getElementById("CreateFile");
  if (fileForm) {
    fileForm.addEventListener("change", handleFormChange);
  } else {
    console.error("Form element not found.");
  }
}
