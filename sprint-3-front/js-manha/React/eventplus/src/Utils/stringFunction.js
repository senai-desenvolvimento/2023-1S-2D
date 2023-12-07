/**
 * Função que inverte a data do banco de dados
 * @param {*} data 
 * @returns 
 */
export const dateFormatDbToView = data => {
    // EX: 2023-09-30T00:00:00 para 30/09/2023
    data = data.substr(0, 10);     // retorna apenas a data (2023-09-30)
    data = data.split("-");       //retorna um array [2023, 09, 30]
    return `${data[2]} / ${data[1]}/${data[0]}`;     //retorna 30/09/2023
}
