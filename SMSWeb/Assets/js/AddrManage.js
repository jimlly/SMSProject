var pageIndex = 0; //联系人分页
var pageSize = 5;

//内容高度改变时触发
var setpageContainerHeight = function (update) {
    //alert($(".history-top").height());

    var pageContainerHeight = $(window).height() - $(".navbar-fixed-top").height() - $(".navbar-fixed-bottom").height();
    $("div#pageContainer").css("max-height", pageContainerHeight);

    if (update == 1)
        $("div#pageContainer").mCustomScrollbar("update");
}

//初始化联系人列表
var InitContactors = function (id) {
    pageSize = parseInt($("#selSize").val());
    var search = $("#txt_SearchContent").val();
    //InitTable(pageIndex);//多余调用
    //总条目数
    //var InHtmlCount = 0;

    ////取页面分类总数 非查询状态取全部
    //if (search == "" && id != "") {
    //    switch (id) {
    //        case "liAll":
    //            InHtmlCount = $("span#allSum").text();
    //            break;
    //        case "liUnGrouped":
    //            InHtmlCount = $("span#unGroupedSum").text();
    //            break;
    //        default:
    //            InHtmlCount = $("li#" + id + " span.badge").text();
    //            break;
    //    }

    //}
    //var count = InHtmlCount != 0 ? InHtmlCount : window.Meetingtel.Web.Common.AjaxHandler.GetContactorCount($("#hidGroupId").val(), search).value;
    //$.post("/Common/AddressGroupCount.ashx", { groupId: $("#hidGroupId").val(), search: search }, function (data) {
    //    $("#allSum").text(data)
    //});
    //var count = null;
    //$("#Pagination").pagination(count, {
    //    callback: PageCallback,
    //    prev_text: '上一页',
    //    next_text: '下一页',
    //    items_per_page: pageSize,
    //    num_display_entries: 6,//连续分页主体部分分页条目数  
    //    current_page: pageIndex,//当前页索引  
    //    num_edge_entries: 2//两侧首尾分页条目数  
    //});

    //if (InHtmlCount == 0) {
    $.post("/Addr/CotactorGroup/GetGroupCount", { groupId: $("#hidGroupId").val(), search: search }, function (count) {
        $("#Pagination").pagination(count, {
            callback: PageCallback,
            prev_text: '上一页',
            next_text: '下一页',
            items_per_page: pageSize,
            num_display_entries: 6,//连续分页主体部分分页条目数  
            current_page: pageIndex,//当前页索引  
            num_edge_entries: 2//两侧首尾分页条目数  
        });
    });
    //} else {
    //    $("#Pagination").pagination(InHtmlCount, {
    //        callback: PageCallback,
    //        prev_text: '上一页',
    //        next_text: '下一页',
    //        items_per_page: pageSize,
    //        num_display_entries: 6,//连续分页主体部分分页条目数  
    //        current_page: pageIndex,//当前页索引  
    //        num_edge_entries: 2//两侧首尾分页条目数  
    //    });
    //}
};

$(document).ready(function () {
    //var pageContainerHeight = $(window).height() - $(".navbar-fixed-top").height() - $(".navbar-fixed-bottom").height();
    //$("div#pageContainer").css("max-height", pageContainerHeight);

    setpageContainerHeight();
    $(window).resize(function () {
        setpageContainerHeight(1);
    });

    $("div#pageContainer").mCustomScrollbar({
        theme: "inset-dark",
        scrollButtons: { enable: true }
    });

    InitContactorsGroups();
    InitContactors();
    //initGroupsDropDownList();

    //设置下拉框自动关闭
    $("#div_GroupManager,a.dropdown-toggle").mouseleave(function () {
        $("#div_GroupManager").data("enter", "0");
    }).mouseenter(function () {
        $("#div_GroupManager").data("enter", "1");
    });
});

//翻页调用  
function PageCallback(index, jq) {
    InitTable(index);

}

//请求数据  
function InitTable(pageIndex) {
    var search = $("#txt_SearchContent").val();
    var groupid = $("#hidGroupId").val();
    $.ajax({
        type: "POST",
        dataType: "text",
        url: '/Addr/Contactor/GetContactorList',
        data: "pageindex=" + (pageIndex + 1) + "&pagesize=" + pageSize + "&search=" + search + "&groupid=" + groupid,
        success: function (data) {
            //alert(data);
            $("#tbAddress tr:gt(0)").remove();//移除Id为Result的表格里的行，从第二行开始（这里根据页面布局不同页变）  
            $("#tbAddress").append(data);//将返回的数据追加到表格  
        }
    });
}
//获取自定义所有联系人分组
function InitContactorsGroups() {
    //全部条数
    //var allcount = window.Meetingtel.Web.Common.AjaxHandler.GetContactorCount("0", "").value;
    //$("#allSum").text(allcount);

    $.post("/Addr/CotactorGroup/GetGroupCount", { groupId: "0", search: $("#txt_SearchContent").val() }, function (data) {
        $("#allSum").text(data)
    });
    //未分组条数
    //var ungroupcount = window.Meetingtel.Web.Common.AjaxHandler.GetContactorCount("-2", "").value;
    //$("#unGroupedSum").text(ungroupcount);

    $.post("/Addr/CotactorGroup/GetGroupCount", { groupId: "-2", search: $("#txt_SearchContent").val() }, function (data) {
        $("#unGroupedSum").text(data)
    });

    $("#ulGroup").empty();
    $.post("/Addr/CotactorGroup/GetList", function (data) {

        $("#ulGroup").append(data);

        //groupIndex
        $("div#MoreLink").remove();
        $("#ulGroup").after("<div id='MoreLink' style='text-align:center;cursor:pointer' index='1' page=" + ($("#ulGroup li").length == 0 ? 1 : (Math.ceil($("#ulGroup li").length / 10))) + " class=\"well MoreLink well-small\">加载更多...</div>");

        //分页方法
        var MoreLink = $("#MoreLink");
        //alert(MoreLink.html());
        if (MoreLink.attr("page") == 1) {
            MoreLink.hide();
        } else {
            $("li[page][page!=1]").hide();//不是第一页的隐藏起来
        }

        //加载更多点击方法
        MoreLink.click(function () {
            var index = parseInt($(this).attr("index"));
            var page = parseInt($(this).attr("page"));
            index += 1;//加一页
            page -= 1;
            if (page == 1) $(this).hide();//当前已经是最后一页
            $("li[page=" + index + "]").show();
            $(this).attr("index", index);
            $(this).attr("page", page);
        });

    });


    //var rep = window.Meetingtel.Web.Common.AjaxHandler.GetAllContactorGroups();
    ////var rep = null;
    //if (rep != null && rep.value != null) {
    //    $("#ulGroup").empty();
    //    var tab = [];
    //    $.each(rep.value, function (y, obj) {

    //        var currentPage = Math.floor(y / 10) + 1;
    //        tab.push("<li page='" + currentPage + "'  id='li" + obj.ContactorGroupID + "' style='cursor: pointer'>");
    //        tab.push("<div id='divShowGroup" + obj.ContactorGroupID + "' class='group-user-show' onclick=\"li_click('li" + obj.ContactorGroupID + "','" + obj.ContactorGroupName + "')\"><a>" + obj.ContactorGroupName + "</a>");
    //        tab.push("<span id='spCount" + obj.ContactorGroupID + "' class='badge badge-hover3'>" + obj.ContactorCount + "</span>");
    //        tab.push("<span class='badge badge-hover2' title='编辑' onclick=\"javascript:li_dblclick('" + obj.ContactorGroupID + "','" + obj.ContactorGroupName + "')\"><span><i class='icon-pencil icon-white'></i></span></span>");
    //        tab.push("<span class='badge badge-hover' title='删除' onclick=\"javascript:li_delclick('li" + obj.ContactorGroupID + "')\" ><span><i class='icon-trash icon-white'></i></span></span>");
    //        tab.push("</div>");
    //        tab.push("<div style='position:relative' id='divEditGroup" + obj.ContactorGroupID + "' class='group-user-edit form-inline'>");
    //        tab.push("<div style='padding-right:130px'><input type='text' id='txtEdit" + obj.ContactorGroupID + "' class='input-small' value='" + obj.ContactorGroupName + "'  style='width:100%;' /></div>");
    //        tab.push("<div style='position: absolute;right:2px;top: 4px;'><input type='button' id='btnOK' onclick=\"SaveGroupByLeft('" + obj.ContactorGroupID + "')\" value='确定' class='btn btn-primary' />&nbsp;");
    //        tab.push("<input type='button' id='btnCancel' onclick=\"CloseGroupByLeft('" + obj.ContactorGroupID + "')\" value='取消' class='btn' /></div>");
    //        tab.push("</div>");
    //        tab.push("</li>");
    //    });

    //    $("#ulGroup").append(tab.join(''));

    //    //groupIndex
    //    $("div#MoreLink").remove();
    //    $("#ulGroup").after("<div id='MoreLink' style='text-align:center;cursor:pointer' index='1' page=" + ($("#ulGroup li").length == 0 ? 1 : (Math.ceil($("#ulGroup li").length / 10))) + " class=\"well MoreLink well-small\">加载更多...</div>");

    //    //分页方法
    //    var MoreLink = $("#MoreLink");
    //    //alert(MoreLink.html());
    //    if (MoreLink.attr("page") == 1) {
    //        MoreLink.hide();
    //    } else {
    //        $("li[page][page!=1]").hide();//不是第一页的隐藏起来
    //    }

    //    //加载更多点击方法
    //    MoreLink.click(function () {
    //        var index = parseInt($(this).attr("index"));
    //        var page = parseInt($(this).attr("page"));
    //        index += 1;//加一页
    //        page -= 1;
    //        if (page == 1) $(this).hide();//当前已经是最后一页
    //        $("li[page=" + index + "]").show();
    //        $(this).attr("index", index);
    //        $(this).attr("page", page);
    //    });
    //}
}

//设置管理组下拉菜单
function initGroupsDropDownList() {
    var rep = window.Meetingtel.Web.Common.AjaxHandler.GetAllContactorGroups();
    //var rep = null;
    if (rep != null && rep.value != null) {
        $("#ul_mGroup").empty();
        var tab = [];
        $.each(rep.value, function (y, obj) {
            tab.push("<li id='li_m" + y + "'>");
            tab.push("<label class='checkbox'><input id='ckb_" + y + "' type='checkbox' name='cb_mItem' value='" + obj.ContactorGroupID + "' text='" + obj.ContactorGroupName + "'/>");
            tab.push("</label>");
            tab.push("<span id='sp_mItem' style='cursor:pointer' onclick=\"ChangeChkBoxState('ckb_" + y + "',this)\">" + obj.ContactorGroupName + "</span>");
            tab.push("</li>");
        });
        $("#ul_mGroup").append(tab.join(''));


    }
}

var ChangeChkBoxState = function (ckbId, that) {
    var isCheck = $("#" + ckbId).attr("checked");
    if (isCheck == "checked") {
        $("#" + ckbId).removeAttr("checked");
        //$(that).removeClass("selected");
    } else {
        $("#" + ckbId).attr("checked", "true");
        //$(that).addClass("selected");
    }
};


/*/////左侧分组操作////////////////////////////////////////////////////////////////////////*/

//添加分组信息
function AddGroupInfo(groupName) {
    if (!window.checkGroupName(groupName)) {
        window.jBox.tip('组名格式应为中文、英文、数字或者-、_、（），长度不超过25个字', 'error');
        return;
    }
    var rep = window.Meetingtel.Web.Common.AjaxHandler.AddGroupInfo(groupName).value;
    if (rep > 0) {
        window.jBox.tip('添加分组成功', 'success');
        $("#hidGroupName").val(groupName);

        //管理组下拉菜单更新
        initGroupsDropDownList();
        var newGroupHtml = "<li style='cursor: pointer' id='li" + rep + "'><div onclick=li_click('li" + rep + "','" + groupName + "') class='group-user-show' id='divShowGroup" + rep + "'><a>" + groupName + "</a><span class='badge badge-hover3' id='spCount" + rep + "'>0</span><span onclick=javascript:li_dblclick('" + rep + "','" + groupName + "') title='编辑' class='badge badge-hover2'><span><i class='icon-pencil icon-white'></i></span></span><span onclick=javascript:li_delclick('li" + rep + "') title='删除' class='badge badge-hover'><span><i class='icon-trash icon-white'></i></span></span></div><div class='group-user-edit form-inline' id='divEditGroup" + rep + "'><input type='text' value='" + groupName + "' class='input-small' id='txtEdit" + rep + "'><input type='button' class='btn btn-primary' value='确定' onclick=SaveGroupByLeft('" + rep + "') id='btnOK'><input type='button' class='btn' value='取消' onclick=CloseGroupByLeft('" + rep + "') id='btnCancel'></div></li>";
        $("#ulGroup").append(newGroupHtml);
        //InitContactorsGroups();
        //InitContactors();
        //initGroupsDropDownList();
    } else if (rep == -3) {
        window.jBox.tip('添加失败，存在同名的组', 'error');
    } else {
        window.jBox.tip('添加分组失败', 'error');
    }
}

//修改分组信息
function UpdateGroupInfo(groupId, groupName) {
    if (!window.checkGroupName(groupName)) {
        window.jBox.tip('组名格式应为中文、英文、数字或者-、_、（），长度不超过25个字', 'error');
        return 0;
    }
    var rep = window.Meetingtel.Web.Common.AjaxHandler.UpdateGroupInfo(groupId, groupName).value;
    return rep;
}

//保存左侧分组编辑事件
function SaveGroupByLeft(id) {
    var groupName;
    if (id == 0) { //新建
        groupName = $("#txtAddNew").val();
    } else {
        groupName = $("#txtEdit" + id).val();
    }

    var groupId = $("#hidGroupId").val();

    if (groupName == "") {
        $.jBox.tip('组名不能为空', 'info', { focusId: 'txtEdit' });
        return;
    }
    if (groupName == "所有" || groupName == "所有联系人" || groupName == "未分组" || groupName == "未分组联系人") {
        $.jBox.tip('组名不能为所有联系人和未分组', 'info', { focusId: 'txtEdit' });
        return;
    }
    if (groupName == $("#hidGroupName").val()) {
        $.jBox.tip('组名没有更改', 'info', { focusId: 'txtEdit' });
        return;
    }
    if (id == 0)
        AddGroupInfo(groupName);//添加分组信息
    else {
        var groupCount = $("#spCount" + id).text();
        var ret = UpdateGroupInfo(groupId, groupName); //修改分组信息
        if (ret == 1) {

            window.jBox.tip('修改分组成功', 'success');
            $("#hidGroupName").val(groupName);

            //管理组下拉菜单更新
            initGroupsDropDownList();
            $("#sp_groupName").text("自定义分组：" + groupName);
            var newGroupHtml = "<li style='cursor: pointer' id='li" + groupId + "'><div onclick=li_click('li" + groupId + "','" + groupName + "') class='group-user-show' id='divShowGroup" + groupId + "'><a>" + groupName + "</a><span class='badge badge-hover3' id='spCount" + groupId + "'>" + groupCount + "</span><span onclick=javascript:li_dblclick('" + groupId + "','" + groupName + "') title='编辑' class='badge badge-hover2'><span><i class='icon-pencil icon-white'></i></span></span><span onclick=javascript:li_delclick('li" + groupId + "') title='删除' class='badge badge-hover'><span><i class='icon-trash icon-white'></i></span></span></div><div class='group-user-edit form-inline' id='divEditGroup" + groupId + "'><input type='text' value='" + groupName + "' class='input-small' id='txtEdit" + groupId + "'><input type='button' class='btn btn-primary' value='确定' onclick=SaveGroupByLeft('" + groupId + "') id='btnOK'><input type='button' class='btn' value='取消' onclick=CloseGroupByLeft('" + groupId + "') id='btnCancel'></div></li>";
            $("#li" + groupId).after(newGroupHtml).remove();
            //InitContactorsGroups();
            //InitContactors();
        } else if (ret == -3) {
            window.jBox.tip('修改失败，存在同名的组', 'error');
            $("#txtEdit" + id).val($("#hidGroupName").val());
        } else {
            window.jBox.tip('修改分组失败', 'error');
            $("#txtEdit" + id).val($("#hidGroupName").val());
        }
    }

    CloseGroupByLeft(id);//关闭左侧分组编辑框
}

//关闭左侧分组编辑框
function CloseGroupByLeft(id) {
    if (id == 0) {
        $("#ulGroup li").remove("li[id=li_new]");
        $("#txtAddNew").val("");
    } else {
        $("#divShowGroup" + id).css("display", "block");
        $("#divEditGroup" + id).css("display", "none");
        $("#txtEdit").val("");//清空编辑文本框
        $("#hidGroupId").val("");//清空分组ID缓存
    }
}

//左侧导航内容编辑事件
function li_dblclick(id, name) {
    //显示编辑层
    $("#divShowGroup" + id).css("display", "none");
    $("#divEditGroup" + id).css("display", "block");
    $("#hidGroupId").val(id);
    $("#hidGroupName").val(name);
}

//左侧点击添加分组事件
function clickAddGroup() {
    if ($("#ulGroup li[id=li_new]").html() != null) {
        return;
    }
    var add = "<li id='li_new' style='cursor: pointer'>" +
        "<div id='divAddGroupNew' class='group-user-edit form-inline' style='position:relative;display:block'>" +
        "<div style='padding-right:130px'><input type='text' id='txtAddNew' class='input-small' style='width:100%;' /></div>" +
        "<div style='position: absolute;right:2px;top: 4px;'><input type='button' id='btnOK' onclick=\"SaveGroupByLeft(0)\" value='确定' class='btn btn-primary' />&nbsp;" +
        "<input type='button' id='btnCancel' onclick=\"CloseGroupByLeft(0)\" value='取消' class='btn' /></div></div></li>";
    $("#ulGroup").append(add);
}

//左侧导航内容单击事件
function li_click(id, groupName) {
    $("#txt_SearchContent").val("");
    if (groupName == "所有联系人") {
        $("#hidGroupId").val(0);
        $("#sp_groupName").text(groupName);
    } else if (groupName == "未分组联系人") {
        $("#hidGroupId").val(-2);
        $("#sp_groupName").text(groupName);
    } else {
        $("#hidGroupId").val(id.substring(2, id.length));
        $("#sp_groupName").text("自定义分组：" + groupName);
    }
    InitContactors(id);
    $(".group-user li").removeClass("active");
    $("#" + id).addClass("active");
    Fadeout();
}

//删除左侧分组事件
function li_delclick(id) {
    var submit = function (v, h, f) {
        if (v == 'ok') {
            var result = Meetingtel.Web.Common.AjaxHandler.DelGroupInfo(id.substring(2));
            if (result) {
                $("#" + id).remove();
                window.jBox.tip('成功删除分组', 'success');
                $("#hidGroupId").val(0);
                $("#sp_groupName").text("所有联系人");
                InitContactors();
                //更新管理组下拉框
                initGroupsDropDownList();
                //InitContactorsGroups();
                InitContactors(0);
            } else {
                window.jBox.tip('删除分组失败', 'error');
            }
        }
        return true; //close
    };

    $.jBox.confirm("确定删除 " + $("#" + id + " a").text() + " 分组吗？", "提示", submit);

    //$("#ulGroup li").remove("li[id="+id+"]");
}



/*/////右侧通讯录操作////////////////////////////////////////////////////////////////////////*/

//获取通讯录列表中复选框选中项value
function getAddress_cb_checked() {
    var result = new Array();
    $("[name = cbItem]:checkbox").each(function () {
        if ($(this).is(":checked")) {
            result.push(parseInt($(this).attr("value")));
        }
    });
    return result;
}

//获取管理组下拉列表中复选框选中项value
function getGroup_cb_checked() {
    var result = new Array();
    $("[name = cb_mItem]:checkbox").each(function () {
        if ($(this).is(":checked"))
            result.push(parseInt($(this).attr("value")));
    });
    return result;
}

//全选、全不选
function cb_allclick() {
    if ($("#cbAll").attr("checked") == "checked") {
        //$(':checkbox').attr('checked', 'checked');
        $("[name = cbItem]:checkbox").each(function () {
            $(this).attr('checked', 'checked');
        });
    }
    else {
        //$(':checkbox').removeAttr('checked');
        $("[name = cbItem]:checkbox").each(function () {
            if ($(this).is(":checked"))
                $(this).removeAttr('checked');
        });
    }
}

//设置联系人分组
function SetContactGroup() {
    //获取管理组下拉列表中复选框选中项value
    var groupIds = getGroup_cb_checked();
    //获取通讯录列表中复选框选中项value
    var contactIds = getAddress_cb_checked();
    var result = false;

    if (groupIds.length == 0) {
        $.jBox.tip('请勾选组名');
        return;
    }
    else if (contactIds.length == 0) {
        $.jBox.tip('请选择要编辑分组的联系人');
        return;
    }
    else if (contactIds.length == 1) {
        result = window.Meetingtel.Web.Common.AjaxHandler.SetContactGroupBySingle(contactIds, groupIds);
    } else
        result = window.Meetingtel.Web.Common.AjaxHandler.SetContactGroupByMulti(contactIds, groupIds);

    if (result) {
        window.jBox.tip('设置分组成功', 'success');
        managerShow();
        //InitContactorsGroups();
        if (typeof Array.indexOf !== 'function') {
            Array.prototype.indexOf = function (args) {
                var index = -1;
                for (var i = 0, l = this.length; i < l; i++) {
                    if (this[i] === args) {
                        index = i;
                        break;
                    }
                }
                return index;
            };
        }
        $(contactIds).each(function (i, contactor) {
            //联系人原分组
            var arrContacrGroup = $("#adrTdGroup" + contactor).html().split(' ');

            $(groupIds).each(function (i, group) {
                var count;
                //原分组不包含新组，加分组数量
                if (arrContacrGroup.indexOf(group) < 0) {
                    count = parseInt($("#spCount" + group).text());
                    $("#spCount" + group).text(count + 1);
                }
            });

            $(arrContacrGroup).each(function (i, group) {
                var count;
                //新组不包含原分组，减分组数量
                if (groupIds.indexOf(group) < 0) {
                    count = parseInt($("#spCount" + group).text());
                    $("#spCount" + group).text(count - 1) < 0 ? $("#spCount" + group).text(0) : $("#spCount" + group).text(count - 1);
                }
            });

        });
        InitContactors();
    } else {
        window.jBox.tip('设置分组失败', 'error');
    }
}

//删除联系人
function DelContact() {
    //获取通讯录列表中复选框选中项value
    var contactIds = getAddress_cb_checked();

    if (contactIds.length == 0) {
        $.jBox.tip('请选择要删除的联系人', 'error');
        return;
    }

    var currentGroup = $("#sp_groupName").text();
    var currentGroupId = $("#hidGroupId").val();

    var submit = function (v, h, f) {
        if (v == 'ok') {
            var result;
            if (currentGroup == "所有联系人" || currentGroup == "未分组联系人") {
                //彻底删除联系人
                result = window.Meetingtel.Web.Common.AjaxHandler.DelContact(contactIds);
            } else {
                //从当前组中删除联系人
                result = window.Meetingtel.Web.Common.AjaxHandler.DelContactByGroup(contactIds, currentGroupId);
            }
            if (result) {
                window.jBox.tip('删除联系人成功', 'success');
                var count;
                var sum;
                var ungroupCount;
                if (currentGroup == "所有联系人") {
                    $(contactIds).each(function (i, contactor) {
                        //联系人原分组
                        var arrContacrGroup = $("#adrTdGroup" + contactor).html().split(' ');
                        count = parseInt($("#allSum").text());
                        ungroupCount = parseInt($("#unGroupedSum").text());
                        if (arrContacrGroup == null || arrContacrGroup[0] == "") {
                            $("#allSum").text(count - 1) < 0 ? $("#allSum").text(0) : $("#allSum").text(count - 1);
                            $("#unGroupedSum").text(ungroupCount - 1) < 0 ? $("#unGroupedSum").text(0) : $("#unGroupedSum").text(ungroupCount - 1);
                        } else {
                            $("#allSum").text(count - 1) < 0 ? $("#allSum").text(0) : $("#allSum").text(count - 1);
                            $(arrContacrGroup).each(function (y, group) {
                                var spCount = parseInt($("#spCount" + group).text());
                                $("#spCount" + group).text(spCount - 1) < 0 ? $("#spCount" + group).text(0) : $("#spCount" + group).text(spCount - 1);
                            });
                        }
                    });
                } else if (currentGroup == "未分组联系人") {
                    count = parseInt($("#allSum").text());
                    ungroupCount = parseInt($("#unGroupedSum").text());
                    sum = parseInt(contactIds.length);
                    $("#unGroupedSum").text(ungroupCount - sum) < 0 ? $("#unGroupedSum").text(0) : $("#unGroupedSum").text(ungroupCount - sum);
                    $("#allSum").text(count - sum) < 0 ? $("#allSum").text(0) : $("#allSum").text(count - sum);
                } else {
                    //InitContactorsGroups();
                    count = $("#spCount" + currentGroupId).text();
                    sum = parseInt(contactIds.length);
                    if (count - sum >= 0) {
                        $("#spCount" + currentGroupId).text(count - sum);
                    } else {
                        $("#spCount" + currentGroupId).text(0);
                    }
                }
                InitContactors();
            } else {
                window.jBox.tip('删除联系人失败', 'error');
            }
        }
        return true;
    };

    if (currentGroupId == "" || currentGroupId == "0" || currentGroupId == "-2") {
        $.jBox.confirm("确认要删除这" + contactIds.length + "位联系人，这将会彻底删除这" + contactIds.length + "位联系人 ？", "提示", submit);
    } else {
        $.jBox.confirm("确认要删除这" + contactIds.length + "位联系人，本次删除只是针对当前组", "提示", submit);
    }
}

//编辑联系人
function EditContact(contactId, target) {
    Fadein(contactId, target);
}



/*/////编辑层滑入滑出操作////////////////////////////////////////////////////////////////////////*/

var cont = "";//记录展示层的ID

//编辑层滑入
function Fadein(contactId, target) {
    if ($(target).closest("tr").hasClass("clicked")) {
        return;
    }
    $("tr.clicked").removeClass("clicked");//如果其他行正在编辑状态，移除其点击状态
    $(target).attr("id") == "btAdd" ? $(target).attr("disabled", "disabled") : $(target).closest("tr").addClass("clicked");
    $("#" + cont).html("");
    if (cont != "") {
        $("#" + cont).slideUp();
        $("#" + cont).html("");
        cont = "";
    }

    cont = contactId == "" ? "divEdit" : "td" + contactId;


    var groupId = $("#hidGroupId").val();
    var parames = { "contactId": contactId, "groupId": groupId };
    $.ajax({
        url: '/Addr/Contactor/Edit',
        data: parames,
        error: function () { window.jBox.tip('修改联系人失败', 'error'); },
        success: function (data) {
            $("#" + cont).html(data);
            $("#" + cont).slideDown("500");
        }
    });
}

//编辑层滑出
function Fadeout(target) {

    //取消点击行或者添加新行被禁用
    if ($("button#btAdd").attr("disabled")) {
        $("button#btAdd").removeAttr("disabled");
    } else {
        $("tr.clicked").removeClass("clicked");
    }

    $("#" + cont).slideUp();
    $("#" + cont).html("");
    cont = "";
}

//管理组下拉菜单显示隐藏
var managerShow = function () {

    //加载管理组
    if ($("#ul_mGroup").html() == "") {
        //alert("加载"); //第一次点击加载
        initGroupsDropDownList();
    }

    var divDisplay = $("#div_GroupManager").css("display");
    if (divDisplay == "none") {
        //alert('enter1');


        $("#div_GroupManager").css("display", "block");

        $(document).click(function () {
            $div = $("#div_GroupManager");
            if ($div.data("enter") == 0) {
                //alert('enter');
                $div.data("enter", "1");
                $div.hide();
                $(document).unbind("click");
            }

        });
    } else {
        $("#div_GroupManager").css("display", "none");
    }

    $("[name = cb_mItem]:checkbox").each(function () {
        //清空选中组
        $(this).removeAttr('checked');
        //当前组选中
        var groupId = $("#hidGroupId").val();
        if (groupId != 0 && groupId != -2) {
            if ($(this).attr('value') == groupId) {
                $(this).attr('checked', 'checked');
            }
        }
    });
};

//导入导出事件
var importXlsAddr = function () {
    //$.jBox.open("iframe:Address/ImportAndExport.aspx", "导入/导出", 600, 430, { buttons: {} });
    //$.post("/Address/ImportAndExport.aspx", function (data) {

    //});
    //拖放元素
    $("#ifraExchage").attr("src", "/Address/ImportAndExport.aspx");
    //添加tab事件
    $(".Export").click(function () {
        $(this).addClass("active").siblings().removeClass("active");
        var dom = navigator.appName == "Netscape" ? document.getElementById("ifraExchage").contentDocument : window.frames["ifraExchage"].document;
        dom.getElementById("hidType").value = "1";
        dom.getElementById("Import").style.display = "none";
        dom.getElementById("Export").style.display = "block";
    });
    $(".Import").click(function () {
        $(this).addClass("active").siblings().removeClass("active");
        var dom = navigator.appName == "Netscape" ? document.getElementById("ifraExchage").contentDocument : window.frames["ifraExchage"].document;
        dom.getElementById("hidType").value = "0";
        dom.getElementById("Export").style.display = "none";
        dom.getElementById("Import").style.display = "block";
    });
    $("#ExchangeModel").show().ppdrag();
    //拖放导致按钮冒泡 造成flash上传附件按钮点击无效
    //$("#ExchangeModel .tab-content").mousedown(function (e) {
    //    if (e && e.stopPropagation) {//非IE   
    //        e.stopPropagation();
    //    }
    //    else {//IE    
    //        window.event.cancelBubble = true;
    //    }
    //});

};

//导出
var exportXlsAddr = function () {
    var groupId = $("#hidGroupId").val();
    $.ajax({
        url: "../Common/AddressExport.ashx",
        type: "get",
        data: "groupid=" + groupId,
        beforeSend: function (XMLHttpRequest) {
            //发送请求前可修改 XMLHttpRequest 对象的函数
            //alert("loading");
        },
        success: function (data, textStatus) {
            //请求成功后回调函数
            alert("导出成功");
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            // 请求失败后回调函数
            alert("导出失败");
        },
        complete: function (XMLHttpRequest, textStatus) {
            //请求完成后回调函数 (请求成功或失败时均调用)
            //alert("complete");
        },
    });
};


var defaultData = [
          {
              text: 'Parent 1',
              href: '#parent1',
              tags: ['4'],
              nodes: [{ text: '李思思', id: '772432', href: '#', title: '手机号：13810712519', phone: '13810712519', selected: false, parentnode: 6710 }, { text: 'Nancy', id: '772430', href: '#', title: '手机号：15215558585', phone: '15215558585', selected: false, parentnode: 6710 }]
          },
          {
              text: 'Parent 2',
              href: '#parent2',
              tags: ['0']
          }
]

var addrSync = function () {
    $("#loading").show();
    var result = window.Meetingtel.Web.Common.AjaxHandler.ContactorWaySync().value;
    if (result) {
        window.jBox.tip('同步成功', 'success');
    } else {
        window.jBox.tip('同步失败', 'error');
    }
    $("#loading").hide();
};
