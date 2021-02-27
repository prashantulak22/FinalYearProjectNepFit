
(function (angular) {
    angular
        .module('nepFitApp')
        .factory('progressTrackerService', progressTrackerService);

    progressTrackerService.$inject = ['$http'];

    function progressTrackerService($http) {
        var service = {
            getUserProgress: getUserProgress
        };

        return service;

        function getUserProgress() {
            return $http({
                method: 'GET',
                url: 'api/user/progress'
            }).then(
                function (data, status, headers, config) {
                    return data;
                });
        }
    }
})(angular);
