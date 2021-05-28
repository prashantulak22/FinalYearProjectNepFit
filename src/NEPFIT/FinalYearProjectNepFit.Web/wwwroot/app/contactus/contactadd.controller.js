
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('contactUsCtrl', contactUsCtrl);
    contactUsCtrl.$inject = ['contactService', '$scope', 'blockUI','$state'];
    function contactUsCtrl(contactService, $scope, blockUI, $state) {
        var vm = this;
        vm.isNew = true;


        activate();
        function showLoading() {
            blockUI.start();
        }

        function hideLoading() {
            blockUI.stop();
        }
        function activate() {


            function initialize() {
                return {
                    subject: "",
                    email: "",
                    message:""
                }
            }
            vm.contact = initialize();
            vm.validationError = [];

            function validateForm() {
                vm.validationError = [];
                if (vm.validationError.length > 0) return false;
                if ($scope.validator.validate()) return true;
                return false;
            }

            vm.sendEmail = function (option) {
                if (!validateForm()) return;
                showLoading();
                contactService.sendemail(vm.contact)
                    .then(function () {
                        hideLoading();
                        alert("Message sucessfully sent") 
                        $state.go("home");
                    }, function errorCallback(response) {
                        hideLoading();
                    });
            }


        }


    }




})(angular, $, kendo);

