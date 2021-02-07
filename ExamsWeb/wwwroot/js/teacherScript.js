const addSubjectBtn = document.getElementById("addSubjectBtn");
const subjectsInput = document.getElementById("subjectsInput");
const subjectsSection = document.getElementById("subjectsSection");
const invitationInput = document.getElementById("invitationInput");
const invitationTable = document.getElementById("invitationTable");

let subjectCount = 1; 
let emailCount = 1;
// Adding Subject title and description inputs

addSubjectBtn.addEventListener("click", (e) => {
    e.preventDefault();
    subjectsSection.innerHTML += ` <div class="row" id="Subject${subjectCount}">
        <div class="col-3">
           <input type="text" name="Subjects[${subjectCount}].Title">
        </div>
        <div class="col-8">
            <input class="DescriptionInputs" type="text"
            id="Subjects_${subjectCount}__Description"
            name="Subjects[${subjectCount}].Description">
        </div>
        <a onclick="return removeSubject(Subject${subjectCount})" class="col-1">X</a>
     </div>`;
    subjectCount++;
});


const removeSubject = (subjectToDelete) => {

    subjectToDelete.parentNode.removeChild(subjectToDelete);
}

const addEmail = () => {
    let emailAddres = invitationInput.innerHTML;
    invitationTable.innerHTML += `<tr>
        <td>${emailCount}</td>
        <td  class="invitationsTd">
            <input readonly="readonly" name="Invitation[${emailCount}] value=${invitationInput.value}/>"
        </td>
</tr>`
    emailCount++;
}