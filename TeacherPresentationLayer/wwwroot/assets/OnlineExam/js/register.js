var mainViewModel = {
    isActiveRegisterForm: ko.observable(true),
    data: ko.observable({}),
    user: ko.observable({}),
    changePassword: ko.observable({}),
};

$(function () {
    ko.applyBindings(mainViewModel, document.getElementById('mainArea'));
    //============================================================================
    $('body').on('submit', '#registerForm', function () {
        if ($(this).valid()) {
            toastr.remove();
            $('.icon-loader').show();
            DataTransfer('/api/Identities/ConfirmationCodes/AddForRegister', 'post', ko.toJSON(mainViewModel.data()), '.icon-loader', function (e) {
                mainViewModel.isActiveRegisterForm(false);
                mainViewModel.data(e.Value)
                timeCountDown(e.Value.RemainingTimeToExpire);
            }, function (e) {
                toastr.error(e.responseJSON.Message);
            });
        }
        return false;
    }); 
    //==========================================================================================
    $('body').on('submit', '#forgetPasswordForm', function () {
        if ($(this).valid()) {
            toastr.remove();
            $('.icon-loader').show();
            DataTransfer('/api/Identities/ConfirmationCodes/AddForForgetPassword', 'post', ko.toJSON(mainViewModel.data()), '.icon-loader', function (e) {
                mainViewModel.isActiveRegisterForm(false);
                mainViewModel.data(e.Value)
                timeCountDown(e.Value.RemainingTimeToExpire);
            }, function (e) {
                toastr.error(e.responseJSON.Message);
            });
        }
        return false;
    });
    //============================================================================
    $('body').on('click', '#changeMobNoBtn', function () {
        mainViewModel.data({});
        if (time != null)
            clearTimeout(time);
        mainViewModel.isActiveRegisterForm(true);
    });
    //============================================================================
    var time = null
    function timeCountDown(timeleft) {
        $('.time').html('زمان باقیمانده:  (<span></span>)');
        $('.time').find('span').html((Math.floor(timeleft / 60) < 10 ? "0" + Math.floor(timeleft / 60) : Math.floor(timeleft /
            60)) + ":" + (timeleft % 60 < 10 ? "0" + timeleft % 60 : timeleft % 60));
        if (timeleft > 0) {
            time = setTimeout(function () {
                timeCountDown(timeleft - 1);
            }, 1000);
        }
    };
    //============================================================================
    $('body').on('click', '#ReSendBtn', function () {
        toastr.remove();
        $('.icon-loader').show();
        DataTransfer('/api/Identities/ConfirmationCodes/ReSendCode', 'post', ko.toJSON(mainViewModel.data()), '.icon-loader', function (e) {
            mainViewModel.data(e.Value);
            if (time != null)
                clearTimeout(time);
            timeCountDown(e.Value.RemainingTimeToExpire);
            toastr.success(e.Value.Message);
        }, function (e) {


            toastr.error(e.responseJSON.Message);
        });
    });
    //============================================================================
    $('body').on('click', '#confirmBtn', function () {
        toastr.remove();
        var confirmCode = $('#ConfirmCode').val();
        if (IsNullOrEmptyString(confirmCode)) {
            toastr.error('کد تایید نباید خالی باشد');
            return;
        }
        mainViewModel.data().ConfirmCode = confirmCode;
        $('.icon-loader').show();
        DataTransfer('/api/Identities/ConfirmationCodes/Confirm', 'post', ko.toJSON(mainViewModel.data()), '.icon-loader', function (e) {
            window.location.href = "/Identities/Register/MainPage?" + 'HashId=' + e.Value.HashId + '&UserName=' + e.Value.UserName;
        }, function (e) {
            toastr.error(e.responseJSON.Message);
        });
    });
    //============================================================================
    $('body').on('click', '#forgetPasswordConfirmBtn', function () {
        toastr.remove();
        var confirmCode = $('#ConfirmCode').val();
        if (IsNullOrEmptyString(confirmCode)) {
            toastr.error('کد تایید نباید خالی باشد');
            return;
        }
        mainViewModel.data().ConfirmCode = confirmCode;
        $('.icon-loader').show();
        DataTransfer('/api/Identities/ConfirmationCodes/Confirm', 'post', ko.toJSON(mainViewModel.data()), '.icon-loader', function (e) {
            window.location.href = "/Identities/ForgetPassword/ChangePasswordPage?" + 'HashId=' + e.Value.HashId + '&UserName=' + e.Value.UserName;
        }, function (e) {
            toastr.error(e.responseJSON.Message);
        });
    });
    //============================================================================  Register Main Page Script  

    $('body').on('submit', '#registerUserForm', function () {
        toastr.remove();
        
        var urlParams = new URLSearchParams(window.location.search);
        mainViewModel.user().HashId = urlParams.get('HashId');
        mainViewModel.user().UserName = urlParams.get('UserName');
        if ($(this).valid()) {
            $('.icon-loader').show();
            DataTransfer('/api/Identities/ConfirmationCodes/AddUser', 'post', ko.toJSON(mainViewModel.user()), '.icon-loader', function (e) {
                window.location.href = "/Identities/Register/CompletePage?" + 'HashId=' + e.Value.HashId + '&UserName=' + e.Value.UserName;
            }, function (e) {
                toastr.error(e.responseJSON.Message);
            });
        }
        return false;
    }); 
    //=============================================================================== 
    $('#changePasswordForm').submit( function () {
        toastr.remove();
        var urlParams = new URLSearchParams(window.location.search);
        mainViewModel.changePassword().HashId = urlParams.get('HashId');
        mainViewModel.changePassword().UserName = urlParams.get('UserName');
        if ($(this).valid()) {
            $('.icon-loader').show();
            DataTransfer('/api/Identities/ConfirmationCodes/ChangePassword', 'post', ko.toJSON(mainViewModel.changePassword()), '.icon-loader', function (e) {
                window.location.href = "/Identities/ForgetPassword/CompletePage?" + 'HashId=' + e.Value.HashId + '&UserName=' + e.Value.UserName;
            }, function (e) {
                toastr.error(e.responseJSON.Message);
            });
        }
        return false;
    });
     
     //===============================================================================
});

