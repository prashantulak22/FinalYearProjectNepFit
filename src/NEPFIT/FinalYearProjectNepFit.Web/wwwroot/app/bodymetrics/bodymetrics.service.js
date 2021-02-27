
(function (angular, app) {
    angular
        .module('nepFitApp')
        .factory('bodyMetricsService', bodyMetricsService);

    bodyMetricsService.$inject = ['$http'];

    function bodyMetricsService($http) {
        var service = {
            getAllBodyMetricsById: getAllBodyMetricsById,
            updateBodyMetrics: updateBodyMetrics,
            createBodyMetrics: createBodyMetrics,
        };

        return service;

        function getAllBodyMetricsById(item) {
            return $http({
                method: 'POST',
                url:  'api/bodymetrics/getbyid',
                data: item
            }).then(
                function (data, status, headers, config) {
                    return data;
                });
        }

        function createBodyMetrics(item) {
            return $http({
                method: 'POST',
                url: 'api/bodymetrics/add',
                data: item
            }).then(
                function (data, status, headers, config) {
                    return data;
                });
        }

        function updateBodyMetrics(item) {
            return $http({
                method: 'POST',
                url: 'api/bodymetrics/update',
                data: item
            }).then(
                function (data, status, headers, config) {
                    return data;
                });
        }
    }
})(angular, app);
