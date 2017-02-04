var mainModule = angular.module("mainModule", ['ngRoute']);



mainModule.config(function ($routeProvider) {
    $routeProvider

        .when('/', {
            templateUrl: '/home.html',
            controller: 'homePretragaController'
        })

        .when('/prijaviNestanak', {
            templateUrl: '/prijaviNestanak.html',
            controller: 'prijaviNestanakController'
        })

        .when('/prijaviDelinkventa', {
            templateUrl: '/prijaviDelinkventa.html',
            controller: 'prijaviDelinkventaController'
        })
        .when('/pregledNestalih', {
            templateUrl: '/pregledNestalih.html',
            controller: 'homePretragaController'
        })
        .when('/pregledPrestupnika', {
            templateUrl: '/pregledPrestupnika.html',
            controller: 'homePretragaController'
        });

});