import { normalizeText, searchAcronym } from "../J0402utils/J0402normalizeTextUtil.js";

export async function initAppointmentType(DSLoaiCLS) {
    try {
        var htmlContent = ''

        await DSLoaiCLS.forEach(item => {
            htmlContent += `
            <div class="appointment-body-item">
                <input id="${item.id}" value="${item.id}" type="radio" name="appointment-type" />
                <label for="${item.id}">
                    ${item.tenMau}
                </label>
            </div>`
        });

        return htmlContent;
    } catch (error) {
        console.error('Error fetching data:', error);

        return '';
    }
}

export async function searchAppointmentType(searchName, data) {
    var htmlContent = ''

    await data.forEach(item => {
        if (normalizeText(item.tenMau).includes(normalizeText(searchName)) || searchAcronym(item.tenMau, normalizeText(searchName))) {
            htmlContent += `
            <div class="appointment-body-item">
                <input id="${item.id}" value="${item.id}" type="radio" name="appointment-type" />
                <label for="${item.id}">${item.tenMau}</label>
            </div>`
        }
    });

    return htmlContent;
}