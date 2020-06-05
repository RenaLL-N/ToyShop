const uri = 'api/Toys';
let toys = [];

function getToys() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayToys(data))
        .catch(error => console.error('Unable to get Toys.', error));
}

function addToy() {
    const addNameTextbox = document.getElementById('add-name');

    const toy = {
        name: addNameTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(toy)
    })
        .then(response => response.json())
        .then(() => {
            getToys();
            addNameTextbox.value = '';
        })
        .catch(error => console.error('Unable to add Toy.', error));
}

function deleteToy(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getToys())
        .catch(error => console.error('Unable to delete Toy.', error));
}

function displayEditForm(id) {
    const toy = toys.find(toy => toy.toyId === id);

    document.getElementById('edit-id').value = toy.toyId;
    document.getElementById('edit-name').value = toy.name;
    document.getElementById('editToy').style.display = 'block';
}

function updateToy() {
    const toyId = document.getElementById('edit-id').value;
    const toy = {
        toyId: parseInt(toyId, 10),
        name: document.getElementById('edit-name').value.trim()
    };

    fetch(`${uri}/${toyId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(toy)
    })
        .then(() => getToys())
        .catch(error => console.error('Unable to update toys.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editToy').style.display = 'none';
}


function _displayToys(data) {
    const tBody = document.getElementById('toys');
    tBody.innerHTML = '';


    const button = document.createElement('button');

    data.forEach(toy => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${toy.toyId})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteToy(${toy.toyId})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(toy.name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        td2.appendChild(editButton);
        td2.appendChild(deleteButton);
    });

    toys = data;
}