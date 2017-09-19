(function () {
    "use strict";
    angular
        .module("stationManagement")
        .controller("RegistrationListCtrl",
        [RegistrationListCtrl]);
    
    function RegistrationListCtrl() {
        var vm = this;
        if (vm.register) {
            vm.title = "Edit: " + vm.register.productName;
        }
        else {
            vm.title = "New Product";
        }
    }
}());
