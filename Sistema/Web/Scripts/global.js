/**********************
*** DECLARACIONES *****
***********************/

var global = {
    jdivEsperaAjax: $("#divEsperaAjax"),
    jdivFondoEsperaAjax: $("#divFondoEsperaAjax"),
    pathRaiz: "",
    tituloDialogos: "",
    terminos: {
        Aceptar: "",
        SI: "",
        NO: "",
        Cargando: "",
        Pagina: "",
        Cerrar: ""
    }
};

/****************
*** MÉTODOS *****
*****************/

global.MostrarEsperaAjax = function () {
    var width = global.width();
    global.jdivEsperaAjax.css({
        left: "" + ((width / 2) - 150).toFixed(0) + "px",
        top: "" + (self.pageYOffset || $.support.boxModel && document.documentElement.scrollTop || document.body.scrollTop) + "px"
    }).show();
    global.jdivFondoEsperaAjax.css({ width: width + "px", height: this.height() }).show();
}
global.OcultarEsperaAjax = function () {
    global.jdivEsperaAjax.hide();
    global.jdivFondoEsperaAjax.hide();
}

global.height = function () {
    var scrollHeight,
			offsetHeight;
    // handle IE 6
    if ($.browser.msie && $.browser.version < 7) {
        scrollHeight = Math.max(
				document.documentElement.scrollHeight,
				document.body.scrollHeight
			);
        offsetHeight = Math.max(
				document.documentElement.offsetHeight,
				document.body.offsetHeight
			);

        if (scrollHeight < offsetHeight) {
            return $(window).height() + 'px';
        } else {
            return scrollHeight + 'px';
        }
        // handle "good" browsers
    } else {
        return $(document).height() + 'px';
    }
}

global.width = function () {
    var scrollWidth,
			offsetWidth;
    // handle IE 6
    if ($.browser.msie && $.browser.version < 7) {
        scrollWidth = Math.max(
				document.documentElement.scrollWidth,
				document.body.scrollWidth
			);
        offsetWidth = Math.max(
				document.documentElement.offsetWidth,
				document.body.offsetWidth
			);

        if (scrollWidth < offsetWidth) {
            return $(window).width();
        } else {
            return scrollWidth;
        }
        // handle "good" browsers
    } else {
        return $(document).width();
    }
}
global.widthPx = function () {
    return this.width + "px";
}