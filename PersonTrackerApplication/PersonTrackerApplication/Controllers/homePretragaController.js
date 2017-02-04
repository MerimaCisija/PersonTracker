mainModule.directive('template-comment', function () {
    return {
        restrict: 'M',
        link: function (scope, elem, attr) {
            alert(attr.myDirectiveName);
        }
    };
});

mainModule.controller('homePretragaController', ['$scope', '$http', '$log', function ($scope, $http, $log, ngAuthSettings) {

    $scope.parametarPretrage = null;
    var serviceBase = "http://localhost:4094/";
    $scope.listaNestalih = [];


    $scope.btn_add = function (index, txtcomment, imeKorisnika, prezimeKorisnika, emailKorisnika, idNestali, idPrestupnik) {
        console.log(index)
        console.log(txtcomment)

        if (txtcomment != '') {
            $http.post(serviceBase + 'api/Komentar/RegisterCom?komentar=' + txtcomment + '&ime=' + imeKorisnika + '&prezime=' + prezimeKorisnika + '&email=' + emailKorisnika + '&idNestali=' + idNestali + '&idPrestupnik='+idPrestupnik)
                .success(function (data) {
                    $scope.greeting = data;
                    $scope.listaNestalih[index].listaKomentara.push(txtcomment);

                })
        }

    }


    $scope.pretragaNestali = function () {
        $http.get(serviceBase + 'api/Pretraga/PretraziNestale?parametarPretrage=' + $scope.parametarPretrage)
        .success(function (data) {
            $scope.listaNestalih = data;
        })
    }

    $scope.izlistajNestale = function () {
        $http.get(serviceBase + 'api/Pretraga/IzlistajNestale')
        .success(function (data) {
            $scope.listaNestalih = data;
        })
    }

    $scope.pretragaPrestupnici = function () {
        $http.get(serviceBase + 'api/Pretraga/PretraziPrestupnike?parametarPretrage=' + $scope.parametarPretrage)
        .success(function (data) {
            $scope.lista = data;
        })
    }

    $scope.izlistajPrestupnike = function () {
        $http.get(serviceBase + 'api/Pretraga/IzlistajPrestupnike')
        .success(function (data) {
            $scope.lista = data;
        })
    }
}]);
