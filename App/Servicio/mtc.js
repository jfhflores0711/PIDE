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

        self.param1 = ko.observable(2);
        self.param2 = ko.observable("");
        self.param3 = ko.observable("");
        self.param4 = ko.observable("");

        self.cambio_de_tipo = ko.computed(function () {

            self.param2("");
            self.param3("");
            self.param4("");

            switch (self.param1()) {
                case "1":
                    $("#inputdocuemnto").attr('maxlength', '11');
                    $("#inputdocuemnto").attr('onkeypress', 'if(isNaN(this.value + String.fromCharCode(event.keyCode))) return false');
                    $("#inputdocuemnto").attr('placeholder', 'N° de RUC');
                    break;
                case "2":
                    $("#inputdocuemnto").attr('maxlength', '8');
                    $("#inputdocuemnto").attr('onkeypress', 'if(isNaN(this.value + String.fromCharCode(event.keyCode))) return false');
                    $("#inputdocuemnto").attr('placeholder', 'N° de DNI');
                    break;
                default:
                    $("#inputdocuemnto").attr('maxlength', '20');
                    $("#inputdocuemnto").attr('onkeypress', '');
                    $("#inputdocuemnto").attr('placeholder', 'N° de documento');
                    break;
            }

        }, this);
    },
    model_busqueda2: function () {
        var self = this;

        self.param1 = ko.observable(0);
        self.param2 = ko.observable("");
        self.param3 = ko.observable("");
        self.param4 = ko.observable("");
    },
    ListaVM: function () {
        self = this;

        //formulario paginacion-busqueda
        self.form_busqueda = ko.observable(new appOpenB.model_busqueda());
        self.form_busqueda2 = ko.observable(new appOpenB.model_busqueda2());

        //data
        self.valor_tipo = ko.observable(1);

        self.valor_buscado = ko.observable();
        self.flag_resultado = ko.observable(false);
        self.consulta_resulado = ko.observable(null);
        self.consulta_resulado_ = ko.observableArray([]);
        //acciones
        self.consultar_datos = function () {
            var l = objEcVM.form_busqueda().param2();
            if (l.length > 0) {
                appOpenB.fn_Listar_Objetos();
            }
            else {
                alertWarning("Mensaje", "Escriba N° de documento e intente nuevamente.", "fas fa-exclamation-circle");
            }
        }

        self.consultar_datos_record = function () {
            var l = objEcVM.form_busqueda().param2();
            var l2 = objEcVM.form_busqueda().param3();
            console.log('cliccc');
            if (objEcVM.valor_tipo() == 1) {

                if (l.length > 0) {
                    appOpenB.fn_Listar_Objetos_Record();
                }
                else {
                    alertWarning("Mensaje", "Escriba número de documento e intente nuevamente.", "fas fa-exclamation-circle");
                }
            }
            if (objEcVM.valor_tipo() == 2) {

                if (l2.length > 0) {
                    appOpenB.fn_Listar_Objetos_Record();
                }
                else {
                    alertWarning("Mensaje", "Escriba número de record e intente nuevamente.", "fas fa-exclamation-circle");
                }
            }
        }

        self.consultar_datos_papeleta = function () {
            var l = objEcVM.form_busqueda().param2();
            if (l.length == 8) {
                appOpenB.fn_Listar_Objetos_Licencia();
                appOpenB.fn_Listar_Objetos_Papeleta();
            }
            else {
                alertWarning("Mensaje", "Escriba número de DNI correcto e intente nuevamente.", "fas fa-exclamation-circle");
            }
        }

        self.consultar_datos_licencia = function () {
            var l = objEcVM.form_busqueda().param2();
            if (l.length > 0) {
                appOpenB.fn_Listar_Objetos_Licencia();
            }
            else {
                alertWarning("Mensaje", "Escriba N° de documento e intente nuevamente.", "fas fa-exclamation-circle");
            }
        }

        self.consultar_datos_sanciones = function () {
            var l = objEcVM.form_busqueda().param2();
            if (l.length > 0) {

                appOpenB.fn_Listar_Objetos_Licencia();
                appOpenB.fn_Listar_Objetos_Sanciones();
            }
            else {
                alertWarning("Mensaje", "Escriba N° de documento e intente nuevamente.", "fas fa-exclamation-circle");
            }
        }


        self.cargar_data = function (data, viewmodel) {
            ko.mapping.fromJS(data, viewmodel);
        };
    },
    fn_Listar_Objetos: function () {
        var sp_url_ctrl_action = url_ + '/Mtc/ConsultaLicenciaConducir';

        var sp_data = ko.toJSON(objEcVM.form_busqueda);
        objEcVM.consulta_resulado_([]);
        objEcVM.consulta_resulado(null)
        var cargar = addLoading();

        $.when(openb.jsonPost(sp_url_ctrl_action, sp_data))
            .then(function (r) {

                if (r.flag == true) {
                    objEcVM.valor_buscado(objEcVM.form_busqueda().param2());
                    objEcVM.form_busqueda().param2('');

                    objEcVM.flag_resultado(r.flag);

                    const obje = JSON.parse(r.data.JsonString);

                    if (obje == null) {
                        removeLoading(cargar);
                        return;
                    }

                    if (obje.GetDatosLicenciaMTCResponse.GetDatosLicenciaMTCResult.CodigoRespuesta === "MSJ00") {
                        objEcVM.consulta_resulado(obje.GetDatosLicenciaMTCResponse.GetDatosLicenciaMTCResult.Licencia);
                    }
                    else {
                        objEcVM.flag_resultado(false);
                        window.alertMessage('La consulta del documento ' + objEcVM.valor_buscado() + ', no ha retornado resultados.', '', '', "fas fa-exclamation-circle");
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
    ,
    fn_Listar_Objetos_Record: function () {
        var sp_url_ctrl_action = url_ + '/Mtc/ConsultaRecordConductor';

        if (objEcVM.valor_tipo() == 1) {
            objEcVM.form_busqueda2().param1(objEcVM.form_busqueda().param1());
            objEcVM.form_busqueda2().param2(objEcVM.form_busqueda().param2());
            objEcVM.form_busqueda2().param3('');
            objEcVM.form_busqueda2().param4('');

            objEcVM.valor_buscado(objEcVM.form_busqueda().param2());
            objEcVM.form_busqueda().param2('');
            objEcVM.form_busqueda().param3('');
        }
        if (objEcVM.valor_tipo() == 2) {
            objEcVM.form_busqueda2().param1('');
            objEcVM.form_busqueda2().param2('');
            objEcVM.form_busqueda2().param3(objEcVM.form_busqueda().param3());
            objEcVM.form_busqueda2().param4('');

            objEcVM.valor_buscado(objEcVM.form_busqueda().param3());
            objEcVM.form_busqueda().param3('');
            objEcVM.form_busqueda().param2('');
        }

        var sp_data = ko.toJSON(objEcVM.form_busqueda2);

        objEcVM.consulta_resulado_([]);
        objEcVM.flag_resultado(false);
        objEcVM.consulta_resulado(null)
        var cargar = addLoading();

        $.when(openb.jsonPost(sp_url_ctrl_action, sp_data))
            .then(function (r) {

                if (r.flag == true) {

                    objEcVM.flag_resultado(r.flag);

                    const obje = JSON.parse(r.data.JsonString);

                    console.log(obje);

                    if (obje == null) {
                        removeLoading(cargar);
                        return;
                    }

                    if (obje.getRecordConductorResponse.getRecordConductorResult.strMensaje === 'MSJ00') {
                        objEcVM.consulta_resulado(obje.getRecordConductorResponse.getRecordConductorResult.btRecord);
                    }
                    else {
                        objEcVM.consulta_resulado(null);
                        objEcVM.flag_resultado(false);
                        window.alertMessage('La consulta no ha retornado resultados.', '', '', "fas fa-exclamation-circle");

                        //alertWarning("Mensaje", "No existe record del conductor, contacte al administrador.", "fas fa-exclamation-circle");
                        removeLoading(cargar);
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
    ,
    fn_Listar_Objetos_Papeleta: function () {
        var sp_url_ctrl_action = url_ + '/Mtc/ConsultaDatosPapeletas';

        var sp_data = ko.toJSON(objEcVM.form_busqueda);
        objEcVM.consulta_resulado_([]);
        var cargar = addLoading();

        $.when(openb.jsonPost(sp_url_ctrl_action, sp_data))
            .then(function (r) {

                if (r.flag == true) {
                    objEcVM.valor_buscado(objEcVM.form_busqueda().param2());

                    objEcVM.flag_resultado(r.flag);

                    const obje = JSON.parse(r.data.JsonString);

                    if (obje == null) {
                        removeLoading(cargar);
                        return;
                    }

                    console.log(obje);

                    if ('NewDataSet' in obje.GetDatosPapeletasMTCResponse.GetDatosPapeletasMTCResult.diffgram) {
                        objEcVM.consulta_resulado_(obje.GetDatosPapeletasMTCResponse.GetDatosPapeletasMTCResult.diffgram.NewDataSet.Table);
                        console.log(objEcVM.consulta_resulado_());
                    }
                    else {
                        objEcVM.consulta_resulado_([]);
                        window.alertMessage('La consulta no ha retornado resultados.', '', '', "fas fa-exclamation-circle");
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
    ,
    fn_Listar_Objetos_Licencia: function () {
        var sp_url_ctrl_action = url_ + '/Mtc/ConsultaUltimaLicencia';

        var sp_data = ko.toJSON(objEcVM.form_busqueda);
        objEcVM.consulta_resulado_([]);
        objEcVM.consulta_resulado(null)
        var cargar = addLoading();

        $.when(openb.jsonPost(sp_url_ctrl_action, sp_data))
            .then(function (r) {

                if (r.flag == true) {
                    objEcVM.valor_buscado(objEcVM.form_busqueda().param2());
                    //objEcVM.form_busqueda().param2('');

                    objEcVM.flag_resultado(r.flag);

                    const obje = JSON.parse(r.data.JsonString);

                    if (obje == null) {
                        removeLoading(cargar);
                        return;
                    }

                    console.log(obje);

                    if ('NewDataSet' in obje.GetDatosUltimaLicenciaMTCResponse.GetDatosUltimaLicenciaMTCResult.diffgram) {
                        objEcVM.consulta_resulado(obje.GetDatosUltimaLicenciaMTCResponse.GetDatosUltimaLicenciaMTCResult.diffgram.NewDataSet.Table);
                    }
                    else if ('DocumentElement' in obje.GetDatosUltimaLicenciaMTCResponse.GetDatosUltimaLicenciaMTCResult.diffgram) {
                        var rr = obje.GetDatosUltimaLicenciaMTCResponse.GetDatosUltimaLicenciaMTCResult.diffgram.DocumentElement.dt.dc;
                        rr = rr.replace("Ãº", "ú");
                        objEcVM.flag_resultado(false);
                        window.alertMessage(rr, '', '', "fas fa-exclamation-circle");
                    }
                    else {
                        objEcVM.flag_resultado(false);
                        window.alertMessage('La consulta no ha retornado resultados.', '', '', "fas fa-exclamation-circle");
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
    ,
    fn_Listar_Objetos_Sanciones: function () {
        var sp_url_ctrl_action = url_ + '/Mtc/ConsultaUltimasSanciones';

        var sp_data = ko.toJSON(objEcVM.form_busqueda);
        objEcVM.consulta_resulado_([]);
        //objEcVM.consulta_resulado(null)
        var cargar = addLoading();

        $.when(openb.jsonPost(sp_url_ctrl_action, sp_data))
            .then(function (r) {

                if (r.flag == true) {
                    objEcVM.valor_buscado(objEcVM.form_busqueda().param2());
                    //objEcVM.form_busqueda().param2('');

                    objEcVM.flag_resultado(r.flag);

                    const obje = JSON.parse(r.data.JsonString);

                    if (obje == null) {
                        removeLoading(cargar);
                        return;
                    }

                    console.log(obje);

                    if ('NewDataSet' in obje.GetDatosUltimasSancionesMTCResponse.GetDatosUltimasSancionesMTCResult.diffgram) {
                        objEcVM.consulta_resulado_(obje.GetDatosUltimasSancionesMTCResponse.GetDatosUltimasSancionesMTCResult.diffgram.NewDataSet.Table);
                    }
                    else if ('DocumentElement' in obje.GetDatosUltimasSancionesMTCResponse.GetDatosUltimasSancionesMTCResult.diffgram) {
                        var rr = obje.GetDatosUltimasSancionesMTCResponse.GetDatosUltimasSancionesMTCResult.diffgram.DocumentElement.dt.dc;
                        rr = rr.replace("Ãº", "ú");
                        //objEcVM.flag_resultado(false);
                        window.alertMessage(rr, '', '', "fas fa-exclamation-circle");
                    }
                    else {
                        //objEcVM.flag_resultado(false);
                        window.alertMessage('La consulta no ha retornado resultados.', '', '', "fas fa-exclamation-circle");
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

