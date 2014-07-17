$(document).ready(function () {

    //------------- Login page simple functions -------------//
    $("html").addClass("loginPage");

    wrapper = $(".login-wrapper");
    barBtn = $("#bar .btn");

    //change the tabs
    barBtn.click(function () {
        btnId = $(this).attr('id');
        wrapper.attr("data-active", btnId);
        $("#bar").attr("data-active", btnId);
    });

    //show register tab
    $("#register").click(function () {
        btnId = "reg";
        wrapper.attr("data-active", btnId);
        $("#bar").attr("data-active", btnId);
    });

    //check if user is change remove avatar
    var userField = $("input#user");
    var avatar = $("#avatar>img");

    //if user change email or username change avatar
    userField.change(function () {
        if ($(this).val() === 'suggeelson@suggeelson.com') {
            avatar.attr('src', 'images/avatars/suggebig.jpg')
        } else {
            avatar.attr('src', 'images/avatars/no_avatar.jpg')
        }
    });

    //------------- Validation -------------//
    $("#login-form").validate({
        rules: {
            email: {
                required: true,
                email: true
            },
            password: {
                required: true,
                minlength: 6
            }
        },
        messages: {
            email: {
                required: "Введите ваш Email",
                email: "Введите правильный Email"
            },
            password: {
                required: "Введите ваш пароль",
                minlength: "Минимальная длина пароля - 6 символов"
            }
        }
    });

    //------------- Validation -------------//
    $("#reg-form").validate({
        rules: {
            email: {
                required: true,
                email: true,
                remote: "/cabinet/account/check"
            },
            password: {
                required: true,
                minlength: 6
            },
            password1: {
                required: true,
                equalTo: "#rpassword-field",
                minlength: 6
            }
        },
        messages: {
            email: {
                required: "Введите ваш Email",
                email: "Введите правильный Email"
            },
            password: {
                required: "Введите ваш пароль",
                minlength: "Минимальная длина пароля - 6 символов",
                equalTo: "Введите тоже самое значение снова"
            },
            password1: {
                required: "Введите ваш пароль",
                minlength: "Минимальная длина пароля - 6 символов",
                equalTo: "Введите тоже самое значение снова"
            }
        }
    });
    //------------- Validation -------------//
    $("#forgot-form").validate({
        rules: {
            email: {
                required: true,
                email: true,
                remote: "/cabinet/account/check2"
            }
        },
        messages: {
            email: {
                required: "Введите ваш Email",
                email: "Введите правильный Email"
            }
        }
    });

});