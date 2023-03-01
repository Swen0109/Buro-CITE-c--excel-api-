//Functie om alle studenten en hun leeftijd en id op te halen en in een array studenten met objects te zetten
function getInfoFromHtml() {

    let items = $(".column");
    var student = {};
    var studenten = [];
  
    $(items).each(function (index, row) {
        $(row.children).each(function (idx, item) {
            let i = $(item).attr("name");
            student[i] = $(item).text();
        })
        studenten[index] = student;
        student = {};
    })
    return studenten;
}

//Functie om 1 student op te halen en zijn id, leeftijd en naam op te halen en in een array te zetten.
function getSingleStudentInfo() {

    let info = $(".active_row");
    var student = {};
    var studenten = [];
    $(info).each(function (index, tr) {
        $(tr.children).each(function (idx, item) {
            let i = $(item).attr("name");
            student[i] = $(item).text();
        });
        studenten[index] = student;
        student = {};
    });
    return studenten;
}

//Functie om met ajax de opgehaalde informatie van 1 of alle studenten naar een controller functie te sturen.
function sendStudentInfo(studenten) {

    $.ajax({
        url: "/GcExcel/PostStudentInfo",
        type: "POST",
        data: { studenten: studenten },
        success: function () { alert("You're students have successfuly been exported to excel.") },
        error: function () { alert("Failed to export students to excel...") },
    });  
}

function sendSelectedStudentInfo(studenten) {

    $.ajax({
        url: "/GcExcel/PostStudentInfo",
        type: "POST",
        data: { studenten: studenten },
        error: function () { alert("Failed to export students to excel...") },
    });
}
//Een functie met alle functies die te maken hebben met het doorsturen of gebruiken van de html data.
$(document).ready(function () {

    var submitAllStudents = document.getElementById("allInfo");

    //functie om als er op een row met een student word geklikt de class active_row word gegeven zodat deze student word opgehaald bij submit.
    $("#infoTable tr").click(function () {
        $(this).toggleClass("active_row");

        if ($(this).hasClass("active_row") == true) {
            submitAllStudents.className = "displayNone";
        }

        else if ($("#infoTable tr").hasClass("active_row") == false) {
            submitAllStudents.className = "display";
        }
    });

    //Functie om alle data van studenten uit de html table op te halen en naar de sendStudentInfo functie te sturen met de parameter result (bevat alle studenten.)
    $("#allInfo").click(function () {
        $(this).addClass("column");
        let result = getInfoFromHtml();
        sendStudentInfo(result);
    });

    //Functie die als er in de html op submit word geklikt de geselecteerde studenten ophaald en die vervolgens ook doorstuurd naar de sendStudentInfo functie maar dan met alleen de geselecteerde student.
    $("#btnSubmit").click(function () {
        let singleInfo = getSingleStudentInfo();
        submitAllStudents.className = "display";

        if (singleInfo == 0) {
            alert("You must select at least 1 student to export to excel!");
        }
        
        else if (singleInfo.length == 1) {
            alert(JSON.stringify(singleInfo[0].StudentName + "'s been succesfuly exported to excel!"));
            $("#infoTable tr").removeClass("active_row");
            sendSelectedStudentInfo(singleInfo);
        }

        else {
            alert("The selected students have been exported to excel.");
            sendSelectedStudentInfo(singleInfo);
            $("#infoTable tr").removeClass("active_row");
        }
    });
});