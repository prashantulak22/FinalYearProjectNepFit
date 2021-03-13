
(function (angular, $, kendo, App) {
    'use strict';

    angular
        .module('tableapp')
        .controller('exercisepackageroutineListCtrl', exercisepackageroutineListCtrl);
    exercisepackageroutineListCtrl.$inject = ['exercisePackageRoutineService', '$scope', '$uibModal'];
    function exercisepackageroutineListCtrl(exercisePackageRoutineService, $scope, $uibModal) {
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
                        field: "DateUpdated", dir: "desc"
                    }
                },
                scrollable: true,
                sortable: true,
                filterable: true,
                resizable: true,
                groupable: true,
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
       field: 'ExercisePackageRoutineId',
      },{
       title: 'ExercisePackageId',
       field: 'ExercisePackageId',
      },{
       title: 'ExerciseRoutineId',
       field: 'ExerciseRoutineId',
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
                        template: '<i ng-click=" vm.removeExercisePackageRoutineRequest(dataItem)" class="glyphicon glyphicon-trash handCursor"></i>'
                    }
                ] 
            };
 
        }
            
      vm.showAddExercisePackageRoutine = function () {
                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: '/tableapp/tableapp/add',
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
                    templateUrl: '/tableapp/tableapp/edit',
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
                    templateUrl: '/tableapp/tableapp/DeleteConfirm',
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
            App.blockUI({
                target: '#exercisepackageroutineList',
                boxed: true,
                message: 'Loading...'
            });
        }
        function hideLoading() {
            App.unblockUI('#exercisepackageroutineList');
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



})(angular, $, kendo, App);

