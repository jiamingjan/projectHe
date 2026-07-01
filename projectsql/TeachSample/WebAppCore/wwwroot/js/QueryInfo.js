function QueryInfoTable(un, right) {
    if (right == '1') {
        $("#deleteBtn").show();
    }
    var userName = un;
    if (userName == null || userName == 'undefined' || userName == 'null')
        userName = "";
    else {
        $('#user').val(userName);
        $('#user').prop("readonly", true);
    }
        
    this.initSearch = function () {
        $('#searchBtn').bind('click', function () {
            isSearch = true;
            var data = $("#searchForm").serialize();
            $("#table_QueryInfo").jqGrid('clearGridData');  //清空表格
            $("#table_QueryInfo").jqGrid('setGridParam', {  // 重新加载数据
                url: 'GetTableData?' + data,//请求数据的地址
                data: data,   //  newdata 是符合格式要求的需要重新加载的数据

            }).trigger("reloadGrid");
        });
        $('#clearBtn').bind('click', function () {
            if (userName == "") //当前用户不是登录用户，即当管理员的时候
                $('#user').val("");
            $('#queryStock').val("");           
            $('#startTime').val("");
            $('#endTime').val("");
        });
    };

    this.initTable = function () {
        // alert();
        var tableHeight = $(window).height() - 260;
        $.jgrid.defaults.styleUI = 'Bootstrap';
        var data = $("#searchForm").serialize();
        var url = 'GetTableData?' + data;      
        $("#table_QueryInfo").jqGrid({
            regional: 'cn',
            url: url,//请求数据的地址
            datatype: "json",// 服务器返回的数据类型，常用的是xml和json两种
            height: tableHeight,
            autowidth: true,
            shrinkToFit: true,
            rowNum: 20,// 默认的每页显示记录条数
            rowList: [10, 20, 30],// 可供用户选择的每页显示记录条数。
            rownumbers: true,//是否显示右
            colNames: ['Id', '查询的用户', '查询的股票', '返回的股票', '产生日期', '查询时间'],
            colModel: [
                {
                    name: 'Id',
                    index: 'Id',
                    key: true,
                    hidden: true
                },
                {
                    name: 'User',
                    index: 'User',
                    width: 40,
                    sortable: false
                },
                {
                    name: 'QueryStock',
                    index: 'QueryStock',
                    width: 40,
                    sortable: false
                },
                {
                    name: 'RespStocks',
                    index: 'RespStocks',
                    width: 40,
                    sortable: false
                },                
                {
                    name: 'RespStockDate',
                    index: 'RespStockDate',
                    width: 40,
                    sortable: false
                },
                {
                    name: 'QueryTime',
                    index: 'QueryTime',
                    width: 50,
                    sortable: true,
                }
            ],

            pager: "#pager_QueryInfo",// 导航条对应的Div标签的ID,注意一定是DIV，不是Table
            viewrecords: true,// 定义是否在导航条上显示总的记录数
            hidegrid: false,
            multiselect: true,
            //caption : "", // 显示表格的表名称
            //toolbar : [true, "top"],//表格头上的一行白的
            editurl: "/RowEditing",//editurl: "DeleteTableData", //没起作用
            //cellurl: "${pageContext.request.contextPath}/order/editEntity.shtml",
            gridComplete: function () {
                //var ids = $("#table_Yanghu").getDataIDs();
                //for (var i = 0; i < ids.length; i++) {
                //    var rowData = $("#table_Yanghu").getRowData(ids[i]);
                //    if (rowData.Color != "black") {//如果审核不通过，则背景色置于红色
                //        $('#' + ids[i]).find("td").css("background-color", rowData.Color);
                //        $('#' + ids[i]).find("td").css("color", "black");
                //    }
                //}
            }
        });


        //下面是隐藏多选中的全选//
        //var myGrid = $("#table_JiaoBanZhuang");
        //$("#cb_" + myGrid[0].id).hide();

        // Add responsive to jqGrid
        $(window).bind('resize', function () {
            var width = $('.jqGrid_wrapper').width();
            $('#table_QueryInfo').setGridWidth(width);
        });
    };

    this.initPager = function () {
        // Setup buttons
        $("#table_QueryInfo").jqGrid('navGrid', '#pager_QueryInfo', {
            edit: false,
            add: false,
            del: false,
            search: false
        },
            {
                height: 200,
                reloadAfterSubmit: true
            });
    };

    this.initEvent = function () {   
        $('#deleteBtn').bind('click', function () {
            var rowids = jQuery("#table_QueryInfo").jqGrid('getGridParam', 'selarrrow');
            //alert(rowid);
            if (rowids == null || rowids == 'undefined' || rowids.length == 0)
                layer.msg('请先选中要删除的行', { icon: 5, time: 2000 });
            else {
                //做删除
                layer.confirm('确定要删除选中的行？注意删除后不可恢复！', { btn: ['确定', '取消'], title: "提示" }, function () {
                    //var rowDatas = $("#table_Stock").getRowData();//所有的数据
                    var Ids = rowids;

                    $.ajax({

                        url: "DeleteTableData",
                        type: "GET",
                        async: false,
                        data: "Ids=" + escape(Ids),
                        success: function (data) {
                            var json = $.parseJSON(data);
                            if (json.code == 200) {
                                layer.msg('删除' + json.msg + '行成功！', { icon: 1, time: 2000 });

                                var search = $("#searchForm").serialize();
                                $("#table_QueryInfo").jqGrid('setGridParam', {  // 重新加载数据
                                    url: 'GetTableData?' + search,//请求数据的地址
                                    data: search,   //  newdata 是符合格式要求的需要重新加载的数据
                                }).trigger("reloadGrid");
                            }
                            else {
                                layer.msg('删除失败：' + json.msg, { icon: 2, time: 2000 });
                            }
                        }
                    });

                });
            }
        });
    };
}

$(document).ready(function () {
    var tool = new MyTool();
    var userName = tool.getUrlParam('userName');
    var right = tool.getUrlParam('right');
    var query = new QueryInfoTable(userName,right);
    query.initSearch();
    query.initTable();
    query.initPager();
    query.initEvent();
});