
function HacerSubmitConDato(pNombreForm, pHidden, pDato) {
    document.getElementById(pHidden).value = pDato;
    HacerSubmit(pNombreForm);
}

function HacerSubmitConDatoConAction(pNombreForm, pHidden, pDato,pAction) {
    document.getElementById(pHidden).value = pDato;
    document.getElementById(pNombreForm).action = pAction;
    HacerSubmit(pNombreForm);
}

function HacerSubmitConAction(pNombreForm,pAction) {
    document.getElementById(pNombreForm).action = pAction;
    document.getElementById(pNombreForm).method="get";
    HacerSubmit(pNombreForm);
}

function HacerSubmit(pNombreForm){
    document.getElementById(pNombreForm).submit();
}

