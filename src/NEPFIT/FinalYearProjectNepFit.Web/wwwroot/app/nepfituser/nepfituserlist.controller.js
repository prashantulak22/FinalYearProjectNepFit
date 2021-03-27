
(function (angular, $, kendo, App) {
    'use strict';

    angular
        .module('tableapp')
        .controller('nepfituserListCtrl', nepfituserListCtrl);
    nepfituserListCtrl.$inject = ['nepFitUserService', '$scope', '$uibModal'];
    function nepfituserListCtrl(nepFitUserService, $scope, $uibModal) {
        var vm = this;
        activate();
 
        function activate() {
            vm.mainGridOptions = {
                dataSource: {
                    requestStart: showLoading,
                    requestEnd: hideLoading,
                    transport: {
                        read: function (options) {
                            nepFitUserService.getAllNepFitUser().then(function (result) {
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
                    { name: "addNepFitUser", text: "Add NepFitUser", imageClass: "fa fa-map-marker", className: "k-grid-addnepfituser", iconClass: "k-icon" }
                ],
                pageable: {
                    pageSize: 20
                },
                columns: [
                                   {
                        width: "35px",
                        template: '<i ng-click=" vm.showEditNepFitUser(dataItem)" class=" glyphicon glyphicon-pencil handCursor"></i>'
                    }
                   {
       title: 'UserId',
       field: 'UserId',
      },{
       title: 'FirstName',
       field: 'FirstName'
      },
      {
       title: 'LastName',
       field: 'LastName'
      },
      {
       title: 'DateOfBirth',
       field: 'DateOfBirth',
       template: "#= kendo.toString(kendo.parseDate(DateOfBirth), 'MM/dd/yyyy h:mm tt') #",
      },{
       title: 'Gender',
       field: 'Gender'
      },
      {
       title: 'MobileNumber',
       field: 'MobileNumber',
      },                   
                    {
                        width: "35px",
                        template: '<i ng-click=" vm.removeNepFitUserRequest(dataItem)" class="glyphicon glyphicon-trash handCursor"></i>'
                    }
                ] 
            };
 
        }
            
      vm.showAddNepFitUser = function () {
                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: '/tableapp/tableapp/add',
                    controller: 'nepfituserAddCtrl as vm',
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
            
            
      vm.showEditNepFitUser = function (item) {
                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: '/tableapp/tableapp/edit',
                    controller: 'nepfituserEditCtrl as vm',
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
            
            vm.removeNepFitUserRequest = function (item) {
                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: '/tableapp/tableapp/DeleteConfirm',
                    controller: 'nepfituserDeleteCtrl as vm',
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
                target: '#nepfituserList',
                boxed: true,
                message: 'Loading...'
            });
        }
        function hideLoading() {
            App.unblockUI('#nepfituserList');
        }

        $scope.$on("kendoWidgetCreated", function (event, widget) {
            if (widget === vm.nepfituserList) {
                widget.element.find(".k-grid-addnepfituser").on("click", function (e) {
                    e.preventDefault();
                    vm.showAddNepFitUser();
                });
            }
        });

        }



})(angular, $, kendo, App);

