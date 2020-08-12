
var URL = "https://localhost:44348/api/Quiz";

$(document).ready(function () {
    //$(".toshow").hide();
    //$("#cerateQuiz").show();
    //GetAllQuiz();
    
    
    //$.getScript("dx.all.js")
    //    .done(function (script, textStatus) {
    //        ShowAllQuizData();
    //    })
    //    .fail(function (jqxhr, settings, exception) {
    //        alert("fail to load script");
    //    });
    $("#addQuestion").click(function () {
        $(".toshow").hide();
        $("#addQues").show();
    });
    $("#editQuestion").click(function () {
        $(".toshow").hide();
        $("#editQues").show();
    });
    $("#addAnswer").click(function () {
        $(".toshow").hide();
        $("#addAns").show();
    });
    $("#editAnswer").click(function () {
        $(".toshow").hide();
        $("#editAns").show();
    });
    $("#addExplanation").click(function () {
        $(".toshow").hide();
        $("#addExpl").show();
    });
    $("#editExplanation").click(function () {
        $(".toshow").hide();
        $("#editExpl").show();
    });
    $("#addQuiz").click(function () {
        $(".toshow").hide();
        $("#createQuiz").show();
    });
    $("#editQuizBtn").click(function () {
        $(".toshow").hide();
        $("#editQuiz").show();
    });


});
function ShowAllQuizData() {
    $("#quizGridConatiner").dxDataGrid({        
        dataSource: DevExpress.data.AspNet.createStore({
            key: "q_id", //primary key or table for which api created
            loadUrl: URL,
            deleteUrl: URL + "/Delete",
            insertUrl: URL + "/Post",
            updateUrl: URL + "/Update",
            onBeforeSend: function (method, jQueryAjaxSettings) {
                jQueryAjaxSettings.xhrFields = { withCredentials: true };
                if (method === "insert") {
                    var json = $.parseJSON(jQueryAjaxSettings.data.values);                   
                    jQueryAjaxSettings.url += "?q_name=" + json.q_name + "&q_instruction=" + json.q_instruction + "&q_duration=" + json.q_duration
                        + "&q_status=" + json.q_status + "&q_tag=" + json.q_tag + "&q_adder=" + json.q_adder 
                    alert("Add Link: " + jQueryAjaxSettings.url);
                    DevExpress.ui.notify('Record Created successfully!!', 'success', 1000);
                }
                if (method === "update") {                    
                    var json = $.parseJSON(jQueryAjaxSettings.data.values);
                    jQueryAjaxSettings.url += "?q_id=" + json.q_id + "&q_name='" + json.q_name + "'&q_instruction='" + json.q_instruction + "'&q_duration=" + json.q_duration
                        + "&q_status=" + json.q_status + "&q_tag=" + json.q_tag + "&q_adder=" + json.q_adder;
                    alert("UPdate Link: " + jQueryAjaxSettings.url);
                    DevExpress.ui.notify('Record Updated successfully!!', 'success', 1000);
                }
                if (method === "delete") {                    
                    jQueryAjaxSettings.url += "?id=" + jQueryAjaxSettings.data.key;
                    //alert("Delete API: " + jQueryAjaxSettings.url);
                    DevExpress.ui.notify('Record Deleted successfully!!', 'success', 1000);
                }
            }
        }),
        editing: {
            mode: "form",
            allowAdding: true,
            allowUpdating: true,
            allowDeleting: true
        },
        paging: {
            enabled: true,
            size: 15
        },
        allowColumnResizing: true,
        columnMinWidth: 50,
        columnAutoWidth: true,
        rowAlternationEnabled: true,
        showRowLines: true,
        showBorders: true,
        pager: {
            showPageSizeSelector: true,
            allowedPageSizes: [5, 10, 15, 20],
            showInfo: true
        },
        filterRow: {
            visible: true
        },
        headerFilter: { visible: true },
        filterPanel: { visible: true },
        filterValue: [],
        wordWrapEnabled: true,
        searchPanel: {
            visible: true,
            width: 240,
            placeholder: "Search..."
        },
        columns: [
            {
                dataField: "q_id", width: 100, allowHeaderFiltering: false, caption: "Quiz Id",
                formItem: {
                    visible: false
                }
                //setCellValue: function (rowData, value) {
                //    rowData.CategoryTypeID = value;
                //    rowData.CategoryID = null;
                //    rowData.BasketID = null;
                //    rowData.RegionID = null;
                //    rowData.CountryID = null;
                //    rowData.SubstituteFullName = null;
                //    rowData.Tailend = false;
                //    rowData.CollaborationModelID = null;
                //},
                //lookup: {
                //    dataSource: Master.CategoryType,
                //    valueExpr: "CategoryTypeID",
                //    displayExpr: "CategoryTypeName",
                //    allowClearing: true
                //},
                
            },
            {
                dataField: "q_name", width: 120, allowHeaderFiltering: false, caption: "Quiz Name",
                //setCellValue: function (rowData, value) {
                //    rowData.CategoryID = value;
                //    rowData.BasketID = null;
                //    rowData.RegionID = null;
                //    rowData.CountryID = null;
                //    rowData.SubstituteFullName = null;
                //    rowData.Tailend = false;
                //},
                //lookup: {
                //    dataSource: function (options) {
                //        return {
                //            store: Master.Category,
                //            key: "CategoryID",
                //            filter: options.data ? [["CategoryID", "<>", null], "or", ["CategoryTypeID", "=", options.data.CategoryTypeID]] : null,
                //            paginate: true,
                //            pageSize: 10
                //        };
                //    },
                //    valueExpr: "CategoryID",
                //    displayExpr: "CategoryName",
                //    searchExpr: "CategoryName",
                //    allowClearing: true
                //}
                validationRules: [{ type: 'required' }]
            },
            {
                dataField: "q_instruction", width: 220, allowHeaderFiltering: false, caption: "Instruction"                
            },
            {
                dataField: "q_duration", width: 70, allowHeaderFiltering: false, caption: "Duration", dataType: "datetime",
                format: "shortTime"
            },
            {
                dataField: "q_status", width: 95, allowHeaderFiltering: true, caption: "Status"
            },
            {
                dataField: "q_tag", width: 70, allowHeaderFiltering: true, caption: 'Tag'
            },
            {
                dataField: "q_adder", width: 100, allowHeaderFiltering: true,caption: "Added By",
                formItem: {
                    visible: false
                }
            }            
        ],
        "export": {
            enabled: true,
            fileName: "NewFileName",
            allowExportSelectedData: false
        },
        onRowUpdating: function (options) {
            /* check if lookup coloumns is not undefined (coloumn will be undefined if it is not edited by user)
               then replace the colfoumn value, which was having data as object before, with single required field  */
            /*if (options.newData.CategoryTypeID)
                options.newData.CategoryTypeID = options.newData.CategoryTypeID;*/
            $.extend(options.newData, $.extend({}, options.oldData, options.newData));
        },
    });
}

//function GetAllQuiz() {
//    $.ajax({
//        url: "https://localhost:44348/api/Quiz/",
//        type: "GET",
//        dataType: "json",
//        contentType: "application/json",        
//        success: function (data) {
//            //var myjson = json.stringify(data);
//            var $table = $('<table/>').addClass('dataTable table table-bordered table-striped');
//            var $header = $('<thead/>').html('<tr><th>Q.No.</th><th>Quiz</th><th>Instruction</th><th>Added By</th><th>Status</th></tr>');
//            $table.append($header);
//            $.each(data, function (i, val) {
//                var $row = $('<tr/>');
//                $row.append($('<td/>').html(val.q_id));
//                $row.append($('<td/>').html(val.q_name));
//                $row.append($('<td/>').html(val.q_instruction));
//                $row.append($('<td/>').html(val.q_adder));
//                $row.append($('<td/>').html(val.q_status));
//                $table.append($row);
//            });
//            $('#AllQuiz').html($table);
//        },
//        error: function (xhr, status, error) {
//            alert("Result: " + status + " " + error + " " + xhr.status + " " + xhr.statusText)
//        }
//    });
//}



