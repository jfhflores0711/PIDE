var openb = {
    ValidaNum: function (evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode;
        if ((charCode <= 13) || (charCode >= 48 && charCode <= 57)) {
            return true;
        }
        else {
            return false;
        }
    },
    get: function (_url, _data) {
        return $.ajax({
            url: _url,
            dataType: "json",
            data: _data
        });
    },
    jsonPost: function (_url, _data) {
        return $.ajax({
            url: _url,
            type: "POST",
            data: _data,
            dataType: "json",
            contentType: "application/json; charset=utf-8"
        });
    },
    jsonGETCallback: function (_url, _data, _callbackCompleted, _callbackDone, _callbackError) {
        return $.ajax({
            url: _url,
            type: "GET",
            data: _data,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            complete: _callbackCompleted,
            success: _callbackDone,
            error: _callbackError
        });
    },

    jsonPostCallback: function (_url, _data, _callbackCompleted, _callbackDone, _callbackError) {
        return $.ajax({
            url: _url,
            type: "POST",
            data: _data,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            complete: _callbackCompleted,
            success: _callbackDone,
            error: _callbackError
        });
    },
    formPost: function (_url, _data) {
        //$.param(_data);
        return $.ajax({
            url: _url,
            type: "POST",
            data: _data,
            dataType: "json",
            contentType: "application/x-www-form-urlencoded; charset=UTF-8"
        });
    },

    init: function () {
        //init
    },
    error: function (mensaje, errores) {
        console.log(mensaje);
        if (errores === undefined || errores == null) {
            alertSecondary("Mensaje", mensaje, 'error', 6, function () { });
        } else {
            if (errores.length > 0) {
                if (errores.length > 0) {
                    var _mensaje = '<ul>'

                    errores.forEach(function (error) {
                        _mensaje += '<li>' + error.ErrorMessage + '</li>';
                    });
                    _mensaje += '</ul>';
                    alertSecondary("Mensaje", _mensaje).set('labels', { ok: 'Aceptar', cancel: 'Cancelar' });
                }
            } else {
                alertSecondary("Mensaje", mensaje, 'error', 6, function () { });
            }
        }
    },
    menuactivo: function (p, h) {
        $("#" + p).collapse('show');
        $("#" + h).css('background-color', "#eaecf4");



       
    },
      menuactivop: function (h) {

          //: ;
          //: normal;
          //font - weight: bold;
          //font - size: 14px;
          //line - height: 15px;
          ///* or 107% */

          //display: flex;
          //align - items: flex - end;
          //letter - spacing: 0.514286px;
          //text - transform: uppercase;

          //color: #575756;


          if (h == "PADRE_107") {
              $("#" + h).css('font-weight', "bold");
              $("#" + h).css('color', "#575756");

              $("#" + h).css('border-left', "3px solid #F94199");

              $("#" + h).css('-webkit-box-shadow', "inset 8px 0 5px -6px  #F94199");
          $("#" + h).css('-moz-box-shadow', "inset 8px 0 5px -6px  #F94199");
          $("#" + h).css('box-shadow', "inset 8px 0 5px -6px #F94199");

          }  
          if (h == "PADRE_110") {
              $("#" + h).css('font-weight', "bold");
              $("#" + h).css('color', "#575756");
      $("#" + h).css('border-left', "3px solid #F59D24");

              $("#" + h).css('-webkit-box-shadow', "inset 8px 0 5px -6px  #F59D24");
              $("#" + h).css('-moz-box-shadow', "inset 8px 0 5px -6px  #F59D24");
              $("#" + h).css('box-shadow', "inset 8px 0 5px -6px #F59D24");

          }
          if (h == "PADRE_108") {
              $("#" + h).css('font-weight', "bold");
              $("#" + h).css('color', "#575756");
              $("#" + h).css('border-left', "3px solid #318F3D");

              $("#" + h).css('-webkit-box-shadow', "inset 8px 0 5px -6px  #318F3D");
              $("#" + h).css('-moz-box-shadow', "inset 8px 0 5px -6px  #318F3D");
              $("#" + h).css('box-shadow', "inset 8px 0 5px -6px #318F3D");

          }
          if (h == "PADRE_109") {
              $("#" + h).css('font-weight', "bold");
              $("#" + h).css('color', "#575756");
              $("#" + h).css('border-left', "3px solid #004A92");

              $("#" + h).css('-webkit-box-shadow', "inset 8px 0 5px -6px  #004A92");
              $("#" + h).css('-moz-box-shadow', "inset 8px 0 5px -6px  #004A92");
              $("#" + h).css('box-shadow', "inset 8px 0 5px -6px #004A92");

          }
    }
};


var bgLoading = `<div id="cnt_loading" class="modal-backdrop 
fade show align-items-center
justify-content-center d-flex">
<div class="">
<svg class="lds-typing" width="200px" height="200px" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" viewBox="0 0 100 100" preserveAspectRatio="xMidYMid" style="background: none;"> <circle cx="27.5" cy="51.1806" r="5" fill="#098bb3"> <animate attributeName="cy" calcMode="spline" keySplines="0 0.5 0.5 1;0.5 0 1 0.5;0.5 0.5 0.5 0.5" repeatCount="indefinite" values="62.5;37.5;62.5;62.5" keyTimes="0;0.25;0.5;1" dur="1s" begin="-0.5s"></animate> </circle> <circle cx="42.5" cy="62.5" r="5" fill="#318e3d"> <animate attributeName="cy" calcMode="spline" keySplines="0 0.5 0.5 1;0.5 0 1 0.5;0.5 0.5 0.5 0.5" repeatCount="indefinite" values="62.5;37.5;62.5;62.5" keyTimes="0;0.25;0.5;1" dur="1s" begin="-0.375s"></animate> </circle> <circle cx="57.5" cy="62.5" r="5" fill="#f49c24"> <animate attributeName="cy" calcMode="spline" keySplines="0 0.5 0.5 1;0.5 0 1 0.5;0.5 0.5 0.5 0.5" repeatCount="indefinite" values="62.5;37.5;62.5;62.5" keyTimes="0;0.25;0.5;1" dur="1s" begin="-0.25s"></animate> </circle> <circle cx="72.5" cy="62.5" r="5" fill="#e61b72"> <animate attributeName="cy" calcMode="spline" keySplines="0 0.5 0.5 1;0.5 0 1 0.5;0.5 0.5 0.5 0.5" repeatCount="indefinite" values="62.5;37.5;62.5;62.5" keyTimes="0;0.25;0.5;1" dur="1s" begin="-0.125s"></animate> </circle> </svg>
</div></div>`;

function addLoading() {
    if (document.getElementById("cnt_loading") == null || document.getElementById("cnt_loading").length == 0) {
        var bgLoading = `<div id="cnt_loading" class="modal-backdrop 
    fade show align-items-center
    justify-content-center d-flex" style="z-index:99 !important">
    <div class="">
    <svg class="lds-typing" width="200px" height="200px" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" viewBox="0 0 100 100" preserveAspectRatio="xMidYMid" style="background: none;"> <circle cx="27.5" cy="51.1806" r="5" fill="#098bb3"> <animate attributeName="cy" calcMode="spline" keySplines="0 0.5 0.5 1;0.5 0 1 0.5;0.5 0.5 0.5 0.5" repeatCount="indefinite" values="62.5;37.5;62.5;62.5" keyTimes="0;0.25;0.5;1" dur="1s" begin="-0.5s"></animate> </circle> <circle cx="42.5" cy="62.5" r="5" fill="#318e3d"> <animate attributeName="cy" calcMode="spline" keySplines="0 0.5 0.5 1;0.5 0 1 0.5;0.5 0.5 0.5 0.5" repeatCount="indefinite" values="62.5;37.5;62.5;62.5" keyTimes="0;0.25;0.5;1" dur="1s" begin="-0.375s"></animate> </circle> <circle cx="57.5" cy="62.5" r="5" fill="#f49c24"> <animate attributeName="cy" calcMode="spline" keySplines="0 0.5 0.5 1;0.5 0 1 0.5;0.5 0.5 0.5 0.5" repeatCount="indefinite" values="62.5;37.5;62.5;62.5" keyTimes="0;0.25;0.5;1" dur="1s" begin="-0.25s"></animate> </circle> <circle cx="72.5" cy="62.5" r="5" fill="#e61b72"> <animate attributeName="cy" calcMode="spline" keySplines="0 0.5 0.5 1;0.5 0 1 0.5;0.5 0.5 0.5 0.5" repeatCount="indefinite" values="62.5;37.5;62.5;62.5" keyTimes="0;0.25;0.5;1" dur="1s" begin="-0.125s"></animate> </circle> </svg>
    </div></div>`;
        $(bgLoading).appendTo('body');
        var e = document.getElementById("cnt_loading");
        return e;
    }
    else {
        return null
    }


}
function removeLoading(e) {
    if (e != null) {
        setTimeout(function () {
            $(e).remove();
        }, 500);
    }
}
function GetContentLoading() {
    return '<svg class="lds-typing" width="200px" height="200px" xmlns="http://www.w3.org/2000/svg" xmlns: xlink="http://www.w3.org/1999/xlink" viewBox="0 0 100 100" preserveAspectRatio="xMidYMid" style="background: none;"> <circle cx="27.5" cy="51.1806" r="5" fill="#098bb3"> <animate attributeName="cy" calcMode="spline" keySplines="0 0.5 0.5 1;0.5 0 1 0.5;0.5 0.5 0.5 0.5" repeatCount="indefinite" values="62.5;37.5;62.5;62.5" keyTimes="0;0.25;0.5;1" dur="1s" begin="-0.5s"></animate> </circle> <circle cx="42.5" cy="62.5" r="5" fill="#318e3d"> <animate attributeName="cy" calcMode="spline" keySplines="0 0.5 0.5 1;0.5 0 1 0.5;0.5 0.5 0.5 0.5" repeatCount="indefinite" values="62.5;37.5;62.5;62.5" keyTimes="0;0.25;0.5;1" dur="1s" begin="-0.375s"></animate> </circle> <circle cx="57.5" cy="62.5" r="5" fill="#f49c24"> <animate attributeName="cy" calcMode="spline" keySplines="0 0.5 0.5 1;0.5 0 1 0.5;0.5 0.5 0.5 0.5" repeatCount="indefinite" values="62.5;37.5;62.5;62.5" keyTimes="0;0.25;0.5;1" dur="1s" begin="-0.25s"></animate> </circle> <circle cx="72.5" cy="62.5" r="5" fill="#e61b72"> <animate attributeName="cy" calcMode="spline" keySplines="0 0.5 0.5 1;0.5 0 1 0.5;0.5 0.5 0.5 0.5" repeatCount="indefinite" values="62.5;37.5;62.5;62.5" keyTimes="0;0.25;0.5;1" dur="1s" begin="-0.125s"></animate> </circle> </svg>';
}
function GetCssState(state) {
    switch (state) {
        case 0: return "badge badge-danger";
        case 1: return "badge badge-success";
        case 2: return "badge badge-success";
        case 3: return "badge badge-info";
        case 5: return "badge badge-warning";
        default: return "";
    }
}