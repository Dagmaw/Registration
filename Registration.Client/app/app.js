(function () {
    "use strict";
    var app = angular.module("stationManagement",
        ["common.services",
            "ui.router",
            "ui.mask",
            "ui.bootstrap",
            "angularCharts",
            "registrationResourceMock"]);

    app.config(function ($provide) {
        $provide.decorator("$exceptionHandler",
            ["$delegate",
                function ($delegate) {
                    return function (exception, cause) {
                        exception.message = "Please contact the Help Desk! \n Message: " +
                            exception.message;
                        $delegate(exception, cause);
                        alert(exception.message);
                    };
                }]);
    });

    app.config(["$stateProvider",
        "$urlRouterProvider",
        function ($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise("/register/edit/user");

            $stateProvider
                .state("home", {
                    url: "/",
                    templateUrl: "app/welcomeView.html"
                })
                .state("registrationList", {
                    url: "/register",
                    templateUrl: "app/register/RegistrationListView.html",
                    controller: "RegistrationListCtrl as vm"
                })
                .state("registrationEdit", {
                    abstract: true,
                    url: "/register/edit:registrationId",
                    templateUrl: "app/register/RegistrationEditView.html",
                    controller: "RegistrationEditCtrl as vm"
                })
                .state("registrationEdit.user", {
                    url: "/user",
                    templateUrl: "app/register/RegistrationEditUserView.html"
                })
                .state("registrationEdit.group", {
                    url: "/group",
                    templateUrl: "app/register/RegistrationEditGroupView.html"
                })
                .state("registrationEdit.app", {
                    url: "/app",
                    templateUrl: "app/register/RegistrationEditAppView.html"
                })
                .state("registrationDetail", {
                    url: "/register/:registrationId",
                    templateUrl: "app/register/RegistrationDetailView.html",
                    controller: "RegistrationDetailCtrl as vm"
                })
                .state("RegistrationReport", {
                    url: "/report",
                    templateUrl: "app/register/RegistrationReportView.html",
                    controller: "RegistrationReportCtrl as vm"
                })
        }]
    );
}());