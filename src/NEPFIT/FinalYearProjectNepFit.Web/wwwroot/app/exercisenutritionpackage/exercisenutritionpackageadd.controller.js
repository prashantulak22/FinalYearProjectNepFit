
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('exercisenutritionpackageAddCtrl', exercisenutritionpackageAddCtrl);
    exercisenutritionpackageAddCtrl.$inject = ['exerciseNutritionPackageService', "$uibModalInstance", '$scope', 'blockUI', 'exercisePackageService', 'nutritionPackageService'];
    function exercisenutritionpackageAddCtrl(exerciseNutritionPackageService, $uibModalInstance, $scope, blockUI, exercisePackageService, nutritionPackageService) {
        var vm = this;
        vm.isNew = true;
        vm.title = ' Add ExerciseNutritionPackage';

        activate();
        function showLoading() {
            blockUI.start();
        }

        function hideLoading() {
            blockUI.stop();
        }

        function activate() {
            exercisePackageService.getAllExercisePackage()
                .then(function (result) {
                    vm.exercisePackageIdDropdownOptions = {
                        dataTextField: "name",
                        dataValueField: "exercisePackageId",
                        valuePrimitive: true,
                        dataSource: {
                            data: result.data
                        }
                    }

                });


            
            nutritionPackageService.getAllNutritionPackage()
                .then(function (result) {
                    vm.nutritionPackageIdDropdownOptions = {
                        dataTextField: "name",
                        dataValueField: "nutritionPackageId",
                        valuePrimitive: true,
                        dataSource: {
                            data: result.data
                        }
                    }

                });

                function initialize() {
                    return {

                        exerciseNutritionPackageId: "",
                        exercisePackageId: "",
                        nutritionPackageId: "",

                    };
                }
                vm.exerciseNutritionPackage = initialize();
                vm.validationError = [];

                function validateForm() {
                    vm.validationError = [];
                    if (vm.validationError.length > 0) return false;
                    if ($scope.validator.validate()) return true;
                    return false;
                }

                vm.saveExerciseNutritionPackage = function (option) {
                    if (!validateForm()) return;
                    showLoading();
                    exerciseNutritionPackageService.createExerciseNutritionPackage(vm.exerciseNutritionPackage)
                        .then(function () {
                            hideLoading();
                            vm.close();
                        }, function errorCallback(response) {
                            hideLoading();
                        });
                }

                vm.close = function () {
                    $uibModalInstance.close();
                };


            }



        }

    

})(angular, $, kendo);

