$(document).ready(function () {
    $('body').on('click', '.more-de-d', function () {
        $('html, body').animate({
            scrollTop: $("#menu0").offset().top
        }, 2000);
    });
    //apply on typing and focus
    $('html').on('keyup', 'input.currency', function () {
        $(this).manageCommas();
    });

    $(document).on('keyup', 'input, textarea', function () {
        // $(this).val($(this).val().trim());
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

    var odo = $(".odometer");
    odo.each(function () {
        var countNumber = $(this).attr("data-count");
        $(this).html(countNumber);
    });
    if (document.getElementById("particles-js-circle-bubble")) particlesJS("particles-js-circle-bubble", {
        "particles": {
            "number": {
                "value": 300, "density": {
                    "enable": true, "value_area": 800
                }
            },
            "color": {
                "value": "#ffffff"
            },
            "shape": {
                "type": "circle", "stroke": {
                    "width": 0, "color": "#000000"
                },
                "polygon": {
                    "nb_sides": 5
                },
                "image": {
                    "src": "img/github.svg", "width": 100, "height": 100
                }
            },
            "opacity": {
                "value": 1, "random": true, "anim": {
                    "enable": true, "speed": 1, "opacity_min": 0, "sync": false
                }
            },
            "size": {
                "value": 3, "random": true, "anim": {
                    "enable": false, "speed": 4, "size_min": 0.3, "sync": false
                }
            },
            "line_linked": {
                "enable": false, "distance": 150, "color": "#ffffff", "opacity": 0.4, "width": 1
            },
            "move": {
                "enable": true, "speed": 1, "direction": "none", "random": true, "straight": false, "out_mode": "out", "bounce": false, "attract": {
                    "enable": false, "rotateX": 600, "rotateY": 600
                }
            }
        },
        "interactivity": {
            "detect_on": "canvas", "events": {
                "onhover": {
                    "enable": true, "mode": "bubble"
                },
                "onclick": {
                    "enable": true, "mode": "repulse"
                },
                "resize": true
            },
            "modes": {
                "grab": {
                    "distance": 400, "line_linked": {
                        "opacity": 1
                    }
                },
                "bubble": {
                    "distance": 250, "size": 0, "duration": 2, "opacity": 0, "speed": 3
                },
                "repulse": {
                    "distance": 400, "duration": 0.4
                },
                "push": {
                    "particles_nb": 4
                },
                "remove": {
                    "particles_nb": 2
                }
            }
        },
        "retina_detect": true
    });
    //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==
    $('#navbarNavAltMarkup .navbar-nav li').removeClass('active');
    $('#navbarNavAltMarkup .navbar-nav li a[href="' + location.pathname + '"]').parent().addClass('active');

    $('.carousel-indicators li').remove();
    $('.singleCourse .carousel').carousel({
        interval: 0
    })

    var swiper4 = new Swiper('.swiper-teach', {
        slidesPerView: 1,
        spaceBetween: 10,
        slidesPerColumn: 1,
        slidesPerColumnFill: 'row',
        init: true,
        pagination: {
            el: '.swiper-pagination-teach',
            type: 'bullets',
            clickable: true,
        }

        ,
        navigation: {
            nextEl: '.swiper-button-next',
            prevEl: '.swiper-button-prev',
        }

        ,
        breakpoints: {
            640: {
                slidesPerView: 2,
                slidesPerColumn: 2,
                slidesPerColumnFill: 'row',
                spaceBetween: 10,
            },
            768: {
                slidesPerView: 2,
                slidesPerColumn: 2,
                slidesPerColumnFill: 'row',
                spaceBetween: 10,
            },
            1024: {
                slidesPerView: 4,
                slidesPerColumn: 2,
                slidesPerColumnFill: 'row',
                spaceBetween: 10,
            },
        }
    });
    var swiper7 = new Swiper('.swiper-azmoons', {
        slidesPerView: 1,
        spaceBetween: 10,
        slidesPerColumn: 1,
        slidesPerColumnFill: 'row',
        init: true,
        pagination: {
            el: '.swiper-pagination-teach',
            type: 'bullets',
            clickable: true,
        }

        ,
        navigation: {
            nextEl: '.swiper-button-next',
            prevEl: '.swiper-button-prev',
        }

        ,
        breakpoints: {
            640: {
                slidesPerView: 1,
                slidesPerColumn: 2,
                slidesPerColumnFill: 'row',
                spaceBetween: 10,
            },
            768: {
                slidesPerView: 1,
                slidesPerColumn: 2,
                slidesPerColumnFill: 'row',
                spaceBetween: 10,
            },
            1024: {
                slidesPerView: 3,
                slidesPerColumn: 2,
                slidesPerColumnFill: 'row',
                spaceBetween: 10,
            },
        }
    });
    var swiper2 = new Swiper('.swiper2', {
        slidesPerView: 1,
        spaceBetween: 10,
        slidesPerColumn: 2,
        slidesPerColumnFill: 'row',
        // init: false,
        pagination: {
            el: '.swiper-pagination2',
            clickable: true,
        },
        breakpoints: {
            640: {
                slidesPerView: 1,
                spaceBetween: 10,
                slidesPerColumn: 2,
                slidesPerColumnFill: 'row',
            },
            768: {
                slidesPerView: 2,
                spaceBetween: 10,
                slidesPerColumn: 2,
                slidesPerColumnFill: 'row',
            },
            1024: {
                slidesPerView: 2,
                spaceBetween: 10,
                slidesPerColumn: 2,
                slidesPerColumnFill: 'row',
            },
        }
    });

    var azmon = new Swiper('.azmon', {
        slidesPerView: 1,
        spaceBetween: 10,
        slidesPerColumn: 2,
        slidesPerColumnFill: 'row',
        // init: false,
        pagination: {
            el: '.swiper-pagination2',
            clickable: true,
        },
        breakpoints: {
            640: {
                slidesPerView: 1,
                spaceBetween: 10,
                slidesPerColumn: 2,
                slidesPerColumnFill: 'row',
            },
            768: {
                slidesPerView: 1,
                spaceBetween: 10,
                slidesPerColumn: 1,
                slidesPerColumnFill: 'row',
            },
            1024: {
                slidesPerView: 2,
                spaceBetween: 10,
                slidesPerColumn: 2,
                slidesPerColumnFill: 'row',
            },
        }
    });

    var swiper1 = new Swiper('.swiper1', {
        slidesPerView: 1,
        spaceBetween: 10,
        // init: false,
        pagination: {
            el: '.swiper-pagination1',
            clickable: true,
        },
        autoplay:
        {
            delay: 2000,
        },
        loop: true,
        breakpoints: {
            640: {
                slidesPerView: 2,
                spaceBetween: 10,
            },
            768: {
                slidesPerView: 5,
                spaceBetween: 10,
            },
            1024: {
                slidesPerView: 7,
                spaceBetween: 10,
            },
        }
    });

    var swiper3 = new Swiper('.swiper3', {
        slidesPerView: 1,
        spaceBetween: 10,
        // init: false,
        pagination: {
            el: '.swiper-pagination3',
            clickable: true,
        },
        breakpoints: {
            640: {
                slidesPerView: 2,
                spaceBetween: 10,
            },
            768: {
                slidesPerView: 4,
                spaceBetween: 10,
            },
            1024: {
                slidesPerView: 4,
                spaceBetween: 10,
            },
        }
    });

    var swiper5 = new Swiper('.teachersCourse', {
        slidesPerView: 1,
        spaceBetween: 10,
        slidesPerColumn: 2,
        slidesPerColumnFill: 'row',
        init: true,
        pagination: {
            el: '.swiper-pagination-teach',
            type: 'bullets',
            clickable: true,
        }
        ,
        autoplay:
        {
            delay: 2000,
        },
        navigation: {
            nextEl: '.swiper-button-next',
            prevEl: '.swiper-button-prev',
        }

        ,
        breakpoints: {
            640: {
                slidesPerView: 1,
                slidesPerColumn: 2,
                slidesPerColumnFill: 'row',
                spaceBetween: 10,
            },
            768: {
                slidesPerView: 2,
                slidesPerColumn: 2,
                slidesPerColumnFill: 'row',
                spaceBetween: 10,
            },
            1024: {
                slidesPerView: 3,
                slidesPerColumn: 2,
                slidesPerColumnFill: 'row',
                spaceBetween: 10,
            },
        }
    });

    var swiper9 = new Swiper('.swiper9', {
        slidesPerView: 1,
        spaceBetween: 20,
        // init: false,
        pagination: {
            el: '.swiper-pagination1',
            clickable: true,
        },
        autoplay:
        {
            delay: 3000,
        },
        loop: false,
        breakpoints: {
            640: {
                slidesPerView: 2,
                slidesPerColumnFill: 'row',
                spaceBetween: 20,
            },
            768: {
                slidesPerView: 2,
                slidesPerColumnFill: 'row',
                spaceBetween: 20,
            },
            1024: {
                slidesPerView: 4,
                slidesPerColumnFill: 'row',
                spaceBetween: 20,
            },
        }
    });
    var swiper10 = new Swiper('.swiper10', {
        slidesPerView: 1,
        spaceBetween: 10,
        slidesPerColumn: 2,
        slidesPerColumnFill: 'row',
        init: true,
        pagination: {
            el: '.swiper-pagination1',
            clickable: true,
        },
        autoplay:
        {
            delay: 3000,
        },
        loop: false,
        breakpoints: {
            640: {
                slidesPerView: 2,
                slidesPerColumnFill: 'row',
                spaceBetween: 10,
            },
            768: {
                slidesPerView: 2,
                slidesPerColumnFill: 'row',
                spaceBetween: 10,
            },
            1024: {
                slidesPerView: 4,
                slidesPerColumnFill: 'row',
                spaceBetween: 10,
            },
        }
    });

});


$(function () {

    $('.videos-epizero .box-video-item').click(function () {
        $('.videos-epizero .box-video-item').removeClass('active');
        $(this).addClass('active');
        var srcvideo = $(this).data('video');
        console.log(srcvideo);
        $('.box-video source').attr('src', srcvideo);
        $('.box-video video')[0].load();
    });
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
    $('[data-toggle="tooltip"]').tooltip();
    //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=
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


    $('body').on('click', '.btn-like', function () {
        toastr.remove();
        var id = $(this).attr('data-Id');
        var data = { CourseStudentQuestionId : id };
        DataTransfer('/api/Trainings/CourseStudentQuestionLikes/AddStudentQuestionLike/', 'post', ko.toJSON(data), '.wrapper-parent', function (e) {
            toastr.success(e.Message);
            getCount(id);
        }, function (e) {
            toastr.error(e.responseJSON.Message);
            getCount(id);
        });

        function getCount($id) {
            DataTransfer('/api/Trainings/CourseStudentQuestionLikes/ReadCountStudentQuestionLike?CourseStudentQuestionId=' + $id, 'get', '', '', function (e) {

                var $custom = '#custom_' + $id;
 
                if (e > 0) {
                    console.log('up', $custom);
                    $($custom).find('.like_item_couter').html(e);
                    $($custom).find('.like_item_couter').show();
                }
                else {
                    console.log('down', $custom);
                    $($custom).hide();
                }


            }, function (e) {

            });
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



        //var jj = jQuery.noConflict();
        //function scrollToAnchor(aid) {

        //    var aTag = jj("a[name='" + aid + "']");
        //    jj('html,body').animate({
        //        scrollTop: aTag.offset().top
        //    }, 3000);
        //}

        //jj("#azmoon10").click(function () {
        //    scrollToAnchor('azmoon_p');
        //});


        //jj("#blog10").click(function () {
        //    scrollToAnchor('blog_p');
        //});

    });
    //jQuery(document).on('ready', function () {



    //    //var a7000109 = jQuery.noConflict();
    //    //a7000109("#steep1").change(function () { 
    //    //    a7000109("#steep2").html('<option value="0"></option>');
    //    //    a7000109("#steep3").html('<option value="0"></option>'); 
    //    //    var steep1 = a7000109('#steep1').val(); 
    //    //    a7000109.ajax({
    //    //        type: 'POST',
    //    //        url: 'https://epizero.ir/steep1.php',
    //    //        data: "steep1=" + steep1,

    //    //        success: function (data) {
    //    //            a7000109("#steep2").html(data); 
    //    //        } 
    //    //    });

    //    //});

    //    //var a7000109 = jQuery.noConflict();
    //    //a7000109("#steep2").change(function () { 
    //    //    //var a = $('#steep1').val();
    //    //    var steep2 = a7000109('#steep2').val(); 
    //    //    //alert(steep1); 
    //    //    a7000109.ajax({
    //    //        type: 'POST',
    //    //        url: 'https://epizero.ir/steep2.php',
    //    //        data: "steep2=" + steep2,

    //    //        success: function (data) {
    //    //            a7000109("#steep3").html(data); 
    //    //        } 
    //    //    }); 
    //    //});

    //    //a1 = jQuery.noConflict();
    //    //a70001500 = jQuery.noConflict(); 
    //    //function video_load(v) { 
    //    //    //alert(1);
    //    //    a70001500("#video_load").html(''); 
    //    //    a70001500.ajax({
    //    //        type: 'POST',
    //    //        url: 'video_load.php',
    //    //        data: "v=" + v, 
    //    //        success: function (data) {
    //    //            a70001500("#video_load").html(data); 
    //    //        } 
    //    //    }); 
    //    //} 
    //});

});
//================================================
var mainViewModel = {
    isActiveRegisterForm: ko.observable(true),
    isActiveLoginMobNoForm: ko.observable(true),
    loginWithUser: ko.observable({}),
    user: ko.observable({}),
    changePassword: ko.observable({}),
    loginWithMobNo: ko.observable({}),
    contactUs: ko.observable({}),
    infoProfile: ko.observable({}),
    infoUserMessage: ko.observable({}),
    fileHomework: ko.observable({}),
    financialSummary: ko.observable({}),
    financialSummaryCheque: ko.observable({}),
    financialSummaryNoCheque: ko.observable({}),
    financialSummaryReturnPayment: ko.observable({}),
    financialSummaryPosPayment: ko.observable({}),
    creditPayment: ko.observable({}),
    courseStudentQuestions: ko.observable({}),
    allCourseStudentQuestions: ko.observable({}),
    questionAdd: ko.observable({}),
    questionAnswerAdd: ko.observable({}),
    finalizedOrders: ko.observable({}),
    infoFinalizedOrders: ko.observable({}),
    courseSearch: ko.observable([]),
    liveOnlineClasses: ko.observable([]),
    newComment: ko.observable({}),
    fe: ko.observable({}),
    studentUserMessages: ko.observable({}),
    notificationStudent: ko.observable({})
};
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
$(function () {

    ko.applyBindings(mainViewModel, document.getElementById('mainArea'));

    const identifierUserHashId_UrlSearchParams = new URLSearchParams(window.location.search);
    if (!IsNullOrEmptyString(identifierUserHashId_UrlSearchParams.get('IdentifierUserHashId'))) {
        localStorage.setItem('IdentifierUserHashId', decodeURIComponent(identifierUserHashId_UrlSearchParams.get('IdentifierUserHashId')));
    }

    //================================================================================ Start Login And Register
    var time_register = null;
    var time_login = null;

    function redirectAfterLogin() {
        const urlParams = new URLSearchParams(window.location.search);
        if (!IsNullOrEmptyString(urlParams.get('ReturnUrl'))) {
            window.location.href = decodeURIComponent(urlParams.get('ReturnUrl'));
        } else {
            if (window.location.pathname.startsWith('/Account/Login')) {
                window.location.href = '/';
            } else {
                window.location.reload();
            }

        }
    }
    //******************************************* start register
    function timeCountDown_register(timeleft) {
        $('.timeCountDown_register').html('زمان باقیمانده:  (<span></span>)');
        $('.timeCountDown_register').find('span').html((Math.floor(timeleft / 60) < 10 ? "0" + Math.floor(timeleft / 60) : Math.floor(timeleft /
            60)) + ":" + (timeleft % 60 < 10 ? "0" + timeleft % 60 : timeleft % 60));
        if (timeleft > 0) {
            time_register = setTimeout(function () {
                timeCountDown_register(timeleft - 1);
            }, 1000);
        }
    };

    $('body').on('click', '#ReSendCodeBtn_register', function () {
        toastr.remove();
        DataTransfer('/api/Identities/ConfirmationCodes/ReSendCode', 'post', ko.toJSON(mainViewModel.user()), '.loader', function (e) {
            if (time_register != null)
                clearTimeout(time_register);
            timeCountDown_register(e.Value.RemainingTimeToExpire);
            toastr.success(e.Message);
        }, function (e) {
            toastr.error(e.responseJSON.Message);
        });
    });



    $('body').on('submit', '#registerForm', function () {
        if ($(this).valid()) {
            toastr.remove();
            var data = {
                UserName: $('#UserName').val()
            }
            DataTransfer('/api/Identities/ConfirmationCodes/AddForRegister', 'post', ko.toJSON(data), '.loader', function (e) {
                mainViewModel.isActiveRegisterForm(false);
                mainViewModel.user().HashId = e.Value.HashId;
                mainViewModel.user().IdentifierUserHashId = IsNullOrEmptyString(localStorage.getItem('IdentifierUserHashId')) ? '' : localStorage.getItem('IdentifierUserHashId');
                timeCountDown_register(e.Value.RemainingTimeToExpire);
                toastr.success(e.Message);
            }, function (e) {
                toastr.error(e.responseJSON.Message);
            });
        }
        return false;
    });
    $('body').on('submit', '#registerConfirmForm', function () {
        toastr.remove();
        if (IsNullOrEmptyString($('#register_confirmCode').val())) {
            toastr.error('کد تایید نبایستی خالی باشد');
            return false;
        }
        mainViewModel.user().ConfirmCode = $('#register_confirmCode').val();
        DataTransfer('/api/Identities/ConfirmationCodes/ConfirmAndAddUser', 'post', ko.toJSON(mainViewModel.user()), '.loader', function (e) {
            toastr.success(e.Message);
            localStorage.removeItem('IdentifierUserHashId');
            setTimeout(function () {
                redirectAfterLogin()
            }, 1000);
        }, function (e) {
            toastr.error(e.responseJSON.Message);
        });
        return false;
    });
    //******************************************* start register

    //******************************************* start login with mobile number
    function timeCountDown_login(timeleft) {
        $('.timeCountDown_login').html('زمان باقیمانده:  (<span></span>)');
        $('.timeCountDown_login').find('span').html((Math.floor(timeleft / 60) < 10 ? "0" + Math.floor(timeleft / 60) : Math.floor(timeleft /
            60)) + ":" + (timeleft % 60 < 10 ? "0" + timeleft % 60 : timeleft % 60));
        if (timeleft > 0) {
            time_login = setTimeout(function () {
                timeCountDown_login(timeleft - 1);
            }, 1000);
        }
    };


    $('body').on('click', '#ReSendCodeBtn_login', function () {
        toastr.remove();
        DataTransfer('/api/Identities/ConfirmationCodes/ReSendCode', 'post', ko.toJSON(mainViewModel.loginWithMobNo()), '.loader', function (e) {
            //mainViewModel.data(e.Value);
            if (time_login != null)
                clearTimeout(time_login);
            timeCountDown_login(e.Value.RemainingTimeToExpire);
            toastr.success(e.Message);
        }, function (e) {
            toastr.error(e.responseJSON.Message);
        });
    });

    $('body').on('submit', '#loginWithMobNoForm', function () {
        if ($(this).valid()) {
            toastr.remove();
            var data = {
                UserName: $('#LoginWithMobNo_UserName').val()
            }
            DataTransfer('/api/Identities/ConfirmationCodes/AddForLogin', 'post', JSON.stringify(data), '.loader', function (e) {
                mainViewModel.isActiveLoginMobNoForm(false);
                mainViewModel.loginWithMobNo(e.Value);
                timeCountDown_login(e.Value.RemainingTimeToExpire);
                toastr.success(e.Message);
            }, function (e) {
                toastr.error(e.responseJSON.Message);
            });
        }
        return false;
    });


    $('body').on('click', '#loginWithMobNoBtn', function () {
        toastr.remove();
        if (IsNullOrEmptyString($('#login_confirmCode').val())) {
            toastr.error('کد تایید نبایستی خالی باشد');
            return false;
        }
        mainViewModel.loginWithMobNo().ConfirmCode = $('#login_confirmCode').val();
        mainViewModel.loginWithMobNo().UniqueIdentifier = localStorage.getItem('UniqueIdentifier');
        DataTransfer('/api/Identities/Account/LoginWithMobNo', 'post', ko.toJSON(mainViewModel.loginWithMobNo()), '.loader', function (e) {
            setTimeout(function () {
                redirectAfterLogin();
            }, 1000);
        }, function (e) {
            toastr.error(e.responseJSON.Message);
        });
        return false;
    });
    //******************************************* end login


    //******************************************* start reset login and register modal
    $('#loginModal').on('hidden.bs.modal', function (e) {
        $('.field-validation-error').removeClass('field-validation-error').addClass('field-validation-valid');
        $('span.field-validation-valid > span').remove();
        $('.input-validation-error').removeClass('input-validation-error').addClass('valid');
        $('span.input-validation-valid > span').remove();
        mainViewModel.isActiveRegisterForm(true);
        mainViewModel.isActiveLoginMobNoForm(true);
        mainViewModel.loginWithUser({});
        mainViewModel.user({});
        mainViewModel.loginWithMobNo({});
        if (time_login != null)
            clearTimeout(time_login);
        if (time_register != null)
            clearTimeout(time_register);
    });
    //******************************************* end reset login and register modal

    //******************************************* start login with username
    $('body').on('submit', '#loginWithUsernameForm', function () {
        if ($(this).valid()) {
            toastr.remove();
            $('.loader').show();
            mainViewModel.loginWithUser().UniqueIdentifier = localStorage.getItem('UniqueIdentifier');
            DataTransfer('/api/Identities/Account/LoginWithUsername', 'post', ko.toJSON(mainViewModel.loginWithUser()), '.icon-loader', function (e) {
                toastr.success(e.Message);
                $('.loader').hide();
                setTimeout(function () {
                    redirectAfterLogin();
                }, 1500);
            }, function (e) {
                toastr.error(e.responseJSON.Message);
            });
        }
        return false;
    });
    //******************************************* end login with username 
    //================================================================================ End Login And Register



    //================================================================================ Start Cart Operation
    function AddOrderItem(academyProductTypeId, academyProductId) {
        toastr.remove();
        var data = {
            AcademyProductId: academyProductId,
            AcademyProductTypeId: academyProductTypeId
        }

        DataTransfer('/api/Orders/Orders/AddItem/', 'post', ko.toJSON(data), '.wrapper-parent', function (e) {
            toastr.success(e.Message);
            getCountOrderDetailItems();
            $("#ModalAfterAddCarts").modal("show");
        }, function (e) {
            toastr.error(e.responseJSON.Message);
        });
    }
    //**************************
    $('body').on('click', '.cart-btn', function () {
        AddOrderItem($(this).attr('data-academyProductTypeId'), $(this).attr('data-academyProductId'));
    });
    //**************************
    $('body').on('click', '.remove-cart-item', function () {
        var data = {
            OrderDetailId: $(this).attr('data-cartDetailId'),
        }
        bootbox.confirm({
            message: "آیا از حذف آیتم سبد خرید مطمئن هستید؟",
            buttons: {
                confirm: {
                    label: 'تایید',
                    className: 'btn-primary'
                },
                cancel: {
                    label: 'انصراف',
                    className: 'btn-default'
                }
            },
            callback: function (result) {
                if (result) {
                    toastr.remove();

                    DataTransfer('/api/Orders/Orders/RemoveItem/', 'post', ko.toJSON(data), '.wrapper-parent', function (e) {
                        window.location.reload();
                    }, function (e) {
                        toastr.error(e.responseJSON.Message);
                    });
                }
            }
        });
    });
    //**************************
    $('body').on('click', '#addCouponBtn', function () {
        toastr.remove()
        if (IsNullOrEmptyString($('#CouponCode').val())) {
            toastr.error('کد تخفیف نبایستی خالی باشد');
            return false;
        }
        var data = {
            Code: $('#CouponCode').val(),
        }
        DataTransfer('/api/Orders/DiscountCodes/AppendToOrder/', 'post', ko.toJSON(data), '.wrapper-parent', function (e) {
            window.location.reload();
        }, function (e) {
            toastr.error(e.responseJSON.Message);
        });
    });
    //**************************
    $('body').on('click', '#removeCouponBtn', function () {
        DataTransfer('/api/Orders/DiscountCodes/DeleteFromOrder/', 'post', '', '.wrapper-parent', function (e) {
            window.location.reload();
        }, function (e) {
            toastr.error(e.responseJSON.Message);
        });
    });
    //================================================================================ End Cart Operation
    function getCountOrderDetailItems() {
        DataTransfer('/api/Orders/Orders/CountOrderDetailItems', 'get', '', '', function (e) {
            if (e.Value > 0)
                $('#cart_item_couter').show();
            else
                $('#cart_item_couter').hide();
            $('#cart_item_couter').text(e.Value);
        }, function (e) {

        });
    }
    getCountOrderDetailItems();
    //================================================================================
    setInterval(function () {
        DataTransfer('/Home/KeepAlive/', 'post', '', '', function (e) { }, function (e) { });
    }, 150000);
    //================================================================================
    $('[data-toggle="tooltip"]').tooltip();
    //================================================================================ Begin Change Password
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
    //================================================================================ End Change Password
    //================================================================================ Begin Course Search
    $('#input-s').keyup(function () {
        DataTransfer('/api/Trainings/CourseSearch/Operation?searchValue=' + $(this).val(), 'get', '', '.loader', function (e) {
            mainViewModel.courseSearch(e.Value);
        }, function (e) {

        });
    });
    //==================== End Course Search
    //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-نوتفیکشن صفحه اصلی=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    function createCookie(name, value, days) {
        if (days) {
            var date = new Date();
            date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
            var expires = "; expires=" + date.toGMTString();
        } else {
            var expires = "";
        }
        document.cookie = name + "=" + value + expires + "; path=/";
        window.location.reload();
    }
    function ReadCookie(cname) {
        let name = cname + "=";
        let decodedCookie = decodeURIComponent(document.cookie);
        let ca = decodedCookie.split(';');
        for (let i = 0; i < ca.length; i++) {
            let c = ca[i];
            while (c.charAt(0) == ' ') {
                c = c.substring(1);
            }
            if (c.indexOf(name) == 0) {
                return c.substring(name.length, c.length);
            }
        }
        return "";
    }
    function checkCookie(cookieName) {
        let result = ReadCookie(cookieName);
        if (result != "" && result != null) {
            $('body').removeClass('overflow');
            $('.js-wheel-floating-box').css('display', 'none');

        } else {

            $('body').addClass('overflow');
            $('.js-wheel-floating-box').css('display', 'flex');
        }
    }
    checkCookie('_StartPageAdvertise');
    //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    $('body').on('click', '.js-wheel-floating-box', function () {
        $('body').removeClass('overflow');
        $(this).css('display', 'none');
        createCookie('_StartPageAdvertise', 1, 30);
    });
    //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    $('body').on('click', '.link-watsap', function (e) {
        e.preventDefault();
        var link = $(this).attr('href');
        console.log("link", link)
        window.open(link, '_blank');

    });
    //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    $('body').on('change', '#ruleaccept', function (e) {
        if ($(this).is(':checked')) {
            $('.btn--login').prop("disabled", false);
            $('.btn--login').removeClass('disablesBtn');
        } else {
            $('.btn--login').prop("disabled", true);
            $('.btn--login').addClass('disablesBtn');
        }
    });

    $('#ruleaccept').change();
});



///Create Unique Identifier
$(document).ready(function () {

    if (localStorage.getItem("UniqueIdentifier") === null) {
        localStorage.setItem("UniqueIdentifier", CreateGuid());
    }
});
function CreateGuid() {
    function _p8(s) {
        var p = (Math.random().toString(16) + "000000000").substr(2, 8);
        return s ? "-" + p.substr(0, 4) + "-" + p.substr(4, 4) : p;
    }
    return _p8() + _p8(true) + _p8(true) + _p8();
}

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