function editField(labelId, textBoxId) {
    var label = document.getElementById(labelId);
    var textBox = document.getElementById(textBoxId);

    if (label.style.display !== "none") {
        textBox.value = label.innerText; // Copy current value
        label.style.display = "none";
        textBox.style.display = "inline-block";
        textBox.focus();
    } else {
        label.innerText = textBox.value; // Save new value
        label.style.display = "inline";
        textBox.style.display = "none";
    }

    return false; // Prevent page refresh
}
