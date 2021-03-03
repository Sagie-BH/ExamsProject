const headerForm = document.getElementById("headerForm");
const saveExamHeaderBtn = document.getElementById("saveExamHeaderBtn");
const examHeader = document.getElementById("examHeader");
const textAreaInput = document.getElementById("textAreaInput");

let index = 0;

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

// Save Header Input Values To Labels
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
    }
    else {
        checkBox.parentElement.classList.remove("pushIcon");
    }
}

// Bold Text
const textBold = (cb) => {
    if (cb.checked) {
        textAreaInput.style.fontWeight = "bold";
    }
    else {
        textAreaInput.style.fontWeight = "normal";
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
const setTextAlignment = (alignment) => {
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



// Save Text Input To Object
let textInputCount = 0;
document.getElementById("textInputBtn").addEventListener('click', (e) => {
    e.preventDefault();
    // Creating Text Input Object From Inputs
    let examTextInput = new ExamTextInput();
    examTextInput.Text = document.getElementById("textAreaInput").value;
    examTextInput.Color = document.getElementById("textColorPicker").value;
    examTextInput.FontSize = document.getElementById("textFontSizeInput").value;
    examTextInput.Alignment = document.getElementById("textAlignmentSelect").value;
    examTextInput.Bold = document.getElementById("textBoldInput").checked;
    examTextInput.Underline = document.getElementById("textUnderlineInput").checked;
    examTextInput.Italic = document.getElementById("textItalicInput").checked;
    examTextInput.Index = index++;
    //localStorage.setItem("ExamText_" + textInputCount++, JSON.stringify(examTextInput));

    AddExamTextToStorage(examTextInput);

    // Validate TextInputFrom & TextArea Not Empty
    $(textInputForm).validate().form();
    if ($(textInputForm).valid() == true) {
        // Add Text Input To Exam
        $.ajax({
            type: "POST",
            url: 'AddTextInput/',
            data: JSON.stringify(examTextInput),
            dataType: "html",
            contentType: "application/json; charset=utf-8",
            success: (data, info) => {
                console.log(info);
                document.getElementById("examInputSection").insertAdjacentHTML('beforeend', data);
                document.getElementById("questionInput").classList.remove("hide");
            },
            error: (data, err) => {
                console.log(data);
                console.log(err);
            }
        });
        textInputForm.reset();
        Array.from(document.getElementsByClassName("checkBoxInput"))
            .forEach(cb => {
                cb.parentElement.classList.remove("pushIcon");
            });
        $('input:checkbox').removeAttr('checked');
        textAreaInput.removeAttribute('style');
        document.getElementById("textInputForm").classList.add("hide")
    }
});

// Showing Text Input 
document.getElementById("addExamText").addEventListener('click', () => {
    document.getElementById("textInputForm").classList.remove("hide");
    document.getElementById("questionInput").classList.add("hide");
});


// Add Image Input To Exam
let imageCount = 0;
document.getElementById("addExamImage").addEventListener('click', () => {
    document.getElementById("imageInputForm").classList.remove("hide");
    document.getElementById("questionInput").classList.add("hide");
    let newImage = document.createElement('img');
    let newDiv = document.createElement('div');
    newDiv.appendChild(newImage);
    newDiv.setAttribute('id', "examImageDiv" + imageCount);
    newImage.classList.add('col-4');
    newImage.setAttribute('id', "examImage" + imageCount);
    document.getElementById("examInputSection").appendChild(newDiv);
});

// Add Image To Exam
document.getElementById("imageFileInput").addEventListener('change', (image) => {
    let newImage = document.getElementById("examImage" + imageCount)
    newImage.src = URL.createObjectURL(image.target.files[0]);
    newImage.onload = function () {
        URL.revokeObjectURL(newImage.src) // free memory
    }
    newImage.classList.add('d-block','mr-auto');
    newImage.style.width = "100%";
});

// Change Image Alignment
let newImageAlignment = "";
const setImageAlignment = (alignment) => {
    const img = document.getElementById("examImage" + imageCount);
    switch (alignment.value) {
        case "0":
            img.classList.remove('mx-auto', 'ml-auto');
            img.classList.add('mr-auto');
            break;
        case "1":
            img.classList.remove('ml-auto', 'mr-auto');
            img.classList.add('mx-auto');
            break;
        case "2":
            img.classList.remove('mr-auto', 'mx-auto');
            img.classList.add('ml-auto');
            break;
    }
    newImageAlignment = alignment.options[alignment.selectedIndex].text;
}

// Change Image Size
let newImageSize = "";
const setImageSize = (size) => {
    const img = document.getElementById("examImage" + imageCount);
    switch (size.value) {
        case "0":
            img.classList.remove('col-6', 'col-8', 'col-10', 'col-12');
            img.classList.add('col-4');
            break;
        case "1":
            img.classList.remove('col-4', 'col-8', 'col-10', 'col-12');
            img.classList.add('col-6');
            break;
        case "2":
            img.classList.remove('col-4', 'col-6', 'col-10', 'col-12');
            img.classList.add('col-8');
            break;
        case "3":
            img.classList.remove('col-4', 'col-6', 'col-8', 'col-12');
            img.classList.add('col-10');
            break;
        case "4":
            img.classList.remove('col-4', 'col-6', 'col-8', 'col-10');
            img.classList.add('col-12');
            break;
    }
    newImageSize = size.options[size.selectedIndex].text;
}

// Saving ExamImage To Storage 
document.getElementById('SaveNewImageBtn').addEventListener('click', (e) => {
    e.preventDefault();
    let newImage = document.getElementById("examImage" + imageCount)
    let newImageToStore = {
        ImagePath: newImage.src,
        ImageSize: newImageSize,
        Alignment: newImageAlignment,
        Index: index++
    };
    imageCount++;
    //localStorage.setItem('ExamImage_' + imageCount, JSON.stringify(newImageToSend));
    AddExamImageToStorage(newImageToStore);
    document.getElementById('imageInputForm').classList.add('hide');
    document.getElementById("questionInput").classList.remove("hide");
});

// Adding TextInput To Storage List
const AddExamTextToStorage = (textInput) => {
    let ExamTexts = JSON.parse(localStorage.getItem('ExamTexts'));
    if (ExamTexts == null) {
        ExamTexts = [];
    }
    ExamTexts.push(textInput);
    localStorage.setItem('ExamTexts', JSON.stringify(ExamTexts));
};
// Adding ImageInput To Storage List
const AddExamImageToStorage = (imageInput) => {
    let ExamImages = JSON.parse(localStorage.getItem('ExamImages'));
    if (ExamImages == null) {
        ExamImages = [];
    }
    ExamImages.push(imageInput);
    localStorage.setItem('ExamImages', JSON.stringify(ExamImages));
};