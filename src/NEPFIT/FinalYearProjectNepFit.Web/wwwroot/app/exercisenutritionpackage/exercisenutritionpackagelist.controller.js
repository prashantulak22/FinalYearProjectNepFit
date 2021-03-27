
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('exercisenutritionpackageListCtrl', exercisenutritionpackageListCtrl);
    exercisenutritionpackageListCtrl.$inject = ['exerciseNutritionPackageService', '$scope', '$uibModal','blockUI'];
    function exercisenutritionpackageListCtrl(exerciseNutritionPackageService, $scope, $uibModal, blockUI) {
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
                        field: "DateUpdated", dir: "asc"
                    }
                },
                scrollable: true,
                sortable: true,
                filterable: true,
                resizable: true,
               
                toolbar: [
                    { name: "addExerciseNutritionPackage", text: "Add ExerciseNutritionPackage", imageClass: "fa fa-map-marker", className: "k-grid-addexercisenutritionpackage", iconClass: "k-icon" }
                ],
                pageable: {
                    pageSize: 20
                },
                columns: [
                                   {
                        width: "35px",
                        template: '<i ng-click=" vm.showEditExerciseNutritionPackage(dataItem)" class=" fa fa-pencil handCursor"></i>'
                    },
                   {
       title: 'ExercisePackageName',
       field: 'exercisePackageName',
      },{
       title: 'NutritionPackageName',
       field: 'nutritionPackageName',
      },{
       title: 'DateUpdated',
       field: 'dateUpdated',
       template: "#= kendo.toString(kendo.parseDate(dateUpdated), 'MM/dd/yyyy h:mm tt') #",
      },{
       title: 'DateCreated',
       field: 'dateCreated',
       template: "#= kendo.toString(kendo.parseDate(dateCreated), 'MM/dd/yyyy h:mm tt') #",
      },                   
                    {
                        width: "35px",
                        template: '<i ng-click=" vm.removeExerciseNutritionPackageRequest(dataItem)" class="fa fa-trash handCursor"></i>'
                    }
                ] 
            };
 
        }
            
      vm.showAddExerciseNutritionPackage = function () {
                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: '/app/exercisenutritionpackage/addExerciseNutritionPackage.html',
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
                    templateUrl: '/app/exercisenutritionpackage/editExerciseNutritionPackage.html',
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
                    templateUrl: '/app/exercisenutritionpackage/deleteExerciseNutritionPackage.html',
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
            blockUI.start();
        }

        function hideLoading() {
            blockUI.stop();
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



})(angular, $, kendo);

