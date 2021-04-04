
(function (angular) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('homeCtrl', homeCtrl);
    homeCtrl.$inject = ['$uibModal', '$state', 'nepFitUserService'];
    function homeCtrl($uibModal, $state, nepFitUserService) {
        var vm = this;
        vm.dispalyContent = false;
        activate();
        function activate() {
            app.user = {};
            nepFitUserService.getLoggedInUser().then(function (result) {
                app.user = result.data;
                vm.isAdmin = app.user.isAdmin;
                if (!result.data) {
                    $state.go('register');
                } else {
                    vm.dispalyContent = true;
                }

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

     
        vm.showAdmin = function () {
            $state.go('admin');
        }

        vm.showPostRegister = function () {
            $state.go('register');
        }
    }


})(angular);

