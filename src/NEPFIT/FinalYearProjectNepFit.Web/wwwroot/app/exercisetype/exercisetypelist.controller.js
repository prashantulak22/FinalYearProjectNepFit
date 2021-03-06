
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('exercisetypeListCtrl', exercisetypeListCtrl);
    exercisetypeListCtrl.$inject = ['exerciseTypeService', '$scope', '$uibModal', 'blockUI'];
    function exercisetypeListCtrl(exerciseTypeService, $scope, $uibModal, blockUI) {
        var vm = this;
        activate();

        function activate() {
            vm.mainGridOptions = {
                dataSource: {
                    requestStart: showLoading,
                    requestEnd: hideLoading,
                    transport: {
                        read: function (options) {
                            exerciseTypeService.getAllExerciseType().then(function (result) {
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
                    {
                        name: "addExerciseType", text: "Add ExerciseType",
                        imageClass: "fa fa-map-marker", className: "k-grid-addexercisetype", iconClass: "k-icon"
                    }
                ],
                pageable: {
                    pageSize: 10,
                    refresh: true
                },
                columns: [
                    {
                        width: "35px",
                        template: '<i ng-click=" vm.showEditExerciseType(dataItem)" class=" glyphicon glyphicon-pencil handCursor"></i>'
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
                        template: '<i ng-click=" vm.removeExerciseTypeRequest(dataItem)" class="glyphicon glyphicon-trash handCursor"></i>'
                    }
                ]
            };

        }

        vm.showAddExerciseType = function () {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: '/app/exercisetype/addExerciseType.html',
                controller: 'exercisetypeAddCtrl as vm',
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


        vm.showEditExerciseType = function (item) {
            console.log(item);
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: '/app/exercisetype/editExerciseType.html',
                controller: 'exercisetypeEditCtrl as vm',
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

        vm.removeExerciseTypeRequest = function (item) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: '/app/exercisetype/deleteExerciseType.html',
                controller: 'exercisetypeDeleteCtrl as vm',
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
            if (widget === vm.exercisetypeList) {
                widget.element.find(".k-grid-addexercisetype").on("click", function (e) {
                    e.preventDefault();
                    vm.showAddExerciseType();
                });
            }
        });

    }



})(angular, $, kendo);

