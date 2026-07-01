window.onload = function () {
    pwdClick = function (id) {
        //alert(id);
        var url1 = '../Login/ResetPwdPanel?id=' + id;
        //var content1 = '<iframe class="myiframe" id="ifr" src="' + url1 + '"  frameborder="no" border="0" "></iframe>';
        var content1 = '<iframe id="ifr" src="' + url1 + '"  frameborder="no" border="0" "></iframe>';
        //页面层
        //tab层
        layer.tab({
            area: ['500px', '300px'],
            tab: [
                {
                    title: '修改密码',
                    content: content1
                }]
        });
    }

    //打开新的标签页
    openNewPage = function (url, title ,right) {
        var nav = $(window.parent.document).find('.J_menuTabs .page-tabs-content ');
        $(window.parent.document).find('.J_menuTabs .page-tabs-content ').find(".J_menuTab.active").removeClass("active");
        $(window.parent.document).find('.J_mainContent').find("iframe").css("display", "none");
        var iframe = '<iframe class="J_iframe" name="iframe10000" width="100%" height="100%" src=' + url + '?right=' + right + ' frameborder="0" data-id="' + url
            + '" seamless="" style="display: inline;"></iframe>';
        console.log("iframe", iframe);
        $(".J_menuTab[data-id='" + url + "']", window.top.document).find(".fa.fa-times-circle").click(); //关闭该url的tab
        $(window.parent.document).find('.J_menuTabs .page-tabs-content ').append(
            ' <a href="javascript:;" class="J_menuTab active" data-id="' + url  + '">' + title + ' <i class="fa fa-times-circle"></i></a>');
        $(window.parent.document).find('.J_mainContent').append(iframe);
    }

    //点击地区
    regionClick = function (id, this_grade, this_region) {
        Cookies.set('RegionNo', id, { expires: 60, path: '/' });
        Cookies.set('Region', this_region, { expires: 60, path: '/' });
        var menuId;
        var url;

        if ($("#R" + id).html() != '' ) {
            $("#R" + id).toggle();
            //return;
        }
        
        console.log("this_grade", this_grade);

        if (this_grade == 3) {
            menuId = '36';
            url = '../Street/index';
        }
        else if (this_grade == 4) {
            menuId = '37';
            url = '../Comminuty/index';
        }
        else if (this_grade == 5) {
            menuId = '38';
            url = '../Building/index';
        }
        else if (this_grade == 6) {
            menuId = '39';
            url = '../Location/index';
        }

        if (this_grade == 3 || this_grade == 4 || this_grade == 5 || this_grade == 6) {
            $.ajax(
                {
                    url: 'GetRightByMenu?menuId=' + menuId,
                    type: "GET",
                    async: false,
                    data: '',
                    success: function (res) {
                        console.log("res", res);
                        openNewPage(url, this_region, res);
                    }
                 });
        }

        //if (this_grade == 3) {
        //    openNewPage('../Street/index', this_region ,right);
        //}
        //else if (this_grade == 4) {
        //    openNewPage('../Comminuty/index', this_region, right);
        //}
        //else if (this_grade == 5) {
        //    openNewPage('../Building/index', this_region, right);
        //}
        //else if (this_grade == 6) {
        //    openNewPage('../Location/index', this_region, right);
        // }

        var url = 'GetRegions?parentNo=' + id;
        //$.cookie('RegionNo', id, { expires: 7, path: '/' });
        $.get(url, function (result) {
            var json = jQuery.parseJSON(result);
            var html = '';
            //var iframe0 = document.getElementsByName("iframe0");
            for (var i = 0; i < json.length; i++)
            {
                var region = json[i];
                if (region.Grade == 1) {
                    console.log("Region为", region.Region)
                    html += '<a href="#" onclick="regionClick(' + region.RegionNo + ', ' + region.Grade + ',\'' + region.Region + '\')">'
                    html += '<span class="nav-label">' + region.Region + '</span >';
                    html += '</a>'

                    html += '<ul class="nav nav-second-level" aria-expanded="true">'
                    html += '<li id = "R' + region.RegionNo + '" style="margin-left:10px;"></li>'
                    html += '</ul>'
                }
                else if (region.Grade == 2) {
                    console.log("Region为", region.Region)
                    html += '<a href="#" onclick="regionClick(' + region.RegionNo + ', ' + region.Grade + ',\'' + region.Region + '\')">'
                    html += '<span class="nav-label">' + region.Region + '</span >';
                    html += '</a>'

                    html += '<ul class="nav nav-second-level" aria-expanded="true">'
                    html += '<li id = "R' + region.RegionNo + '" style="margin-left:20px;"></li>'
                    html += '</ul>'
                    
                }
                else if (region.Grade == 3) {
                    console.log("Region为", region.Region)
                    //http://localhost:4498/Street/index
                    html += '<a href="#" onclick="regionClick(' + region.RegionNo + ', ' + region.Grade + ',\'' + region.Region + '\')">'
                    html += '<span class="nav-label">' + region.Region + '</span >';
                    html += '</a>'

                    html += '<ul class="nav nav-second-level" aria-expanded="true">'
                    html += '<li id = "R' + region.RegionNo + '" style="margin-left:20px;"></li>'
                    html += '</ul>'
                }
                else if (region.Grade == 4) {
                    console.log("Region为", region.Region)
                    //http://zhzm.gdjtypt.com/Comminuty/index
                    html += '<a href="#" onclick="regionClick(' + region.RegionNo + ', ' + region.Grade + ',\'' + region.Region + '\')">'
                    html += '<span class="nav-label">' + region.Region + '</span >';
                    html += '</a>'

                    html += '<ul class="nav nav-second-level" aria-expanded="true">'
                    html += '<li id = "R' + region.RegionNo + '" style="margin-left:20px;"></li>'
                    html += '</ul>'
                }
                else if (region.Grade == 5) {
                    console.log("Region为", region.Region)
                    //http://localhost:4498/Building/index
                    html += '<a href="#" onclick="regionClick(' + region.RegionNo + ', ' + region.Grade + ',\'' + region.Region + '\')">'
                    html += '<span class="nav-label">' + region.Region + '</span >';
                    html += '</a>'

                    html += '<ul class="nav nav-second-level" aria-expanded="true">'
                    html += '<li id = "R' + region.RegionNo + '" style="margin-left:20px;"></li>'
                    html += '</ul>'
                }
                else if (region.Grade == 6) {
                    console.log("Region为", region.Region)
                    //http://zhzm.gdjtypt.com/Location/index
                    html += '<a href="#" onclick="regionClick(' + region.RegionNo + ', ' + region.Grade + ',\'' + region.Region + '\')">'
                    html += '<span class="nav-label">' + region.Region + '</span >';
                    html += '</a>'

                    html += '<ul class="nav nav-second-level" aria-expanded="true">'
                    html += '<li id = "R' + region.RegionNo + '" style="margin-left:20px;"></li>'
                    html += '</ul>'
                }
                else
                {
                    html += '<a href="#">'
                    html += '<span class="nav-label">' + region.Region + '</span >';
                    html += '</a>'
                    $("#R" + region.ParentNo).addClass("active");
                }
            }
        
            $("#R" + id).html(html);
        });

        //}
    }


}

