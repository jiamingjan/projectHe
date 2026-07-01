function MyTool() {
    this.getUrlParam = function (name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
        var data = decodeURI(window.location.search);
        var r = data.substr(1).match(reg);  //匹配目标参数
        if (r != null) return unescape(r[2]); return null; //返回参数值
    }
    //处理 # + 等特殊字符
    this.urlDeal = function(url){
        return escape(url).replace(/\+/g, '%2B').replace(/\"/g, '%22').replace(/\'/g, '%27').replace(/\//g, '%2F').replace(/\#/g, '%23');
    }

    this.getDateString = function () {
        var now = new Date();
        var year = now.getFullYear();       //年
        var month = now.getMonth() + 1;     //月
        var day = now.getDate();            //日
        
        var hh = now.getHours();            //时
        var mm = now.getMinutes();          //分
        var ss = now.getSeconds(); //秒

        if (month < 10) {
            month = "0" + month;
        }
        if (day < 10) {
            day = "0" + day;
        }

        if (hh < 10) {
            hh = "0" + hh;
        }
        if (mm < 10) {
            mm = "0" + mm;
        }
        if (ss < 10) {
            ss = "0" + ss;
        }

        return "" + year + month + day + hh + mm + ss;
    }

    //获取某年某月的天数
    this.getDaysInOneMonth = function (year, month) {    
        month = parseInt(month, 10);
        var d = new Date(year, month, 0);
        return d.getDate();
    }

    this.jqgrid2csv = function (dom, fileName) {    
        var options = {
            csvEnclosure: "\"",
            csvSeparator: ",",
            type: "text/csv;charset=utf-8"
        }
        function fake_click(obj) {
            var ev = document.createEvent("MouseEvents");
            ev.initMouseEvent("click", true, false, window);
            obj.dispatchEvent(ev);
        }

        function save_local_file(name, data) {
            var opts = {
                type: options.type
            }
            var url = window.URL || window.webkitURL || window;
            var file;
            try {
                file = new File([data], name, opts);
            } catch (e) {
                file = new Blob([data], opts);
            }

            var link = document.createElementNS("http://www.w3.org/1999/xhtml", "a");
            link.href = url.createObjectURL(file);
            link.download = name;
            fake_click(link);
        }
        function escapeRegExp(string) {
            return string.replace(/([.*+?^=!:${}()|\[\]\/\\])/g, "\\$1");
        }
        function replaceAll(s, find, replace) {
            return s.replace(new RegExp(escapeRegExp(find), 'g'), replace);
        }
        function csvString(csvValue) {
            var result = replaceAll(csvValue, options.csvEnclosure, options.csvEnclosure + options.csvEnclosure);
            //if ( result.indexOf(options.csvSeparator) >= 0 || /[\r\n ]/g.test(result) )
            result = options.csvEnclosure + result + options.csvEnclosure;
            return result;
        }

        var lines = $(dom).find(".ui-jqgrid-htable tr,.ui-jqgrid-btable tr");
        var i;
        var data = [];
        for (i = 0; i < lines.length; i++) {
            if ($(lines[i]).hasClass("jqgfirstrow")) continue;
            var fields = $(lines[i]).find("td");
            if (fields.length < 1) fields = $(lines[i]).find("th");
            var c;
            var a = [];
            for (c = 0; c < fields.length; c++) {
                var v = $(fields[c]).text();
                if (v == undefined || v == null) v = '';
                a.push(csvString(v));
            }
            data.push(a.join(",") + "\r\n");
        }

        var s = data.join("");

        save_local_file(fileName, s);
    }

    this.getSearchSelectOption = function (sid, url, selectedItem, defaultItem) {
        if (defaultItem == null || defaultItem == '')
            defaultItem = "请选择";
        $.ajax({
            type: "get",
            url: url,
            async: true,
            success: function (data) {
                var str = "";
                var json = $.parseJSON(data);
                str = "<option value='" + defaultItem+ "'>" + defaultItem + "</option>"; //默认
                for (var i = 0; i < json.length; i++) {
                    //注意，json[i].Key传过来的是子表的自增id，这里还是用不可重复的有意义的值吧
                    if (json[i].Value == selectedItem) //默认选中项
                        str += "<option value='" + json[i].Value/*json[i].Key*/ + "'selected='selected'>" + json[i].Value + "</option>";
                    else
                        str += "<option value='" + json[i].Value/*json[i].Key*/ + "'>" + json[i].Value + "</option>";
                }
                $(sid).html(str);
     //           $(sid).selectpicker('refresh'); //这句有问题
                //$(sid).selectpicker('render');
                return str;
            }
        });
    }

    this.getSelectOptionNoDefault = function (sid, url, selectedItem) {
        $.ajax({
            type: "get",
            url: url,
            async: true,
            success: function (data) {
                var str = "";
                var json = $.parseJSON(data);
                //str = "<option value='" + "" + "'>" + "请选择" + "</option>"; //默认
                for (var i = 0; i < json.length; i++) {
                    //注意，json[i].Key传过来的是子表的自增id，这里还是用不可重复的有意义的值吧
                    if (json[i].Value == selectedItem) //默认选中项
                        str += "<option value='" + json[i].Value/*json[i].Key*/ + "'selected='selected'>" + json[i].Value + "</option>";
                    else
                        str += "<option value='" + json[i].Value/*json[i].Key*/ + "'>" + json[i].Value + "</option>";
                }
                $(sid).html(str);
                //           $(sid).selectpicker('refresh'); //这句有问题
                //$(sid).selectpicker('render');
                return str;
            }
        });
    }

    this.isRealNum = function (val) {    
        // isNaN()函数 把空串 空格 以及NUll 按照0来处理 所以先去除，

        if (val === "" || val == null) {
            return false;
        }
        if (!isNaN(val)) {
            //对于空数组和只有一个数值成员的数组或全是数字组成的字符串，isNaN返回false，例如：'123'、[]、[2]、['123'],isNaN返回false,
            //所以如果不需要val包含这些特殊情况，则这个判断改写为if(!isNaN(val) && typeof val === 'number' )
            return true;
        }

        else {
            return false;
        }
    }

   
    //传入 YYYY-MM , YYYY-MM  (2020-09)  (2020-12)  返回 YYYY-MM 数组
    this.getYearAndMonth = function (start, end) {
        var result = [];
        var starts = start.split('-');
        var ends = end.split('-');
        var staYear = parseInt(starts[0]);
        var staMon = parseInt(starts[1]);
        var endYear = parseInt(ends[0]);
        var endMon = parseInt(ends[1]);
        while (staYear <= endYear) {
            if (staYear === endYear) {
                while (staMon <= endMon) {
                    var str = staYear + '-' + (staMon >= 10 ? staMon : '0' + staMon);
                    result.push(str);
                    staMon++;
                }
                staYear++;
            } else {
                //staMon++;
                if (staMon > 12) {
                    staMon = 1;
                    staYear++;
                }
                var str = staYear + '-' + (staMon >= 10 ? staMon : '0' + staMon);
                result.push(str);
                staMon++;
            }
        }
        //console.log(result)
        return result;
    }  

    this.getAuthHeader = function (start, end) {
        return { 'Authorization': `Bearer ${Cookies.get('token')}` };
    }
}




