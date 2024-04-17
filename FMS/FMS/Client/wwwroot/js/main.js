function qrcreate(strValue) {
    var qr = document.getElementById("qrcodes");

    // 이전 QR 코드 제거
    qr.innerHTML = "";

    var qrcode = new QRCode(qr, {
        width: 100,
        height: 100
    });

    // QR 생성
    qrcode.makeCode(strValue);
}