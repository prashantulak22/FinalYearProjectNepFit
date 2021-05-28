(function (angular, app) {
    'use strict';
    angular
        .module('nepFitApp', ['kendo.directives', 'ui.bootstrap', 'ui.router', 'blockUI', 'commonModule'])
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
                            title: "ExerciseType",
                            resolve: { checkAccess: checkAccess }
                        })

                    .state("admin",
                        {
                            url: "/adminpanel",
                            templateUrl: "/app/admin/admin.html",
                            title: "Admin Panel",
                            resolve: { checkAccess: checkAccess }
                            
                        }) 
                    .state("profile",
                        {
                            url: "/profile",
                            templateUrl: "/app/profile/profile.html",
                            title: "Profile",

                            

                        }) 

                    .state("exerciseRoutine",
                        {
                            url: "/exerciseRoutine",
                            templateUrl: "/app/exerciseroutine/exerciseRoutine.html",
                            title: "ExerciseType",
                            resolve: { checkAccess: checkAccess }

                        })
                    .state("exercisePackage",
                        {
                            url: "/exercisePackage",
                            templateUrl: "/app/exercisepackage/exercisePackage.html",
                            title: "ExercisePackage",
                            resolve: { checkAccess: checkAccess }
                        })
                    .state("nutritionType",
                        {
                            url: "/nutritionType",
                            templateUrl: "/app/nutritiontype/nutritionType.html",
                            title: "NutritionType",
                            resolve: { checkAccess: checkAccess }
                        })
                    .state("nutritionPackage",
                        {
                            url: "/nutritionPackage",
                            templateUrl: "/app/nutritionpackage/nutritionPackage.html",
                            title: "NutritionPackage",
                            resolve: { checkAccess: checkAccess }
                        })
                    .state("nutritionRoutine",
                        {
                            url: "/nutritionRoutine",
                            templateUrl: "/app/nutritionroutine/nutritionRoutine.html",
                            title: "NutritionRoutine",
                            resolve: { checkAccess: checkAccess }
                        })
                    .state("nutritionPackageRoutine",
                        {
                            url: "/nutritionPackageRoutine",
                            templateUrl: "/app/nutritionpackageroutine/nutritionPackageRoutine.html",
                            title: "NutritionPackageRoutine",
                            resolve: { checkAccess: checkAccess }
                        })
                    .state("exercisePackageRoutine",
                        {
                            url: "/exercisePackageRoutine",
                            templateUrl: "/app/exercisepackageroutine/exercisePackageRoutine.html",
                            title: "ExercisePackageRoutine",
                            resolve: { checkAccess: checkAccess }
                        })

                    .state("exerciseNutritionPackage",
                        {
                            url: "/exerciseNutritionPackage",
                            templateUrl: "/app/exercisenutritionpackage/exercisenutritionpackage.html",
                            title: "ExerciseNutritionPackage",
                            resolve: { checkAccess: checkAccess }
                        })

                    .state("nepFitUser",
                        {
                            url: "/nepFitUser",
                            templateUrl: "/app/nepfituser/nepfituser.html",
                            title: "NepFitUser"
                        })


                    .state("register",
                        {
                            url: "/register/postregister",
                            templateUrl: "/app/nepfituser/postRegister.html",
                            title: "Register"
                        })

                    .state("userexerciseroutine",
                        {
                            url: "/user/exercise/routine",
                            templateUrl: "/app/exerciseroutine/userexerciseroutine.html",
                            title: "Exercise Routine"

                        })


                    .state("usernutritionroutine",
                        {
                            url: "/user/nutrition/routine",
                            templateUrl: "/app/nutritionroutine/usernutritionroutine.html",
                            title: "Nutrition Routine"
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

                    .state("contact",
                        {
                            url: "/contact",
                            templateUrl: "/app/User/contact.html",
                            title: "Contact"
                        })

                    .state("wheyprotein",
                        {
                            url: "/wheyprotein",
                            templateUrl: "/app/User/wheyprotein.html",
                            title: "Wheyprotein"
                        });

                function checkAccess($state) {
                    if (app.user.isAdmin) {
                        return true;
                    }
                    $state.go('home');
                }


                $urlRouterProvider.otherwise(function ($injector, $location) {
                    var $state = $injector.get('$state');
                    console.log($location.$location.$$url);
                    $state.go('home', {});
                });
            }
        ]);

})(angular, app);

(function (angular) {
    'use strict';
    angular
        .module('commonModule', [])
        .config(httpConfig);


    httpConfig.$inject = ['$httpProvider'];
    var notification = $("#notification").kendoNotification({
        position: {
            pinned: false,
            bottom: 30,
            right: 30,
            allowHideAfter: 1000
        },
        autoHideAfter: 0,
        stacking: "down"
    }).data("kendoNotification");

    function httpConfig($httpProvider) {
        $httpProvider.interceptors.push(['$q', function ($q) {
            return {
                'responseError': function (rejection) {
                    // do something on error
                    var rejectionData = '';
                    if (rejection.data !== null) {
                        if (typeof rejection.data === "object") {
                            rejectionData = JSON.stringify(rejection.data);
                        }
                        else
                            rejectionData = rejection.data;
                    }
                    if (rejection.status === 400) {
                        console.log("Bad Request (400) " + moment().format()
                            , "error");
                    }
                    else if (rejection.status === 401) {
                        alert("User not authorized or authenticated (401) " + moment().format()
                            , "error");
                    }
                    else if (rejection.status === 404) {
                        alert("Oops! We can't seem to find resource you are looking for (404) " + moment().format()
                            , "error");
                    }
                    else if (rejection.status === 502) {
                        alert("502 Bad Gateway server error, while acting as a gateway or proxy, received an invalid response from the upstream server. " + moment().format()
                            , "error");
                    }
                    else if (rejection.data !== null && (rejection.data.Message || rejection.data.message)) {
                        alert((rejection.data.Message || rejection.data.message) + moment().format(), "error");
                    }
                    else {
                        //alert("Unexpected Error"
                        //    , "error " + moment().format());
                        console.log("Unexpected Error " + rejection.data + " " + moment().format());
                        rejection.data = "";
                    }
                    return $q.reject(rejection);
                }
            };
        }]);
    }



})(angular);

