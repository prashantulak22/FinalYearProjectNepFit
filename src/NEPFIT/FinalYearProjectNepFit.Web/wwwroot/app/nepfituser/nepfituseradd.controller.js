
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('nepfituserAddCtrl', nepfituserAddCtrl);
    nepfituserAddCtrl.$inject = ['nepFitUserService', '$scope', 'blockUI', 'exerciseNutritionPackageService','$state'];
    function nepfituserAddCtrl(nepFitUserService, $scope, blockUI, exerciseNutritionPackageService, $state) {
        var vm = this;
        vm.isNew = true;
        vm.title = ' Add NepFitUser';
        
        activate();
        function showLoading() {
            blockUI.start();
        }

        function hideLoading() {
            blockUI.stop();
        }
        function activate() {
            vm.nepFitUser = initialize();
            nepFitUserService.getLoggedInUser().then(function (result) {
                app.user = result.data;
                vm.isAdmin = app.user.isAdmin;
                exerciseNutritionPackageService.getAllExerciseNutritionPackage()
                    .then(function (result) {
                        vm.nutritionPackageIdDropdownOptions = {
                            dataTextField: "nutritionPackageName",
                            dataValueField: "exerciseNutritionPackageId",
                            valuePrimitive: true,
                            value: vm.nepFitUser.exerciseNutritionPackageId,
                            dataSource: {
                                data: result.data
                            }
                        }

                    });
                
                
                if (app.user) {
                    vm.isNewUser = false;
                    vm.nepFitUser = app.user;
                    vm.nepFitUser.dateOfBirth = moment(app.user.dateOfBirth).toDate();
                } else {
                    vm.isNewUser = true;
                    
                }

            });
            
       
        
                function initialize() {
            return {
              
                    
                    firstName: "",
                    lastName: "",
                    dateOfBirth: "",
                    gender: "M",
                    isAdmin: false,
                    exerciseNutritionPackageId:"",

                               
            };
            }
           
             vm.validationError = [];
     
             function validateForm() {
            vm.validationError = [];
                  if (vm.validationError.length > 0) return false;
                if ($scope.validator.validate()) return true;
                return false;
        }
        
                vm.saveNepFitUser = function (option) {
            if (!validateForm()) return;
           showLoading();
            nepFitUserService.createNepFitUser(vm.nepFitUser)
                .then(function () {
                    hideLoading();
                    nepFitUserService.getLoggedInUser().then(function (result) {
                        app.user = result.data;
                      
                        

                    });

                }, function errorCallback(response) {
                    hideLoading();
                    });
        }
        
                vm.close = function () {
           
        };
        
        
        }
             
 
        }
        



})(angular, $, kendo);

