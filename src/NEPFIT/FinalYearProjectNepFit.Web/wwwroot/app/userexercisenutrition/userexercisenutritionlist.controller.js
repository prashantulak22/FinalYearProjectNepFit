
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('userexercisenutritionListCtrl', userexercisenutritionListCtrl);
    userexercisenutritionListCtrl.$inject = ['userExerciseNutritionService', '$scope', '$uibModal', 'blockUI'];
    function userexercisenutritionListCtrl(userExerciseNutritionService, $scope, $uibModal, blockUI) {
        var vm = this;
        activate();
 
        function activate() {
            vm.mainGridOptions = {
                dataSource: {
                    requestStart: showLoading,
                    requestEnd: hideLoading,
                    transport: {
                        read: function (options) {
                            userExerciseNutritionService.getAllUserExerciseNutrition().then(function (result) {
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
                    { name: "addUserExerciseNutrition", text: "Add UserExerciseNutrition", imageClass: "fa fa-map-marker", className: "k-grid-adduserexercisenutrition", iconClass: "k-icon" }
                ],
                pageable: {
                    pageSize: 20
                },
                columns: [
                                   {
                        width: "35px",
                        template: '<i ng-click=" vm.showEditUserExerciseNutrition(dataItem)" class=" fa fa-pencil handCursor"></i>'
                    },
                   
                   {
                   title: 'UserExerciseNutritionId',
                   field: 'userExerciseNutritionId',
                  },{
                   title: 'DateUpdated',
                   field: 'dateUpdated',
                   template: "#= kendo.toString(kendo.parseDate(dateUpdated), 'MM/dd/yyyy h:mm tt') #",
                  },{
                   title: 'DateCreated',
                   field: 'dateCreated',
                   template: "#= kendo.toString(kendo.parseDate(dateCreated), 'MM/dd/yyyy h:mm tt') #",
                  },{
                   title: 'UserId',
                   field: 'userId',
                  },{
                   title: 'ExerciseNutritionPackageId',
                   field: 'exerciseNutritionPackageId',
                  },                   
                    {
                        width: "35px",
                        template: '<i ng-click=" vm.removeUserExerciseNutritionRequest(dataItem)" class="fa fa-trash handCursor"></i>'
                    }
                ] 
            };
 
        }
            
      vm.showAddUserExerciseNutrition = function () {
                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: '/app/userexercisenutrition/addUserExerciseNutrition.html',
                    controller: 'userexercisenutritionAddCtrl as vm',
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
            
            
      vm.showEditUserExerciseNutrition = function (item) {
                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: '/app/userexercisenutrition/editUserExerciseNutrition.html',
                    controller: 'userexercisenutritionEditCtrl as vm',
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
            
            vm.removeUserExerciseNutritionRequest = function (item) {
                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: '/app/userexercisenutrition/deleteUserExerciseNutrition.html',
                    controller: 'userexercisenutritionDeleteCtrl as vm',
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
            if (widget === vm.userexercisenutritionList) {
                widget.element.find(".k-grid-adduserexercisenutrition").on("click", function (e) {
                    e.preventDefault();
                    vm.showAddUserExerciseNutrition();
                });
            }
        });

        }



})(angular, $, kendo);

