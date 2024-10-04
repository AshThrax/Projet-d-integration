function startCarousels() {
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