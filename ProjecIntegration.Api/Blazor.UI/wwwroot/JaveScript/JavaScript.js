export function startCarousels() {
    $('.carousel').carousel({ interval: 4000 });
}

export function ShowModale(elementId)
{
    if (elementId != null && elementId != undifined)
        modaleElement.style.display = "block";
    return "ok"
    else {
        return "error"
    }
}
export function addTooltips() {
    $('[data-toggle="tooltip"]').tooltip({
        trigger: 'hover'
    });
    $('[data-toggle="tooltip"]').on('mouseleave', function () {
        $(this).tooltip('hide');
    });
    $('[data-toggle="tooltip"]').on('click', function () {
        $(this).tooltip('dispose');
    });
}

export function generateAndDownloadPdf(htmlOrElement, filename) {
    const doc = new jspdf.jsPDF({
        orientation: 'p',
        unit: 'pt',
        format: 'a4'
    });

    return new Promise((resolve, reject) => {
        doc.html(htmlOrElement, {
            callback: doc => {
                doc.save(filename);
                resolve();
            }
        });
    });
}

export function generatePdf(htmlOrElement) {
    const doc = new jspdf.jsPDF();
    return new Promise((resolve, reject) => {
        doc.html(htmlOrElement, {
            callback: doc => {
                const output = doc.output("arraybuffer");
                resolve(new Uint8Array(output));
            }
        });
    });
}