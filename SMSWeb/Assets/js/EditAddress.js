
var oldEditContactorGroup = new Array();//编辑人原分组

//初始化组下拉菜单
function InitSelGroups(groupId) {

    // var rep = window.Meetingtel.Web.Common.AjaxHandler.GetAllContactorGroups();
    $.post("/Addr/ContactorGroup/GetALLGroups", function (rep) {
        console.Debug(rep);
        if (rep != null && rep.value != null) {
            var liString = "";
            $.each(rep.value, function (y, obj) {
                liString += "<option value='" + obj.ContactorGroupID + "'>" + obj.ContactorGroupName + "</option>";
            });
            $("#selGroup").append(liString);

            //填充分组
            $("#selGroup").val(groupId).select2();
        }
    });

}

//添加联系方式
function AddContactWay(selVal, txtVal, radVal) {
    var i = $("select").length - 1;

    var content = "<div class=\"control-group\" id=\"li" + i + "\"><label class=\"control-label col-sm-3\" style=\"padding-top:0;\"><select style=\"width: auto\" id=\"selWay" + i + "\"  onchange=\"SelWay_change('" + i + "')\">" +
        "<option value=\"1\">手机号码</option>" +
        "<option value=\"2\">电话号码</option>" +
        "<option value=\"3\">邮箱地址</option>" +
        "</select></label><div class=\"col-lg-3\"><input type=\"text\" id=\"txtCN" + i + "\" value=\"" + txtVal + "\" /></div> " +
        "<div><a class=\"btn\" id=\"btnDelCW\" onclick=\"DelContactWay('" + i + "')\"><i class=\"icon-remove\"></i></a> " +
        "<input type=\"radio\" title=\"设置参会号码\" name=\"cmNum\" id=\"radio" + i + "\" value=\"txtCN" + i + "\" /></div></div></div>";
    $("#Way").before(content);

    $("#selWay" + i).attr("value", selVal);
    if (selVal == "3")
        $("#radio" + i).css("display", "none");
    if (radVal)
        $("#radio" + i).attr("checked", 'checked');

    i++;
}

//删除联系方式
function DelContactWay(param) {
    $("#li" + param).remove();
}

//联系方式选择事件
function SelWay_change(param) {
    if ($("#selWay" + param).val() == "3")
        $("#radio" + param).css("display", "none");
    else
        $("#radio" + param).css("display", "inline-block");
}

//保存联系人编辑
function SaveContact(contactId) {
    //获取联系人姓名
    var contactName = $("#txtName").val();
    if (!checkName(contactName)) {
        return;
    }

    //获取联系组
    var contactGroups = new Array();
    if ($("#selGroup").val() != null) {

        $.each($("#selGroup").val(), function (i, selValue) {
            contactGroups.push({ ContactorGroupID: selValue });
        });
    }

    //获取联系方式
    var contactWays = new Array();
    $("select[id^='selWay']").each(function () {
        //if ($(this).attr("id") != "selGroup") {
        var contactNum = $("#txtCN" + $(this).attr("id").substring($(this).attr("id").length - 1)).val();
        var contactWayType = $(this).val();
        //contactWays.push("{\"" + $(this).attr("value") + "\":\"" + contactNum + "\"}");
        contactWays.push({ Way: contactNum, ContactWayType: contactWayType });
        //}
    });

 
    //if (!checkWay(contactWays)) {
    //    return;
    //}
    if (contactWays.length == 0) {
        window.jBox.tip('请添加一种联系方式', 'error');
        return;
    }

    //获取参会号码
    var cmNum = $("#" + $('input[name="cmNum"]:checked').val()).val();
    if (cmNum == undefined) {
        var ret = true;
        $(contactWays).each(function (i, way) {
            if (way.ContactWayType == 1 || way.ContactWayType == 2) {
                window.jBox.tip('请设置默认参会号码', 'error');
                ret = false;
            } else {
                cmNum = "";
            }
            return ret;
        });
        if (!ret) {
            return;
        }
    }

    //转成json
    var jsContact = { ContactorID: contactId, ContactorName: contactName, ConfParticipatePhoneNo: cmNum, CGroups: contactGroups, CWays: contactWays };
    // var contact = $.toJSON(jsContact);
    console.log(jsContact);
    var url;
    if (contactId != 0) {
        //修改联系人//Addr/Contactor/AddContact
        url = "/Addr/Contactor/SetContact";
    } else {   
        url = "/Addr/Contactor/AddContact";
    }
    $.ajax({
        type: "POST",
        dataType: "json",
        url: url,
        traditional: true,
        data: jsContact,
        success: function (result) {

            if (result) {
                window.jBox.tip('保存成功', 'success');
                Fadeout();
                InitContactors();
                //InitContactorsGroups();
                if (contactId == 0) {
                    $("#allSum").text(parseInt($("#allSum").text()) + 1);
                }
                //新分组
                var current = new Array();
                $(contactGroups).each(function (i, group) {
                    current.push(parseInt(group.ContactorGroupID));
                });
                $(current).each(function (i, group) {
                    var count;
                    //原分组不包含新组，加分组数量
                    if (oldEditContactorGroup.indexOf(group) < 0) {
                        count = parseInt($("#spCount" + group).text());
                        $("#spCount" + group).text(count + 1);
                    }
                });
                $(oldEditContactorGroup).each(function (i, group) {
                    var count;
                    //新组不包含原分组，减分组数量
                    if (current.indexOf(group) < 0) {
                        count = parseInt($("#spCount" + group).text());
                        $("#spCount" + group).text(count - 1) < 0 ? $("#spCount" + group).text(0) : $("#spCount" + group).text(count - 1);
                    }
                });
                
            } else {
                window.jBox.tip('保存失败', 'error');
            }
        }
    });


}

//获取联系人信息
function GetContactDetail(contactId) {
    // var result = window.Meetingtel.Web.Common.AjaxHandler.GetContactDetail(contactId).value;
    //if (result == null) return;
    $.post("/Addr/Contactor/GetContactDetail", { contactId: contactId }, function (result) {
        if (result == null) return;
        var contact = result;

        //填充姓名文本框
        $("#txtName").val(contact.ContactorName);

        //填充分组内容
        var groupId = new Array();
        if (contact.CGroups != null) {
            $.each(contact.CGroups, function (m, group) {
                groupId.push(group.ContactorGroupID);
                //原分组
                oldEditContactorGroup.push(parseInt(group.ContactorGroupID));
            });
            $("#selGroup").val(groupId).select2();
        }

        //填充联系方式
        if (contact.CWays != null) {
            var first = true;
            $.each(contact.CWays, function (m, way) {
                var radio = false;
                if (way.Way == contact.ConfParticipatePhoneNo) {
                    radio = true;
                }
                if (first) {
                    $("#selWay0").attr("value", way.ContactWayType);
                    $("#txtCN0").val(way.Way);
                    if (way.ContactWayType != 3) {
                        if (radio) {
                            $("#radio0").attr("checked", "checked");
                        } else {
                            $("#radio0").attr("checked", "");
                        }
                    } else {
                        $("#radio0").css("display", "none");
                    }
                    first = false;
                }
                else {
                    AddContactWay(way.ContactWayType, way.Way, radio);
                }
            });
        }

    });


}