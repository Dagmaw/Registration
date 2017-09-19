//Defining angularjs module
var app = angular.module('demoModule', []);

//Defining angularjs controller and injecting RegistrationService
app.controller('demoCtrl', function ($scope, $http, registrationService) {
    $scope.registrationsData = null;
    //fatching records from factory created at the bottom of the script file
    registrationService.GetAllRecords().then(function (d) {
        $scope.registrationsData = d.data; //success
    }, function () {
        alert('Error occured!!!'); //Failed
    });
    $scope.Registration = {
        RegistrationId: '',
        FirstName: '',
        LastName: '',
        Email: '',
        Login: '',
        Organization: '',
        Question: '',
        Answer: '',
        Password: '',
        GroupName: ''
    };
     //Reset registration details
    $scope.clear = function () {
        $scope.Registration.RegistrationId = '';
        $scope.Registration.FirstName = '';
        $scope.Registration.LastName = '';
        $scope.Registration.Email = '';
        $scope.Registration.Login = '';
        $scope.Registration.Organization = '';
        $scope.Registration.Question = '';
        $scope.Registration.Answer = '';
        $scope.Registration.Password = '';
        $scope.Registration.GroupName = '';
    }
    //Add New Items
    $scope.save = function () {
        if ($scope.Registration.FirstName != "" && $scope.Registration.FirstName != "" && $scope.Registration.LastName != "" && $scope.Registration.Email != "" && $scope.Registration.Login != "" && $scope.Registration.Organization != "" &&
            $scope.Registration.Question != "" && $scope.Registration.Answer != "" && $scope.Registration.Password != "" && $scope.Registration.GroupName != "" ){
            //you can call Http request using $http
            $http({
                method: 'POST',
                url: 'api/Registration/PostRegistrant/',
                data: $scope.Registration
            }).then(function successCallback(response) {
                // this callback will be called asynchronously
                // when the response is available
                $scope.registrationsData.push(response.data);
                $scope.clear();
                alert("Registration Successfull !!!");
            }, function errorCallback(response) {
                // called asynchronously if an error occurs
                // or server returns response with an error status.
                alert("Error : " + response.data.ExceptionMessage);
            });
        }
        else {
        alert('Please Enter All the Values !!');
    }
    };
    // Edit registration details
    $scope.edit = function (data) {
        $scope.Registration = { RegistrationId: data.RegistrationId, FirstName: data.FirstName, LastName: data.LastName, Email: data.Email, Login: data.Login, Organization: data.Organization, Question: data.Question, Answer: data.Answer, Password: data.Password, GroupName: data.GroupName };
    }

    // Cancel registration details
    $scope.cancel = function () {
        $scope.clear();
    }

    // Update product details
    $scope.update = function () {
        if ($scope.Registration.FirstName != "" && $scope.Registration.FirstName != "" && $scope.Registration.LastName != "" && $scope.Registration.Email != "" && $scope.Registration.Login != "" && $scope.Registration.Organization != "" &&
            $scope.Registration.Question != "" && $scope.Registration.Answer != "" && $scope.Registration.Password != "" && $scope.Registration.GroupName != "") {
            $http({
                method: 'PUT',
                url: 'api/Registration/PutRegistrant/' + $scope.Registration.RegistrationId,
                data: $scope.Registration
            }).then(function successCallback(response) {
                $scope.registrationsData = response.data;
                $scope.clear();
                alert("RegistrationSuccessfull !!!");
            }, function errorCallback(response) {
                alert("Error : " + response.data.ExceptionMessage);
            });
        }
        else {
            alert('Please Enter All the Values !!');
        }
    };

    // Delete product details
    $scope.delete = function (index) {
        $http({
            method: 'DELETE',
            url: 'api/Registration/DeleteRegistrant/' + $scope.registrationsData[index].RegistrationId,
        }).then(function successCallback(response) {
            $scope.registrationsData.splice(index, 1);
            alert("Registrant Deleted Successfully !!!");
        }, function errorCallback(response) {
            alert("Error : " + response.data.ExceptionMessage);
        });
    };

});

// Here I have created a factory which is a popular way to create and configure services.
// You may also create the factories in another script file which is best practice.

app.factory('registrationService', function ($http) {
    var fac = {};
    fac.GetAllRecords = function () {
        return $http.get('api/Registration/GetAllRegistrants');
    }
    return fac;
});