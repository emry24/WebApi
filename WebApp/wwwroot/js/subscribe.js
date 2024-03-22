function validateForm() {
    var checkboxes = document.querySelectorAll('input[type="checkbox"]');
    var checked = false;
    checkboxes.forEach(function (checkbox) {
        if (checkbox.checked) {
            checked = true;
        }
    });
    if (!checked) {
        alert("Please select at least one checkbox.");
        return false;
    }
    return true;
}
