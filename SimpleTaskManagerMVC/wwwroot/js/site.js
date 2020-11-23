// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function checkDate() {
    var selectedText = document.getElementById('DueDate').value;
    var selectedDate = new Date(selectedText);
    var now = new Date();
    if (selectedDate < now) {
    alert("Due date must be in the future");
        return false;
    }
    return true;
}

function validateForm() {
    var taskName = document.getElementById('Name').value;
    if (taskName == null) {
        alert("Task name is required!")
        return false;
    }

    var validDate = checkDate();
    if (!validDate) {
        return false;
    }

    return true;
}
