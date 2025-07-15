function ViewPDF(iframeId, byteBase64) {
    document.getElementById(iframeId).innerHTML = "";
    var iframe = document.createElement('iframe');
    iframe.setAttribute("src", "data:application/pdf;base64," + byteBase64);
    iframe.style.width = "100%";
    iframe.style.height = "680px";
    document.getElementById(iframeId).appendChild(iframe);
}


