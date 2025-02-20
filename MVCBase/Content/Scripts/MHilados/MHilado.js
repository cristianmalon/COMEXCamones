
function enableTransactHE() {
    console.log('enableTransactHE')
    $('.transactHE').each(function (i, e) {
        $(e).removeAttr('disabled')
    })
    $('select.selectpicker.transactHE').each(function (i, e) {
        // Actualizar el elemento select
        e.selectedIndex = e.selectedIndex; // Esto fuerza la actualización visual
    });
   /* $('#chkEstadoEspecifico').bootstrapToggle({
        on: 'Activo',
        off: 'Inactivo'
    }).bootstrapToggle('enable');*/
}
function disableTransactHE() {
    //$('.transact').prop('disable', false)
    console.log('disabled')
    $('.transactHE').each(function (i, e) {
        $(e).attr('disabled', 'disabled')
    })
    $('select.transactHE').each(function (i, e) {
        // Actualizar el elemento select
        e.selectedIndex = e.selectedIndex; // Esto fuerza la actualización visual
    });    //debugger
   /* $('#chkEstadoEspecifico').bootstrapToggle({
        on: 'Activo',
        off: 'Inactivo'
    }).bootstrapToggle('disable');*/
}

function handleBtnNuevoClick() {
    sessionStorage.setItem('optionHM', 'new');
    $.get("/MHilado/HiladoMadrePartial", function (data) {
        BootstrapDialog.show({
            closeByBackdrop: false,
            title: 'Registrar Hilado Madre',
            size: BootstrapDialog.SIZE_LARGE,
            message: $(data)
        });
    });

    // Ejecutar acciones después de un cierto tiempo de retardo
    setTimeout(() => {
        console.log("ACA LLEGA");
        loadCombosIni();
        $(".panelHEspecificos").hide();
    }, 500); // Tiempo de retardo en milisegundos (en este caso, 500 ms)
}

function handleBtnEditarClick(parametro) {
    

    console.log("parametro123editar",parametro);
    sessionStorage.setItem('optionHM', 'edit')

             
        $.get("/MHilado/HiladoMadrePartial", function (data) {
            BootstrapDialog.show({
                closeByBackdrop: false,
                title: 'Editar Hilado Madre',
                size: BootstrapDialog.SIZE_LARGE,
                message: $(data)
            });
        });

    sleep(500).then(() => {
            loadCombosIni();
            $(txtCodigoHilo).val(parametro.Codigo)
            console.log("EL VALOR DE PARAMETRO CODIGO ES", parametro.Codigo);
        $.blockUI({ message: '<img src="/Content/Images/loading.gif">', css: { border: 'none', background: 'transparent' } });
            loadByCodigo();
    });

}

function handleBtnVerClick(parametro) {
    console.log("parametro", parametro);
    sessionStorage.setItem('optionHM', 'ver')


    $.get("/MHilado/HiladoMadrePartial", function (data) {
        BootstrapDialog.show({
            closeByBackdrop: false,
            title: 'Ver Hilado Madre',
            size: BootstrapDialog.SIZE_LARGE,
            message: $(data)
        });
    });

    sleep(500).then(() => {
        loadCombosIni();
        $(txtCodigoHilo).val(parametro.Codigo)
        console.log("EL VALOR DE PARAMETRO CODIGO ES", parametro.Codigo);
        $.blockUI({
            message: '<img src="/Content/Images/loading.gif">',
            css: { border: 'none', background: 'transparent', zIndex: 2000 },
            overlayCSS: {
                backgroundColor: '#000',  // Color de fondo para el overlay
                opacity: 0.6,             // Opacidad del fondo
                zIndex: 2000              // Asegúrate de que el z-index del overlay sea mayor que el del BootstrapDialog
            }

        });
        loadByCodigo();
    });

}

function handleBtnCopyClick(parametro) {
    console.log("parametro", parametro);
    sessionStorage.setItem('optionHM', 'new')


    $.get("/MHilado/HiladoMadrePartial", function (data) {
        BootstrapDialog.show({
            closeByBackdrop: false,
            title: 'Ver Hilado Madre',
            size: BootstrapDialog.SIZE_LARGE,
            message: $(data)
        });
    });

    sleep(500).then(() => {
        loadCombosIni();
        $(txtCodigoHilo).val(parametro.Codigo)
        console.log("EL VALOR DE PARAMETRO CODIGO ES", parametro.Codigo);
        $.blockUI({
            message: '<img src="/Content/Images/loading.gif">',
            css: { border: 'none', background: 'transparent', zIndex: 2000 },
            overlayCSS: {
                backgroundColor: '#000',  // Color de fondo para el overlay
                opacity: 0.6,             // Opacidad del fondo
                zIndex: 2000              // Asegúrate de que el z-index del overlay sea mayor que el del BootstrapDialog
            }

        });

        loadByCodigo();

        sleep(3500).then(() => {

            $(txtCodigoHilo).val(0)
            $("div.panelHEspecificos").hide()
            console.log('eeeeeeeeeee')
            enableTransact()
        })
    });

}

function sleep(time) {
    return new Promise((resolve) => setTimeout(resolve, time));
}

/**
 * /COPIA
 */
function handleBtnEditarClick(parametro) {
    console.log("parametro", parametro);
    sessionStorage.setItem('optionHM', 'edit')


    $.get("/MHilado/HiladoMadrePartial", function (data) {
        BootstrapDialog.show({
            closeByBackdrop: false,
            title: 'Editar Hilado Madre',
            size: BootstrapDialog.SIZE_LARGE,
            message: $(data)
        });
    });
    sleep(500).then(() => {
        loadCombosIni();
        $(txtCodigoHilo).val(parametro.Codigo)
        console.log("EL VALOR DE PARAMETRO CODIGO ES", parametro.Codigo);
        $.blockUI({
            message: '<img src="/Content/Images/loading.gif">',
            css: { border: 'none', background: 'transparent', zIndex: 2000 },
            overlayCSS: {
                backgroundColor: '#000',  // Color de fondo para el overlay
                opacity: 0.6,             // Opacidad del fondo
                zIndex: 2000              // Asegúrate de que el z-index del overlay sea mayor que el del BootstrapDialog
            }
        });
        loadByCodigo();
    });
    

}

//INDEX PAGINAL INICIAL DE HILO MADRE
function openModalAddHEspecificoInBandeja(parametro) {
    console.log("parametro", parametro);



    $.get("/MHilado/ModalHiladoEspecifico", function (data) {
        BootstrapDialog.show({
            closeByBackdrop: false,
            title: 'Hilado Específico',
            size: BootstrapDialog.SIZE_LARGE,
            message: $(data),
            buttons: [
                {
                    label: 'Registrar',
                    id: 'btnDialogokPro',
                    cssClass: 'btn-default transactHE btnSaveHEspecifico',
                    action: function (dialog) {

                        var procesoHilo = $(cmbProcesoHilo).val();
                        var colorHilo = $(lblColorID).text();
                        var descripcionLarga = $(txtDescripcionEspecifico).val();
                        var codigoHiloMadre = $(txtCodigoHiloHMADRE).val();
                        var codigoHiloHijo = $(txtCodigoHiloEspecifico).val();
                        var tipoHiladoMadre = $(cmbTipoHiladoHMADRE).val()
                        var codigoRefProveedor = $(txtCodigoProveedor).val();
                        var descripcionCorta = $(txtDescripcionEspecificoCorta).val();
                        var vvp = $(txtVPPEspecifico).val();
                        if (procesoHilo == null || procesoHilo == undefined || procesoHilo == "" || procesoHilo == "0") {
                            /*$("<div></div>").kendoAlert({
                                title: "Mensaje",
                                content: "Seleccione Proceso Hilado"
                            }).data("kendoAlert").open();*/
                            DevExpress.ui.dialog.alert("Seleccione Proceso Hilado", "Mensaje", "OK");

                            return;
                        }

                        if (colorHilo == null || colorHilo == undefined || colorHilo == "" || colorHilo == "0") {
                            //$("<div></div>").kendoAlert({
                            //    title: "Mensaje",
                            //    content: "Seleccione Color Hilado"
                            //}).data("kendoAlert").open();
                            //return;
                            colorHilo = "";
                        }
                        //if ($("#tblFibrasEspecifico>tbody>tr").length == 0 && $(cmbTipoHiladoHMADRE).val() == "1") {
                        //    AlertMessage("No ha ingresado fibras")
                        //    return;
                        //}
                        //
                        var fibrasInCombo = $('#cmbFibraHE option').toArray().map(it => $(it).val())
                        var fibrasInComboArr = []

                        $.each(fibrasInCombo, function (i, item) {
                            o = { fibra: item, usado: false }
                            fibrasInComboArr.push(o)
                        })
                        console.log(fibrasInComboArr)
                        //var xxx = '02'



                        console.log(fibrasInComboArr)

                        var XML = '<ROOT>'
                        var detalle = []
                        //$("#tblFibrasEspecifico>tbody>tr").each(function (i, tr) {
                        //    XML = XML + '<DETALLE>'
                        //    XML = XML + '<CodigoDetalleFabri>' + '0' + '</CodigoDetalleFabri>'
                        //    XML = XML + '<CodigoTipoFibra>' + $(tr).find('td.tdTipoFibraHEID').text() + '</CodigoTipoFibra>'
                        //    XML = XML + '<Fibra>' + $(tr).find('td.tdFibraHEID').text() + '</Fibra>'
                        //    XML = XML + '</DETALLE>'
                        //    var item = {
                        //        CodigoDetalleFabri: "0",
                        //        CodigoTipoFibra: $(tr).find('td.tdTipoFibraHEID').text(),
                        //        CodigoFibra: $(tr).find('td.tdFibraHEID').text()
                        //    }
                        //    detalle.push(item);

                        //    $.each(fibrasInComboArr, function (i, item) {
                        //        if (item.fibra.trim() == $(tr).find('td.tdFibraHEID').text().trim()) {
                        //            item.usado = true
                        //        }
                        //    })
                        //})

                        //var isValid = true
                        //if (fibrasInCombo.length == 0) { isValid = false };
                        /*   if ($("#tblFibrasEspecifico>tbody>tr").length==0) { isValid = false };*/



                        //$.each(fibrasInComboArr, function (i, item) {
                        //    if (item.usado == false) {
                        //        isValid = false
                        //    }
                        //})
                        //debugger
                        //console.log(isValid)
                        //debugger
                        //if ($(cmbTipoHiladoHMADRE).val() == 1) {
                        //    if (isValid == false) {
                        //        $("<div></div>").kendoAlert({
                        //            title: "Mensaje",
                        //            content: "Debe especificar en todos las Fibras"
                        //        }).data("kendoAlert").open();
                        //        $(cmbFibraHE).selectpicker('toggle');
                        //        return;
                        //    }
                        //}

                        XML = XML + '</ROOT>'
                        var encodeXML = encodeURIComponent(XML);
                        var o = {
                            Nombre: descripcionLarga,
                            DescripcionLarga: descripcionLarga,
                            CodigoHiloComer: codigoHiloMadre,
                            ColCCod: colorHilo.substring(0, 6),
                            TTeCCod: colorHilo.substring(6, 7),
                            CodigoAcadoHilo: procesoHilo,
                            CodigoRefProveedor: codigoRefProveedor,
                            TipoHiladoConfigurado: tipoHiladoMadre,
                            CodigoHiloFabri: codigoHiloHijo,
                            //UsuarioCreacion: $(lblUserId).text().trim(),
                            //UsuarioCreacion: $(lblUserId).text().trim(),
                            descripcionCorta: descripcionCorta,
                            VPP: vvp,
                            detalle: detalle,
                            DetalleXml: encodeXML,
                            Estado_DES: $('#chkEstadoEspecifico').prop('checked') == true ? 'A' : 'I'
                        }
                        console.log(o)

                        //debugger;
                        // Realizando Ajax
                        $.ajax({
                            type: "POST",
                            url: '/HiloEspecifico/InsertHiladoE',
                            data: o,                            
                            success: function (data) {
                                var rpt = JSON.parse(data);
                                console.log(rpt);
                                desbloqObject();

                                if (rpt.status == 1) {
                                    $(txtCodigoHiloEspecifico).val(rpt.codigo.replaceAll('"', ''));
                                    //loadHiloEspecificoBandeja('');
                                    //onChangeHMadre()
                                    //AlertMessage("Hilo Específico generado: " + rpt.codigo.replaceAll('"', ''))
                                    DevExpress.ui.dialog.alert("Hilo Específico generado: " + rpt.codigo.replaceAll('"', ''), "Alerta", "OK");

                                    $("button.btnSaveHEspecifico").closest('div.bootstrap-dialog').modal('hide')
                                } else if (rpt.status == 0) {
                                    //AlertMessage("Ya existe un registro con las mismas características (" + rpt.codigo.replaceAll('"', '') + ')')
                                    DevExpress.ui.dialog.alert("Ya existe un registro con las mismas características (" + rpt.codigo.replaceAll('"', '') + ')', "Alerta", "OK");

                                }
                                //loadListHilados();

                                //AlertMessage("Hilo Específico generado: " + data.replaceAll('"', ''))
                                var dataGrid2 = $('#gridContainerHijo').dxDataGrid('instance');

                                dataGrid2.refresh();


                                //if (!data.result) {
                                //    AlertMessage(data.msg);
                                //    console.log(data.msg);
                                //}
                                //else {
                                //    AlertMessage(data.msg);
                                //    ReloadGrid();
                                //    dialog.close();
                                //}
                            },
                            dataType: 'text',
                        }).fail(function (jqxhr, textStatus, error) {
                            console.log("Request Failed: " + error);
                            desbloqObject();
                        });
                    },
                    error: function (e) {
                        console.log("Error obtener Datos de Procesos : [ " + e + " ]")
                    }
                },
                {
                    label: 'Cerrar',
                    action: function (dialogRef) {
                        dialogRef.close();
                    }
                }]
        });
    });



    sleep(500).then(() => {
        /*$('select').selectpicker();
        $('#chkEstadoEspecifico').bootstrapToggle({
            on: 'Activo',
            off: 'Inactivo'
        }).bootstrapToggle('enable');*/
        //rowSelected = gridoRp.dataItem(selectedItemRp)
        $(txtCodigoHiloEspecifico).val('0')
        console.log(123)
        console.log("PRUEBA CARGAR")
        //debugger;
        $(txtCodigoHiloHMADRE).val(parametro.Codigo.trim());
        loadHMadreByCodigo(parametro.Codigo.trim());
        sleep(500).then(() => {
            console.log('cmbProcesoHilo')
            console.log($(cmbProcesoHilo).text())
            loadHijoByCodigo()
            $.blockUI({
                message: '<img src="/Content/Images/loading.gif">',
                css: { border: 'none', background: 'transparent', zIndex: 2000 },
                overlayCSS: {
                    backgroundColor: '#000',  // Color de fondo para el overlay
                    opacity: 0.6,             // Opacidad del fondo
                    zIndex: 2000              // Asegúrate de que el z-index del overlay sea mayor que el del BootstrapDialog
                }
            });
        })

    });



}






//INDEX PAGINAL INICIAL DE HILO HIJJO

function openModalBandejaHEspecifico(parametro, updInt) {
    console.log("parametro", parametro);


    $.get("/MHilado/ModalHiladoEspecifico", function (data) {

        BootstrapDialog.show({
            closeByBackdrop: false,
            title: 'Hilado Específico',
            type: BootstrapDialog.TYPE_PRIMARY,
            closeByBackdrop: false,
            //size: BootstrapDialog.SIZE_LARGE,
            message: $(data),
            buttons: [
                {
                    label: 'Registrar',
                    id: 'btnDialogokPro',
                    cssClass: 'btn-default transactHE btnSaveHEspecifico',
                    action: function (dialog) {

                        var procesoHilo = $(cmbProcesoHilo).val();
                        var colorHilo = $(lblColorID).text();
                        var descripcionLarga = $(txtDescripcionEspecifico).val()
                        var codigoHiloMadre = $(txtCodigoHiloHMADRE).val();
                        var codigoHiloHijo = $(txtCodigoHiloEspecifico).val();
                        var tipoHiladoMadre = $(cmbTipoHiladoHMADRE).val()
                        var codigoRefProveedor = $(txtCodigoProveedor).val();
                        var descripcionCorta = $(txtDescripcionEspecificoCorta).val();
                        var vvp = $(txtVPPEspecifico).val();
                        console.log("procesoHilo", procesoHilo);
                        if ($('#chkEstadoMadre').prop('checked') == false) {
                            Swal.fire({
                                icon: 'error',
                                title: 'Oops...',
                                text: "El Hilo Madre se encuentra inactivo"
                            })
                            return;
                        }

                        if (procesoHilo == null || procesoHilo == undefined || procesoHilo == "" || procesoHilo == "0") {
                            $("<div></div>").kendoAlert({
                                title: "Mensaje",
                                content: "Seleccione Proceso Hilado"
                            }).data("kendoAlert").open();
                            return;
                        }

                        if (colorHilo == null || colorHilo == undefined || colorHilo == "" || colorHilo == "0") {
                            //$("<div></div>").kendoAlert({
                            //    title: "Mensaje",
                            //    content: "Seleccione Color Hilado"
                            //}).data("kendoAlert").open();
                            //return;
                            colorHilo = "";
                        }
                        //if ($("#tblFibrasEspecifico>tbody>tr").length == 0 && $(cmbTipoHiladoHMADRE).val() == "1") {
                        //    AlertMessage("No ha ingresado fibras")
                        //    return;
                        //}

                        var detalle = []
                        var XML = '<ROOT>'
                        $("#tblFibrasEspecifico>tbody>tr").each(function (i, tr) {
                            XML = XML + '<DETALLE>'
                            XML = XML + '<CodigoDetalleFabri>' + '0' + '</CodigoDetalleFabri>'
                            XML = XML + '<CodigoTipoFibra>' + $(tr).find('td.tdTipoFibraHEID').text() + '</CodigoTipoFibra>'
                            XML = XML + '<Fibra>' + $(tr).find('td.tdFibraHEID').text() + '</Fibra>'
                            XML = XML + '</DETALLE>'


                            var item = {
                                CodigoDetalleFabri: "0",
                                CodigoTipoFibra: $(tr).find('td.tdTipoFibraHEID').text(),
                                CodigoFibra: $(tr).find('td.tdFibraHEID').text()
                            }
                            detalle.push(item);
                        })
                        XML = XML + '</ROOT>'
                        var encodeXML = encodeURIComponent(XML);
                        var o = {
                            Nombre: descripcionLarga,
                            DescripcionLarga: descripcionLarga,
                            CodigoHiloComer: codigoHiloMadre,
                            ColCCod: colorHilo.substring(0, 6),
                            TTeCCod: colorHilo.substring(6, 7),
                            CodigoAcadoHilo: procesoHilo,
                            CodigoRefProveedor: codigoRefProveedor,
                            TipoHiladoConfigurado: tipoHiladoMadre,
                            CodigoHiloFabri: codigoHiloHijo,
                            //UsuarioCreacion: $(lblUserId).text().trim(),
                            descripcionCorta: descripcionCorta,
                            VPP: vvp,
                            detalle: detalle,
                            DetalleXml: encodeXML,
                            Estado_DES: $('#chkEstadoEspecifico').prop('checked') == true ? 'A' : 'I'
                        }
                        console.log(o)
                        //debugger;
                        // Realizando Ajax
                        $.ajax({
                            
                            url: '/HiloEspecifico/InsertHiladoE',
                            type: 'POST',
                            dataType: 'text',
                            data: o,
                           
                            success: function (data) {
                                console.log(data);
                                desbloqObject();
                                var rpt = JSON.parse(data)
                                //loadListHilados();
                                //$(txtCodigoHiloEspecifico).val(data.replaceAll('"', ''));
                                //AlertMessage("Hilo Específico generado: " + data.replaceAll('"', ''))
                                //loadHiloEspecificoBandeja();

                                if (rpt.status == 1) {
                                    $(txtCodigoHiloEspecifico).val(rpt.codigo.replaceAll('"', ''));
                                    //loadListHilados();
                                    //loadHiloEspecificoBandeja2();
                                    //loadHiloEspecificoBandeja();
                                    //onChangeHMadre()
                                    if (updInt == 1) {
                                        //AlertMessage("Hilo Específico actualizado: " + rpt.codigo.replaceAll('"', ''))
                                        DevExpress.ui.dialog.alert("Hilo Específico actualizado: " + rpt.codigo.replaceAll('"', ''), "Alerta", "OK");

                                    } else {
                                        //AlertMessage("Hilo Específico generado: " + rpt.codigo.replaceAll('"', ''))
                                        DevExpress.ui.dialog.alert("Hilo Específico generado: " + rpt.codigo.replaceAll('"', ''), "Alerta", "OK");

                                    }

                                    $("button.btnSaveHEspecifico").closest('div.bootstrap-dialog').modal('hide')

                                } else if (rpt.status == 0) {
                                    //AlertMessage("Ya existe un registro con las mismas características (" + rpt.codigo.replaceAll('"', '') + ')')
                                    DevExpress.ui.dialog.alert("Ya existe un registro con las mismas características (" + rpt.codigo.replaceAll('"', '') + ')', "Alerta", "OK");

                                }

                                //if (!data.result) {
                                //    AlertMessage(data.msg);
                                //    console.log(data.msg);
                                //}
                                //else {
                                //    AlertMessage(data.msg);
                                //    ReloadGrid();
                                //    dialog.close();
                                //}
                            }
                        }).fail(function (jqxhr, textStatus, error) {
                            console.log("Request Failed: " + error);
                            desbloqObject();
                        });
                    },
                    error: function (e) {
                        console.log("Error obtener Datos de Procesos : [ " + e + " ]")
                    }
                },
                {
                    label: 'Cerrar',
                    action: function (dialogRef) {
                        dialogRef.close();
                    }
                }]

        });
    });

    
   

    sleep(500).then(() => {
       /* $('select').selectpicker();
        $('#chkEstadoEspecifico').bootstrapToggle({
            on: 'Activo',
            off: 'Inactivo'
        }).bootstrapToggle('enable');*/
        $(txtCodigoHiloEspecifico).val('0')

        //debugger;
        //$(txtCodigoHiloHMADRE).val(rowSelected.Codigo.trim());
        console.log('12345')
        console.log(parametro.HCoCCod)
        $(txtCodigoHiloHMADRE).val(parametro.HCoCCod);
        $(txtCodigoHiloEspecifico).val(parametro.CodigoHiloFabri)
        loadHMadreByCodigo(parametro.HCoCCod.trim());
        sleep(500).then(() => {
            console.log('cmbProcesoHilo')
            console.log($(cmbProcesoHilo).text())
            $.blockUI({
                message: '<img src="/Content/Images/loading.gif">',
                css: { border: 'none', background: 'transparent', zIndex: 2000 },
                overlayCSS: {
                    backgroundColor: '#000',  // Color de fondo para el overlay
                    opacity: 0.6,             // Opacidad del fondo
                    zIndex: 2000              // Asegúrate de que el z-index del overlay sea mayor que el del BootstrapDialog
                }
            });
            loadHijoByCodigo(0)
            sleep(500).then(() => {
                if (updInt == 3) {
                    $(txtCodigoHiloEspecifico).val('')
                }

                enableTransactHE()
                if (updInt == 2) {
                    disableTransactHE()
                }
            })



        })



        //loadHijoByCodigo()
    });

    

}


