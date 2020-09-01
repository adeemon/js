const storage = new Storage();
const body = document.querySelector('.body');
const editor = document.querySelector('.editor-window-container');
const notesList = document.querySelector(".notes-list");
const saveButton = document.querySelector('.editor-window-savebutton');
const closeButton = document.querySelector('.editor-window-closebutton');
const addButton = document.querySelector('.add-button');
const editorTitleField = document.querySelector('.editor-window-title');
const editorTextField = document.querySelector('.editor-window-textarea');
let isEdditing = false;

document.querySelector(".editor-window-closebutton").addEventListener("click", closeModel, true);
document.querySelector(".editor-window-savebutton").addEventListener("click ", setupChanges, true);



storage.add(['Привет!', 'Тестовая заметочка']);

AddContainingNotes();

function AddContainingNotes() {
    notesList.innerHTML = '';
    let allNotes = storage.getAll();

    for (let key of allNotes) {
        console.log(key);
        AddNote(key.id, key[0], key[1]);
    }
}

function noteClick () {
    openModel();
    console.log(this);
    let noteId = this.id;

    let noteTitle = this.querySelector(".note-header").innerHTML;
    let noteText = this.querySelector(".note-text").innerHTML;

    setupChanges(noteId, noteTitle, noteText, this);
    
}

function setupChanges(id, title, text) {

    document.querySelector(".editor-window-title").value = title;
    document.querySelector(".editor-window-textarea").value = text;
    document.querySelector(".editor-window-id").value = id;

    document.querySelector(".editor-window-savebutton").addEventListener("click", changeNote)

}

const changeNote = () => {
    let editorNote = event.target.parentNode;
    
    let id = editorNote.querySelector(".editor-window-id").value;
    let newData = editorNote.querySelector(".editor-window-textarea").value;
    let newTitle = editorNote.querySelector(".editor-window-title").value;
    if (newData.length==0&&newTitle.length==0)
    {
        alert("Пустая заметка, для удаления воспользуйтесь кнопкой в углу");
        closeModel();
        return;
    }
    let changedNote = notesList.childNodes[id];

    console.log(changedNote);
    changedNote.querySelector(".note-text").innerHTML = newData;
    changedNote.querySelector(".note-header").innerHTML = newTitle;

    notesList.childNodes[id] = changedNote;

    console.log(notesList.childNodes[id]);
    closeModel();
    
}

function openModel() {
    let modal = document.querySelector(".modal");
    modal.style.display = "block";
}

function closeModel() {
    let modal = document.querySelector(".modal");
    modal.style.display = "none";
}



function RemoveClick() {

    if (confirm('Вы действительно хотите удалить заметку?')) {
        let note = this.parentNode;
        note = note.parentNode;
        console.log(note);
        storage.deleteById(note.getAttribute('id'));
        note.parentNode.removeChild(note);
    }
}



function AddNote(id, title, text) {

    if (text.length == 0) console.log("Пустая заметка")
    else {
        let bodyElement = document.createElement('div');
        bodyElement.className = 'note';
        bodyElement.id = id;
        bodyElement.style.opacity = 1;
        bodyElement.onclick = noteClick;

        let bodyElementHeader = document.createElement('h3');
        bodyElementHeader.className = 'note-header';
        bodyElementHeader.id = `${id}-title`;
        bodyElementHeader.appendChild(document.createTextNode(`${title}`));

        let bodyElementText = document.createElement('p');
        bodyElementText.className = 'note-text';
        bodyElementText.id = `${id}-text`;
        bodyElementText.appendChild(document.createTextNode(`${text}`));

        let bodyRemoveButton = document.createElement('button');
        bodyRemoveButton.className = 'note-remove-button';
        bodyRemoveButton.name = 'remove';
        bodyRemoveButton.value = 'delete';
        bodyRemoveButton.id = id;

        let bodyRemoveButtonImg = document.createElement('img');
        bodyRemoveButtonImg.src = "close.svg";
        bodyRemoveButtonImg.alt = "window closure icon";
        bodyRemoveButtonImg.id = id;
        bodyRemoveButtonImg.className = "note-remove-button-img";
        bodyRemoveButtonImg.onclick = RemoveClick;
        bodyRemoveButton.appendChild(bodyRemoveButtonImg);

        bodyElement.appendChild(bodyElementHeader);
        bodyElement.appendChild(bodyElementText);
        bodyElement.appendChild(bodyRemoveButton);

        notesList.appendChild(bodyElement);
    }
}