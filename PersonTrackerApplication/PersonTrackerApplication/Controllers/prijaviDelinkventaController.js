mainModule.controller('prijaviDelinkventaController', ['$scope','$http','$log', function ($scope, $http, $log, ngAuthSettings){
    var serviceBase = "http://localhost:4094/";

    $scope.glava = null;
    $scope.celjust = null;
    $scope.oci = null;
    $scope.nos = null;
    $scope.obrve = null;
    $scope.usta = null;
    $scope.kosa = null;
    $scope.brada = null;

    var d_canvas = document.getElementById('canvas');
    var context = d_canvas.getContext('2d');

    function crtajSkicuGlava (glava) {
        for (var i = 1; i < 10; i++) {
            if (glava == i.toString()) {
                var img = new Image();
                img.onload = function () {
                    context.drawImage(img, 0, 0, 270, 110);

                }
                img.src = 'Skica/Glava/' + i.toString() + '.png';
                break;        
            }
        }
    }

    function crtajSkicuBrada (brada) {
        for (var i = 1; i < 10; i++) {
            if (brada == i.toString()) {
                var img = new Image();
                img.onload = function () {
                    context.drawImage(img, 37, 80, 210, 60);

                }
                img.src = 'Skica/Brada/' + i.toString() + '.png';
                break;
            }
        }
    }

    function crtajSkicuCeljust (celjust) {
        for (var i = 1; i < 10; i++) {
            if (celjust == i.toString()) {
                var img = new Image();
                img.onload = function () {
                    context.drawImage(img, 0, 0, 270, 170);

                }
                img.src = 'Skica/Celjust/' + i.toString() + '.png';
                break;
            }
        }
    }

    function crtajSkicuKosa (kosa) {
        for (var i = 1; i < 10; i++) {
            if (kosa == i.toString()) {
                var img = new Image();
                img.onload = function () {
                    context.drawImage(img, 10, 0, 250, 70);
                }
                img.src = 'Skica/Kosa/' + i.toString() + '.png';
                break;
            }
        }
    }

    function crtajSkicuNos (nos) {
        for (var i = 1; i < 10; i++) {
            if (nos == i.toString()) {
                var img = new Image();
                img.onload = function () {
                    context.drawImage(img, 75, 20, 130, 110);

                }
                img.src = 'Skica/Nos/' + i.toString() + '.png';
                break;
            }
        }
    }

    function crtajSkicuObrve (obrve) {
        for (var i = 1; i < 10; i++) {
            if (obrve == i.toString()) {
                var img = new Image();
                img.onload = function () {
                    context.drawImage(img, 30, 30, 220, 50);
                }
                img.src = 'Skica/Obrve/' + i.toString() + '.png';
                break;
            }
        }
    }

    function crtajSkicuOci (oci) {
        for (var i = 1; i < 10; i++) {
            if (oci == i.toString()) {
                var img = new Image();
                img.onload = function () {
                    context.drawImage(img, 0, 0, 280, 120);
                }
                img.src = 'Skica/Oci/' + i.toString() + '.png';
                break;
            }
        }
    }

     function crtajSkicuUsta (usta) {
        for (var i = 1; i < 10; i++) {
            if (usta == i.toString()) {
                var img = new Image();
                img.onload = function () {
                    context.drawImage(img, 40, 35, 200, 120);
                }
                img.src = 'Skica/Usta/' + i.toString() + '.png';
                break;
            }
        }
    }

     $scope.crtajSkicu = function (glava, celjust, kosa, obrve, oci, nos, usta, brada) {
         var podloga = new Image();
         podloga.onload = function () {
             context.drawImage(podloga, 0, 0, 500, 500);
         }
         podloga.src = 'podlogaSkiceBijela.jpg';

         if (glava != null) crtajSkicuGlava(glava);
         if (celjust != null) crtajSkicuCeljust(celjust);
         if (kosa != null) crtajSkicuKosa(kosa);
         if (obrve != null) crtajSkicuObrve(obrve);
         if (oci != null) crtajSkicuOci(oci);
         if (nos != null) crtajSkicuNos(nos);
         if (usta != null) crtajSkicuUsta(usta);
         if (brada != null) crtajSkicuBrada(brada);
     }

     $scope.validacija = function (glava, celjust, oci, obrve, nos, usta, mjesto, datum, Ime, Prezime, Email) {
         var poruka ="";
         if (glava == null || celjust == null || oci == null || nos == null || usta == null || obrve == null)
             poruka = poruka + "<br>\n* Završite crtanje skice prestupnika.\n  Svaka skica minimalno treba da sadrži glavu, čeljust, oči, obrve, nos i usta.";
         if (mjesto == null)
             poruka = poruka + "<br>\n* Unesite mjesto prestupništva.";
         if (datum == null)
             poruka = poruka + "<br>\n* Unesite datum prestupništva.";
         if (Ime == null || Prezime==null || Email == null)
             poruka = poruka + "<br>\n* Vaši podaci nisu dostupni ostalim korisnicima, ali su obavezan dio prijave."
         if (poruka != "")
             return [false, poruka];
         return [true, poruka];
     }

     $scope.dodajPrestupnika = function (glava, celjust, oci, obrve, nos, usta, mjesto, datum, Ime, Prezime, Email) {
         var src = d_canvas.toDataURL("image/jpeg", 0.5);
         console.log(src);
         var validno = $scope.validacija(glava, celjust, oci, obrve, nos, usta, mjesto, datum, Ime, Prezime, Email);
         if (validno[0]) {

             var Prestupnik = {
                 DatumPrestupa: $scope.datum,
                 MjestoPrestupa: $scope.mjesto,
                 Opis: $scope.opis,
                 Foto: src,
                 Korisnik: {
                     Ime: $scope.Ime,
                     Prezime: $scope.Prezime,
                     Email: $scope.Email
                 }
             }
             $log.info(Prestupnik);
             $http.post(serviceBase + 'api/Prestupnik/Register', Prestupnik)
             .success(function (data) {
                 $scope.greeting = data;
             })
             document.getElementById('greske').innerHTML = "Uspješno ste prijavili prestupnika.";
         }
         else {
             document.getElementById('greske').innerHTML = validno[1];
         }
     }

}]);
