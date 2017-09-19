(function () {
    "use strict";

    angular
        .module("stationManagement")
        .controller("RegistrationEditCtrl",
        ["$state",
            RegistrationEditCtrl]);


    function RegistrationEditCtrl(register, $state, registrationService) {
        var vm = this;

        vm.register = register;
        vm.priceOption = "percent";

        vm.marginPercent = function () {
            return registrationService.calculateMarginPercent(vm.register.price,
                vm.register.cost)
        };

        /* Calculate the price based on a markup */
        vm.calculatePrice = function () {
            var price = 0;

            if (vm.priceOption == 'amount') {
                price = registrationService.calculatePriceFromMarkupAmount(
                    vm.register.cost, vm.markupAmount);
            }

            if (vm.priceOption == 'percent') {
                price = registrationService.calculatePriceFromMarkupPercent(
                    vm.register.cost, vm.markupPercent);
            }
            vm.register.price = price;
        };

        if (vm.register) {
            vm.title = "Edit: " + vm.register.productName;
        }
        else {
            vm.title = "New Product";
        }

        vm.open = function ($event) {
            $event.preventDefault();
            $event.stopPropagation();

            vm.opened = !vm.opened;
        };

        vm.submit = function (isValid) {
            if (isValid) {
                vm.register.$save(function (data) {
                    toastr.success("Save Successful");
                })
            } else {
                alert("Please correct the validation errors first.");
            }
        };

        vm.cancel = function () {
            $state.go('registrationList');
        };

        vm.addTags = function (tags) {
            if (tags) {
                var array = tags.split(',');
                vm.register.tags = vm.register.tags ? vm.register.tags.concat(array) : array;
                vm.newTags = "";
            } else {
                alert("Please enter one or more tags separated by commas");
            }
        };

        vm.removeTag = function (idx) {
            vm.register.tags.splice(idx, 1);
        };
    }
}());
