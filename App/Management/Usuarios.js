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
        appOpenB.fn_Listar_Objetos();
    },

    fn_Mostrar_Elemento: function (item) {
        appOpenB.popular_formulario_item(item);
        $('#mNuevo').modal('show')
    },

    fn_Mostrar_Elemento_Rol: function (item) {
        appOpenB.fn_Listar_Roles(item.n_id_usuario);
        objEcVM.desc_rol(item.c_login);
        $('#mRoles').modal('show')
    },

    fn_Listar_Objetos: function () {
        var sp_url_ctrl_action = url_ + '/Management/Listar_usuarios';
        objEcVM.form_busqueda().rows(objEcVM.Pager().PageSize);
        objEcVM.form_busqueda().page(objEcVM.Pager().CurrentPage);

        objEcVM.form_busqueda().tipo(objEcVM.tipo_busqueda());
 
        console.log(objEcVM.form_busqueda().tipo());

        switch (objEcVM.form_busqueda().tipo()) {
            case '1':
                objEcVM.form_busqueda().valor(objEcVM.busqueda_login());
                break;
            case '2':
                objEcVM.form_busqueda().valor(objEcVM.busqueda_dni());
                break;
            case '3':
                objEcVM.form_busqueda().valor(objEcVM.busqueda_nombre());
                break;
            case '4':
                objEcVM.form_busqueda().valor(objEcVM.busqueda_estado());
                objEcVM.form_busqueda().estado(objEcVM.busqueda_estado());
                break;
        }


        var sp_data = ko.toJSON(objEcVM.form_busqueda);

        console.log(sp_data);

        var cargar = addLoading();

        $.when(openb.jsonPost(sp_url_ctrl_action, sp_data))
            .then(function (r) {

                if (r.flag == true) {

                    objEcVM.TotalResults(r.data.records);
                    objEcVM.lista_objetos(r.data.rows);

                    removeLoading(cargar);
                    objEcVM.flag_load(false);
                } else {
                    alertWarning("Mensaje", r.mensaje, "fas fa-exclamation-circle");
                    removeLoading(cargar);
                    objEcVM.flag_load(false);
                }

            }, function () { // error
                console.log("Hubo un error al consultar los datos.");
            });

    },
    fn_Listar_Roles: function (key) {
        var sp_url_ctrl_action = url_ + '/Management/Listar_roles_usuario';
        var sp_data = ko.toJSON({ id: key });
        var cargar = addLoading();

        $.when(openb.jsonPost(sp_url_ctrl_action, sp_data))
            .then(function (r) {

                if (r.flag == true) {

                    objEcVM.lista_objetos_rol(r.data);

                    removeLoading(cargar);
                    objEcVM.flag_load(false);
                } else {
                    alertWarning("Mensaje", r.mensaje, "fas fa-exclamation-circle");
                    removeLoading(cargar);
                    objEcVM.flag_load(false);
                }

            }, function () { // error
                console.log("Hubo un error al consultar los datos.");
            });

    },
    fn_Set_Roles: function (item) {
        var sp_url_ctrl_action = url_ + '/Management/set_roles';
        var sp_data = ko.toJSON({ i_id_usuario: item.i_id_usuario, i_id_rol: item.n_id_rol, valor: item.roles });
        var cargar = addLoading();
        $.when(openb.jsonPost(sp_url_ctrl_action, sp_data))
            .then(function (r) {

                if (r.flag == true) {

                    removeLoading(cargar);
                    objEcVM.flag_load(false);
                } else {
                    alertWarning("Mensaje", r.mensaje, "fas fa-exclamation-circle");
                    removeLoading(cargar);
                    objEcVM.flag_load(false);
                }

            }, function () { // error
                console.log("Hubo un error al consultar los datos.");
            });

    },
    fn_Nuevo_Elemento: function () {
        appOpenB.limpiar_formulario_item();
        $('#mNuevo').modal('show')
    },
    fn_Modal_Clave: function (item) {
        objEcVM.desc_rol(item.c_login);
        objEcVM.form_clave().n_id_usuario(item.n_id_usuario);
        objEcVM.form_clave().c_clave('');
        $('#mClave').modal('show');
    },
    fn_Edicion_Elemento: function () {

        var sp_url_ctrl_action = url_ + '/Management/Edicion_cliente';

        var sp_data = ko.toJSON(objEcVM.form_item);

        var cargar = addLoading();

        $.when(openb.jsonPost(sp_url_ctrl_action, sp_data))
            .then(function (r) {

                if (r.flag == true) {
                    alertSuccess("Mensaje", r.mensaje, "fas fa-exclamation-circle");
                    appOpenB.fn_Listar_Objetos();
                    $('#mNuevo').modal('toggle')
                    removeLoading(cargar);
                } else {

                    var items = r.errores, ul = document.createElement('ul');
                    items.forEach(function (name) {
                        var li = document.createElement('li');
                        ul.appendChild(li);
                        li.innerHTML += name.ErrorMessage;
                    });

                    alertWarning("Mensaje", $(ul).html(), "fas fa-exclamation-circle");
                    removeLoading(cargar);
                }

            }, function () { // error
                console.log("Hubo un error al consultar los datos.");
            });

    },
    fn_Anula_Elemento: function (item) {

        var sp_url_ctrl_action = url_ + '/Management/Actualizar_usuario';

        var sp_data = ko.toJSON({ id: item.n_id_usuario });

        var cargar = addLoading();

        $.when(openb.jsonPost(sp_url_ctrl_action, sp_data))
            .then(function (r) {

                if (r.flag == true) {
                    alertSuccess("Mensaje", r.mensaje, "fas fa-exclamation-circle");
                    appOpenB.fn_Listar_Objetos();
                    removeLoading(cargar);
                } else {

                    alertWarning("Mensaje", r.mensaje, "fas fa-exclamation-circle");
                    removeLoading(cargar);
                }

            }, function () { // error
                console.log("Hubo un error al consultar los datos.");
            });

    },

    fn_Actualizar_Clave: function () {

        var sp_url_ctrl_action = url_ + '/Management/Actualizar_clave';
        var sp_data = ko.toJSON(objEcVM.form_clave);
        console.log(sp_data);
        var cargar = addLoading();

        $.when(openb.jsonPost(sp_url_ctrl_action, sp_data))
            .then(function (r) {

                if (r.flag == true) {
                    alertSuccess("Mensaje", r.mensaje, "fas fa-exclamation-circle");
                    removeLoading(cargar);
                    $('#mClave').modal('hide');
                } else {

                    alertWarning("Mensaje", r.mensaje, "fas fa-exclamation-circle");
                    removeLoading(cargar);
                }

            }, function () { // error
                console.log("Hubo un error al consultar los datos.");
            });

    },
    model_busqueda: function () {
        var self = this;

        self.sidx = ko.observable("-");
        self.sord = ko.observable("-");
        self.page = ko.observable(0);
        self.rows = ko.observable(0);

        self.tipo = ko.observable(0);
        self.valor = ko.observable('');
        self.estado = ko.observable(2);
    },
    limpiar_formulario_item: function () {
        objEcVM.form_item().n_id_usuario(0);
        objEcVM.form_item().c_login('');
        objEcVM.form_item().c_dni('');
        objEcVM.form_item().c_appaterno('');
        objEcVM.form_item().c_apmaterno('');
        objEcVM.form_item().c_nombres('');

        objEcVM.form_item().c_cargo('');
        objEcVM.form_item().n_estado(true);

        objEcVM.form_item().c_password1('');
        objEcVM.form_item().c_password2('');

    },
    popular_formulario_item: function (m) {
        objEcVM.form_item().n_id_usuario(m.n_id_usuario);
        objEcVM.form_item().c_login(m.c_login);
        objEcVM.form_item().c_dni(m.c_dni);
        objEcVM.form_item().c_appaterno(m.c_appaterno);
        objEcVM.form_item().c_apmaterno(m.c_apmaterno);
        objEcVM.form_item().c_nombres(m.c_nombres);

        objEcVM.form_item().c_cargo(m.c_cargo);
        objEcVM.form_item().n_estado(m.n_estado);

        objEcVM.form_item().c_password1('');
        objEcVM.form_item().c_password2('');
    },
    model_item: function () {
        var self = this;
        self.n_id_usuario = ko.observable("");
        self.c_login = ko.observable("");
        self.c_dni = ko.observable("");
        self.c_appaterno = ko.observable("");
        self.c_apmaterno = ko.observable("");
        self.c_nombres = ko.observable("");
        //self.c_nombrec = ko.observable("");
        self.c_cargo = ko.observable("");
        self.n_estado = ko.observable("");

        self.c_password1 = ko.observable("");
        self.c_password2 = ko.observable("");

        self.c_nombrec = ko.computed(function () {
            return (self.c_nombres() + ' ' + self.c_appaterno() + ' ' + self.c_apmaterno());
        }, this);
    },
    model_clave: function () {
        var self = this;
        self.n_id_usuario = ko.observable("");
        self.c_clave = ko.observable("");
    },
    ListaVM: function () {
        self = this;

        //acciones
        self.mostrar_elemento = function (item) {
            appOpenB.fn_Mostrar_Elemento(item);
        }

        self.nuevo_item = function () {
            appOpenB.fn_Nuevo_Elemento();
        }

        self.nuevo_item_edit = function (item) {
            appOpenB.fn_Edicion_Elemento(item);
        }

        self.mostrar_detalle_rol = function (item) {
            appOpenB.fn_Mostrar_Elemento_Rol(item);
        }

        self.actualizar_clave = function (item) {
            appOpenB.fn_Modal_Clave(item);
        }

        self.actualizar_pass = function () {
            appOpenB.fn_Actualizar_Clave();
        }

        self.anular_elemento = function (item) {
            window.confirmMessage("Anular ítem", "Desea anular el ítem " + item.NRO,
                function () {
                    appOpenB.fn_Anula_Elemento(item);
                }
                , function () { }, "fas fa-exclamation-circle");
        }

        //formulario paginacion-busqueda
        self.form_busqueda = ko.observable(new appOpenB.model_busqueda());
        self.form_item = ko.observable(new appOpenB.model_item());
        self.form_clave = ko.observable(new appOpenB.model_clave());
        //data
        self.lista_objetos = ko.observableArray([]);

        self.lista_objetos_rol = ko.observableArray([]);
        self.desc_rol = ko.observable('');

        self.seg_pass = ko.observable('');

        self.tipo_busqueda = ko.observable(1);

        self.busqueda_login = ko.observable('');
        self.busqueda_dni = ko.observable('');
        self.busqueda_nombre = ko.observable('');
        self.busqueda_estado = ko.observable(2);


        self.tipo_busqueda.subscribe(function () {
            self.busqueda_login('');
            self.busqueda_dni('');
            self.busqueda_nombre('');
            self.busqueda_estado(2);
        });

        //Paginación
        self.flag_load = ko.observable(false);

        self.SetTotalResults = ko.observable(0);
        self.TotalResults = ko.observable(0);
        self.Pager = ko.pager(self.TotalResults);

        self.Pager().CurrentPage.subscribe(function () {// Subscribe to current page changes.
            self.search();
        });

        self.Pager().PageSize.subscribe(function () {
            self.Pager().CurrentPage(1);//Page change, return first page
            self.search();
        });

        self.search = function () {
            self.flag_load(true);

            appOpenB.fn_Listar_Objetos();
        }

        self.cargar_data = function (data, viewmodel) {
            ko.mapping.fromJS(data, viewmodel);
        };

        self.cambio_estado_rol = function (r) {
            appOpenB.fn_Set_Roles(r)
            return r.roles;
        }

        self.limpiar_lista = function () {
            self.tipo_busqueda(1);
            appOpenB.fn_Listar_Objetos();
        }

        self.buscar_proceso = function () {
            appOpenB.fn_Listar_Objetos();
        }
    }
};

