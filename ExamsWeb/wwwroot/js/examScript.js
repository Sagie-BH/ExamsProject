const headerForm = document.getElementById("headerForm");

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
    let examHeader = new ExamHeader();
    examHeader.title = document.getElementById("examTitleInput").value
    document.getElementById("examTitleLbl").innerText = document.getElementById("examTitleInput").value;
    examHeader.description = document.getElementById("examDescriptionInput").value;
    document.getElementById("examDescriptionLbl").innerText = document.getElementById("examDescriptionInput").value;
    examHeader.subjectTitle = document.getElementById("examSubTitleInput").value;
    document.getElementById("examSubjectTitleLbl").innerText = document.getElementById("examSubTitleInput").value;
    examHeader.subjectDescription = document.getElementById("examSubDescriptionInput").value;
    document.getElementById("examSubjectDescriptionLbl").innerText = document.getElementById("examSubDescriptionInput").value;
    localStorage.setItem('ExamHeader', JSON.stringify(examHeader));
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


// Save Text Input
document.getElementById("textInputBtn").addEventListener('click', (e) => {
    e.preventDefault();
    let examTextInput = new ExamTextInput();
    examTextInput.Text = document.getElementById("textAreaInput").value;
    examTextInput.Color = document.getElementById("textColorPicker").value;
    examTextInput.FontSize = document.getElementById("textFontSizeInput").value;
    examTextInput.Alignment = document.getElementById("orientationSelect").value;
    examTextInput.Bold = document.getElementById("textBoldInput").value;
    examTextInput.Underline = document.getElementById("textUnderlineInput").value;
    examTextInput.Italic = document.getElementById("textItalicInput").value;
    //sessionStorage.setItem("textInput", JSON.stringify(examTextInput));

    // Add Text Input To Template
    $.ajax({
        type: "POST",
        url: 'AddTextInput/',
        data: JSON.stringify(examTextInput),
        dataType: "html",
        contentType: "application/json; charset=utf-8",
        success: (data, err) => {
            console.log(data);
            console.log(err);
            document.getElementById("examInputSection").insertAdjacentHTML('afterbegin', data);
            document.getElementById("textInputForm").style.display = "none";
        },
        error: (data, err) => {
            console.log(data);
            console.log(err);
        }
    });
});


const showTextInput = () => {
    document.getElementById("textInputForm").style.display = "block";
}