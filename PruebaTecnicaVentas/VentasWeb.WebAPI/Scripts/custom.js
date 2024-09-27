function alertar() {
alert('Hola Mundo');
}

function runScript(script){
    setTimeout(script,
        2000);
}

function showSpinner() {
    $('#spinner').fadeIn(() => {
        $('#spinner').addClass('show');
        $('#spinner').removeClass('visually-hidden');
    });
}

function hideSpinner() {
    $('#spinner').fadeOut(() => {
        $('#spinner').removeClass('show');
        $('#spinner').addClass('visually-hidden');
    });
}