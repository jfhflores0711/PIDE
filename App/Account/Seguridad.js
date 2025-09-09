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
    fn_Actualizar_Datos: function () {
        var sp_url_ctrl_action = url_ + '/Account/set_restablecer_clave';
        var sp_data = ko.toJSON(objEcVM.formulario_cambio);
        var cargar = addLoading();
        $.when(openb.jsonPost(sp_url_ctrl_action, sp_data))
            .then(function (r) {

                if (r.flag == true) {
                    appOpenB.limpiar_formulario_cambio();
                    alertSuccess("Mensaje", r.mensaje, "fas fa-exclamation-circle");
                    objEcVM.mostrar_texto();
                   removeLoading(cargar);
                } else {

                    var items = r.errores, ul = document.createElement('ul');

                    if (items.length != 0) {
                        items.forEach(function (name) {
                            var li = document.createElement('li');
                            ul.appendChild(li);
                            li.innerHTML += name.ErrorMessage;
                        });

                        alertWarning("Mensaje", $(ul).html(), "fas fa-exclamation-circle");
                        removeLoading(cargar);
                    }
                    else {
                        alertWarning("Mensaje", r.mensaje, "fas fa-exclamation-circle");
                        removeLoading(cargar);
                    }
                }

            }, function () { // error
                console.log("Hubo un error al consultar los datos.");
            });

    },

    model_seguridad_cambio: function () {
        var self = this;

        self.actual = ko.observable("");
        self.nuevo1 = ko.observable("");
        self.nuevo2 = ko.observable("");

        self.textop = ko.observable(false);
    },
    limpiar_formulario_cambio: function () {
        objEcVM.formulario_cambio().actual('');
        objEcVM.formulario_cambio().nuevo1('');
        objEcVM.formulario_cambio().nuevo2('');
        objEcVM.formulario_cambio().textop(false);
    },
    
    ListaVM: function () {
        self = this;

        //formulario paginacion-busqueda
        self.formulario_cambio = ko.observable(new appOpenB.model_seguridad_cambio());

        //acciones
        self.actualizar_datos = function () {
            appOpenB.fn_Actualizar_Datos();
        }

        self.mostrar_texto = function () {
            if (objEcVM.formulario_cambio().textop()) {
                document.getElementById('inputPassword1').type = 'text';
                document.getElementById('inputPassword2').type = 'text';
                document.getElementById('inputPassword3').type = 'text';
            }
            else {
                document.getElementById('inputPassword1').type = 'password';
                document.getElementById('inputPassword2').type = 'password';
                document.getElementById('inputPassword3').type = 'password';
            }
        }

        

    }
};

