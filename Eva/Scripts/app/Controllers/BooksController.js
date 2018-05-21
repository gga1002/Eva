
(function () {
    var app = angular.module("Eva");

    var BooksController = function ($scope, BookService) {
        $scope.title = "Books List";
        $scope.books = BookService.GetBooks();
    };

    app.controller("BooksController", BooksController);
})();