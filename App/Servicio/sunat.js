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
        self.consulta_resulado_secundario = ko.observable(null);
        self.consulta_resulado_domicilio = ko.observable(null);
        self.consulta_resulado_representante = ko.observable(null);

        self.consulta_resulado_ = ko.observableArray([]);
        //acciones
        self.consultar_datos = function () {
            var l = objEcVM.form_busqueda().param1();
            if (l.length == 11) {
                appOpenB.fn_Listar_Objetos();
                appOpenB.fn_Listar_Objetos_Secundarios();
                appOpenB.fn_Listar_Objetos_Domicilio();
                appOpenB.fn_Listar_Objetos_Representante();
            }
            else {
                alertWarning("Mensaje", "Escriba N° de RUC con 11 dígitos e intente nuevamente.", "fas fa-exclamation-circle");
            }
        }


        self.cargar_data = function (data, viewmodel) {
            ko.mapping.fromJS(data, viewmodel);
        };
    },
    fn_Listar_Objetos: function () {
        var sp_url_ctrl_action = url_ + '/Sunat/ConsultaServicioRuc';

        var sp_data = ko.toJSON(objEcVM.form_busqueda);
        objEcVM.consulta_resulado_([]);
        objEcVM.consulta_resulado(null)
        var cargar = addLoading();

        $.when(openb.jsonPost(sp_url_ctrl_action, sp_data))
            .then(function (r) {
                console.log(r);
                if (r.flag == true) {
                    objEcVM.valor_buscado(objEcVM.form_busqueda().param1());

                    objEcVM.flag_resultado(r.flag);

                    if (r.data.Codigo != -4) {
                        const obj = JSON.parse(r.data.JsonString);
                        objEcVM.consulta_resulado(obj);

                        if (obj.ddp_ubigeo === "true" && obj.cod_dep === "true" && obj.cod_prov === "true") {
                            objEcVM.flag_resultado(false);
                            window.alertMessage('La consulta del RUC ' + objEcVM.valor_buscado() + ', no ha retornado resultados.', '', '', "fas fa-exclamation-circle");
                        }
                        //Object.keys(objEcVM.consulta_resulado()).forEach(function (k) {
                        //    objEcVM.consulta_resulado_.push({ nombre: appOpenB.fn_Actualizar_Label(k), valor: obj[k] });
                        //});
                    }
                    else {
                        objEcVM.flag_resultado(false);
                        alertWarning("Mensaje", r.data.Mensaje, "fas fa-exclamation-circle");
                    }


                    removeLoading(cargar);
                } else {
                    alertWarning("Mensaje", r.mensaje, "fas fa-exclamation-circle");
                    removeLoading(cargar);
                }

            }, function () { // error
                console.log("Hubo un error al consultar los datos.");
            });

    },
    fn_Listar_Objetos_Secundarios: function () {
        var sp_url_ctrl_action = url_ + '/Sunat/ConsultaServicioRucSecundario';

        var sp_data = ko.toJSON(objEcVM.form_busqueda);
        objEcVM.consulta_resulado_secundario(null)
        var cargar = addLoading();

        $.when(openb.jsonPost(sp_url_ctrl_action, sp_data))
            .then(function (r) {

                if (r.flag == true) {
                    objEcVM.valor_buscado(objEcVM.form_busqueda().param1());

                    if (r.data.Codigo != -4) {
                        const obj = JSON.parse(r.data.JsonString);
                        objEcVM.consulta_resulado_secundario(obj);

                    }
                    else {
                        alertWarning("Mensaje", r.data.Mensaje, "fas fa-exclamation-circle");
                    }
                    removeLoading(cargar);
                } else {
                    alertWarning("Mensaje", r.mensaje, "fas fa-exclamation-circle");
                    removeLoading(cargar);
                }

            }, function () { // error
                console.log("Hubo un error al consultar los datos.");
            });
    },
    fn_Listar_Objetos_Domicilio: function () {
        var sp_url_ctrl_action = url_ + '/Sunat/ConsultaServicioRucDomicilio';

        var sp_data = ko.toJSON(objEcVM.form_busqueda);
        objEcVM.consulta_resulado_domicilio(null)
        var cargar = addLoading();

        $.when(openb.jsonPost(sp_url_ctrl_action, sp_data))
            .then(function (r) {
                if (r.flag == true) {
                    objEcVM.valor_buscado(objEcVM.form_busqueda().param1());

                    if (r.data.Codigo != -4) {
                        const obj = JSON.parse(r.data.JsonString);
                        objEcVM.consulta_resulado_domicilio(obj);
                    }
                    else {
                        alertWarning("Mensaje", r.data.Mensaje, "fas fa-exclamation-circle");
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
    fn_Listar_Objetos_Representante: function () {
        var sp_url_ctrl_action = url_ + '/Sunat/ConsultaServicioRucRepresentante';

        var sp_data = ko.toJSON(objEcVM.form_busqueda);
        objEcVM.consulta_resulado_representante(null)
        var cargar = addLoading();

        $.when(openb.jsonPost(sp_url_ctrl_action, sp_data))
            .then(function (r) {

                if (r.flag == true) {
                    objEcVM.valor_buscado(objEcVM.form_busqueda().param1());

                    if (r.data.Codigo != -4) {
                        const obj = JSON.parse(r.data.JsonString);
                        objEcVM.consulta_resulado_representante(obj);

                    }
                    else {
                        alertWarning("Mensaje", r.data.Mensaje, "fas fa-exclamation-circle");
                    }
                    removeLoading(cargar);
                } else {
                    alertWarning("Mensaje", r.mensaje, "fas fa-exclamation-circle");
                    removeLoading(cargar);
                }

            }, function () { // error
                console.log("Hubo un error al consultar los datos.");
            });
    },
    fn_Actualizar_Label: function (k) {
        var TextoServicio = [];
        TextoServicio["ddp_numruc"] = "RUC";
        TextoServicio["ddp_nombre"] = "Contribuyente";

        TextoServicio["ddp_ubigeo"] = "Ubigeo departamento";
        TextoServicio["desc_dep"] = "Departamento";
        TextoServicio["cod_dep"] = "Código departamento";
        TextoServicio["desc_tpoemp"] = "Tipo Contribuyente";
        TextoServicio["cod_prov"] = "Código provincia";
        TextoServicio["desc_prov"] = "Provincia";
        TextoServicio["cod_dist"] = "Código distrito";
        TextoServicio["desc_dist"] = "Distrito";
        TextoServicio["ddp_ciiu"] = "Código actividad";
        TextoServicio["desc_ciiu"] = "Actividad(es) Económica(s)";

        TextoServicio["ddp_estado"] = "Código estado";
        TextoServicio["desc_estado"] = "Estado";

        TextoServicio["ddp_fecact"] = "Fecha de actualización";
        TextoServicio["ddp_fecalt"] = "Fecha de inscripción";

        TextoServicio["ddp_fecbaj"] = "Fecha de baja";
        TextoServicio["ddp_identi"] = "Cod. persona";
        TextoServicio["desc_identi"] = "Persona";
        TextoServicio["ddp_lllttt"] = "";

        TextoServicio['ddp_nomvia'] = 'Nombre vía';
        TextoServicio['ddp_numer1'] = 'Número';
        TextoServicio['ddp_inter1'] = '';
        TextoServicio['ddp_inter1'] = 'Zona';
        TextoServicio['ddp_refer1'] = 'Referencia';
        TextoServicio['ddp_flag22'] = 'Código condición';
        TextoServicio['desc_flag22'] = 'Condición del Contribuyente';
        TextoServicio['ddp_numreg'] = 'Código intendencia';
        TextoServicio['desc_numreg'] = 'Intendencia';
        TextoServicio['ddp_tipvia'] = 'Código vía';
        TextoServicio['desc_tipvia'] = 'Descripción vía';
        TextoServicio['ddp_tipzon'] = 'Código zona';
        TextoServicio['ddp_nomzon'] = 'Nombre de zona';
        TextoServicio['desc_tipzon'] = 'Descripción zona';
        TextoServicio['ddp_tpoemp'] = 'Código tipo';
        TextoServicio['ddp_secuen'] = 'Secuencia';
        TextoServicio['esActivo'] = 'Activo';
        TextoServicio['esHabido'] = 'Habido';

        return TextoServicio[k] == undefined ? k : TextoServicio[k];
    }
};

