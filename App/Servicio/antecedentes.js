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
        self.param3 = ko.observable("");
        self.param4 = ko.observable("");
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

        self.antecedente_judicial = ko.observable('');
        self.antecedente_penal = ko.observable('');
        self.antecedente_policial = ko.observable('');

        //acciones
        self.consultar_datos = function () {

            var l1 = objEcVM.form_busqueda().param1();
            var l2 = objEcVM.form_busqueda().param2();
            var l3 = objEcVM.form_busqueda().param3();
            var l4 = objEcVM.form_busqueda().param4();

            if (l1.length == 8) {
                if (l2 != '' || l3 != '' || l4 != '') {

                    objEcVM.valor_buscado(objEcVM.form_busqueda().param1() + ' - ' + objEcVM.form_busqueda().param4() + ' ' + objEcVM.form_busqueda().param2() + ' ' + objEcVM.form_busqueda().param3());

                    appOpenB.fn_Listar_Objetos_Aj();
                    appOpenB.fn_Listar_Objetos_Ap();
                    appOpenB.fn_Listar_Objetos_Apol();
                }
                else {
                    alertWarning("Mensaje", "Escriba datos completos e intente nuevamente.", "fas fa-exclamation-circle");
                }
            }
            else {
                alertWarning("Mensaje", "Escriba N° de DNI con 8 dígitos e intente nuevamente.", "fas fa-exclamation-circle");
            }
        }

        self.cargar_data = function (data, viewmodel) {
            ko.mapping.fromJS(data, viewmodel);
        };
    },
    fn_Listar_Objetos_Aj: function () {
        var sp_url_ctrl_action = url_ + '/Antecedentes/ConsultaServicioAj';

        var sp_data = ko.toJSON(objEcVM.form_busqueda);
        var cargar = addLoading();

        $.when(openb.jsonPost(sp_url_ctrl_action, sp_data))
            .then(function (r) {
                if (r.flag == true) {

                    objEcVM.flag_resultado(r.flag);

                    console.log(r);

                    if (r.data.Codigo != -4) {

                        objEcVM.antecedente_judicial(r.data.r);
                    }
                    else {
                        objEcVM.antecedente_judicial('');
                        alertWarning("Mensaje", r.data.Mensaje, "fas fa-exclamation-circle");
                        objEcVM.flag_resultado(false);
                        removeLoading(cargar);
                    }

                    removeLoading(cargar);
                } else {
                    alertWarning("Mensaje", r.mensaje, "fas fa-exclamation-circle");
                    removeLoading(cargar);
                }

            }, function () { // error
                objEcVM.antecedente_judicial('Hubo un error al consultar el servicio, contáctese con el administrador.');
                objEcVM.flag_resultado(false);
                removeLoading(cargar);
            });

    }
    ,
    fn_Listar_Objetos_Ap: function () {
        var sp_url_ctrl_action = url_ + '/Antecedentes/ConsultaServicioAp';

        var sp_data = ko.toJSON(objEcVM.form_busqueda);
        var cargar = addLoading();

        $.when(openb.jsonPost(sp_url_ctrl_action, sp_data))
            .then(function (r) {
                if (r.flag == true) {

                    objEcVM.flag_resultado(r.flag);

                    console.log(r);

                    if (r.data.Codigo != -4) {

                        objEcVM.antecedente_penal(r.data.r.xMensajeRespuesta);
                    }
                    else {
                        objEcVM.antecedente_penal('');
                        alertWarning("Mensaje", r.data.Mensaje, "fas fa-exclamation-circle");
                        objEcVM.flag_resultado(false);
                        removeLoading(cargar);
                    }

                    removeLoading(cargar);
                } else {
                    alertWarning("Mensaje", r.mensaje, "fas fa-exclamation-circle");
                    removeLoading(cargar);
                }

            }, function () { // error
                objEcVM.antecedente_penal('Hubo un error al consultar el servicio, contáctese con el administrador.');
                objEcVM.flag_resultado(false);
                removeLoading(cargar);
            });

    }
    ,
    fn_Listar_Objetos_Apol: function () {
        var sp_url_ctrl_action = url_ + '/Antecedentes/ConsultaServicioApol';

        var sp_data = ko.toJSON(objEcVM.form_busqueda);
        var cargar = addLoading();

        $.when(openb.jsonPost(sp_url_ctrl_action, sp_data))
            .then(function (r) {
                if (r.flag == true) {

                    objEcVM.flag_resultado(r.flag);

                    console.log(r);

                    if (r.data.Codigo != -4) {

                        objEcVM.antecedente_policial(r.data.r[0].descripcionMensaje);
                    }
                    else {
                        objEcVM.antecedente_policial('');
                        alertWarning("Mensaje", r.data.Mensaje, "fas fa-exclamation-circle");
                        objEcVM.flag_resultado(false);
                        removeLoading(cargar);
                    }

                    removeLoading(cargar);
                } else {
                    alertWarning("Mensaje", r.mensaje, "fas fa-exclamation-circle");
                    removeLoading(cargar);
                }

            }, function () { // error
                objEcVM.antecedente_policial('Hubo un error al consultar el servicio, contáctese con el administrador.');
                objEcVM.flag_resultado(false);
                removeLoading(cargar);
            });

    }
};

