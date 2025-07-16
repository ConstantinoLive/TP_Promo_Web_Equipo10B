function mostrarFormulario() {
    const overlay = document.getElementById('registro-form');
    overlay.classList.add('active');
}

function cerrarFormulario() {
    document.getElementById('registro-form').classList.remove('active');
}

function mostrarFormVoucher(idArticulo) {
    document.getElementById('registro-voucher').classList.add('active');
    const hidden = document.querySelector('input[type="hidden"][id$="hfIdArticulo"]');
    if (hidden) hidden.value = idArticulo;
}




/*
function cerrarFormVoucher() {
    document.getElementById('registro-voucher').classList.remove('active');
   
}*/