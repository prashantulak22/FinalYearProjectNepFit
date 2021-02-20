
(function (angular) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('bodymetricsAddCtrl', bodymetricsAddCtrl);
    bodymetricsAddCtrl.$inject = ['bodyMetricsService', "$uibModalInstance", '$scope','blockUI'];
    function bodymetricsAddCtrl(bodyMetricsService, $uibModalInstance, $scope, blockUI) {
        var vm = this;
        vm.isNew = true;
        vm.title = ' Add BodyMetrics';

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
                    chestSize: 0,
                    armSize: 0,
                    forearmSize: 0,
                    wristSize: 0,
                    neckSize: 0,
                    upperAbs: 0,
                    lowerAbs: 0,
                    hipSize: 0,
                    waistSize: 0,
                    thighSize: 0,
                    calveSize: 0
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

