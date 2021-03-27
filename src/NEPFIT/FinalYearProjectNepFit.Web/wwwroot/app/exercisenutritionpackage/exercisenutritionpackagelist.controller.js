
(function (angular, $, kendo, App) {
    'use strict';

    angular
        .module('tableapp')
        .controller('exercisenutritionpackageListCtrl', exercisenutritionpackageListCtrl);
    exercisenutritionpackageListCtrl.$inject = ['exerciseNutritionPackageService', '$scope', '$uibModal'];
    function exercisenutritionpackageListCtrl(exerciseNutritionPackageService, $scope, $uibModal) {
        var vm = this;
        activate();
 
        function activate() {
            vm.mainGridOptions = {
                dataSource: {
                    requestStart: showLoading,
                    requestEnd: hideLoading,
                    transport: {
                        read: function (options) {
                            exerciseNutritionPackageService.getAllExerciseNutritionPackage().then(function (result) {
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
                    { name: "addExerciseNutritionPackage", text: "Add ExerciseNutritionPackage", imageClass: "fa fa-map-marker", className: "k-grid-addexercisenutritionpackage", iconClass: "k-icon" }
                ],
                pageable: {
                    pageSize: 20
                },
                columns: [
                                   {
                        width: "35px",
                        template: '<i ng-click=" vm.showEditExerciseNutritionPackage(dataItem)" class=" glyphicon glyphicon-pencil handCursor"></i>'
                    }
                   {
       title: 'ExerciseNutritionPackageId',
       field: 'ExerciseNutritionPackageId',
      },{
       title: 'ExercisePackageId',
       field: 'ExercisePackageId',
      },{
       title: 'NutritionPackageId',
       field: 'NutritionPackageId',
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
                        template: '<i ng-click=" vm.removeExerciseNutritionPackageRequest(dataItem)" class="glyphicon glyphicon-trash handCursor"></i>'
                    }
                ] 
            };
 
        }
            
      vm.showAddExerciseNutritionPackage = function () {
                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: '/tableapp/tableapp/add',
                    controller: 'exercisenutritionpackageAddCtrl as vm',
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
            
            
      vm.showEditExerciseNutritionPackage = function (item) {
                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: '/tableapp/tableapp/edit',
                    controller: 'exercisenutritionpackageEditCtrl as vm',
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
            
            vm.removeExerciseNutritionPackageRequest = function (item) {
                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: '/tableapp/tableapp/DeleteConfirm',
                    controller: 'exercisenutritionpackageDeleteCtrl as vm',
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
                target: '#exercisenutritionpackageList',
                boxed: true,
                message: 'Loading...'
            });
        }
        function hideLoading() {
            App.unblockUI('#exercisenutritionpackageList');
        }

        $scope.$on("kendoWidgetCreated", function (event, widget) {
            if (widget === vm.exercisenutritionpackageList) {
                widget.element.find(".k-grid-addexercisenutritionpackage").on("click", function (e) {
                    e.preventDefault();
                    vm.showAddExerciseNutritionPackage();
                });
            }
        });

        }



})(angular, $, kendo, App);

