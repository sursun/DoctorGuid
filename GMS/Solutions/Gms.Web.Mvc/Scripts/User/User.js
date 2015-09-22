
var User;
if (!User) {
    User = {};
}

User.Init = function () {

    $('#entity_search_list').datagridEx({
        toolbar: '#toolbar',
        pagination: true,
        singleSelect: true,
        columns: [
            [
                { field: 'CodeNo', title: '工号', width: 100 },
                { field: 'RealName', title: '姓名', width: 100 },
                { field: 'Department', title: '科室', width: 100 },
                { field: 'SexString', title: '性别', width: 100 },
                { field: 'EnabledString', title: '状态', width: 80 }
            ]
        ],
        onSelect: function(rowIndex, rowData) {
            if (rowData != null) {
                $('#user_selected_Id').val(rowData.Id);
                $('#user_selected_Name').val(rowData.RealName);
                $('#user_selected_CodeNo').val(rowData.CodeNo);
            }
        }
    });
    
    $("#entityform").validate({
        onkeyup: false,
        onfocusout: false,
        rules: {
            CodeNo: "required",
            psw: "required",
            RealName: "required",
            Mobile: "required"
        },
        messages: {
            LoginName: "请输入工号",
            psw: "请输入密码",
            RealName: "请输入真实姓名",
            Mobile: "请输入手机号码"
        }
        , showErrors: function (errorMap, errorList) {
            var message = '请完善以下内容后，再提交。\n';
            var errors = "";
            if (errorList.length > 0) {
                for (x = 0; x < errorList.length; x++) {
                    errors += "<br/>\u25CF " + errorList[x].message;
                }

                $.messager.alert("提示", message + errors);
            }

        }

    });

    $("a.reset").live("click", function() {
        var rec = $('#entity_search_list').datagrid("getSelected");
        if (rec == null) {
            return false;
        }
        
        $.post("/User/ResetPassword", { id: rec.Id }, function (data) {
            if (data.success) {
                $.messager.alert("提示", "密码重新重置为[" + data.data + "]");
            } else {
                $.messager.alert("提示", data.data);
            }
        },"json");

    });


    //----------------------------------------- 选择科室 -------------------------------------//
    $("#selectDept").live("click",function () {

        $("#selcet_dept_dlg_content").attr("src", "/Department/Select");

        var opt = {
            title: '选择科室',
            width: 300,
            height: 200,
            buttons: [{
                text: '确定',
                iconCls: 'icon-ok',
                handler: function () {
                    var deptContents = $("#selcet_dept_dlg_content").contents();

                    $("#Department_Id").val(deptContents.find("#dept_selected_Id").val());
                    $("#Department_Name").val(deptContents.find("#dept_selected_Name").val());
                 
                    $("#selcet_dept_dlg").dialog('close');
                }
            }, {
                text: '取消',
                iconCls: 'icon-cancel',
                handler: function () {
                    $("#selcet_dept_dlg").dialog('close');
                }
            }]
        };

        $("#selcet_dept_dlg").show();
        $("#selcet_dept_dlg").dialog(opt);

        return false;

    });


    $('#frameeditdlg').dialog({
        title: "信息完善",
        height: 600,
        width: 900,
        closed: true,
        buttons: [{
            text: '关闭',
            handler: function () {
                $('#frameeditdlg').dialog("close");
            }
        }]
        //,
        //onClose: function () {
        //    $('#bldlg').datagrid("reload");
        //}
    });

    var openFrameDialog = function (url, title) {

        //设置标题
        var opts = $('#frameeditdlg').dialog('options');
        opts.title = title;
        $('#frameeditdlg').dialog(opts);

        //更改链接
        $("iframe", $('#frameeditdlg')).attr("src", url);

        $('#frameeditdlg').dialog("open");
    };
  
};
