function IsFirstNameEmpty() {
    if (document.getElementById('TxtFName').value == "") {
        return 'First Name should not be empty';
    }
    else {
        return "";
    }
}



function IsFirstNameInValid() {
    //alert(document.getElementById('TxtFName').value.indexOf("@"));
    if (document.getElementById('TxtFName').value.indexOf("@") == -1) {
        return 'First Name should not contain @';
    }
        else { return ""; }
}

function IsLastNameInValid() {
    if (document.getElementById('TxtLName').value.length <= 5) {
        return 'Last Name should not contain more 5 character';
    }
    else {
        return "";
    }
}

function IsValid() {
    var FirstNameEmptyMessage = IsFirstNameEmpty();
    var FirstNameInValidMessage = IsFirstNameInValid();
    var LastNameInValidMessage = IsLastNameInValid();

    var FinalErrorMessage = "Errors:";
    if (FirstNameEmptyMessage != "") {
        FinalErrorMessage += "\n" + FirstNameEmptyMessage;
    }
    if (FirstNameInValidMessage != "") {
        FinalErrorMessage += "\n" + FirstNameInValidMessage;
    }
    if (LastNameInValidMessage != "") {
        FinalErrorMessage += "\n" + LastNameInValidMessage;
    }

    if (FinalErrorMessage != "Errors:") {
        alert(FinalErrorMessage);
        return false;
    }
    else {
        return true;
    }
}
