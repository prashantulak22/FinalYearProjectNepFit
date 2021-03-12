
(function (angular) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('homeCtrl', homeCtrl);
    homeCtrl.$inject = ['$uibModal', '$state'];
    function homeCtrl($uibModal, $state) {
        var vm = this;
        activate();
        function activate() {
            $("#chart").kendoChart({
                dataSource: {
                    transport: {
                        read: {
                            url: "api/user/progress",
                            dataType: "json"
                        }
                    }
                },
                title: {
                    text: "Progress Tracker (cm)"
                },
                legend: {
                    position: "top"
                },
                seriesDefaults: {
                    type: "line"
                },
                series: [{
                    field: "newChestSize",
                    categoryField: "yearMonth",
                    name: "Chest Size"
                }, {
                    field: "newArmSize",
                    categoryField: "yearMonth",
                    name: "Arm Size"
                }],
                categoryAxis: {
                    labels: {
                        rotation: -90
                    },
                    crosshair: {
                        visible: true
                    }
                },
                valueAxis: {
                    labels: {
                        format: "N0"
                    },
                    majorUnit: 20
                },
                tooltip: {
                    visible: true,
                    shared: true,
                    format: "N0"
                }
            });
        }

        vm.showAddBodyMetrics = function () {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: '/app/bodymetrics/create.html',
                controller: 'bodymetricsAddCtrl as vm',
                backdrop: 'static',
                size: "lg"
            });

        }

        vm.showExcerciseType = function () {
            $state.go('exerciseType');
        }
        vm.showExcerciseRoutine = function () {
            $state.go('exerciseRoutine');
        }
        vm.showExcercisePackage = function () {
            $state.go('exercisePackage');
        }
        vm.showNutritionType = function () {
            $state.go('nutritionType');
        }
        vm.showNutritionPackage = function () {
            $state.go('nutritionPackage');
        }
        vm.showNutritionRoutine = function () {
            $state.go('nutritionRoutine');
        }
    }


})(angular);

