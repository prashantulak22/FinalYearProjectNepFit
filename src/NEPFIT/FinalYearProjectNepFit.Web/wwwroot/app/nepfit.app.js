(function (angular, app) {
    'use strict';
    angular
        .module('nepFitApp', ['kendo.directives', 'ui.bootstrap', 'ui.router', 'blockUI'])
        .config([
            "$stateProvider", "$urlRouterProvider", '$locationProvider', 'blockUIConfig',
            function ($stateProvider, $urlRouterProvider, $locationProvider, blockUIConfig) {

                //Don't use abstract state (and remove app. from url), because it doesn't work with htm5Mode
                //Use the HTML5 History API
                blockUIConfig.autoBlock = false;

                $stateProvider
                    .state("home",
                        {
                            url: "/",
                            templateUrl: "/app/home/home.html",
                            title: "Home"
                        })
                    .state("exerciseType",
                        {
                            url: "/exerciseType",
                            templateUrl: "/app/exercisetype/index.html",
                            title: "ExerciseType"
                        })
                    .state("exerciseRoutine",
                        {
                            url: "/exerciseRoutine",
                            templateUrl: "/app/exerciseroutine/exerciseRoutine.html",
                            title: "ExerciseType"
                        })
                    .state("exercisePackage",
                        {
                            url: "/exercisePackage",
                            templateUrl: "/app/exercisepackage/exercisePackage.html",
                            title: "ExercisePackage"
                        })
                    .state("nutritionType",
                        {
                            url: "/nutritionType",
                            templateUrl: "/app/nutritiontype/nutritionType.html",
                            title: "NutritionType"
                        })
                    .state("nutritionPackage",
                        {
                            url: "/nutritionPackage",
                            templateUrl: "/app/nutritionpackage/nutritionPackage.html",
                            title: "NutritionPackage"
                        })
                    .state("nutritionRoutine",
                        {
                            url: "/nutritionRoutine",
                            templateUrl: "/app/nutritionroutine/nutritionRoutine.html",
                            title: "NutritionRoutine"
                        })
                    .state("nutritionPackageRoutine",
                        {
                            url: "/nutritionPackageRoutine",
                            templateUrl: "/app/nutritionpackageroutine/nutritionPackageRoutine.html",
                            title: "NutritionPackageRoutine"
                        })
                    .state("exercisePackageRoutine",
                        {
                            url: "/exercisePackageRoutine",
                            templateUrl: "/app/exercisepackageroutine/exercisePackageRoutine.html",
                            title: "ExercisePackageRoutine"
                        })

                    .state("exerciseNutritionPackage",
                        {
                            url: "/exerciseNutritionPackage",
                            templateUrl: "/app/exercisenutritionpackage/exercisenutritionpackage.html",
                            title: "ExerciseNutritionPackage"
                        })

                    .state("nepFitUser",
                        {
                            url: "/nepFitUser",
                            templateUrl: "/app/nepfituser/nepfituser.html",
                            title: "NepFitUser"
                        })

                    .state("userExerciseNutrition",
                        {
                            url: "/userExerciseNutrition",
                            templateUrl: "/app/userexercisenutrition/userexercisenutrition.html",
                            title: "UserExerciseNutrition"
                        })
                    .state("register",
                        {
                            url: "/register/postregister",
                            templateUrl: "/app/nepfituser/postRegister.html",
                            title: "Register"
                        })


                  .state("articles",
                      {
                          url: "/articles",
                          templateUrl: "/app/User/articles.html",
                          title: "Articles"
                      })

                    .state("bcaa",
                      {
                          url: "/bcaa",
                          templateUrl: "/app/User/bcaa.html",
                          title: "Bcaa"
                      })
                  .state("caesin",
                      {
                          url: "/caesin",
                          templateUrl: "/app/User/caesin.html",
                          title: "Caesin"
                      })
                  .state("creatine",
                      {
                          url: "/creatine",
                          templateUrl: "/app/User/creatine.html",
                          title: "Creatine"
                      })
                  .state("exercise",
                      {
                          url: "/exercise",
                          templateUrl: "/app/User/exercise.html",
                          title: "Exercise"
                      })
                  .state("food",
                      {
                          url: "/food",
                          templateUrl: "/app/User/food.html",
                          title: "Food"
                      })
                  .state("plant",
                      {
                          url: "/plant",
                          templateUrl: "/app/User/plant.html",
                          title: "Plant"
                      })
                  .state("pre",
                      {
                          url: "/pre",
                          templateUrl: "/app/User/pre.html",
                          title: "Pre"
                      })
                  .state("proteinbar",
                      {
                          url: "/proteinbar",
                          templateUrl: "/app/User/proteinbar.html",
                          title: "Proteinbar"
                      })
                  .state("supplements",
                      {
                          url: "/supplements",
                          templateUrl: "/app/User/supplements.html",
                          title: "Supplements"
                      })
                  .state("weightgainer",
                      {
                          url: "/weightgainer",
                          templateUrl: "/app/User/weightgainer.html",
                          title: "Weightgainer"
                      })
                  .state("wheyisolate",
                      {
                          url: "/wheyisolate",
                          templateUrl: "/app/User/wheyisolate.html",
                          title: "Wheyisolate"
                      })
                  .state("wheyprotein",
                      {
                          url: "/wheyprotein",
                          templateUrl: "/app/User/wheyprotein.html",
                          title: "Wheyprotein"
                      });



                $urlRouterProvider.otherwise(function ($injector, $location) {
                    var $state = $injector.get('$state');
                    console.log($location.$location.$$url);
                    $state.go('home', {});
                });
            }
        ]);

})(angular, app);

