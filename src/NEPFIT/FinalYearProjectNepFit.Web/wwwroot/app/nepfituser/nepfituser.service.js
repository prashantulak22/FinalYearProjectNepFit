
(function (angular, app) {
    angular
        .module('nepFitApp')
        .factory('nepFitUserService', nepFitUserService);

    nepFitUserService.$inject = ['$http'];

    function nepFitUserService($http) {
        var service = {
            getAllNepFitUser: getAllNepFitUser,
            getAllNepFitUserById: getAllNepFitUserById,
            updateNepFitUser: updateNepFitUser,
            createNepFitUser: createNepFitUser,
            deleteNepFitUser: deleteNepFitUser,
            getLoggedInUser: getLoggedInUser,
        };

        return service;

        function getLoggedInUser() {

            return $http({
                method: 'GET',
                url: 'api/nepfituser',
                headers: { 'Authorization': 'Bearer ' + app.jwtToken },
            }).then(
                function (data, status, headers, config) {
                    return data;
                });

        }

        function getAllNepFitUser() {

            return $http({
                method: 'GET',
                url: 'api/nepfituser/all',
                headers: { 'Authorization': 'Bearer ' + app.jwtToken },
            }).then(
                function (data, status, headers, config) {
                    return data;
                });

        }

        function getAllNepFitUserById(item) {

            return $http({
                method: 'POST',
                url: 'api/nepfituser/getbyid',
                headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                data: item
            }).then(
                function (data, status, headers, config) {
                    return data;
                });

        }

        function createNepFitUser(item) {

            return $http({
                method: 'POST',
                url: 'api/nepfituser/add',
                headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                data: item
            }).then(
                function (data, status, headers, config) {
                    return data;
                });

        }

        function updateNepFitUser(item) {

            return $http({
                method: 'POST',
                url: 'api/nepfituser/update',
                headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                data: item
            }).then(
                function (data, status, headers, config) {
                    return data;
                });

        }

        function deleteNepFitUser(item) {
            return $http({
                method: 'POST',
                url: '/api/nepfituser/delete',
                headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                data: item
            }).then(
                function (data, status, headers, config) {
                    return data;
                });
        }


    }
})(angular, app);
