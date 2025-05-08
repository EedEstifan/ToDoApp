document.addEventListener("DOMContentLoaded", function () {
    const folderContainer = document.getElementById("folderContainer");
    const addFolderBtn = document.getElementById("addFolderBtn");
    const contextMenu = document.getElementById("contextMenu");
    const addFolderTextBox = document.getElementById("addFolderTextBox");
    let selectedFolder = null;

    // Navigate to FolderManager.aspx with selected folder
    folderContainer.addEventListener("click", function (e) {
        const folderDiv = e.target.closest(".folder");
        if (folderDiv) {
            const folderName = folderDiv.dataset.folder;
            //this navigation i will chick later
            //window.location.href = `FolderManager.aspx?folder=${encodeURIComponent(folderName)}`;
        }
    });

    // Add folder
    addFolderBtn.addEventListener("click", function () {
        const folderName = addFolderTextBox.value.trim();
        addFolderTextBox.value = "";
        if (folderName !== "") {
            const div = document.createElement("div");
            div.classList.add("folder");
            div.dataset.folder = folderName;
            div.innerHTML = `<img src="pics/folder.png" alt="Folder"><span>${folderName}</span>`;
            folderContainer.appendChild(div);
        }
    });
    addFolderTextBox.addEventListener("keypress", function (e) {
        if (e.key === "Enter") addFolderBtn.click();
    });
    
    // Show context menu on right click
    folderContainer.addEventListener("contextmenu", function (e) {
        const folderDiv = e.target.closest(".folder");
        if (folderDiv) {
            e.preventDefault();
            selectedFolder = folderDiv;
            contextMenu.style.top = `${e.pageY}px`;
            contextMenu.style.left = `${e.pageX}px`;
            contextMenu.style.display = "block";
            console.log(e.target.closest(".folder"));
        }
    });

    // Hide context menu on click outside
    document.addEventListener("click", function () {
        contextMenu.style.display = "none";
    });

    // Rename folder
    document.getElementById("renameFolder").addEventListener("click", function () {
        if (selectedFolder) {
            const newName = prompt("Enter new name:", selectedFolder.dataset.folder);
            if (newName) {
                selectedFolder.dataset.folder = newName;
                selectedFolder.querySelector("span").innerText = newName;
            }
        }
    });

    // Delete folder
    document.getElementById("deleteFolder").addEventListener("click", function () {
        if (selectedFolder && confirm("Are you sure you want to delete this folder?")) {
            selectedFolder.remove();
        }
    });
});
