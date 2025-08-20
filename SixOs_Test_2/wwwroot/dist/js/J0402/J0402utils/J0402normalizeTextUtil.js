export function normalizeText(str) {
    return str
        .normalize("NFD") // tách ký tự có dấu thành base + dấu
        .replace(/[\u0300-\u036f]/g, "") // xóa dấu
        .toLowerCase(); // bỏ phân biệt hoa thường
}
function makeAcronym(str) {
    return str
        .normalize("NFD")                   // chuẩn hóa
        .replace(/[\u0300-\u036f]/g, "")    // bỏ dấu
        .toLowerCase()                      // thường hóa
        .split(/\s+/)                       // tách theo khoảng trắng
        .map(word => word[0])               // lấy ký tự đầu
        .join("");                          // ghép thành acronym
}

export function searchAcronym(text, keyword) {
    const acronym = makeAcronym(text);
    const normalizedKeyword = keyword
        .normalize("NFD")
        .replace(/[\u0300-\u036f]/g, "")
        .toLowerCase();
    return acronym.includes(normalizedKeyword);
}
