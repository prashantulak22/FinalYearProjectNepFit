
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('nutritionpackageListCtrl', nutritionpackageListCtrl);
    nutritionpackageListCtrl.$inject = ['nutritionPackageService', '$scope', '$uibModal', 'blockUI'];
    function nutritionpackageListCtrl(nutritionPackageService, $scope, $uibModal, blockUI) {
        var vm = this;
        activate();

        function activate() {
            vm.mainGridOptions = {
                dataSource: {
                    requestStart: showLoading,
                    requestEnd: hideLoading,
                    transport: {
                        read: function (options) {
                            nutritionPackageService.getAllNutritionPackage().then(function (result) {
                                options.success(result.data);
                                vm.optionCallback = options;
                            });
                        }
                    },
                    sort: {
                        field: "Name", dir: "asc"
                    }
                },

                sortable: true,
                filterable: true,
                resizable: true,

                toolbar: [
                    { name: "addNutritionPackage", text: "Add NutritionPackage", imageClass: "fa fa-map-marker", className: "k-grid-addnutritionpackage", iconClass: "k-icon" }
                ],
                pageable: {
                    pageSize: 20

                },
                columns: [
                    {
                        width: "35px",
                        template: '<i ng-click=" vm.showEditNutritionPackage(dataItem)" class=" glyphicon glyphicon-pencil handCursor"></i>'
                    },
                    {
                        title: 'Name',
                        field: 'name'
                    },
                    {
                        title: 'Description',
                        field: 'description'
                    },
                    {
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
                        template: '<i ng-click=" vm.removeNutritionPackageRequest(dataItem)" class="glyphicon glyphicon-trash handCursor"></i>'
                    }
                ]
            };

        }

        vm.showAddNutritionPackage = function () {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: '/app/nutritionpackage/addNutritionPackage.html',
                controller: 'nutritionpackageAddCtrl as vm',
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


        vm.showEditNutritionPackage = function (item) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: '/app/nutritionpackage/editNutritionPackage.html',
                controller: 'nutritionpackageEditCtrl as vm',
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

        vm.removeNutritionPackageRequest = function (item) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: '/app/nutritionpackage/deleteNutritionPackage.html',
                controller: 'nutritionpackageDeleteCtrl as vm',
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
            if (widget === vm.nutritionpackageList) {
                widget.element.find(".k-grid-addnutritionpackage").on("click", function (e) {
                    e.preventDefault();
                    vm.showAddNutritionPackage();
                });
            }
        });

    }



})(angular, $, kendo);

