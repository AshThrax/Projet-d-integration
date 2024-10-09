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