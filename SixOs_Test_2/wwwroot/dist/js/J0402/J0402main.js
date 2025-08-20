import { initAppointmentType, searchAppointmentType } from "./J0402modules/J0402appointmentModalModule.js";
import { createPDF } from "./J0402apis/J0402XuatPDFApi.js"
import { fetchDbLoaiCLS } from "./J0402apis/J0402DMloaiCLSApi.js";

var DSLoaiCLS = [];

async function initAppointmentModal() {
    //Khởi tạo danh sách nội dung cuộc hẹn
    const appointmentTypeBody = document.querySelector('.appointment-body');

    appointmentTypeBody.innerHTML = '<div class="appointment-modal-loading">Đang tải danh sách nội dung cuộc hẹn...</div>';

    DSLoaiCLS = await fetchDbLoaiCLS(_maLoaiCLS);

    var content = await initAppointmentType(DSLoaiCLS);

    appointmentTypeBody.innerHTML = content + content + content + content;

    //Gán sự kiện call API khi click vào nút "Xuất PDF"
    const exportPDFButton = document.querySelector('#appointment-btn-export');

    exportPDFButton.addEventListener('click', async () => {
        const selectedType = document.querySelector('input[name="appointment-type"]:checked');
        if (!selectedType) {
            alert("Vui lòng chọn một loại cuộc hẹn.");
            return;
        }

        const idCN = _idcn;
        const idVaoVien = _idVaoVien;
        const maLoaiCLS = _maLoaiCLS;
        const idNoiDungHen = selectedType.value;

        try {
            const fileURL = await createPDF(idCN, idVaoVien, maLoaiCLS, idNoiDungHen);

            const iframe = document.getElementById('pdfFrame');
            iframe.src = fileURL;

            iframe.onload = function () {
                iframe.contentWindow.focus();
                iframe.contentWindow.print();
            };
        } catch (error) {
            console.error("Error creating PDF:", error);

            alert("Đã xảy ra lỗi khi tạo PDF. Vui lòng thử lại sau.");
        }
    });

    //Gán sự kiện tìm kiếm khi click nút tìm
    var searchInput = document.querySelector('.appointment-search-input')

    searchInput.addEventListener('input', async () => {
        var content = await searchAppointmentType(searchInput.value, DSLoaiCLS)

        if (content == "") {
            appointmentTypeBody.innerHTML = "Không tồn tại nội dung phiếu khám phù hợp"
        } else {
            appointmentTypeBody.innerHTML = content
        }
    })
}

document.addEventListener("DOMContentLoaded", () => {
  initAppointmentModal();
});
