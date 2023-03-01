function getAllTeachers() {

    let items = $(".column");
    var teacher = {};
    var teachers = [];
     
    $(items).each(function (index, row) {
        $(row.children).each(function (idx, item) {
            let i = $(item).attr("name");
            teacher[i] = $(item).text();
        })
        teachers[index] = teacher;
        teacher = {};
    })

    return teachers;
}

function getSelectedTeacher(){

    let selectedInfo = $(".active_row");
    var teacher = {};
    var teachers = [];

    $(selectedInfo).each(function (index, tr) {
        $(tr.children).each(function (idx, item) {
            let i = $(item).attr("name");
            teacher[i] = $(item).text();
        });
        teachers[index] = teacher;
        teacher = {};
    });

    return teachers;
}

function exportTeachersToExcel(teachers) {

    $.ajax({
        url: "/GcExcel/PostTeacherInfo",
        type: "POST",
        data: { teachers: teachers },
        success: function () { alert("The teachers have successfuly been exported to excel. Check you're files for the excel file with teachers.") },
        error: function () { alert("Unfortunately we failed to export the teachers to excel.") },
    }); 
}

function exportSelectedTeachersToExcel(teachers) {

    $.ajax({
        url: "/GcExcel/PostTeacherInfo",
        type: "POST",
        data: { teachers: teachers },
        error: function () { alert("Unfortunately we failed to export the teachers to excel.") },
    });
}

$(document).ready(function () {

    var getBtn = document.getElementById("allTeachers");

    $("#allTeachers").click(function () {
        $(this).addClass("column");
        let allTeachers = getAllTeachers();
        exportTeachersToExcel(allTeachers);
    })

    $("#teacherTable tr").click(function () {
        $(this).toggleClass("active_row");

        if ($(this).hasClass("active_row") == true) {
            getBtn.className = "displayNone";
        }

        else if ($("#teacherTable tr").hasClass("active_row") == false) {
            getBtn.className = "display";
        }
    });

    $("#submitTeacher").click(function () {
        let singleTeacher = getSelectedTeacher();
        getBtn.className = "display";
        
        if (singleTeacher == 0) {
            alert("You have to select at least 1 teacher before u can export!")
        }
 
        else if (singleTeacher.length == 1) {
            alert(JSON.stringify(singleTeacher[0].TeacherName + "'s been successfuly exported to excel! Check you're files for the excel file."));
            $("#teacherTable tr").removeClass("active_row");
            exportSelectedTeachersToExcel(singleTeacher);
        }       
                            
        else {
            alert("The selected teachers have been exported.");
            $("#teacherTable tr").removeClass("active_row");
            exportSelectedTeachersToExcel(singleTeacher);
        }
    });
});