var data = [];
// //const host=window.location.href;
// const host = "https://localhost:7083/";
var url = `${host}api/Folders/WithFile`;
httpGetAsync(url, caltr);

const container = document.getElementById("tree-container");
const treeData = buildTree(data);
container.appendChild(createTreeElement(treeData));

function buildTree(data) {
  const nodeMap = new Map();
  const rootNodes = [];

  data.forEach((node) => {
    nodeMap.set(node.id, { ...node, children: [] });
  });

  data.forEach((node) => {
    const currentNode = nodeMap.get(node.id);
    if (node.parentId === 0) {
      rootNodes.push(currentNode);
    } else {
      const parentNode = nodeMap.get(node.parentId);
      if (parentNode) {
        parentNode.children.push(currentNode);
      }
    }
  });

  return rootNodes;
}

function createTreeElement(nodes) {
  const ul = document.createElement("ul");
  nodes.forEach((node) => {
    const li = document.createElement("li");
    const icon = document.createElement("span");

    const spanElement = setNodeIcon(node);
    spanElement.classList.add("tooltip-container");

    icon.classList.add("icon");

    const textSpan = document.createElement("span");
    textSpan.setAttribute("parentId", node.parentId);
    textSpan.setAttribute("id", node.id);
    textSpan.setAttribute("isFile", node.isFile);
    textSpan.setAttribute("fileId", node.fileId);
    textSpan.textContent = node.name;

    textSpan.addEventListener("click", function (e) {
      e.stopPropagation();
      document
        .querySelectorAll(".selected")
        .forEach((el) => el.classList.remove("selected"));
      this.classList.add("selected");

      let isFile = this.getAttribute("isFile");
      if (isFile === "true") {
        window.location.href = `#fileCard?id=${node.fileId}`;
      } else {
        window.location.href = `#home`;
      }
    });

    if (node.isFile) {
      const tooltipSpan = document.createElement("span");
      tooltipSpan.textContent = node.fileDescription;
      tooltipSpan.classList.add("tooltip");
      spanElement.appendChild(tooltipSpan);
    }

    li.appendChild(icon);
    li.appendChild(spanElement);

    li.appendChild(textSpan);

    if (node.children.length > 0) {
      li.classList.add("collapsible");
      const nestedUl = createTreeElement(node.children);
      nestedUl.classList.add("nested");
      li.appendChild(nestedUl);

      icon.addEventListener("click", function (e) {
        e.stopPropagation();
        li.classList.toggle("open");
        nestedUl.classList.toggle("show");
      });
    }

    ul.appendChild(li);
  });

  return ul;
}

function setNodeIcon(node) {
  const spanElement = document.createElement("span");
  const imgElement = document.createElement("img");
  let isFile = node.isFile;
  let extensionId = node.extensionId;

  if (isFile === true) {
    getFileExtenstion("api/FileExtensions", extensionId, imgElement);
    imgElement.alt = "Description of Image";
  } else {
    imgElement.src = "asserts/folder.svg";
    imgElement.alt = "Description of Image";
  }

  spanElement.appendChild(imgElement);
  return spanElement;
}

function httpGetAsync(theUrl, callback) {
  var xmlHttp = new XMLHttpRequest();
  xmlHttp.onreadystatechange = function () {
    if (xmlHttp.readyState == 4 && xmlHttp.status == 200)
      callback(xmlHttp.responseText);
  };
  xmlHttp.open("GET", theUrl, false);
  xmlHttp.send(null);
}
function caltr(data1) {
  this.data = JSON.parse(data1);
}

function getFileExtenstion(urn, id, element) {
  // const host = "https://localhost:7083";
  fetch(`${host}${urn}/${id}`)
    .then((response) => {
      if (!response.ok) {
        throw new Error("Network response was not ok");
      }

      return response.json();
    })
    .then((item) => {
      const svgEncoded = encodeURIComponent(item.icon.trim());

      element.src = `data:image/svg+xml;charset=utf-8,${svgEncoded}`;
    })
    .catch((error) => {
      console.error("There was a problem with the fetch operation:", error);
    });
}
