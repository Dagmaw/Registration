(function () {
    "use strict";
    angular
        .module("stationManagement")
        .controller("RegistrationReportCtrl",
        [RegistrationReportCtrl]);

    function RegistrationReportCtrl() {
        var vm = this;
        if (vm.register) {
            vm.title = "Edit: ";
        }
        else {
            vm.title = "New Product";
        }
    }
}());
