const baseURL = 'https://localhost:7290/api/noi_dung_hen/'

export async function fetchDbLoaiCLS(maLoaiCLS) {
    return new Promise((resolve, reject) => {
        $.ajax({
            url: baseURL + maLoaiCLS,
            type: 'GET',
            dataType: 'json',
            data: {},
            success: function (response) {
                console.log("Dữ liệu nhận được:", response);

                resolve(response)
            },
            error: function (xhr, status, error) {
                console.log("Lỗi:", error);
   
                reject(error)
            }
        });
    })
}
