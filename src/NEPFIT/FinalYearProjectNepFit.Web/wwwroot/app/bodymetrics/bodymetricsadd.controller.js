
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
                    height: 1,
                    bodyMass: 1,
                    neckSize: 1,
                    shoulderSize: 1,
                    chestSize: 1,
                    foreArmSize: 1,
                    rightBicepSize: 1,
                    leftBicepSize: 1,
                    upperAbsSize: 1,
                    lowerAbsSize: 1,
                    waistSize: 1,
                    hipSize: 1,
                    rightThighSize: 1,
                    leftThighSize: 1,
                    rightCalveSize: 1,
                    leftCalveSize: 1,
                    
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

