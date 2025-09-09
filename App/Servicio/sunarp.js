var url_ = "";
var objEcVM = null;
var self;


var appOpenB = {
    init: function (o, m, inicio) {
        appOpenB.inicializarVM(o, m, inicio);
    },
    inicializarVM: function (o, m, inicio) {
        objEcVM = new appOpenB.ListaVM();
        ko.applyBindings(objEcVM);

        if (inicio != undefined) {
            if (inicio.paterno != null) {
                objEcVM.form_busqueda().param1(inicio.paterno);
                objEcVM.form_busqueda().param2(inicio.materno);
                objEcVM.form_busqueda().param3(inicio.nombre);
                objEcVM.consultar_datos();
            }
        }

        if (o === 1) {
            appOpenB.fn_Listar_Objetos_Oficina(m != undefined ? m.oficina : '');
        }
        if (m != null) {
            if (m.numeroPartida != null) {

                objEcVM.form_busqueda().param3(m.numeroPartida);
                objEcVM.form_busqueda().param2(m.registro);
            }
        }

    },
    model_busqueda: function () {
        var self = this;

        self.param1 = ko.observable("");
        self.param2 = ko.observable("");
        self.param3 = ko.observable("");
        self.param4 = ko.observable("");
        self.param5 = ko.observable("");
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
        self.consulta_resulado_folio = ko.observableArray([]);
        self.consulta_resulado_ficha = ko.observableArray([]);

        self.propietarios_ = ko.observableArray([]);

        self.asiento_transaccion = ko.observable();
        self.asiento_transaccion_num_pag = ko.observable();
        self.asiento_transaccion_img = ko.observable(null);

        self.consulta_oficinas = ko.observableArray([]);
        //acciones
        self.consultar_datos = function () {
            var l1 = objEcVM.form_busqueda().param1();
            var l2 = objEcVM.form_busqueda().param2();
            var l3 = objEcVM.form_busqueda().param3();
            if (l1.length != 0 && l2.length != 0 && l3.length != 0) {
                appOpenB.fn_Listar_Objetos();
            }
            else {
                alertWarning("Mensaje", "Escriba apellidos y nombres completos e intente nuevamente.", "fas fa-exclamation-circle");
            }
        }

        self.consultar_datos_asiento = function () {
            var l1 = objEcVM.form_busqueda().param1();
            var l2 = objEcVM.form_busqueda().param2();
            var l3 = objEcVM.form_busqueda().param3();


            if (l1.length != "" && l2.length != "" && l3.length != "") {

                objEcVM.form_busqueda().param4(l1.codZona);
                objEcVM.form_busqueda().param5(l1.codOficina);

                appOpenB.fn_Listar_Objetos_Asientos();

            }
            else {
                alertWarning("Mensaje", "Complete los datos solicitados e intente nuevamente.", "fas fa-exclamation-circle");
            }
        }

        self.ver_asiento = function (data, a, b) {
            appOpenB.fn_Listar_Objetos_Asientos_Det(a, b);
        }

        self.ver_ficha = function (data, a, b) {
            appOpenB.fn_Listar_Objetos_Ficha_Det(a, b);
        }

        self.ver_ficha_ = function (data, a, b) {
            appOpenB.fn_Listar_Objetos_Ficha_Det_(a, b);
        }

        self.redirigit_asiento = function (data) {
            appOpenB.fn_Redirigir_Objetos_Asiento(data);
        }

        self.redirigit_asiento_varios = function (data) {
            appOpenB.fn_Redirigir_Objetos_Asiento_Varios(data);
        }

        self.ver_folio = function (item) {
            appOpenB.fn_Listar_Objetos_Folio_Det(item);
        }

        self.consultar_datos_pj = function () {
            appOpenB.fn_Listar_Objetos_Pj();
        }

        self.consultar_datos_rs = function () {
            appOpenB.fn_Listar_Objetos_Rs();
        }

        self.consultar_asiento_item = function (item) {
            appOpenB.fn_Listar_Objetos_Oficina_Item(item);
        }

        self.consultar_datos_vehiculo = function () {
            var l1 = objEcVM.form_busqueda().param1();
            var l3 = objEcVM.form_busqueda().param3();

            if (l1.length != "" && l3.length != "") {

                objEcVM.form_busqueda().param4(l1.codZona);
                objEcVM.form_busqueda().param5(l1.codOficina);

                appOpenB.fn_Listar_Objetos_Vehiculo_Placa();

            }
            else {
                alertWarning("Mensaje", "Complete los datos solicitados e intente nuevamente.", "fas fa-exclamation-circle");
            }
        }


        self.cargar_data = function (data, viewmodel) {
            ko.mapping.fromJS(data, viewmodel);
        };
    },
    fn_Listar_Objetos_Oficina: function (ofi) {
        var sp_url_ctrl_action = url_ + '/Sunarp/ListaOficinas';

        var sp_data = {};
        objEcVM.consulta_oficinas([]);
        var cargar = addLoading();

        $.when(openb.jsonPost(sp_url_ctrl_action, sp_data))
            .then(function (r) {
                if (r.flag == true) {

                    objEcVM.flag_resultado(r.flag);

                    const obje = JSON.parse(r.data.JSonOficinas);

                    if (obje == null) {
                        removeLoading(cargar);
                        window.alertMessage('La consulta no ha retornado resultados.', '', '', "fas fa-exclamation-circle");
                        return;
                    }


                    if (r.data.Codigo != -4) {

                        objEcVM.consulta_oficinas(obje);

                        let obj1 = objEcVM.consulta_oficinas().find(o => o.descripcion === (ofi != null ? ofi : 'AYACUCHO') );
                        objEcVM.form_busqueda().param1(obj1);

                        if (obj1 != undefined && ofi != null) {
                            objEcVM.consultar_datos_asiento();
                        }
                        removeLoading(cargar);
                    }
                    else {
                        objEcVM.flag_resultado(false);
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
    fn_Listar_Objetos_Oficina_Item: function (item_) {
        var sp_url_ctrl_action = url_ + '/Sunarp/Asientos';

        var sp_data = {};
        objEcVM.consulta_oficinas([]);
        var cargar = addLoading();

        let obj1 = item_.oficina;
        var obj2 = '';

        if (item_.registro === 'REGISTRO DE BIENES MUEBLES') {
            obj2 = '24000';
        }
        if (item_.registro === 'REGISTRO DE PROPIEDAD INMUEBLE') {
            obj2 = '21000';
        }

        window.open(sp_url_ctrl_action + '?numeroPartida=' + item_.numeroPartida + '&oficina=' + obj1 + '&registro=' + obj2);

        removeLoading(cargar);
    }
    ,
    fn_Listar_Objetos_Asientos: function () {
        var sp_url_ctrl_action = url_ + '/Sunarp/ListaAsientos';

        var sp_data = ko.toJSON(objEcVM.form_busqueda);

        console.log(sp_data);
        objEcVM.consulta_resulado_([]);
        objEcVM.consulta_resulado_folio([]);
        objEcVM.consulta_resulado_ficha([]);

        var cargar = addLoading();

        $.when(openb.jsonPost(sp_url_ctrl_action, sp_data))
            .then(function (r) {
               
                if (r.flag == true) {

                    objEcVM.flag_resultado(r.flag);

                    const obje = JSON.parse(r.data.JsonString);
                    console.log(obje);
                    if (obje == null) {
                        objEcVM.consulta_resulado_([]);
                        objEcVM.asiento_transaccion('');
                        objEcVM.asiento_transaccion_num_pag('');

                        removeLoading(cargar);
                        window.alertMessage('La consulta no ha retornado resultados.', '', '', "fas fa-exclamation-circle");
                        return;
                    }

                    if (obje.listarAsientosSIRSARPResponse.asientos == null) {
                        objEcVM.consulta_resulado_([]);
                        objEcVM.asiento_transaccion('');
                        objEcVM.asiento_transaccion_num_pag('');

                        removeLoading(cargar);
                        window.alertMessage('La consulta no ha retornado resultados.', '', '', "fas fa-exclamation-circle");
                        return;
                    }
                    console.log(obje);

                    if (r.data.Codigo != -4) {

                        objEcVM.consulta_resulado_(obje.listarAsientosSIRSARPResponse.asientos.listAsientos);
                        console.log(obje.listarAsientosSIRSARPResponse.asientos.transaccion);


                        objEcVM.asiento_transaccion(obje.listarAsientosSIRSARPResponse.asientos.transaccion);
                        objEcVM.asiento_transaccion_num_pag(obje.listarAsientosSIRSARPResponse.asientos.nroTotalPag);

                        if ('listFolios' in obje.listarAsientosSIRSARPResponse.asientos) {
                            objEcVM.consulta_resulado_folio(obje.listarAsientosSIRSARPResponse.asientos.listFolios);
                        }
                        if ('listFichas' in obje.listarAsientosSIRSARPResponse.asientos) {
                            objEcVM.consulta_resulado_ficha(obje.listarAsientosSIRSARPResponse.asientos.listFichas);
                            console.log(objEcVM.consulta_resulado_folio().length);
                        }
                        removeLoading(cargar);

                        if (objEcVM.asiento_transaccion_num_pag() === 0) {
                            window.alertMessage('La consulta no ha retornado resultados.', '', '', "fas fa-exclamation-circle");
                        }
                    }
                    else {
                        objEcVM.flag_resultado(false);
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
    fn_Listar_Objetos_Asientos_Det: function (a, b) {
        var sp_url_ctrl_action = url_ + '/Sunarp/VerAsientos';

        var sp_data = {
            'transaccion': objEcVM.asiento_transaccion(),
            'idImg': a.idImgAsiento,
            'tipo': a.tipo,
            'nroTotalPag': objEcVM.asiento_transaccion_num_pag(),
            'nroPagRef': b.nroPagRef,
            'pagina': b.pagina
        };
        console.log(a);
        console.log(b);
        if (a === 'b') {
            sp_data = {
                'transaccion': objEcVM.asiento_transaccion(),
                'idImg': b.idImgAsiento,
                'tipo': b.tipo,
                'nroTotalPag': objEcVM.asiento_transaccion_num_pag(),
                'nroPagRef': b.listPag.nroPagRef,
                'pagina': b.listPag.pagina
            };
        }

        objEcVM.asiento_transaccion_img('');
        var cargar = addLoading();

        $.when(openb.jsonPost(sp_url_ctrl_action, JSON.stringify(sp_data)))
            .then(function (r) {
                if (r.flag == true) {

                    const obje = JSON.parse(r.data.JsonString);

                    if (obje == null) {
                        removeLoading(cargar);
                        window.alertMessage('La consulta no ha retornado resultados.', '', '', "fas fa-exclamation-circle");
                        return;
                    }

                    if (r.data.Codigo != -4) {

                        objEcVM.asiento_transaccion_img(obje.verAsientoSIRSARPResponse.img);
                        $('#modal-imagen').modal('show');
                        removeLoading(cargar);
                    }
                    else {
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
    fn_Listar_Objetos_Ficha_Det: function (a, b) {
        var sp_url_ctrl_action = url_ + '/Sunarp/VerAsientos';
        console.log(a);
        console.log(b);

        var sp_data = {
            'transaccion': objEcVM.asiento_transaccion(),
            'idImg': b.idImgFicha,
            'tipo': b.tipo,
            'nroTotalPag': objEcVM.asiento_transaccion_num_pag(),
            'nroPagRef': b.listPag.nroPagRef,
            'pagina': b.listPag.pagina
        };

        objEcVM.asiento_transaccion_img('');
        var cargar = addLoading();

        $.when(openb.jsonPost(sp_url_ctrl_action, JSON.stringify(sp_data)))
            .then(function (r) {
                if (r.flag == true) {

                    const obje = JSON.parse(r.data.JsonString);

                    if (obje == null) {
                        removeLoading(cargar);
                        window.alertMessage('La consulta no ha retornado resultados.', '', '', "fas fa-exclamation-circle");
                        return;
                    }

                    if (r.data.Codigo != -4) {

                        objEcVM.asiento_transaccion_img(obje.verAsientoSIRSARPResponse.img);
                        $('#modal-imagen').modal('show');
                        removeLoading(cargar);
                    }
                    else {
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
    fn_Listar_Objetos_Ficha_Det_: function (a, b) {
        var sp_url_ctrl_action = url_ + '/Sunarp/VerAsientos';
        console.log(a);
        console.log(b);

        var sp_data = {
            'transaccion': objEcVM.asiento_transaccion(),
            'idImg': a.idImgFicha,
            'tipo': a.tipo,
            'nroTotalPag': objEcVM.asiento_transaccion_num_pag(),
            'nroPagRef': b.nroPagRef,
            'pagina': b.pagina
        };

        objEcVM.asiento_transaccion_img('');
        var cargar = addLoading();

        $.when(openb.jsonPost(sp_url_ctrl_action, JSON.stringify(sp_data)))
            .then(function (r) {
                if (r.flag == true) {

                    const obje = JSON.parse(r.data.JsonString);

                    if (obje == null) {
                        removeLoading(cargar);
                        window.alertMessage('La consulta no ha retornado resultados.', '', '', "fas fa-exclamation-circle");
                        return;
                    }

                    if (r.data.Codigo != -4) {

                        objEcVM.asiento_transaccion_img(obje.verAsientoSIRSARPResponse.img);
                        $('#modal-imagen').modal('show');
                        removeLoading(cargar);
                    }
                    else {
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
    fn_Redirigir_Objetos_Asiento: function (data) {
        var sp_url_ctrl_action = url_ + '/Sunarp/Index';

        var cargar = addLoading();

        if (!Array.isArray(data.propietarios.nombre)) {

            var persona = data.propietarios.nombre.split(" ");

            var nombre = '';
            var paterno = '';
            var materno = '';

            if (persona.length == 5) {
                nombre = persona[0] + " " + persona[1];
                paterno = persona[2];
                materno = persona[3] + " " + persona[4];
            }
            else if (persona.length == 4) {
                nombre = persona[0] + " " + persona[1];
                paterno = persona[2];
                materno = persona[3];
                console.log("nombres: ", nombre);
                console.log("paterno: ", paterno);
                console.log("materno: ", materno);
            } else if (persona.length == 3) {
                nombre = persona[0];
                paterno = persona[1];
                materno = persona[2];
                console.log("nombres: ", nombre);
                console.log("paterno: ", paterno);
                console.log("materno: ", materno);
            }
            window.open(sp_url_ctrl_action + '?nombre=' + nombre + '&paterno=' + paterno + '&materno=' + materno, 'asiento');
        }
        else {
            console.log(data.propietarios.nombre);
            objEcVM.propietarios_(data.propietarios.nombre);

            $('#mTitulares').modal('show');
        }
        removeLoading(cargar);
    }

    ,
    fn_Redirigir_Objetos_Asiento_Varios: function (data) {
        console.log(data);
        var sp_url_ctrl_action = url_ + '/Sunarp/Index';

        var cargar = addLoading();

        if (!Array.isArray(data)) {

            var persona = data.split(" ");

            var nombre = '';
            var paterno = '';
            var materno = '';

            if (persona.length == 5) {
                nombre = persona[0] + " " + persona[1];
                paterno = persona[2];
                materno = persona[3] + " " + persona[4];
            }
            else if (persona.length == 4) {
                nombre = persona[0] + " " + persona[1];
                paterno = persona[2];
                materno = persona[3];
                console.log("nombres: ", nombre);
                console.log("paterno: ", paterno);
                console.log("materno: ", materno);
            } else if (persona.length == 3) {
                nombre = persona[0];
                paterno = persona[1];
                materno = persona[2];
                console.log("nombres: ", nombre);
                console.log("paterno: ", paterno);
                console.log("materno: ", materno);
            }
            window.open(sp_url_ctrl_action + '?nombre=' + nombre + '&paterno=' + paterno + '&materno=' + materno, 'asiento');
        }
        removeLoading(cargar);
    }
    ,
    fn_Listar_Objetos_Folio_Det: function (item) {
        var sp_url_ctrl_action = url_ + '/Sunarp/VerAsientos';
        console.log(item);
        var sp_data = {
            'transaccion': objEcVM.asiento_transaccion(),
            'idImg': item.idImgFolio,
            'tipo': item.tipo,
            'nroTotalPag': objEcVM.asiento_transaccion_num_pag(),
            'nroPagRef': item.nroPagRef,
            'pagina': item.pagina
        };

        objEcVM.asiento_transaccion_img('');
        var cargar = addLoading();

        $.when(openb.jsonPost(sp_url_ctrl_action, JSON.stringify(sp_data)))
            .then(function (r) {
                if (r.flag == true) {

                    const obje = JSON.parse(r.data.JsonString);

                    if (obje == null) {
                        removeLoading(cargar);
                        window.alertMessage('La consulta no ha retornado resultados.', '', '', "fas fa-exclamation-circle");
                        return;
                    }

                    if (r.data.Codigo != -4) {

                        objEcVM.asiento_transaccion_img(obje.verAsientoSIRSARPResponse.img);
                        $('#modal-imagen').modal('show');
                        removeLoading(cargar);
                    }
                    else {
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
    fn_Listar_Objetos: function () {
        var sp_url_ctrl_action = url_ + '/Sunarp/ConsultaServicioTPN';

        var sp_data = ko.toJSON(objEcVM.form_busqueda);
        objEcVM.consulta_resulado_([]);
        objEcVM.consulta_resulado(null)
        var cargar = addLoading();

        $.when(openb.jsonPost(sp_url_ctrl_action, sp_data))
            .then(function (r) {
                if (r.flag == true) {

                    objEcVM.valor_buscado(objEcVM.form_busqueda().param3() + ' ' + objEcVM.form_busqueda().param1() + ' ' + objEcVM.form_busqueda().param2());
                    objEcVM.valor_buscado().toUpperCase();
                    objEcVM.form_busqueda().param1('');
                    objEcVM.form_busqueda().param2('');
                    objEcVM.form_busqueda().param3('');

                    objEcVM.flag_resultado(r.flag);

                    const obje = JSON.parse(r.data.JsonString);

                    console.log(obje);

                    if (obje == null) {
                        removeLoading(cargar);
                        window.alertMessage('La consulta no ha retornado resultados.', '', '', "fas fa-exclamation-circle");
                        return;
                    }

                    if (obje.buscarTitularidadSIRSARPResponse.respuestaTitularidad == null) {
                        window.alertMessage('La consulta no ha retornado resultados.', '', '', "fas fa-exclamation-circle");
                        removeLoading(cargar);
                        return;
                    }
                    if (r.data.Codigo != -4) {

                        const obj = JSON.parse(r.data.JsonString);

                        objEcVM.consulta_resulado(obj.buscarTitularidadSIRSARPResponse.respuestaTitularidad.respuestaTitularidad);

                    }
                    else {
                        objEcVM.flag_resultado(false);
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
    fn_Listar_Objetos_Pj: function () {
        var sp_url_ctrl_action = url_ + '/Sunarp/ConsultaServicioTPJ';

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

                    const obje = JSON.parse(r.data.JsonString);


                    if (obje == null) {
                        removeLoading(cargar);
                        window.alertMessage('La consulta no ha retornado resultados.', '', '', "fas fa-exclamation-circle");
                        return;
                    }

                    if (obje.buscarTitularidadSIRSARPResponse.respuestaTitularidad == null) {
                        removeLoading(cargar);
                        window.alertMessage('La consulta no ha retornado resultados.', '', '', "fas fa-exclamation-circle");
                        return;
                    }
                    if (r.data.Codigo != -4) {

                        const obj = JSON.parse(r.data.JsonString);

                        objEcVM.consulta_resulado(obj.buscarTitularidadSIRSARPResponse.respuestaTitularidad.respuestaTitularidad);
                    }
                    else {
                        objEcVM.flag_resultado(false);
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
    fn_Listar_Objetos_Rs: function () {
        var sp_url_ctrl_action = url_ + '/Sunarp/ConsultaServicioTRS';

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

                    const obje = JSON.parse(r.data.JSonRasoSocial);

                    if (obje == null) {
                        removeLoading(cargar);
                        window.alertMessage('La consulta no ha retornado resultados.', '', '', "fas fa-exclamation-circle");
                        return;
                    }

                    if (obje.personaJuridica == null) {
                        removeLoading(cargar);
                        window.alertMessage('La consulta no ha retornado resultados.', '', '', "fas fa-exclamation-circle");
                        return;
                    }

                    if (obje.personaJuridica.resultado == null) {
                        removeLoading(cargar);
                        window.alertMessage('La consulta no ha retornado resultados.', '', '', "fas fa-exclamation-circle");
                        return;
                    }
                    if (r.data.Codigo != -4) {

                        const obj = JSON.parse(r.data.JSonRasoSocial);

                        objEcVM.consulta_resulado(obje.personaJuridica.resultado);
                    }
                    else {
                        
                        objEcVM.flag_resultado(false);
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
    fn_Listar_Objetos_Vehiculo_Placa: function () {
        var sp_url_ctrl_action = url_ + '/Sunarp/ListaVehiculoPlaca';
        
        var sp_data = ko.toJSON(objEcVM.form_busqueda);

        console.log(sp_data);
        objEcVM.consulta_resulado_([]);

        var cargar = addLoading();

        $.when(openb.jsonPost(sp_url_ctrl_action, sp_data))
            .then(function (r) {

                if (r.flag == true) {

                    objEcVM.flag_resultado(r.flag);

                    const obje = JSON.parse(r.data.JSonVehiculos);

                    if (obje == null) {

                        objEcVM.consulta_resulado_([]);

                        removeLoading(cargar);
                        window.alertMessage('La consulta no ha retornado resultados.', '', '', "fas fa-exclamation-circle");
                        return;
                    }

                    if (obje.verDetalleRPVExtraResponse.vehiculo.placa == null) {
                        objEcVM.consulta_resulado_([]);

                        removeLoading(cargar);
                        window.alertMessage('La consulta no ha retornado resultados.', '', '', "fas fa-exclamation-circle");
                        return;
                    }


                    if (r.data.Codigo != -4) {

                        objEcVM.consulta_resulado_(obje.verDetalleRPVExtraResponse.vehiculo);

                        removeLoading(cargar);
                    }
                    else {
                        objEcVM.flag_resultado(false);
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

};

