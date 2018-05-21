(function () {
    var app = angular.module("Eva");

    var AddBookController = function ($scope, BookService, $location, GenreService) {
        $scope.title = "Add Book To Inventory";
        $scope.genres = GenreService.GetGenres();
        $scope.book = {};
        $scope.AddBook = function (book, addBookForm) {
            if(addBookForm.$valid)
            {
                BookService.AddBook(book)
                    .$promise
                    .then(function (response) { console.log('success', response) })
                    .catch(function (response) { console.log('failure', response) });
            }
        };
        $scope.cancel = function () {
            $location.replace();
            $location.url('/books');
        };
    };

    app.controller("AddBookController", AddBookController);
})();