(function () {

    var GenreService = function ($resource) {

        var resource = $resource('api/genres/');

        var GetGenres = function () {
            return resource.query();
        };

        return {
            GetGenres: GetGenres
        }
    };

    var module = angular.module("Eva");
    module.factory("GenreService", GenreService);

})();