var url_ = "";
var objEcVM = null;
var self;


var appOpenB = {
    init: function () {
        appOpenB.inicializarVM();
    },
    inicializarVM: function () {
        objEcVM = new appOpenB.StockVM();
        ko.applyBindings(objEcVM);
        appOpenB.fn_Listar_Producto();
    },

    fn_Listar_Producto: function () {
        var sp_url_ctrl_action = url_ + '/Stock/ListaProducto';
        objEcVM.form_busqueda().rows(objEcVM.Pager().PageSize);
        objEcVM.form_busqueda().page(objEcVM.Pager().CurrentPage);

        console.log(objEcVM.busqueda_nombre());
        console.log(objEcVM.busqueda_codigo());

        objEcVM.form_busqueda().tipo(objEcVM.tipo_busqueda());
        objEcVM.form_busqueda().c_denominacion(objEcVM.busqueda_nombre());
        objEcVM.form_busqueda().c_codigo_producto(objEcVM.busqueda_codigo());

        var sp_data = ko.toJSON(objEcVM.form_busqueda);


        var cargar = addLoading();
        $.when(openb.jsonPost(sp_url_ctrl_action, sp_data))
            .then(function (r) {
                console.log(r);
                if (r.flag == true) {

                    objEcVM.TotalResults(r.data.records);
                    objEcVM.lista_producto(r.data.rows);

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

    }
    ,
    model_busqueda: function () {
        var self = this;

        self.tipo = ko.observable(0);
        self.id_almacen = ko.observable(0);
        self.c_codigo_producto = ko.observable("");
        self.c_denominacion = ko.observable("");
        self.n_id_linea = ko.observable(0);
        self.n_id_usuario = ko.observable(0);
        self.b_stock = ko.observable(true);

        self.sidx = ko.observable("-");
        self.sord = ko.observable("-");
        self.page = ko.observable(0);
        self.rows = ko.observable(0);
    },
    StockVM: function () {
        self = this;

        //formulario paginacion-busqueda
        self.form_busqueda = ko.observable(new appOpenB.model_busqueda());

        //data
        self.lista_producto = ko.observableArray([]);

        self.tipo_busqueda = ko.observable(1);
        self.busqueda_nombre = ko.observable('');
        self.busqueda_codigo = ko.observable('');

        self.tipo_busqueda.subscribe(function () {
            self.busqueda_nombre('');
            self.busqueda_codigo('');
        });

        self.buscar_cliente = function () {
            appOpenB.fn_Listar_Producto();
        }

        self.limpiar_lista = function () {
            self.tipo_busqueda(1);
            appOpenB.fn_Listar_Producto();
        }

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

            appOpenB.fn_Listar_Producto();
        }

        self.cargar_data = function (data, viewmodel) {
            ko.mapping.fromJS(data, viewmodel);
        };
    },
    SoloDigitos: function (s) {
        var key = window.event ? event.keyCode : event.which;
        if (event.keyCode === 8 || event.keyCode === 46) {
            return true;
        } else if (key < 48 || key > 57) {
            return false;
        } else {
            return true;
        }
    },
};

