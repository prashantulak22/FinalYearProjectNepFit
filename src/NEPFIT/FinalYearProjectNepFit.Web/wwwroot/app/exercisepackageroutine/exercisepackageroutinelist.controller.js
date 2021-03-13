
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('exercisepackageroutineListCtrl', exercisepackageroutineListCtrl);
    exercisepackageroutineListCtrl.$inject = ['exercisePackageRoutineService', '$scope', '$uibModal', 'blockUI'];
    function exercisepackageroutineListCtrl(exercisePackageRoutineService, $scope, $uibModal, blockUI) {
        var vm = this;
        activate();
 
        function activate() {
            vm.mainGridOptions = {
                dataSource: {
                    requestStart: showLoading,
                    requestEnd: hideLoading,
                    transport: {
                        read: function (options) {
                            exercisePackageRoutineService.getAllExercisePackageRoutine().then(function (result) {
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
                    { name: "addExercisePackageRoutine", text: "Add ExercisePackageRoutine", imageClass: "fa fa-map-marker", className: "k-grid-addexercisepackageroutine", iconClass: "k-icon" }
                ],
                pageable: {
                    pageSize: 20
                },
                columns: [
                                   {
                        width: "35px",
                        template: '<i ng-click=" vm.showEditExercisePackageRoutine(dataItem)" class=" glyphicon glyphicon-pencil handCursor"></i>'
                    }
                   {
       title: 'ExercisePackageRoutineId',
       field: 'exercisePackageRoutineId',
      },{
       title: 'ExercisePackageId',
       field: 'exercisePackageId',
      },{
       title: 'ExerciseRoutineId',
       field: 'exerciseRoutineId',
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
                        template: '<i ng-click=" vm.removeExercisePackageRoutineRequest(dataItem)" class="glyphicon glyphicon-trash handCursor"></i>'
                    }
                ] 
            };
 
        }
            
      vm.showAddExercisePackageRoutine = function () {
                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: '/app/exercisepackageroutine/addExercisePackageRoutine.html',
                    controller: 'exercisepackageroutineAddCtrl as vm',
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
            
            
      vm.showEditExercisePackageRoutine = function (item) {
                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: '/app/exercisepackageroutine/editExercisePackageRoutine.html',
                    controller: 'exercisepackageroutineEditCtrl as vm',
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
            
            vm.removeExercisePackageRoutineRequest = function (item) {
                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: '/app/exercisepackageroutine/deleteExercisePackageRoutine.html',
                    controller: 'exercisepackageroutineDeleteCtrl as vm',
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
            if (widget === vm.exercisepackageroutineList) {
                widget.element.find(".k-grid-addexercisepackageroutine").on("click", function (e) {
                    e.preventDefault();
                    vm.showAddExercisePackageRoutine();
                });
            }
        });

        }



})(angular, $, kendo);

