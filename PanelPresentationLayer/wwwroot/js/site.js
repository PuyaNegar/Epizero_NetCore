//************************************************************** General Script 
$(document).ready(function () {
    //apply on typing and focus
    $('html').on('keyup', 'input.currency', function () {
        $(this).manageCommas();
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

//$.fn.santizeCommas = function() {
//  return $(this).val($(this).val().replace(/(,| )/g,''));
//}
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
function rebulidChosen(elementId) {
    try {
        destroyChosen(elementId);
    } catch (ex) { }
    try {
        InitialChosen(elementId);
    } catch (ex) { }
}
//********************************************************************
function CheckForShowCombobox(comboBoxId) {

    if ($(comboBoxId).children().length == 0) {
        $('#ComboBoxSection').hide();
        $('#FreeSection').show();
    } else {
        $('#ComboBoxSection').show();
        $('#FreeSection').hide();
    }
}
//****************************************
function datePickerSetNullIfEmptyValue(elementId) {
    if ($(elementId).val() == '____/__/__') {
        $(elementId).val('').change();
    }
    $(elementId).change();
}
//***************************************
function GenerateReturnBtn() {
    var btnTemplate = '<button id="btnReturn" type="button" class="btn btn-default" style="width:100px;float:left;margin-left:15px;">بازگشت <span class="glyphicon glyphicon-arrow-left"></span></button>';
    $('.buttons-preview').append(btnTemplate);
    $('body').on('click', '#btnReturn', function () {
        window.history.back();
    });
}
//**************************************
function IsNullOrEmptyString(value) {
    if (value == null || value == '') {
        return true
    } else {
        return false;
    }
}
//**************************************
function openCitySelectorModal(parentModalId, targetElementForId, targetElementForText) {
    $('#CitySelectorModal').attr('data-parentModalId', parentModalId);
    $('#CitySelectorModal').attr('data-targetElementForId', targetElementForId);
    $('#CitySelectorModal').attr('data-targetElementForText', targetElementForText);
    $('#CitySelectorModal').modal('show');
}
function openLevelSelectorModal(parentModalId, targetElementForId, targetElementForText) {
    $('#LevelSelectorModal').attr('data-parentModalId', parentModalId);
    $('#LevelSelectorModal').attr('data-targetElementForId', targetElementForId);
    $('#LevelSelectorModal').attr('data-targetElementForText', targetElementForText);
    $('#LevelSelectorModal').modal('show');
}
//**************************************
function openLessonSelectorModal(parentModalId, targetElementForId, targetElementForText) {
    $('#LessonSelectorModal').attr('data-parentModalId', parentModalId);
    $('#LessonSelectorModal').attr('data-targetElementForId', targetElementForId);
    $('#LessonSelectorModal').attr('data-targetElementForText', targetElementForText);
    $('#LessonSelectorModal').modal('show');
}
//************************************
$(function () {
    $('#sidebar a[href="' + window.location.pathname + '"]').parents('li').addClass('active').addClass('open');
    $('#sidebar a[href="' + window.location.pathname + '"]').parent('li').removeClass('open').addClass('active');
    //************************************************************************
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
    $(document).on('keyup', 'input, textarea', function () {
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

    //********************************************************************** toastr option
    toastr.options = {
        positionClass: "toastr-bottom-left",
        progressBar: true,
        closeMethod: 'fadeOut',
        closeDuration: 300,
        closeEasing: 'swing',
        rtl: true
    }
    //********************************************************************
    $('.modal-dialog').parent('div').on('shown.bs.modal', function (e) {
        $('.modal-dialog').removeAttr('style');
    });
    //********************************************************************
    $('.modal-dialog').draggable({
        handle: ".modal-header"
    });
    //********************************************************************
    $('.modal').on('show.bs.modal', function (e) {
        $('html').css('overflow', 'hidden');
    });
    //********************************************************************
    $('.modal').on('hide.bs.modal', function (e) {
        $('html').css('overflow', 'auto');
    });
    //********************************************************************
    $('input').attr('autocomplete', "off");
    //********************************************************************
    $('html').on('click', 'ul.submenu > li > a ', function (event) {
        if ($('#sidebar').hasClass('menu-compact')) {

        }
    });
    $('#refresh-toggler').click(function () {
        window.location.reload(true);
    });

});
//==============================================================================
function resetForm(formId, delegateFn) {
    if (delegateFn != null)
        delegateFn();
    MainViewModel.ch({});
    $("#" + formId).validate().resetForm();
    $('.field-validation-error')
        .removeClass('field-validation-error')
        .addClass('field-validation-valid');
    $('span.field-validation-valid > span').remove();
    $('.input-validation-error')
        .removeClass('input-validation-error')
        .addClass('valid');
    $('span.input-validation-valid > span').remove();
}
//==============================================================================
function reBindAfterAjaxLoading() {
    $(function () {
        $('.modal-dialog').draggable({
            handle: ".modal-header"
        });
        //****************************************************
        $('.modal-dialog').parent('div').on('hidden.bs.modal', function (e) {
            $('.modal-dialog').removeAttr('style');
        });
        //****************************************************
        $('input').attr('autocomplete', "off");
        //****************************************************
        $('#sidebar  li').removeClass('active');
        $('#sidebar a[href="' + window.location.pathname + '"]').parents('li').addClass('active').addClass('open');
        $('#sidebar a[href="' + window.location.pathname + '"]').parent('li').removeClass('open').addClass('active');
        //****************************************************************************************** rebind widget-buttons
        $('.widget-buttons *[data-toggle="maximize"]').on("click", function (event) {
            event.preventDefault();
            var widget = $(this).parents(".widget").eq(0);
            var button = $(this).find("i").eq(0);
            var compress = "fa-compress";
            var expand = "fa-expand";
            if (widget.hasClass("maximized")) {
                if (button) {
                    button.addClass(expand).removeClass(compress);
                }
                widget.removeClass("maximized");
                widget.find(".widget-body").css("height", "auto");
            } else {
                if (button) {
                    button.addClass(compress).removeClass(expand);
                }
                widget.addClass("maximized");
                maximize(widget);
            }
        });

        $('.widget-buttons *[data-toggle="collapse"]').on("click", function (event) {
            event.preventDefault();
            var widget = $(this).parents(".widget").eq(0);
            var body = widget.find(".widget-body");
            var button = $(this).find("i");
            var down = "fa-plus";
            var up = "fa-minus";
            var slidedowninterval = 300;
            var slideupinterval = 200;
            if (widget.hasClass("collapsed")) {
                if (button) {
                    button.addClass(up).removeClass(down);
                }
                widget.removeClass("collapsed");
                body.slideUp(0, function () {
                    body.slideDown(slidedowninterval);
                });
            } else {
                if (button) {
                    button.addClass(down)
                        .removeClass(up);
                }
                body.slideUp(slideupinterval, function () {
                    widget.addClass("collapsed");
                });
            }
        });
        //*********************************************************************************
        $('.modal').on('show.bs.modal', function (e) {
            $('html').css('overflow', 'hidden');
        });

        $('.modal').on('hide.bs.modal', function (e) {
            $('html').css('overflow', 'auto');
        });

    });
}

//window.onerror = function (msg, url, line) {
//    window.location.reload();
//    return false;
//}


$(function () {

    $('#AddBox, #EditBox').on('scroll', function () {
        $('.note-table-popover').hide();
    });
     //*******************************************************************************
    $('body').on('click', '.refresh', function () {
        window.location.reload();
    });
     //*******************************************************************************
    $('.signout').click(function () {
        window.location.href = '/Account/SignOut/';
    });
    //*******************************************************************************
    $(document).on('click', 'a:not(.exclude-default)', function (e) {
        e.preventDefault();
    });
    //*******************************************************************************
    $('#sidebar a').click(function () {
        $('#sidebar  li').removeClass('active');
        $(this).parent('li').addClass('active');
        if ($(this).attr('href') != null && $(this).attr('href') != '#') {
            pageLoader('#PageContent', '#pageLoader', $(this).attr('href'));
            var title = $(this).children('span').html()
            window.history.pushState(null, title, $(this).attr('href'));
            var body = $("html, body");
            body.stop().animate({ scrollTop: 0 }, 500, 'swing', function () { });
        }
    });
    //*******************************************************************************
    $(window).on('popstate', function () {
        pageLoader('#PageContent', '#pageLoader', window.location.pathname);
    });
    //*******************************************************************************





});


function createGuid() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
} 

function pageLoader(LoadingElementDiv, LoadingAnimationIcon, PageUrl, IsPushState) {
    $(function () {
        if (IsPushState != null) {
            window.history.pushState(null, document.title, PageUrl);
        }
        $('.note-popover').hide();
        $('body').off();
        $('.modal').modal('hide');
        $(LoadingAnimationIcon).show();
        $(LoadingElementDiv).hide();
        var nocacheString = '?nocatch=' + createGuid();
        $(LoadingElementDiv).load(PageUrl + nocacheString, function (response, status, xhr) {
            reBindAfterAjaxLoading();
            $(LoadingAnimationIcon).hide();
            toastr.remove();
            $(window).resize();
            $(LoadingAnimationIcon).hide();
            if (status != 'success') {
                if (xhr.status == 401) {
                    window.location.href = '/Account/Index/';
                }
                if (xhr.status == 404) {
                    //************************
                    var notFoundHtml = '<div style="margin-top:50px;">' +
                        '<center>' +
                        '<img src="/images/error.png" style="height:200px;width:200px;" />' +
                        '<h4>با عرض پوزش صفحه مورد نظر شما یافت نشد</h4>' +
                        '<button id="returnBack" type="button" class="btn btn-primary" onclick="window.history.back();">بازگشت</button>' +
                        '</center>' +
                        '</div> ';
                    $(LoadingElementDiv).html(notFoundHtml);
                    //***********************
                } else {
                    var unknowErrorHtml = '<div style="margin-top:50px;">' +
                        '<center>' +
                        '<img src="/images/error.png" style="height:200px;width:200px;" />' +
                        '<h4>خطایی در درخواست شما رخ داده است</h4>' +
                        '<button id="returnBack" type="button" class="btn btn-primary" onclick="window.history.back();">بازگشت</button>' +
                        '</center>' +
                        '</div> ';
                    $(LoadingElementDiv).html(unknowErrorHtml);
                }
                toastr.error('صفحه درخواستی در دسترس نمی باشد', "پيام سیستم");
            }
            $(LoadingElementDiv).show();
        });
    });
}
//*************************************************************************************************************************************************
function CreateComboLoader(url, comboName, iconLoader, valueName, textName, id, isBlankCombo, callbackSuccessDelegate, callbackErrorDelegate) {
    $(comboName).children('option').remove();
    DataTransfer(url + id, '', $(comboName).next('i'), function (f) {
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
//**************************************************************************************************************** 
function IsNullOrEmptyString(value) {
    if (value == null || value == '') {
        return true;
    } else {
        return false;
    }
}
//**************************************************************************************************************** 
setInterval(function () {
    DataTransfer('/Account/KeepAlive/', '', '', function (f) {

    }, function (e) { });
}, 150000); 

//****************************************************************************************
function DataTransfer(url, jsonData, iconLoader, runOnSuccess, runOnError) {
    $(iconLoader).show();
    $.ajax({
        url: url,
        type: 'post',
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
            if (runOnError != null) {
                runOnError(e);
            }
            $(iconLoader).hide();
        },
        complete: function (xhr, textStatus) {
            if (xhr.status == 401) {
                window.location.href = '/Account/Index/';
            }
        }
    });
};
//=======================================================================================================




function GetDataFromServer(url, iconLoader, runOnSuccess, runOnError) {
    $(iconLoader).show();
    $.ajax({
        url: url,
        type: 'get',
        //data: jsonData,
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (e) {
            if (runOnSuccess != null) {
                runOnSuccess(e);
            }
            $(iconLoader).hide();
        },
        error: function (e) {
            if (runOnError != null) {
                runOnError(e);
            }
            $(iconLoader).hide();
        },
        //complete: function (xhr, textStatus) {
        //    if (xhr.status == 401) {
        //        window.location.href = '/Account/Index/';
        //    }
        //  }
    });
};





$(function () {
    var ChangeUserPasswordViewModel = {
        ch: ko.observable({}),
    }
    ko.applyBindings(ChangeUserPasswordViewModel, document.getElementById('userChangePasswordModal'));
    //********************************************************************
    $('#userChangePasswordModal').on('hidden.bs.modal', function (e) {
        resetForm('userChangePasswordForm', function () { ChangeUserPasswordViewModel.ch({}); });
    });
    //***********************************************************************
    $('#userChangePasswordBtn').click(function () {
        $('#userChangePasswordModal').modal({ backdrop: 'static', keyboard: false });
        $('#userChangePasswordModal').modal('show');
    });
    //***********************************************************************
    $('#userChangePasswordForm').submit(function () {
        if ($(this).valid()) {
            DataTransfer('/Identities/AdminUsers/ChangeCurrentUserPassword/', ko.toJSON(ChangeUserPasswordViewModel.ch()), '#resultLoader',
                function (f) {
                    toastr.remove();
                    if (!f.IsSuccess) {
                        toastr.error(f.Message);
                    } else {
                        toastr.success(f.Message);
                        $('#userChangePasswordModal').modal('hide');
                        ChangeUserPasswordViewModel.ch({});
                    }
                },
                function (e) {
                    toastr.remove();
                    toastr.error("خطا در ارتباط با سرور");
                }
            );
        }
        return false;
    });

});  
