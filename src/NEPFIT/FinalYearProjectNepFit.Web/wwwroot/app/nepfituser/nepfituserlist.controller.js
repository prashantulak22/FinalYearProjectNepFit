
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('nepfituserListCtrl', nepfituserListCtrl);
    nepfituserListCtrl.$inject = ['nepFitUserService', '$scope', '$uibModal', 'blockUI'];
    function nepfituserListCtrl(nepFitUserService, $scope, $uibModal, blockUI) {
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
                        field: "DateUpdated", dir: "asc"
                    }
                },
                scrollable: true,
                sortable: true,
                filterable: true,
                resizable: true,
               
                toolbar: [
                    { name: "addNepFitUser", text: "Add NepFitUser", imageClass: "fa fa-map-marker", className: "k-grid-addnepfituser", iconClass: "k-icon" }
                ],
                pageable: {
                    pageSize: 20,
                    refresh: true
                },
                columns: [
                                   {
                        width: "35px",
                        template: '<i ng-click=" vm.showEditNepFitUser(dataItem)" class=" fa fa-pencil handCursor"></i>'
                    },
                                    {
                        title: 'FirstName',
                        field: 'firstName'
                        },
                        {
                        title: 'LastName',
                        field: 'lastName'
                        },
                        {
                        title: 'DateOfBirth',
                        field: 'dateOfBirth',
                        template: "#= kendo.toString(kendo.parseDate(dateOfBirth), 'MM/dd/yyyy h:mm tt') #",
                        },{
                        title: 'Gender',
                        field: 'gender',
                    },

                    {
                        title: 'ExperienceLevel',
                        field: 'experienceLevel',
                    },{
                    title: 'IsAdmin',
                    field: 'isAdmin',
                    }, {
                        title: 'Package',
                        field: 'isAdmin',
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
                        template: '<i ng-click=" vm.removeNepFitUserRequest(dataItem)" class="fa fa-trash handCursor"></i>'
                    }
                ] 
            };
 
        }
            
      vm.showAddNepFitUser = function () {
                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: '/app/nepfituser/addNepFitUser.html',
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
                    templateUrl: '/app/nepfituser/editNepFitUser.html',
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
                    templateUrl: '/app/nepfituser/deleteNepFitUser.html',
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
            blockUI.start();
        }

        function hideLoading() {
            blockUI.stop();
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



})(angular, $, kendo);

