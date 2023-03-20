$(function () {
    var l = abp.localization.getResource('Organizasyon');
    var expertDetailModal = new abp.ModalManager(abp.appPath + 'Presenter/ExpertDetail');

    //var getFilter = function () {

    //    return {
    //        presenterNameFilter: $("#PresenterNameFilter").val(),
    //        registrationNumberFilter: $("#RegistrationNumberFilter").val() === '' ? 0 : $("#RegistrationNumberFilter").val(),
    //        tcNumberFilter: $("#TcNumberFilter").val() === '' ? 0 : $("#TcNumberFilter").val(),
    //        expertOneKeyIdFilter: $("#ExpertOneKeyIdFilter").val(),
    //    };
    //};

    var dataTable = $('#CompanyTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(organizasyon.services.company.getList, getFilter),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('SeeExpert'),
                                    action: function (data) {
                                        expertDetailModal.open({ presenterId: data.record.id });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('CompanyName'),
                    data: "name",
                    render: function (data) {
                        return data;
                    }
                },
                {
                    title: l('Description'),
                    data: "description",
                    render: function (data) {
                        return data;
                    }
                },
                {
                    title: l('Phone'),
                    data: "phone",
                    render: function (data) {
                        return data;
                    }
                },
                {
                    title: l('Email'),
                    data: "email",
                    render: function (data) {
                        return data;
                    }
                },
                {
                    title: l('City'),
                    data: "cityId",
                    render: function (data) {
                        return data;
                    }
                },
                {
                    title: l('Disrict'),
                    data: "disrictId",
                    render: function (data) {
                        return data;
                    }
                },
                //{
                //    title: l('TcNumber'),
                //    data: "tcNumber",
                //    render: function (data) {
                //        if (data === null || data === '') {
                //            return '-'
                //        }
                //        return data;
                //    }
                //},
                {
                    title: l('CompanyValidDate'),
                    data: "companyValidDate",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                },
                {
                    title: l('CreatedDate'),
                    data: "createdDate",
                    render: function (data) {
                        if (data === null) {
                            return '-'
                        }
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                }
            ],
            createdRow: function (nRow, aData) {
            }
        })
    );

    $('#btnSearch').on('click', function (e) {
        $('.loading').show();

        dataTable.ajax.reload(() => {
            $('.loading').hide();
        });
    });

    //$('#btnExport').on('click', function (e) {

    //    var formData = new FormData();
    //    formData.append("presenterNameFilter", getFilter().presenterNameFilter);
    //    formData.append("registrationNumberFilter", getFilter().registrationNumberFilter);
    //    formData.append("tcNumberFilter", getFilter().tcNumberFilter);
    //    formData.append("approvalStatusFilter", getFilter().approvalStatusFilter);
    //    formData.append("expertOneKeyIdFilter", getFilter().expertOneKeyIdFilter);

    //    var url = '/Presenter/Index?handler=ExcelExport';

    //    var todayDate = new Date().toISOString().slice(0, 10);
    //    var xmlFileName = 'Mümessil Listesi_' + todayDate + ".xlsx";
    //    xhttp = new XMLHttpRequest();
    //    xhttp.onreadystatechange = function () {
    //        $('.loading').show();
    //        var a;
    //        if (xhttp.readyState === 4 && xhttp.status === 200) {
    //            a = document.createElement('a');
    //            a.href = window.URL.createObjectURL(xhttp.response);
    //            a.download = xmlFileName;
    //            a.style.display = 'none';
    //            document.body.appendChild(a);
    //            a.click();

    //            setTimeout(function () {
    //                $('.loading').hide();
    //            }, 2000);
    //        }
    //    };
    //    xhttp.open("POST", url);
    //    xhttp.setRequestHeader("RequestVerificationToken", $('input:hidden[name="__RequestVerificationToken"]').val());
    //    xhttp.responseType = 'blob';
    //    xhttp.send(formData);

    //});
});