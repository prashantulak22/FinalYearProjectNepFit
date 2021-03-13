
(function (angular, $, kendo, App) {
    'use strict';

    angular
        .module('tableapp')
        .controller('nutritionpackageroutineListCtrl', nutritionpackageroutineListCtrl);
    nutritionpackageroutineListCtrl.$inject = ['nutritionPackageRoutineService', '$scope', '$uibModal'];
    function nutritionpackageroutineListCtrl(nutritionPackageRoutineService, $scope, $uibModal) {
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
                        field: "DateUpdated", dir: "desc"
                    }
                },
                scrollable: true,
                sortable: true,
                filterable: true,
                resizable: true,
                groupable: true,
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
                    }
                   {
       title: 'NutritionPackageRoutineId',
       field: 'NutritionPackageRoutineId',
      },{
       title: 'NutritionPackageId',
       field: 'NutritionPackageId',
      },{
       title: 'NutritionRoutineId',
       field: 'NutritionRoutineId',
      },{
       title: 'Active',
       field: 'Active',
      },{
       title: 'UpdatedBy',
       field: 'UpdatedBy',
      },{
       title: 'CreatedBy',
       field: 'CreatedBy',
      },{
       title: 'DateUpdated',
       field: 'DateUpdated',
       template: "#= kendo.toString(kendo.parseDate(DateUpdated), 'MM/dd/yyyy h:mm tt') #",
      },{
       title: 'DateCreated',
       field: 'DateCreated',
       template: "#= kendo.toString(kendo.parseDate(DateCreated), 'MM/dd/yyyy h:mm tt') #",
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
                    templateUrl: '/tableapp/tableapp/add',
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
                    templateUrl: '/tableapp/tableapp/edit',
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
                    templateUrl: '/tableapp/tableapp/DeleteConfirm',
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
            App.blockUI({
                target: '#nutritionpackageroutineList',
                boxed: true,
                message: 'Loading...'
            });
        }
        function hideLoading() {
            App.unblockUI('#nutritionpackageroutineList');
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



})(angular, $, kendo, App);

