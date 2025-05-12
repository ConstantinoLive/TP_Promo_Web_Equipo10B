function mostrarFormulario() {
    const overlay = document.getElementById('registro-form');
    overlay.classList.add('active');
}

function cerrarFormulario() {
    document.getElementById('registro-form').classList.remove('active');
}

function mostrarFormVoucher() {
    const overlay = document.getElementById('registro-voucher');
    overlay.classList.add('active');
}

function cerrarFormVoucher() {
    document.getElementById('registro-voucher').classList.remove('active');
}