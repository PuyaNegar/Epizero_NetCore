$(document).ready(function () {
    //apply on typing and focus
    $('html').on('keyup', 'input.currency', function () {
        $(this).manageCommas();
    });
    $(document).on('focusout', 'input, textarea', function () {
        $(this).val($(this).val().trim());
        $(this).val($(this).val().replace(/\s\s+/g, ' '));
        var str = $(this).val();
        str = str.replace(/۰/g, '0');
        str = str.replace(/۱/g, '1');
        str = str.replace(/۲/g, '2');
        str = str.replace(/۳/g, '3');
        str = str.replace(/۴/g, '4');
        str = str.replace(/۵/g, '5');
        str = str.replace(/۶/g, '6');
        str = str.replace(/۷/g, '7');
        str = str.replace(/۸/g, '8');
        str = str.replace(/۹/g, '9');
        str = str.replace(/ك/g, 'ک');
        str = str.replace(/ي/g, 'ی');
        str = str.replace(/ى/g, 'ی');
        $(this).val(str).change();
    });
});

String.prototype.addComma = function () {
    return this.replace(/(.)(?=(.{3})+$)/g, "$1,")
}

$.fn.manageCommas = function () {
    return this.each(function () {
        $(this).val($(this).val().replace(/(,| )/g, '').addComma()).change();
    });
}
$(function () {

    var width = $(window).width(),
        height = $(window).height();

    if ((width >= 1200) && (height >= 0)) {

        /*--------------------- Menu Hover ---------------------*/
        $(".mega-dropdown").hover(function () {

            $(this).find('.mega-dropdown-menu').toggleClass('show');
        });
        /*--------------------- /Menu Hover ---------------------*/

    } else {

        $('.navbar-toggler').click(function () {

            $(this).toggleClass('mm-wrapper_opened');
            $('#navbarNavAltMarkup').toggleClass('show');
        });
        $(document).click(function (event) {
            if (!$(event.target).closest(".navbar-toggler,#navbarNavAltMarkup").length) {
                $(".navbar-toggler").removeClass('mm-wrapper_opened');
                $('#navbarNavAltMarkup').removeClass('show');
            }
        });
        $(document).click(function (event) {
            if (!$(event.target).closest(".navbar-toggler,#navbarNavAltMarkup").length) {
                $(".navbar-toggler").removeClass('mm-wrapper_opened');
                $('#navbarNavAltMarkup').removeClass('show');
            }
        });
    }

});
$(function () {
    InitialChart();
    $('#back-to-top').on('click', function () {
        $('#back-to-top').tooltip('hide');
        $('body,html').animate({
            scrollTop: 0
        }, 800);
        return false;
    });
    //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=
    toastr.options = {
        //positionClass: "toastr-bottom-left",
        progressBar: true,
        closeMethod: 'fadeOut',
        closeDuration: 300,
        closeEasing: 'swing',
        rtl: true
    }
    $(document).on('click', function () {
        $('#result').hide();
        $('#input-s').val("");
    });

    if ($('#input-s').val() == "") {
        $('#result').hide();
    }
    $('#input-s').keyup(function () {
        $('#result').show();
        if ($('#input-s').val() == "") {
            $('#result').hide();
        }
    });

    $('body').on('click', '.loginModalBtn', function () {
        $('#loginModal').modal({ backdrop: 'static', keyboard: false });
        $('#loginModal').modal('show');
    });

    $('.menuBtn').click(function (e) {
        e.preventDefault();
        if ($('.menuBtn').hasClass('clicked')) {
            $(this).removeClass('clicked');
            $('.mainMenu').removeClass('flip');
            $('.container').removeClass('flip');
        } else {
            $(this).addClass('clicked');
            $('.mainMenu').addClass('flip');
            $('.container').addClass('flip');
        }
    });

    $(".mainMenu a").click(function (e) {
        e.preventDefault();

        _this = $(this);
        _page = _this.data('page');

        $('.menuBtn').removeClass('clicked');
        $('.mainMenu').removeClass('flip');
        $('.container').removeClass('flip');

        $('.mainMenu a').removeClass('active');
        _this.addClass('active');

        $(".page").removeClass("active fade");
        $(".page-" + _page).addClass("active fade");

        setTimeout(function () {
            $("html, body").animate({
                scrollTop: 0
            }, "slow");
        }, 500);


        window.console = window.console || function (t) { };
        if (document.location.search.match(/type=embed/gi)) {
            window.parent.postMessage("resize", "*");
        }

        $('.menuBtn').click(function () {
            if ($('.menuBtn').hasClass('clicked')) {
                $(this).removeClass('clicked');
                $('.mainMenu').removeClass('flip');
                $('.container').removeClass('flip');
            } else {
                $(this).addClass('clicked');
                $('.mainMenu').addClass('flip');
                $('.container').addClass('flip');
            }
        });

        $(".mainMenu a").click(function (e) {
            e.preventDefault();

            _this = $(this);
            _page = _this.data('page');

            $('.menuBtn').removeClass('clicked');
            $('.mainMenu').removeClass('flip');
            $('.container').removeClass('flip');

            $('.mainMenu a').removeClass('active');
            _this.addClass('active');

            $(".page").removeClass("active fade");
            $(".page-" + _page).addClass("active fade");

            setTimeout(function () {
                $("html, body").animate({
                    scrollTop: 0
                }, "slow");
            }, 500);

        });
    });
});
var chart = null;
function InitialChart() {

    if ($('#container-chart').length > 0) {
        Highcharts.chart('container-chart', {
            chart: {
                type: 'spline',
                scrollablePlotArea: {
                    minWidth: 600,
                    scrollPositionX: 1
                }
            },
            title: {
                text: 'Wind speed during two days',
                align: 'left'
            },
            subtitle: {
                text: '13th & 14th of February, 2018 at two locations in Vik i Sogn, Norway',
                align: 'left'
            },
            xAxis: {
                type: 'datetime',
                labels: {
                    overflow: 'justify'
                }
            },
            yAxis: {
                title: {
                    text: 'Wind speed (m/s)'
                },
                minorGridLineWidth: 0,
                gridLineWidth: 0,
                alternateGridColor: null,
                plotBands: [{ // Light air
                    from: 0.3,
                    to: 1.5,
                    color: 'rgba(68, 170, 213, 0.1)',
                    label: {
                        text: 'Light air',
                        style: {
                            color: '#606060'
                        }
                    }
                }, { // Light breeze
                    from: 1.5,
                    to: 3.3,
                    color: 'rgba(0, 0, 0, 0)',
                    label: {
                        text: 'Light breeze',
                        style: {
                            color: '#606060'
                        }
                    }
                }, { // Gentle breeze
                    from: 3.3,
                    to: 5.5,
                    color: 'rgba(68, 170, 213, 0.1)',
                    label: {
                        text: 'Gentle breeze',
                        style: {
                            color: '#606060'
                        }
                    }
                }, { // Moderate breeze
                    from: 5.5,
                    to: 8,
                    color: 'rgba(0, 0, 0, 0)',
                    label: {
                        text: 'Moderate breeze',
                        style: {
                            color: '#606060'
                        }
                    }
                }, { // Fresh breeze
                    from: 8,
                    to: 11,
                    color: 'rgba(68, 170, 213, 0.1)',
                    label: {
                        text: 'Fresh breeze',
                        style: {
                            color: '#606060'
                        }
                    }
                }, { // Strong breeze
                    from: 11,
                    to: 14,
                    color: 'rgba(0, 0, 0, 0)',
                    label: {
                        text: 'Strong breeze',
                        style: {
                            color: '#606060'
                        }
                    }
                }, { // High wind
                    from: 14,
                    to: 15,
                    color: 'rgba(68, 170, 213, 0.1)',
                    label: {
                        text: 'High wind',
                        style: {
                            color: '#606060'
                        }
                    }
                }]
            },
            tooltip: {
                valueSuffix: ' m/s'
            },
            plotOptions: {
                spline: {
                    lineWidth: 4,
                    states: {
                        hover: {
                            lineWidth: 5
                        }
                    },
                    marker: {
                        enabled: false
                    },
                    pointInterval: 3600000, // one hour
                    pointStart: Date.UTC(2018, 1, 13, 0, 0, 0)
                }
            },
            series: [{
                name: 'Hestavollane',
                data: [
                    3.7, 3.3, 3.9, 5.1, 3.5, 3.8, 4.0, 5.0, 6.1, 3.7, 3.3, 6.4,
                    6.9, 6.0, 6.8, 4.4, 4.0, 3.8, 5.0, 4.9, 9.2, 9.6, 9.5, 6.3,
                    9.5, 10.8, 14.0, 11.5, 10.0, 10.2, 10.3, 9.4, 8.9, 10.6, 10.5, 11.1,
                    10.4, 10.7, 11.3, 10.2, 9.6, 10.2, 11.1, 10.8, 13.0, 12.5, 12.5, 11.3,
                    10.1
                ]

            }, {
                name: 'Vik',
                data: [
                    0.2, 0.1, 0.1, 0.1, 0.3, 0.2, 0.3, 0.1, 0.7, 0.3, 0.2, 0.2,
                    0.3, 0.1, 0.3, 0.4, 0.3, 0.2, 0.3, 0.2, 0.4, 0.0, 0.9, 0.3,
                    0.7, 1.1, 1.8, 1.2, 1.4, 1.2, 0.9, 0.8, 0.9, 0.2, 0.4, 1.2,
                    0.3, 2.3, 1.0, 0.7, 1.0, 0.8, 2.0, 1.2, 1.4, 3.7, 2.1, 2.0,
                    1.5
                ]
            }],
            navigation: {
                menuItemStyle: {
                    fontSize: '10px'
                }
            }
        });
    }


}
//********************************************************************
function InitialChosen(elementId) {
    $(elementId).chosen({
        no_results_text: "موردی یافت نشد",
        width: "100%",
        rtl: true,
    });
}
//********************************************************************
function destroyChosen(elementId) {
    $(elementId).chosen('destroy');
}
//********************************************************************
function openCitySelectorModal(parentModalId, targetElementForId, targetElementForText) {
    $('#CitySelectorModal').attr('data-parentModalId', parentModalId);
    $('#CitySelectorModal').attr('data-targetElementForId', targetElementForId);
    $('#CitySelectorModal').attr('data-targetElementForText', targetElementForText);
    $('#CitySelectorModal').modal('show');
}
//********************************************************************

//================================================
function IsNullOrEmptyString(value) {
    if (value == null || value == '') {
        return true;
    } else {
        return false;
    }
}
function DataTransfer(url, metod, jsonData, iconLoader, runOnSuccess, runOnError) {
    $(iconLoader).show();
    $.ajax({
        url: url,
        type: metod,
        data: jsonData,
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (e) {
            if (runOnSuccess != null) {
                runOnSuccess(e);
            }
            $(iconLoader).hide();
        },
        error: function (e) {
            console.log(url);
            if (e.status == 400) {
                if (runOnError != null) {
                    runOnError(e);
                }
            } else { 
                if (e.status != 401) {
                    toastr.error('خطا در ارتباط با سرور');
                }
            }
            $(iconLoader).hide();
        },
        complete: function (xhr, textStatus) {
            if (xhr.status == 401) {
                $('#loginModal').modal({ backdrop: 'static', keyboard: false });
                $('#loginModal').modal('show');
            }
        }
    });
}
function CreateComboLoader(url, comboName, iconLoader, valueName, textName, id, isBlankCombo, callbackSuccessDelegate, callbackErrorDelegate) {
    $(comboName).children('option').remove();
    DataTransfer(url + id, 'get', '', $(comboName).next('i'), function (f) {
        if (!f.IsSuccess) {
            toastr.remove();
            toastr.error(f.Message);
            if (callbackErrorDelegate != null) {
                callbackErrorDelegate();
            }
        } else {
            var listStr = '';
            if (isBlankCombo) {
                var str = '<option data-otherValue="?" value="#">!</option>';
                str = str.replace('#', '');
                str = str.replace('!', 'لطفا انتخاب نماييد');

                listStr += str;
            }
            for (i = 0; i < f.Value.length; i++) {
                var str = '<option data-otherValue="?" value="#">!</option>';
                str = str.replace('#', f.Value[i][valueName]);
                str = str.replace('!', f.Value[i][textName]);
                str = str.replace('?', f.Value[i]['Data']);
                listStr += str;
            }
            $(comboName).html(listStr);
            if (callbackSuccessDelegate != null) {
                callbackSuccessDelegate();
            }
        }
    }, function (e) { });
}

//================================================
var mainViewModel = {
    homework: ko.observable({}),
    loginWithUser: ko.observable({}),
    courseMeetingStudents: ko.observable([]),
    sattlementAggregationSummery: ko.observable({}),
    sattlements: ko.observable([]),
    addHomworkStudents: ko.observable({}),
    editHomworkStudents: ko.observable({}),
    homeworkStudent: ko.observable({}),
    homeworkTeachers: ko.observable({}),
    homeworkReceived: ko.observable({}),
    changePassword: ko.observable({}),
    addGradStudents: ko.observable({}),
    courseMeetingBookletStudents: ko.observable({}),
    courseMeetingVideos: ko.observable({}),
    addCourseMeetingBookletStudents: ko.observable({}),
    editCourseMeetingBookletStudents: ko.observable({}),
    studentCourseQuestions: ko.observable([]),
    courseStudentFinancialsSummery: ko.observable(null),
    detailOnlineExam: ko.observable({}),
    contextQuestion: ko.observable({}),
    e: ko.observable({}),  //جهت استفاده در فرم های ویرایش
    fe: ko.observable({}),
    ac : ko.observable({}),// مشاهده و تعیین وضعیت پاسخ ها
    confirm : ko.observable({}),// وضعیت پاسخ ها
    adminAnswerContex: ko.observable({}), // متن سوال
    absentationStudents: ko.observable({}),//    حضور و غیاب دانش آموزان
    updateAbsentationStudents: ko.observable({}),//    حضور و غیاب دانش آموزان ویرایش
    addAbsentationStudents: ko.observable({})//    حضور و غیاب دانش آموزان افزودن
};
ko.applyBindings(mainViewModel, document.getElementById('mainArea'));
//================================================
function datePickerSetNullIfEmptyValue(elementId) {
    if ($(elementId).val() == '____/__/__') {
        $(elementId).val('').change();
    }
    $(elementId).change();
}
//================================================

var table = null; 
var extendViewModelColumns = [];
function getDataGridColumns() {
    var list = [];
    if ($('#modelList > thead').attr('data-checkboxColumn') == 'true' || $('#modelList > thead').attr('data-checkboxColumn') == null) {
        list.push({
            "targets": 0,
            "defaultContent": '<div class="checkbox"><label style="font-size: 1.2em"><input type="checkbox" value=""><span class="cr"><i class="cr-icon fa fa-check"></i></span></label></div>',
            "orderable": false,
            "data": null,
        });
    }
    for (i = 0; i < $('#modelList > thead > tr > th').length; i++) {
        var columnName = $('#modelList > thead > tr > th').eq(i).attr('data-viewModel');
        var orderable = $('#modelList > thead > tr > th').eq(i).attr('data-orderable');
        var thousandSeparator = $('#modelList > thead > tr > th').eq(i).attr('data-thousandseparator');
        console.log(thousandSeparator);
        if (columnName != null && columnName != 'Id') {
            var columnOption = { "data": columnName, "orderable": orderable == null ? true : false };
            if (thousandSeparator == 'true') {
                columnOption.render = $.fn.dataTable.render.number(',', '.', 0);
            }
            list.push(columnOption);
        }
    }
    if ($('#modelList > thead').attr('data-actionColumn') == 'true' || $('#modelList > thead').attr('data-actionColumn') == null) {
        list.push({
            "targets": -1,
            "data": null,
            "orderable": false,
            "defaultContent": "<button class='btn btn-info btn-xs edit'  type='button' style='margin-right:5px; margin-top:2px;  width:60px;'><i class='fa fa-pencil' style='margin-left: 3px;'></i>ویرایش</button>"
        });
    }
    if ($('#modelList > thead').attr('data-actionColumn') == 'custom') {
        list.push({
            "targets": -1,
            "data": null,
            "orderable": false,
            "defaultContent": $('#operands').html()
        });
    }
    return list;
}

function getRequestColumns() {
    var list = [];
    for (i = 0; i < $('#modelList > thead > tr > th').length; i++) {
        var a = $('#modelList > thead > tr > th').eq(i).attr('data-viewModel');
        if (a != null) {
            list.push(a);
        }
    }
    if (extendViewModelColumns.length != 0) {
        for (i = 0; i < extendViewModelColumns.length; i++) {
            list.push(extendViewModelColumns[i]);
        }
    }
    return list;
}
//============================================================
function dataTableConfig(url) { 
            var colCounts = $('#modelList > thead> tr> th').length; 
            var listDisplayCols = [];
            for (i = 1; i < colCounts - 1; i++)
                listDisplayCols.push(i); 
            var options = {
                stateSave: true, 
                'processing': true,
                'pageLength': 100,
                'serverSide': true, 
                ajax: {
                    "url": url,
                    "type": "post",
                    'beforeSend': function (request) {
                        $('.wrapper-parent').show();
                    },
                    data: function (d) {
                        //d.searchWith = $('#SearchWith').val();
                        d.RequestColumns = getRequestColumns();
                        d.Filters = ko.toJSON(mainViewModel.fe());
                    },
                    'complete': function (xhr, textStatus) {
                        if (xhr.status == 401) {
                            window.location.href = '/Account/Index/';
                        }
                        $('.wrapper-parent').hide();
                        $('#modelList > thead > tr > th:first').removeClass('sorting_asc');
                        $(window).resize();
                    },
                    error: function (e) {
                        toastr.remove();
                        toastr.error('خطا در ارتباط با سرور');
                    },
                    "dataSrc": function (json) {
                        if (!json.IsSuccess) {
                            $('.wrapper-parent').hide();
                            toastr.error(json.Message);
                        }
                        json.draw = json.Value.draw;
                        json.recordsTotal = json.Value.recordsTotal;
                        json.recordsFiltered = json.Value.recordsFiltered;
                        return json.Value.data; 
                    }, 
                },
                "columns": getDataGridColumns(),
                //dom: '<"html5buttons"B>lTfgitp', 
                order: [],
                columnDefs: [{ "type": 'pstring', targets: '_all' }],
                language: {
                    "sEmptyTable": "هیچ داده ای در جدول وجود ندارد",
                    "sInfo": "نمایش _START_ تا _END_ از _TOTAL_ رکورد",
                    "sInfoEmpty": "نمایش 0 تا 0 از 0 رکورد",
                    "sInfoFiltered": "(فیلتر شده از _MAX_ رکورد)",
                    "sInfoPostFix": "",
                    "sInfoThousands": ",",
                    "sLengthMenu": "نمایش _MENU_ رکورد",
                    "sLoadingRecords": "در حال بارگزاری...",
                    "sProcessing": "در حال پردازش...",
                    "sSearch": '<div class="input-group" style="position: relative;margin-left:15px;"><span class="glyphicon glyphicon-remove serach-clear" style=""></span> <span class="input-group-addon"><span class="glyphicon glyphicon-search"></span></span> ',
                    "searchPlaceholder": 'جستجو...',
                    "sZeroRecords": "رکوردی با این مشخصات پیدا نشد",
                    "oPaginate": {
                        "sFirst": "ابتدا",
                        "sLast": "انتها",
                        "sNext": "بعدی",
                        "sPrevious": "قبلی"
                    },
                    "oAria": {
                        "sSortAscending": ": فعال سازی نمایش به صورت صعودی",
                        "sSortDescending": ": فعال سازی نمایش به صورت نزولی"
                    }
                }, 
            } 
            table = $('#modelList').DataTable(options);
}
//==============================================
function dataRead(url) { 
    if (table == null) { 
        dataTableConfig(url); 
    } else {
        table.ajax.url(url).load();
    }
}
$('#applyFilter').click(function () {
    toastr.remove(); 
    dataRead($(this).attr('data-url') ,  ko.toJSON(mainViewModel.fe()));
});


$(function () { 
    //******************************************* start login with username
    $('body').on('submit', '#loginWithUsernameForm', function () {
        if ($(this).valid()) {
            toastr.remove();
            $('.loader').show();

            DataTransfer('/api/Identities/Account/LoginWithUsername', 'post', ko.toJSON(mainViewModel.loginWithUser()), '.icon-loader', function (e) {
                toastr.success(e.Message);
                $('.loader').hide();
                window.location.href = "/";
            }, function (e) {
                toastr.error(e.responseJSON.Message);
            });
        }
        return false;
    });
    //******************************************* end login with username

    //================================================================================
    setInterval(function () {
        DataTransfer('/Home/KeepAlive/', 'post', '', '', function (e) { }, function (e) { });
    }, 150000);
    //================================================================================
    $('[data-toggle="tooltip"]').tooltip();

    //====================================================================================== Begin Change Password
    $('#changePasswordBtn').click(function () {
        $('#changePasswordModal').modal({ backdrop: 'static', keyboard: false });
        $('#changePasswordModal').modal('show');
    });
    //================================================================================
    $('body').on('submit', '#changePasswordForm', function () {
        if ($(this).valid()) {
            toastr.remove();
            DataTransfer('/api/Identities/Account/ChangePassword', 'post', ko.toJSON(mainViewModel.changePassword()), '.loader', function (e) {
                toastr.success(e.Message);
                $('#changePasswordModal').modal('hide');
                mainViewModel.changePassword({});
            }, function (e) {
                toastr.error(e.responseJSON.Message);
            });
        }
        return false;
    });
    //====================================================================================== End Change Password
    
});

