mainModule.controller('prijaviNestanakController', ['$scope', '$q', '$http', '$log', function ($scope, $q, $http, $log, ngAuthSettings) {

  
    var serviceBase = "http://localhost:4094/";
    $scope.imeNestali = null;
    $scope.prezimeNestali = null;
    $scope.godRodenjaNestali = null;
    $scope.mjestoNVidenjaNestali = null;
    $scope.datumVidjenjaNestali = null;
    $scope.slika = null;
    $scope.imeKorisnika = null;
    $scope.prezimeKorisnika = null;
    $scope.emailKorisnika = null;
    $scope.spolNestali = null;
    $scope.opisNestali = null;

    $scope.validacija = function (imeNestali, prezimeNestali, godRodenjaNestali, mjestoVidenjaNestali, datumVidjenjaNestali, slikaNestali, imeKorisnika, prezimeKorisnika, emailKorisnika) {
        console.log(imeNestali + prezimeNestali + godRodenjaNestali + mjestoVidenjaNestali + datumVidjenjaNestali + slikaNestali + imeKorisnika + prezimeKorisnika + emailKorisnika);
        var poruka = "";
        if (imeNestali == null || prezimeNestali == null) 
            poruka = poruka + "<br>\n* Unesite ime i prezime nestale osobe.";
        var datum = new Date();
        if (godRodenjaNestali == null)
            poruka = poruka + "<br>\n* Unesite godinu rođenja nestalog.";
        else if (godRodenjaNestali < 1910 || godRodenjaNestali > datum.getFullYear())
            poruka = poruka + "<br>\n* Unesite ispravnu godinu rođenja nestalog.";
        if (mjestoVidenjaNestali == null || datumVidjenjaNestali == null || datum<datumVidjenjaNestali || datumVidjenjaNestali<new Date(1990,1))
            poruka = poruka + "<br>\n* Unesite ispravan datum i mjesto gdje je nestala osoba zadnji put viđena.";
        if (imeKorisnika == null || prezimeKorisnika == null || emailKorisnika == null)
            poruka = poruka + "<br>\n* Vaši podaci nisu dostupni ostalim korisnicima, ali su obavezan dio prijave.";
        if (poruka != "")
            return [false, poruka];
        return [true, poruka];
    }
    
    $scope.dodajNestalog = function (imeNestali, prezimeNestali, godRodenjaNestali, mjestoVidenjaNestali, datumVidjenjaNestali, spolNestali, opisNestali, slikaNestali, imeKorisnika, prezimeKorisnika, emailKorisnika) {

        var validno = $scope.validacija(imeNestali, prezimeNestali, godRodenjaNestali, mjestoVidenjaNestali, datumVidjenjaNestali, slikaNestali, imeKorisnika, prezimeKorisnika, emailKorisnika);
        if (validno[0]) {
            var filesSelected = document.getElementById("slika").files;
            if (filesSelected.length > 0) {
                var fileToLoad = filesSelected[0];

                var fileReader = new FileReader();

                fileReader.onload = function (fileLoadedEvent) {
                    var srcData = fileLoadedEvent.target.result; // <--- data: base64

                    var nestali = {
                        Ime: $scope.imeNestali,
                        Prezime: $scope.prezimeNestali,
                        GodinaRodenja: $scope.godRodenjaNestali,
                        Fotografija: srcData,
                        DatumNestanka: $scope.datumVidjenjaNestali,
                        MjestoNestanka: $scope.mjestoVidenjaNestali,
                        Spol: $scope.spolNestali,
                        Opis:$scope.opisNestali,
                        Korisnik: {
                            Ime: $scope.imeKorisnika,
                            Prezime: $scope.prezimeKorisnika,
                            Email: $scope.emailKorisnika,
                        }
                    }
                    $log.info(nestali)
                    $http.post(serviceBase + 'api/Nestali/Register', nestali)
                    .success(function (data) {
                        $scope.greeting = data;
                    })
                }
                fileReader.readAsDataURL(fileToLoad);
            }
            document.getElementById('greske').innerHTML = "Uspješno ste prijavili nestanak osobe.";
        }
        else
        {
            document.getElementById('greske').innerHTML = validno[1];
            return false;
        }
    }

    
}]);