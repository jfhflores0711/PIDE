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

        self.param1 = ko.observable("");
        self.param2 = ko.observable("");
        self.param2 = ko.observable("");
        self.param3 = ko.observable("");
    },
    ListaVM: function () {
        self = this;

        //formulario paginacion-busqueda
        self.form_busqueda = ko.observable(new appOpenB.model_busqueda());

        //data
        self.valor_buscado = ko.observable();
        self.flag_resultado = ko.observable(false);
        self.consulta_resulado = ko.observable(null);
        self.consulta_resulado_ = ko.observableArray([]);
        //acciones
        self.consultar_datos = function () {
            var l = objEcVM.form_busqueda().param1();
            if (l.length == 8) {
                appOpenB.fn_Listar_Objetos();
            }
            else {
                alertWarning("Mensaje", "Escriba N° de DNI correcto e intente nuevamente.", "fas fa-exclamation-circle");
            }

        }


        self.cargar_data = function (data, viewmodel) {
            ko.mapping.fromJS(data, viewmodel);
        };
    },
    fn_Listar_Objetos: function () {
        var sp_url_ctrl_action = url_ + '/Sunedu/ConsultaServicioGT';

        var sp_data = ko.toJSON(objEcVM.form_busqueda);
        objEcVM.consulta_resulado_([]);
        objEcVM.consulta_resulado(null)
        var cargar = addLoading();

        $.when(openb.jsonPost(sp_url_ctrl_action, sp_data))
            .then(function (r) {
                
                if (r.flag == true) {
                    objEcVM.valor_buscado(objEcVM.form_busqueda().param1());
                    objEcVM.form_busqueda().param1('');

                    objEcVM.flag_resultado(r.flag);

                    objEcVM.consulta_resulado(r.data.r);

                    
                    if (r.data.r.length == 0) {
                        objEcVM.flag_resultado(false);
                        alertWarning("Mensaje", r.data.respuesta.dGenerica, "fas fa-exclamation-circle");
                    }

                    removeLoading(cargar);
                } else {
                    alertWarning("Mensaje", r.mensaje, "fas fa-exclamation-circle");
                    removeLoading(cargar);
                }

            }, function () { // error
                console.log("Hubo un error al consultar los datos.");
            });

    }
};

