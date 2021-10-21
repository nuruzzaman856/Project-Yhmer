
// Write your Javascript code.

function logout() {
    console.log("Logging out");
    delete_cookie(".AspNetCore.Session", "/", "localhost");
    window.location.replace("https://localhost:44377/");
}

function delete_cookie(name, path, domain) {
    if (get_cookie(name)) {
        document.cookie = name + "=" +
            ((path) ? ";path=" + path : "") +
            ((domain) ? ";domain=" + domain : "") +
            ";expires=Thu, 01 Jan 1970 00:00:01 GMT";
    }
}

function get_cookie(name) {
    return document.cookie.split(';').some(c => {
        return c.trim().startsWith(name + '=');
    });
}

function AddSkillRow() {
    //Gets the first object with the id SkillName
    var Input = document.getElementById("SkillsNames").value;
    Input = Input.trim();
    //Gets the first object with the id SkillContainer
    var Container = document.getElementById("SkillContainer");
    if (Container.childElementCount < 10) {
        //Needs check for empty
        if (Input != null && Input.length >= 1) {
            //Create a hidden input
            var input = document.createElement("input");
            //Set property
            input.name = "SkillName";
            input.hidden = true;
            input.value = Input;

            //Create a label
            var Label = document.createElement("label");
            //Set property
            Label.className = "col-4 col-form-label";
            Label.name = "SkillName";
            Label.appendChild(document.createTextNode(Input));

            //Create a div
            var SkillsContainerDiv = document.createElement("div");

            var deleteButton = document.createElement("button");
            deleteButton.className = "btn btn-danger";
            deleteButton.appendChild(document.createTextNode("X"));
            deleteButton.type = "Button";
            deleteButton.style = "Margin-top:0rem;"
            deleteButton.addEventListener('click', function () {
                RemoveStudentSkill(this);
            });

            SkillsContainerDiv.appendChild(Label);
            SkillsContainerDiv.appendChild(input);
            SkillsContainerDiv.appendChild(deleteButton);
            Container.appendChild(SkillsContainerDiv);
        }
    }
}

function AddStudentSkillRows() {
    //Gets the first object with the id SkillName
    var InputName = document.getElementById("SkillName").value;
    InputName = InputName.trim();
    var InputSkillLevel = document.getElementById("SkillLevel").value;
    var Experience = document.getElementById("YearsOfExperience").value;

    console.log(InputSkillLevel);
    //Gets the first object with the id SkillContainer
    var Container = document.getElementById("SkillContainer");
    if (Container.childElementCount < 10) {
        if (InputName != null && InputSkillLevel != null && Experience != null && InputName.length >= 1) {
            //Creates a div
            var ContainerDiv = document.createElement("div");
            ContainerDiv.className = "row";
            //SkillName

            var Label = document.createElement("label");
            Label.appendChild(document.createTextNode("Kunskap: " + InputName));
            Label.style="Margin-left: 1rem"
            Label.className = "col-8 col-form-label";

            var Input1 = document.createElement("input");
            Input1.hidden = true;
            Input1.value = InputName;
            Input1.name = "SkillNameInput";
            var LabelText = "";
            //SkillLevel

            var Label2 = document.createElement("label");
            Label2.className = "col-form-label";
            Label2.style = "Margin-left: 1rem"

            switch (InputSkillLevel) {
                case '1':
                    LabelText = LabelText + " Kunskaps nivå: Teoretisk ";
                    break;
                case '2':
                    LabelText = LabelText + " Kunskaps nivå: Rookie ";
                    break;
                case '3':
                    LabelText = LabelText + " Kunskaps nivå: Medel ";
                    break;
                case '4':
                    LabelText = LabelText + " Kunskaps nivå: Hög ";
                    break;
                case '5':
                    LabelText = LabelText + " Kunskaps nivå: Professionell ";
                    break;
                default:
                    LabelText = LabelText + "";
                    break;
            }
            var Input2 = document.createElement("input");
            switch (InputSkillLevel) {
                case '1':
                    Input2.value = "Teoretisk";
                    break;
                case '2':
                    Input2.value = "Rookie";
                    break;
                case '3':
                    Input2.value = "Medel";
                    break;
                case '4':
                    Input2.value = "Hög";
                    break;
                case '5':
                    Input2.value = "Professionell";
                    break;
                default:
                    Input2.value = "";
                    break;
            }
            Input2.hidden = true;
            Input2.name = "SkillLevelInput";

            //Experience
            LabelText += "Antal år: " + Experience;

            var Input3 = document.createElement("input");
            Input3.hidden = true;
            Input3.value = Experience;
            Input3.name = "Experience";


            Label.appendChild(document.createTextNode(LabelText));
            ContainerDiv.appendChild(Label);
            ContainerDiv.appendChild(Input1);
            ContainerDiv.appendChild(Input2);
            ContainerDiv.appendChild(Input3);

            var deleteButton = document.createElement("button");
            deleteButton.className = "btn btn-danger";
            deleteButton.appendChild(document.createTextNode("X"));
            deleteButton.type = "Button";
            deleteButton.style = "Margin-top:0rem;"
            deleteButton.addEventListener('click', function () {
                RemoveStudentSkill(this);
            });

            ContainerDiv.appendChild(deleteButton);

            Container.appendChild(ContainerDiv);
        }

    }
}

function RemoveStudentSkill(e) {
    e.parentNode.parentNode.removeChild(e.parentNode);
}