(function () {
    "use strict";

    angular
        .module("common.services")
        .factory("registrationResource",
                ["$resource",
                 registrationResource]);

    function registrationResource($resource) {
        return $resource("/api/register/:registrationId")
    }

}());
