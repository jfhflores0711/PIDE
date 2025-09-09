var url_ = "";
var objHomeVM = null;
var self;


var appHome = {
    init: function () {
        appHome.inicializarHomeVM();
      },
    inicializarHomeVM: function () {
        objHomeVM = new appHome.HomeVM();
        ko.applyBindings(objHomeVM);

        appHome.listarHomeReport();
        
    },
    listarHomeReport: function () {
        var e_load = addLoading();

        var url = url_ + "/Reportes/homereport";

        $.when(openb.jsonPostCallback(url)
            .then(function (resultado) {

                objHomeVM.topten(resultado.topten);

                console.log(resultado.indicadores);
                if (resultado.indicadores != null) {
                    objHomeVM.indicador1(resultado.indicadores.Indicador1);
                    objHomeVM.indicador2(resultado.indicadores.Indicador2);
                    objHomeVM.indicador3(resultado.indicadores.Indicador3);
                    objHomeVM.indicador4(resultado.indicadores.Indicador4);
                }
                
                removeLoading(e_load);
            }, function () {
                    console.log("Ocurrió un error al consultar las notificaciones");
                    removeLoading(e_load);
            }));
    },
    HomeVM: function () {
        self = this;
        //data
        self.topten = ko.observableArray([]);
        self.indicador1 = ko.observable(0);
        self.indicador2 = ko.observable(0);
        self.indicador3 = ko.observable(0);
        self.indicador4 = ko.observable(0);
        

        //comportamiento
        self.init = function () {           
            
        };
    },
};

