const headerForm = document.getElementById("headerForm");

const examTitleInput = document.getElementById("examTitleInput");
const examDescriptionInput = document.getElementById("examDescriptionInput");
const examSubTitleInput = document.getElementById("examSubTitleInput");
const examSubDescriptionInput = document.getElementById("examSubDescriptionInput");

const saveExamHeaderBtn = document.getElementById("saveExamHeaderBtn");

const examHeader = document.getElementById("examHeader");
const textAreaInput = document.getElementById("textAreaInput");


saveExamHeaderBtn.addEventListener("click", (e) => {
    e.preventDefault();
    $(headerForm).validate().form();
    if ($(headerForm).valid() == true) {
        SaveInputsToHeader();
        ChangeHeaderSection();
    };
});

// Hide & Show Header
const ChangeHeaderSection = () => {
    $(headerForm).hide();
    $(examHeader).show();
}

// Save Input Values To Labels
const SaveInputsToHeader = () => {
    document.getElementById("examTitleLbl").innerText = examTitleInput.value;
    document.getElementById("examDescriptionLbl").innerText = examDescriptionInput.value;
    document.getElementById("examSubjectTitleLbl").innerText = examSubTitleInput.value;
    document.getElementById("examSubjectDescriptionLbl").innerText = examSubDescriptionInput.value;
}

// Icon Checkbox Push Event
const CheckedBoxEvent = (checkBox) => {
    if (checkBox.checked) {
        checkBox.parentElement.classList.add("pushIcon");
        checkBox.parentElement.classList.remove("unpushIcon");
    }
    else {
        checkBox.parentElement.classList.add("unpushIcon");
        checkBox.parentElement.classList.remove("pushIcon");
    }
}

// Bold Text
const textBold = (cb) => {
    if (cb.checked) {
        textAreaInput.style.fontWeight = "bold"
    }
    else {
        textAreaInput.style.fontWeight = "normal"
    }
    CheckedBoxEvent(cb);
}
// Italic Text
const textItalic = (cb) => {
    if (cb.checked) {
        textAreaInput.style.fontStyle = "italic";
    }
    else {
        textAreaInput.style.fontStyle = "normal";
    }
    CheckedBoxEvent(cb);

}
// Underline Text
const textUnderline = (cb) => {
    if (cb.checked) {
        textAreaInput.style.textDecoration = "underline"
    }
    else {
        textAreaInput.style.textDecoration = "none"
    }
    CheckedBoxEvent(cb);
}
// Font Size
const setFontSize = (size) => {
    textAreaInput.style.fontSize = size + "px";
}
// Font Color
const setTextColor = (color) => {
    textAreaInput.style.color = color;
}
// Text Alignment
const setAlignment = (alignment) => {
    switch (alignment) {
        case "0":
            textAreaInput.style.textAlign = "Left";
            break;
        case "1":
            textAreaInput.style.textAlign = "Center";
            break;
        case "2":
            textAreaInput.style.textAlign = "Right";
            break;
    }
}
