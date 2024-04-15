function addLearningDetail() {
    var container = document.getElementById("learning-details-container");
    var index = container.children.length; // Get the index of the new learning detail

    var detailDiv = document.createElement("div");
    detailDiv.classList.add("learning-detail");

    var input = document.createElement("input");
    input.type = "text";
    input.name = "LearningDetails[" + index + "].Description"; // Set the name attribute dynamically
    detailDiv.appendChild(input);

    var removeButton = document.createElement("button");
    removeButton.type = "button";
    removeButton.classList.add("btn", "btn-sm", "btn-danger");
    removeButton.textContent = "Remove";
    removeButton.onclick = function () {
        removeLearningDetail(index);
    };
    detailDiv.appendChild(removeButton);

    container.appendChild(detailDiv);
}

function removeLearningDetail(index) {
    var container = document.getElementById("learning-details-container");
    var detailToRemove = container.children[index];
    container.removeChild(detailToRemove);
}

function addProgramDetail() {
    var container = document.getElementById("program-details-container");
    var index = container.children.length; // Get the index of the new program detail

    var detailDiv = document.createElement("div");
    detailDiv.classList.add("program-detail");

    var numberLabel = document.createElement("p");
    numberLabel.textContent = "Number";
    detailDiv.appendChild(numberLabel);

    var numberInput = document.createElement("input");
    numberInput.type = "number";
    numberInput.name = "ProgramDetails[" + index + "].Number"; // Set the name attribute dynamically
    detailDiv.appendChild(numberInput);

    var titleLabel = document.createElement("p");
    titleLabel.textContent = "Title";
    detailDiv.appendChild(titleLabel);

    var titleInput = document.createElement("input");
    titleInput.type = "text";
    titleInput.name = "ProgramDetails[" + index + "].Title"; 
    detailDiv.appendChild(titleInput);

    var descriptionLabel = document.createElement("p");
    descriptionLabel.textContent = "Description";
    detailDiv.appendChild(descriptionLabel);

    var descriptionInput = document.createElement("input");
    descriptionInput.type = "text";
    descriptionInput.name = "ProgramDetails[" + index + "].Description"; 
    detailDiv.appendChild(descriptionInput);

    var removeButton = document.createElement("button");
    removeButton.type = "button";
    removeButton.classList.add("btn", "btn-sm", "btn-danger");
    removeButton.textContent = "Remove";
    removeButton.onclick = function () {
        removeProgramDetail(index);
    };
    detailDiv.appendChild(removeButton);

    container.appendChild(detailDiv);
}

function removeProgramDetail(index) {
    var container = document.getElementById("program-details-container");
    var detailToRemove = container.children[index];
    container.removeChild(detailToRemove);
}
