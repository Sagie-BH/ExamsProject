const headerForm = document.getElementById("headerForm");
const saveExamHeaderBtn = document.getElementById("saveExamHeaderBtn");
const examHeader = document.getElementById("examHeader");

let inputIndex = 0;

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
    let examHeader = { };
    examHeader.ExamTitle = document.getElementById("examTitleInput").value
    document.getElementById("examTitleLbl").innerText = document.getElementById("examTitleInput").value;
    examHeader.ExamDescription = document.getElementById("examDescriptionInput").value;
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
const textBold = (cb, input) => {
    const textAreaInput = document.getElementById(input + "AreaInput");

    if (cb.checked) {
        textAreaInput.style.fontWeight = "bold";
    }
    else {
        textAreaInput.style.fontWeight = "normal";
    }
    CheckedBoxEvent(cb);
}

// Italic Text
const textItalic = (cb, input) => {
    const textAreaInput = document.getElementById(input + "AreaInput");
    if (cb.checked) {
        textAreaInput.style.fontStyle = "italic";
    }
    else {
        textAreaInput.style.fontStyle = "normal";
    }
    CheckedBoxEvent(cb);
}

// Underline Text
const textUnderline = (cb, input) => {
    const textAreaInput = document.getElementById(input + "AreaInput");
    if (cb.checked) {
        textAreaInput.style.textDecoration = "underline";
    }
    else {
        textAreaInput.style.textDecoration = "none";
    }
    CheckedBoxEvent(cb);
}

// Font Size
let textInputFontSize = 20;
const setFontSize = (size, input) => {
    const textAreaInput = document.getElementById(input + "AreaInput");
    switch (size) {
        case "0":
            textInputFontSize = 18;
            break;
        case "1":
            textInputFontSize = 28;
            break;
        case "2":
            textInputFontSize = 40;
            break;
        case "3":
            textInputFontSize = 54;
            break;
        case "4":
            textInputFontSize = 72;
            break;
    }
    textAreaInput.style.fontSize = textInputFontSize + "px";
    return textInputFontSize;
}

// Font Color
const setTextColor = (color, input) => {
    const textAreaInput = document.getElementById(input + "AreaInput");
    textAreaInput.style.color = color;
}

// Text Alignment
const setTextAlignment = (alignment, input) => {
    const textAreaInput = document.getElementById(input + "AreaInput");
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

// Getting Text Input Values From Inputs - Returns Exam Input Object
const GetTextInputValues = (inputID) => {
    let examInput = { };
    examInput.Text = document.getElementById(inputID + "AreaInput").value;
    examInput.Color = document.getElementById(inputID + "ColorPicker").value;
    const fontSizeInput = document.getElementById(inputID + "FontSizeInput");
    examInput.FontSize = setFontSize(fontSizeInput.value, inputID);
    examInput.Alignment = document.getElementById(inputID + "AlignmentSelect").value;
    examInput.Bold = document.getElementById(inputID + "BoldInput").checked;
    examInput.Underline = document.getElementById(inputID + "UnderlineInput").checked;
    examInput.Italic = document.getElementById(inputID + "ItalicInput").checked;
    return examInput;
}

// Save Text Input To Object
let textInputCount = 0;
let answerArray = [];
const SaveTextInput = (inputID) => {
    // Validate TextInputFrom & TextArea Not Empty
    const currentInputForm = document.getElementById(inputID + 'InputForm')
    $(currentInputForm).validate().form();
    if ($(currentInputForm).valid() == true) {
        let examTextInput = GetTextInputValues(inputID);
        examTextInput.Index = inputIndex++;
        examTextInput.IdName = 'text';
        AddExamTextToStorage(examTextInput);
        AddTextInputTemplate(examTextInput);
        document.getElementById("questionInput").classList.remove("hide");
        $(currentInputForm).remove();
        return examTextInput;
    }
}

// Adding Text Input Template To Exam
const AddTextInputTemplate = (examTextInput, isAsync) => {
    return $.ajax({
        async: isAsync,
        type: "POST",
        url: 'AddTextInput/',
        data: JSON.stringify(examTextInput),
        dataType: "html",
        contentType: "application/json; charset=utf-8",
        success: (data, info) => {
            console.log(info);
            document.getElementById("examInputSection").insertAdjacentHTML('beforeend', data);
        },
        error: (err) => {
            console.log(err);
        }
    });
}

// Question Saving
const SaveQuestion = inputID => {
    const questionInputForm = document.getElementById('questionInputForm')
    $(questionInputForm).validate().form();
    if ($(questionInputForm).valid() == true) {
        let newQuestion = {};
        newQuestion.QuestionText = GetTextInputValues(inputID);
        newQuestion.Index = inputIndex++;
        newQuestion.IdName = 'question';
        let answerArr = [];
        let baseAnswer = GetTextInputValues('answer');
        const answersInputArr = document.getElementsByClassName('answerInput');
        AddTextInputTemplate(newQuestion.QuestionText, false)
        let answerOptionIndex = 0;
        Array.from(answersInputArr).forEach(input=> {
            let inputIdParts = input.id.split('AreaInput');
            let newAnswer = { };
            newAnswer.AnswerText = { ...baseAnswer };
            newAnswer.AnswerText.Text = input.value;
            newAnswer.IsRightAnswer = document.getElementById(inputIdParts[0] + 'IsRightCb').checked;
            newAnswer.Index = answerOptionIndex++;
            answerArr.push(newAnswer);
            AddTextInputTemplate(newAnswer.AnswerText, false);
        });
        answerOptionIndex = 0;
        newQuestion.AnswerOptions = answerArr;
        AddExamQuestionToStorage(newQuestion);
        document.getElementById("questionInput").classList.remove("hide");
        $(questionInputForm).remove();
    }
    return false;
}

// Getting Text Input Partial View
const GetTextInput = (textInputType) => {
    $.ajax({
        type: "POST",
        url: 'GetTextInput/',
        data: JSON.stringify(textInputType),
        dataType: "html",
        contentType: "application/json; charset=utf-8",
        success: (data, info) => {
            console.log(data);
            document.getElementById("inputsSection").insertAdjacentHTML('beforeend', data);
            document.getElementById("questionInput").classList.add("hide");
        },
        error: (data, err) => {
            console.log(data);
            console.log(err);
        }
    });
}

// Add Image Input To Exam
let imageCount = 0;
document.getElementById("addExamImage").addEventListener('click', () => {
    document.getElementById("imageInputForm").classList.remove("hide");
    document.getElementById("questionInput").classList.add("hide");
    let newImage = document.createElement('img');
    let newDiv = document.createElement('div');
    newDiv.appendChild(newImage);
    newDiv.setAttribute('id', "examImageDiv" + imageCount);
    newDiv.classList.add('mb-2','mt-1');
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
    newImage.classList.add('d-block', 'mr-auto');
    newImage.style.width = "100%";
});

// Change Image Alignment
let newImageAlignment = "0";
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
    newImageAlignment = alignment.options[alignment.selectedIndex].Text;
}

// Change Image Size
let newImageSize = "0";
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
    newImageSize = size.options[size.selectedIndex].Text;
}

// Saving ExamImage To Storage 
document.getElementById('SaveNewImageBtn').addEventListener('click', (e) => {
    e.preventDefault();
    let newImage = document.getElementById("examImage" + imageCount)
    let newImageToStore = {
        ImagePath: newImage.src,
        ImageSize: newImageSize,
        Alignment: newImageAlignment,
        Index: inputIndex++
    };
    imageCount++;
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

// Adding QuestionInput To Storage List
const AddExamQuestionToStorage = (questionInput) => {
    let Questions = JSON.parse(localStorage.getItem('ExamQuestions'));
    if (Questions == null) {
        Questions = [];
    }
    Questions.push(questionInput);
    localStorage.setItem('ExamQuestions', JSON.stringify(Questions));
};

// Add Answer
let answerIndex = 0;
const AddAnswer = () => {
    const answerDiv = document.getElementById('answerDiv');
    const answerCb = document.getElementById('answerIsRightCb')
    const answerAreaInput = document.getElementById('answerAreaInput');
    let answerDivClone = answerDiv.cloneNode(false);
    let answerCbClone = answerCb.cloneNode(false);
    let answerInputClone = answerAreaInput.cloneNode(false);
    answerInputClone.id = 'answer' + answerIndex + 'AreaInput';
    answerInputClone.value = '';
    answerCbClone.id = 'answer' + answerIndex++ + 'IsRightCb';
    answerCbClone.value = false;
    answerDivClone.insertAdjacentElement('beforeend', answerInputClone);
    answerDivClone.insertAdjacentElement('beforeend', answerCbClone);
    document.getElementById('anwersSection').insertAdjacentElement('beforeend', answerDivClone);
    return false;
}
// Answers Group Font Size
const setAnswersFontSize = (size) => {
    const answersInput = document.getElementsByClassName('answerInput');
    Array.from(answersInput).forEach(input => {
        let inputIdParts = input.id.split('AreaInput');
        setFontSize(size, inputIdParts[0]);
    });
};

// Answers Group Bold
const AnwersTextBold = (cb) => {
    const answersInput = document.getElementsByClassName('answerInput');
    Array.from(answersInput).forEach(input => {
        let inputIdParts = input.id.split('AreaInput');
        textBold(cb, inputIdParts[0]);
    });
};

// Answers Group Italic
const AnswersTextItalic = (cb) => {
    const answersInput = document.getElementsByClassName('answerInput');
    Array.from(answersInput).forEach(input => {
        let inputIdParts = input.id.split('AreaInput');
        textItalic(cb, inputIdParts[0]);
    });
};

// Answers Group Underline
const AnswersTextUnderline = (cb) => {
    const answersInput = document.getElementsByClassName('answerInput');
    Array.from(answersInput).forEach(input => {
        let inputIdParts = input.id.split('AreaInput');
        textUnderline(cb, inputIdParts[0]);
    });
};

// Answers Group Alignment
const AnswersTextAlignment = (alignment) => {
    const answersInput = document.getElementsByClassName('answerInput');
    Array.from(answersInput).forEach(input => {
        let inputIdParts = input.id.split('AreaInput');
        setTextAlignment(alignment, inputIdParts[0]);
    });
};

// Answers Group Text Color
const AnswersTextColor = (color) => {
    const answersInput = document.getElementsByClassName('answerInput');
    Array.from(answersInput).forEach(input => {
        let inputIdParts = input.id.split('AreaInput');
        setTextColor(color, inputIdParts[0]);
    });
};

// Save ExamSettings
const SaveExamSettings = () => {
    const dueDateValidationSpan = document.getElementById('dueDateValidationSpan');
    const timeLimitValidationSpan = document.getElementById('timeLimitValidationSpan');
    if (dueDateValidationSpan.innerText == '' && timeLimitValidationSpan.innerText == '') {
        let ExamSettings = {};
        ExamSettings.IsExamPrivate = document.getElementById('examPrivacyInput').checked;
        ExamSettings.ExamDueDate = document.getElementById('dueDateInput').value;
        ExamSettings.ExamTimeLimit = document.getElementById('timeLimitInput').value;
        localStorage.setItem('ExamSettings', JSON.stringify(ExamSettings));
    };
    return false;
}


// OnChange Due Date 3 Months From Today Validation
const ValidateDueDate = (dueDateInput) => {
    const validationSpan = document.getElementById('dueDateValidationSpan');
    let enteredMS = new Date(dueDateInput.value.replace('-', '/')).getTime();
    let currentMS = new Date().getTime();
    let threeMonthMS = new Date(new Date().setMonth(new Date().getMonth() + 3)).getTime();
    if (enteredMS >= threeMonthMS) {
        dueDateInput.setAttribute('aria-invalid', 'true');
        validationSpan.innerHTML = 'Due date can not surpass 3 months from now';
        return;
    }
    if (currentMS >= enteredMS) {
        dueDateInput.setAttribute('aria-invalid', 'true');
        validationSpan.innerHTML = 'Please enter future date';
        return;
    }
    validationSpan.innerHTML = '';
    dueDateInput.setAttribute('aria-invalid', 'false');
}

const SaveExam = (teacherId) => {
    SaveExamSettings();
    let newExam = {};
    newExam.TeacherId = teacherId;
    newExam.ExamHeader = JSON.parse(localStorage.getItem('ExamHeader'));
    newExam.Settings = JSON.parse(localStorage.getItem('ExamSettings'));
    newExam.Questions = JSON.parse(localStorage.getItem('ExamQuestions'));
    newExam.ExamTexts = JSON.parse(localStorage.getItem('ExamTexts'));
    newExam.ExamImages = JSON.parse(localStorage.getItem('ExamImages'));
    SendExamToServer(newExam);
    return false;
}

// Saving Exam To Server
const SendExamToServer = (newExam) => {
    $.ajax({
        type: "POST",
        url: 'SaveNewExam/',
        data: JSON.stringify(newExam),
        contentType: "application/json",
        success: (data, info) => {
            console.log(data);
        },
        error: (data, err) => {
            console.log(data);
            console.log(err);
        }
    });
};

