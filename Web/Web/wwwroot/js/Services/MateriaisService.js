let apis = null;
apis = getApisJson();

data: {
    materiais: null;
}
//fazer o acesso das apis com base nos endpoints do JSON
//let uriMateriaisServices = null;
//if (apis !== null && apis.length > 0)
//    uriMateriaisServices = apis[2].val["materiais-construcao"];

async function getMateriais(numItems, unicByMarca, ordPrice, name) {
    let materiais = [];

    await $.ajax('https://localhost:5001/material/lista-filtro',
        {
            async: true,
            method: 'GET',
            contentType: 'application/json',
            data: { numItems, unicByMarca, ordPrice, name },
            success: function (resp) {
                for (i = 0; i < resp.length; i++) {
                    materiais.push(resp[i]);
                }
            }
        }
    ).done(function () {
        console.log("deu bom");
    }).fail(function () {
        console.error("deu ruim");
    });
    return materiais;
}

async function preencheTabela(name) {
    $('#bodyTableMateriais').empty();
    let content = '';
    let materiais = await getMateriais(10, false, 'ASC', name);

    materiais.forEach(val => {
        content += '<tr>';
        content += '<th scope="row">' + val.id + '</th>';
        content += '<td>' + val.nome + '</td>';
        content += '<td>R$' + val.preco + '</td>';
        content += '<td>' + val.marca.nome + '</td>';
        content += '<td>' + val.marca.codigoMarca + '</td>';
        content += '</tr >';
    });

    $('#bodyTableMateriais').append(content)
}

async function initTable() {
    $('#bodyTableMateriais').empty();
    let content = '';
    let materiais = await getMateriais(10, true, 'ASC', null);

    materiais.forEach(val => {
        content += '<tr>';
        content += '<th scope="row">' + val.id + '</th>';
        content += '<td>' + val.nome + '</td>';
        content += '<td>R$' + val.preco + '</td>';
        content += '<td>' + val.marca.nome + '</td>';
        content += '<td>' + val.marca.codigoMarca + '</td>';
        content += '</tr >';
    });

    $('#bodyTableMateriais').append(content)
}

initTable();