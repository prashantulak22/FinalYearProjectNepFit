
(function (angular) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('homeCtrl', homeCtrl);
    homeCtrl.$inject = ['$uibModal'];
    function homeCtrl($uibModal) {
        var vm = this;

        vm.showAddBodyMetrics = function () {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: '/app/bodymetrics/create.html',
                controller: 'bodymetricsAddCtrl as vm',
                backdrop: 'static',
                size: "lg"
            });

        }
    }


})(angular);

