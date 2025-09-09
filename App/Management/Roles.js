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

    fn_Listar_Objetos: function () {
        var sp_url_ctrl_action = url_ + '/Management/Listar_roles';
        objEcVM.form_busqueda().rows(objEcVM.Pager().PageSize);
        objEcVM.form_busqueda().page(objEcVM.Pager().CurrentPage);

        var sp_data = ko.toJSON(objEcVM.form_busqueda);

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
    model_busqueda: function () {
        var self = this;

        self.sidx = ko.observable("-");
        self.sord = ko.observable("-");
        self.page = ko.observable(0);
        self.rows = ko.observable(0);
    },
    
    ListaVM: function () {
        self = this;

        //formulario paginacion-busqueda
        self.form_busqueda = ko.observable(new appOpenB.model_busqueda());

        //data
        self.lista_objetos = ko.observableArray([]);

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
    }
};

