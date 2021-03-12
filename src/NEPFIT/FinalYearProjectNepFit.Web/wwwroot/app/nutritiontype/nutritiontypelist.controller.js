
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('nutritiontypeListCtrl', nutritiontypeListCtrl);
    nutritiontypeListCtrl.$inject = ['nutritionTypeService', '$scope', '$uibModal','blockUI'];
    function nutritiontypeListCtrl(nutritionTypeService, $scope, $uibModal, blockUI) {
        var vm = this;
        activate();
 
        function activate() {
            vm.mainGridOptions = {
                dataSource: {
                    requestStart: showLoading,
                    requestEnd: hideLoading,
                    transport: {
                        read: function (options) {
                            nutritionTypeService.getAllNutritionType().then(function (result) {
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
                        name: "addNutritionType", text: "Add NutritionType",
                        imageClass: "fa fa-map-marker", className: "k-grid-addnutritiontype", iconClass: "k-icon"
                    }
                ],
                pageable: {
                    pageSize: 10
                },
                columns: [
                                   {
                        width: "35px",
                        template: '<i ng-click=" vm.showEditNutritionType(dataItem)" class=" glyphicon glyphicon-pencil handCursor"></i>'
                    },
                    {
                   
       title: 'NutritionTypeId',
       field: 'NutritionTypeId',
      },{
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
      },{
       title: 'DateCreated',
       field: 'dateCreated',
       template: "#= kendo.toString(kendo.parseDate(dateCreated), 'MM/dd/yyyy h:mm tt') #",
      },                   
                    {
                        width: "35px",
                        template: '<i ng-click=" vm.removeNutritionTypeRequest(dataItem)" class="glyphicon glyphicon-trash handCursor"></i>'
                    }
                ] 
            };
 
        }
            
      vm.showAddNutritionType = function () {
                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: '/app/nutritiontype/addNutritionType.html',
                    controller: 'nutritiontypeAddCtrl as vm',
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
            
            
      vm.showEditNutritionType = function (item) {
                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: '/app/nutritiontype/editNutritionType.html',
                    controller: 'nutritiontypeEditCtrl as vm',
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
            
            vm.removeNutritionTypeRequest = function (item) {
                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: '/app/nutritiontype/deleteNutritionType.html',
                    controller: 'nutritiontypeDeleteCtrl as vm',
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
            if (widget === vm.nutritiontypeList) {
                widget.element.find(".k-grid-addnutritiontype").on("click", function (e) {
                    e.preventDefault();
                    vm.showAddNutritionType();
                });
            }
        });

        }



})(angular, $, kendo);

