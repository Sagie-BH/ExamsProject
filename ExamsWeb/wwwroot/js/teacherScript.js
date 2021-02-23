//const addSubjectBtn = document.getElementById("addSubjectBtn");
//const subjectsInput = document.getElementById("subjectsInput");
//const subjectsSection = document.getElementById("subjectsSection");
const invitationInput = document.getElementById("invitationInput");
const invitationTable = document.getElementById("invitationTable");


// Adding Subject title and description inputs

//let subjectCount = 1; 

//addSubjectBtn.addEventListener("click", (e) => {
//    e.preventDefault();
//    let newSubjectInputHTML = ` <div class="row" id="Subject${subjectCount}">
//        <div class="col-3">
//           <input type="text" name="Subjects[${subjectCount}].Title">
//        </div>
//        <div class="col-8">
//            <input class="DescriptionInputs" type="text"
//            id="Subjects_${subjectCount}__Description"
//            name="Subjects[${subjectCount}].Description">
//        </div>
//        <a onclick="return removeSubject(Subject${subjectCount})" class="col-1">X</a>
//     </div>`;
//    subjectsSection.insertAdjacentHTML('beforeend', newSubjectInputHTML)
//    subjectCount++;
//});



const removeSubject = (subjectToDelete) => {

    subjectToDelete.parentNode.removeChild(subjectToDelete);
}
let emailCount = 0;

const addEmail = () => {
    let emailAddres = invitationInput.value;
    let invitationHTML = `<tr>
        <td>${emailCount}</td>
        <td class="invitationsTd">
            <input readonly="readonly" name="Invitation[${emailCount}]" id="Invitation[${emailCount}]"/>
        </td>
    </tr>`
    invitationTable.insertAdjacentHTML('afterbegin', invitationHTML);
    document.getElementById(`Invitation[${emailCount}]`).value = emailAddres;
    invitationInput.value = "";
    emailCount++;
}