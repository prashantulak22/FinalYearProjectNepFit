
(function (angular) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('bodymetricsAddCtrl', bodymetricsAddCtrl);
    bodymetricsAddCtrl.$inject = ['bodyMetricsService', "$uibModalInstance", '$scope','blockUI'];
    function bodymetricsAddCtrl(bodyMetricsService, $uibModalInstance, $scope, blockUI) {
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
                    height: 0,
                    bodyMass: 0,
                    neckSize: 0,
                    shoulderSize: 0,
                    chestSize: 0,
                    foreArmSize: 0,
                    rightBicepSize: 0,
                    leftBicepSize: 0,
                    upperAbsSize: 0,
                    lowerAbsSize: 0,
                    waistSize: 0,
                    hipSize: 0,
                    rightThighSize: 0,
                    leftThighSize: 0,
                    rightCalveSize: 0,
                    leftCalveSize: 0,
                    
                };
            }
            vm.bodyMetrics = initialize();
            vm.validationError = [];

            function validateForm() {
                vm.validationError = [];
                if (vm.validationError.length > 0) return false;
                if ($scope.validator.validate()) return true;
                return false;
            }

            vm.saveBodyMetrics = function (option) {
                if (!validateForm()) return;
                showLoading();
                bodyMetricsService.createBodyMetrics(vm.bodyMetrics)
                    .then(function () {
                        hideLoading();
                        vm.close();
                    }, function errorCallback(response) {
                        hideLoading();
                    });
            }

            vm.close = function () {
                $uibModalInstance.close();
            };

        }


    }




})(angular);

