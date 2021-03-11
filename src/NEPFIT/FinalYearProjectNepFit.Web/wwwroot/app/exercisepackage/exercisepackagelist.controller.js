
(function (angular, $, kendo, App) {
    'use strict';

    angular
        .module('tableapp')
        .controller('exercisepackageListCtrl', exercisepackageListCtrl);
    exercisepackageListCtrl.$inject = ['exercisePackageService', '$scope', '$uibModal'];
    function exercisepackageListCtrl(exercisePackageService, $scope, $uibModal) {
        var vm = this;
        activate();
 
        function activate() {
            vm.mainGridOptions = {
                dataSource: {
                    requestStart: showLoading,
                    requestEnd: hideLoading,
                    transport: {
                        read: function (options) {
                            exercisePackageService.getAllExercisePackage().then(function (result) {
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
                    { name: "addExercisePackage", text: "Add ExercisePackage", imageClass: "fa fa-map-marker", className: "k-grid-addexercisepackage", iconClass: "k-icon" }
                ],
                pageable: {
                    pageSize: 20
                },
                columns: [
                                   {
                        width: "35px",
                        template: '<i ng-click=" vm.showEditExercisePackage(dataItem)" class=" glyphicon glyphicon-pencil handCursor"></i>'
                    }
                   {
       title: 'ExercisePackageId',
       field: 'ExercisePackageId',
      },{
       title: 'Name',
       field: 'Name'
      },
      {
       title: 'Description',
       field: 'Description'
      },
      {
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
                        template: '<i ng-click=" vm.removeExercisePackageRequest(dataItem)" class="glyphicon glyphicon-trash handCursor"></i>'
                    }
                ] 
            };
 
        }
            
      vm.showAddExercisePackage = function () {
                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: '/tableapp/tableapp/add',
                    controller: 'exercisepackageAddCtrl as vm',
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
            
            
      vm.showEditExercisePackage = function (item) {
                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: '/tableapp/tableapp/edit',
                    controller: 'exercisepackageEditCtrl as vm',
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
            
            vm.removeExercisePackageRequest = function (item) {
                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: '/tableapp/tableapp/DeleteConfirm',
                    controller: 'exercisepackageDeleteCtrl as vm',
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
                target: '#exercisepackageList',
                boxed: true,
                message: 'Loading...'
            });
        }
        function hideLoading() {
            App.unblockUI('#exercisepackageList');
        }

        $scope.$on("kendoWidgetCreated", function (event, widget) {
            if (widget === vm.exercisepackageList) {
                widget.element.find(".k-grid-addexercisepackage").on("click", function (e) {
                    e.preventDefault();
                    vm.showAddExercisePackage();
                });
            }
        });

        }



})(angular, $, kendo, App);

