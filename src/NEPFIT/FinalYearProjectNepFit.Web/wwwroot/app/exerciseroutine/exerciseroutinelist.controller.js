
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('exerciseroutineListCtrl', exerciseroutineListCtrl);
    exerciseroutineListCtrl.$inject = ['exerciseRoutineService', '$scope', '$uibModal', 'blockUI'];
    function exerciseroutineListCtrl(exerciseRoutineService, $scope, $uibModal, blockUI) {
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
                        field: "Name", dir: "asc"
                    }
                },
                scrollable: true,
                sortable: true,
                filterable: true,
                resizable: true,
                
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
       title: 'Repetition',
       field: 'repetition',
      },{
       title: 'Duration',
       field: 'duration',
      },{
       title: 'ExerciseTypeId',
       field: 'exerciseTypeId',
      },{
       title: 'DateUpdated',
       field: 'dateUpdated',
       template: "#= kendo.toString(kendo.parseDate(DateUpdated), 'MM/dd/yyyy h:mm tt') #",
      },{
       title: 'DateCreated',
       field: 'dateCreated',
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
                    templateUrl: '/app/exerciseroutine/addExerciseRoutine.html',
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
                    templateUrl: '/app/exerciseroutine/editExerciseRoutine.html',
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
                    templateUrl: '/app/exerciseroutine/deleteExerciseRoutine.html',
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
            blockUI.start();
        }

        function hideLoading() {
            blockUI.stop();
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



})(angular, $, kendo);

