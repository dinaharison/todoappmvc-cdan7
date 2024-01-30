const hiddenInput = document.querySelector(".form-group.visually-hidden.utile");
const ajouterButton = document.getElementById("ajouterButton");
const modalLabel = document.getElementById("myModalLabel");
const idInput = document.getElementById("idInput");
const etatInput = document.getElementById("etatInput");
const tacheInput = document.getElementById("tacheInput");

/*function tableRowSelection(e) {
    var rowData = e.getElementsByTagName('td');
    modalLabel.innerHTML = "Modifier une Tache";
    idInput.value = rowData[0].innerHTML.trim();
    tacheInput.value = rowData[1].innerHTML.trim();
    etatInput.checked = rowData[2].querySelector('input[type="checkbox"]').checked;
    document.querySelectorAll(".form-group.hidden.utile").forEach(element => {
        element.className = "form-group utile";
    });
}*/

function modifierOnclick(e) {
    var rowData = e.parentElement.parentElement.children;
    modalLabel.innerHTML = "Modifier une Tache";
    idInput.value = rowData[0].innerHTML.trim();
    tacheInput.value = rowData[1].innerHTML.trim();
    etatInput.checked = rowData[2].querySelector('input[type="checkbox"]').checked;
    hiddenInput.className = "form-group utile mt-2";
}

ajouterButton.onclick = () => {
    modalLabel.innerHTML = "Ajouter une Tache";
    reset();
}

function reset() {
    idInput.value = "";
    tacheInput.value = "";
    etatInput.checked = false;
    hiddenInput.className = "form-group visually-hidden utile";
}
