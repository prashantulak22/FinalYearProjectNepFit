
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('nutritionpackageroutineListCtrl', nutritionpackageroutineListCtrl);
    nutritionpackageroutineListCtrl.$inject = ['nutritionPackageRoutineService', '$scope', '$uibModal', 'blockUI'];
    function nutritionpackageroutineListCtrl(nutritionPackageRoutineService, $scope, $uibModal, blockUI) {
        var vm = this;
        activate();

        function activate() {
            vm.mainGridOptions = {
                dataSource: {
                    requestStart: showLoading,
                    requestEnd: hideLoading,
                    transport: {
                        read: function (options) {
                            nutritionPackageRoutineService.getAllNutritionPackageRoutine().then(function (result) {
                                options.success(result.data);
                                vm.optionCallback = options;
                            });
                        }
                    },
                    sort: {
                        field: "DateUpdated", dir: "asc"
                    }
                },
                scrollable: true,
                sortable: true,
                filterable: true,
                resizable: true,

                toolbar: [
                    { name: "addNutritionPackageRoutine", text: "Add NutritionPackageRoutine", imageClass: "fa fa-map-marker", className: "k-grid-addnutritionpackageroutine", iconClass: "k-icon" }
                ],
                pageable: {
                    pageSize: 20
                },
                columns: [
                    {
                        width: "35px",
                        template: '<i ng-click=" vm.showEditNutritionPackageRoutine(dataItem)" class=" glyphicon glyphicon-pencil handCursor"></i>'
                    },
                    {
                        title: 'NutritionPackageRoutineId',
                        field: 'nutritionPackageRoutineId',
                    }, {
                        title: 'NutritionPackageId',
                        field: 'nutritionPackageId',
                    }, {
                        title: 'NutritionRoutineId',
                        field: 'nutritionRoutineId',
                    }, {
                        title: 'DateUpdated',
                        field: 'dateUpdated',
                        template: "#= kendo.toString(kendo.parseDate(dateUpdated), 'MM/dd/yyyy h:mm tt') #",
                    }, {
                        title: 'DateCreated',
                        field: 'dateCreated',
                        template: "#= kendo.toString(kendo.parseDate(dateCreated), 'MM/dd/yyyy h:mm tt') #",
                    },
                    {
                        width: "35px",
                        template: '<i ng-click=" vm.removeNutritionPackageRoutineRequest(dataItem)" class="glyphicon glyphicon-trash handCursor"></i>'
                    }
                ]
            };

        }

        vm.showAddNutritionPackageRoutine = function () {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: '/app/nutritionpackageroutine/addNutritionPackageRoutine.html',
                controller: 'nutritionpackageroutineAddCtrl as vm',
                backdrop: 'static',
                size: "lg",
                resolve: {
                    param: function () {
                        return {
                        };
                    }
                }
            });
            modalInstance.result.then(function () {
                showLoading();
                vm.mainGridOptions.dataSource.transport.read(vm.optionCallback);
            });
        }


        vm.showEditNutritionPackageRoutine = function (item) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: '/app/nutritionpackageroutine/editNutritionPackageRoutine.html',
                controller: 'nutritionpackageroutineEditCtrl as vm',
                backdrop: 'static',
                size: "lg",
                resolve: {
                    param: function () {
                        return {
                            'item': item,
                            'isNew': false,
                        };
                    }
                }
            });
            modalInstance.result.then(function () {
                showLoading();
                vm.mainGridOptions.dataSource.transport.read(vm.optionCallback);
            });
        }

        vm.removeNutritionPackageRoutineRequest = function (item) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: '/app/nutritionpackageroutine/deleteNutritionPackageRoutine.html',
                controller: 'nutritionpackageroutineDeleteCtrl as vm',
                backdrop: 'static',
                size: "md",
                resolve: {
                    param: function () {
                        return {
                            'item': item
                        };
                    }
                }
            });
            modalInstance.result.then(function () {
                vm.mainGridOptions.dataSource.transport.read(vm.optionCallback);
            });
        }


        function showLoading() {
            blockUI.start();
        }

        function hideLoading() {
            blockUI.stop();
        }

        $scope.$on("kendoWidgetCreated", function (event, widget) {
            if (widget === vm.nutritionpackageroutineList) {
                widget.element.find(".k-grid-addnutritionpackageroutine").on("click", function (e) {
                    e.preventDefault();
                    vm.showAddNutritionPackageRoutine();
                });
            }
        });

    }



})(angular, $, kendo);

