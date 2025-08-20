const baseURL = 'https://localhost:7290/api/phieu_hen/';

export async function createPDF(idCN, idVaoVien, maLoaiCLS, idNoiDungHen) {
    return new Promise((resolve, reject) => {
        $.ajax({
            url: baseURL,
            type: 'POST',
            xhrFields: {
                responseType: 'blob'   // Nhận file PDF dạng blob
            },
            contentType: 'application/json',
            data: JSON.stringify({
                idChiNhanh: Number(idCN),
                idVaoVien: Number(idVaoVien),
                maLoaiCLS: maLoaiCLS,
                idNoiDungHen: Number(idNoiDungHen)  
            }),
            success: function (response) {
                console.log("Dữ liệu nhận được:", response);

                const file = new Blob([response], { type: 'application/pdf' });
                const fileURL = URL.createObjectURL(file);

                resolve(fileURL)
            },
            error: function (xhr, status, error) {
                console.log("Lỗi:", error);

                reject(error)
            }
        });
    })
}