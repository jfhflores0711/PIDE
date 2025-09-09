var url_ = "";
var objEcVM = null;
var self;


var appOpenB = {
    init: function () {
        appOpenB.inicializarVM();
    },
    inicializarVM: function () {
        objEcVM = new appOpenB.ListaVM();
        ko.applyBindings(objEcVM);
    },
    model_busqueda: function () {
        var self = this;
        self.param1 = ko.observable(0);
        self.param2 = ko.observable(0);
        self.param3 = ko.observable(0);
        self.param4 = ko.observable(0);
    },
    ListaVM: function () {
        self = this;

        //formulario paginacion-busqueda
        self.form_busqueda = ko.observable(new appOpenB.model_busqueda());

        //data

        //acciones
        self.descargar_datos = function () {
            appOpenB.fn_Descargar_Objeto();
        }


    },
    fn_Descargar_Objeto: function () {
        var sp_url_ctrl_action = url_ + '/Reportes/reportelogmensual';

        var sp_data = ko.toJSON(objEcVM.form_busqueda);
  
        var cargar = addLoading();
        window.open(sp_url_ctrl_action + "?anio=" + objEcVM.form_busqueda().param1() + "&mes=" + objEcVM.form_busqueda().param2());

        setTimeout(
            function () {
                removeLoading(cargar);
            }, 5000);
    }
};

