
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('nutritionroutineListCtrl', nutritionroutineListCtrl);
    nutritionroutineListCtrl.$inject = ['nutritionRoutineService', '$scope', '$uibModal', 'blockUI'];
    function nutritionroutineListCtrl(nutritionRoutineService, $scope, $uibModal, blockUI) {
        var vm = this;
        activate();
 
        function activate() {
            vm.mainGridOptions = {
                dataSource: {
                    requestStart: showLoading,
                    requestEnd: hideLoading,
                    transport: {
                        read: function (options) {
                            nutritionRoutineService.getAllNutritionRoutine().then(function (result) {
                                options.success(result.data);
                                vm.optionCallback = options;
                            });
                        }
                    },
                    sort: {
                        field: "Name", dir: "asc"
                    }
                },
                scrollable: true,
                sortable: true,
                filterable: true,
                resizable: true,
                
                toolbar: [
                    { name: "addNutritionRoutine", text: "Add NutritionRoutine", imageClass: "fa fa-map-marker", className: "k-grid-addnutritionroutine", iconClass: "k-icon" }
                ],
                pageable: {
                    pageSize: 20,
                    refresh: true
                },
                columns: [
                                   {
                        width: "35px",
                        template: '<i ng-click=" vm.showEditNutritionRoutine(dataItem)" class=" fa fa-pencil handCursor"></i>'
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
       title: 'HowToPrepare',
       field: 'howToPrepare'
                    },
                    {
                        title: 'FoodCategory',
                        field: 'foodCategory'
                    },
      {
       title: 'DateUpdated',
       field: 'dateUpdated',
       template: "#= kendo.toString(kendo.parseDate(dateUpdated), 'MM/dd/yyyy h:mm tt') #",
      },{
       title: 'DateCreated',
       field: 'dateCreated',
       template: "#= kendo.toString(kendo.parseDate(dateCreated), 'MM/dd/yyyy h:mm tt') #",
      },{
          title: 'NutritionTypeName',
          field: 'nutritionTypeName',
      },                   
                    {
                        width: "35px",
                        template: '<i ng-click=" vm.removeNutritionRoutineRequest(dataItem)" class="fa fa-trash handCursor"></i>'
                    }
                ] 
            };
 
        }
            
      vm.showAddNutritionRoutine = function () {
                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: '/app/nutritionroutine/addNutritionRoutine.html',
                    controller: 'nutritionroutineAddCtrl as vm',
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
            
            
      vm.showEditNutritionRoutine = function (item) {
                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: '/app/nutritionroutine/editNutritionRoutine.html',
                    controller: 'nutritionroutineEditCtrl as vm',
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
            
            vm.removeNutritionRoutineRequest = function (item) {
                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: '/app/nutritionroutine/deleteNutritionRoutine.html',
                    controller: 'nutritionroutineDeleteCtrl as vm',
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
            if (widget === vm.nutritionroutineList) {
                widget.element.find(".k-grid-addnutritionroutine").on("click", function (e) {
                    e.preventDefault();
                    vm.showAddNutritionRoutine();
                });
            }
        });

        }



})(angular, $, kendo);

