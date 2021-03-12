
(function (angular, $, kendo, App) {
    'use strict';

    angular
        .module('tableapp')
        .controller('exerciseroutineListCtrl', exerciseroutineListCtrl);
    exerciseroutineListCtrl.$inject = ['exerciseRoutineService', '$scope', '$uibModal'];
    function exerciseroutineListCtrl(exerciseRoutineService, $scope, $uibModal) {
        var vm = this;
        activate();
 
        function activate() {
            vm.mainGridOptions = {
                dataSource: {
                    requestStart: showLoading,
                    requestEnd: hideLoading,
                    transport: {
                        read: function (options) {
                            exerciseRoutineService.getAllExerciseRoutine().then(function (result) {
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
                    { name: "addExerciseRoutine", text: "Add ExerciseRoutine", imageClass: "fa fa-map-marker", className: "k-grid-addexerciseroutine", iconClass: "k-icon" }
                ],
                pageable: {
                    pageSize: 20
                },
                columns: [
                                   {
                        width: "35px",
                        template: '<i ng-click=" vm.showEditExerciseRoutine(dataItem)" class=" glyphicon glyphicon-pencil handCursor"></i>'
                    }
                   {
       title: 'ExerciseRoutineId',
       field: 'ExerciseRoutineId',
      },{
       title: 'Name',
       field: 'Name'
      },
      {
       title: 'Description',
       field: 'Description'
      },
      {
       title: 'Repetition',
       field: 'Repetition',
      },{
       title: 'Duration',
       field: 'Duration',
      },{
       title: 'ExerciseTypeId',
       field: 'ExerciseTypeId',
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
                        template: '<i ng-click=" vm.removeExerciseRoutineRequest(dataItem)" class="glyphicon glyphicon-trash handCursor"></i>'
                    }
                ] 
            };
 
        }
            
      vm.showAddExerciseRoutine = function () {
                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: '/tableapp/tableapp/add',
                    controller: 'exerciseroutineAddCtrl as vm',
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
            
            
      vm.showEditExerciseRoutine = function (item) {
                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: '/tableapp/tableapp/edit',
                    controller: 'exerciseroutineEditCtrl as vm',
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
            
            vm.removeExerciseRoutineRequest = function (item) {
                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: '/tableapp/tableapp/DeleteConfirm',
                    controller: 'exerciseroutineDeleteCtrl as vm',
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
                target: '#exerciseroutineList',
                boxed: true,
                message: 'Loading...'
            });
        }
        function hideLoading() {
            App.unblockUI('#exerciseroutineList');
        }

        $scope.$on("kendoWidgetCreated", function (event, widget) {
            if (widget === vm.exerciseroutineList) {
                widget.element.find(".k-grid-addexerciseroutine").on("click", function (e) {
                    e.preventDefault();
                    vm.showAddExerciseRoutine();
                });
            }
        });

        }



})(angular, $, kendo, App);

