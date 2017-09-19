(function () {
    "use strict";
    angular
        .module("stationManagement")
        .controller("RegistrationDetailCtrl",
        [RegistrationDetailCtrl]);

    function RegistrationDetailCtrl() {
        var vm = this;
        if (vm.register) {
            vm.title = "Edit: ";
        }
        else {
            vm.title = "New Product";
        }
    }
}());