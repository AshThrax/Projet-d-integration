﻿using Blazor.UI.data.modelViews;

namespace Blazor.UI.Data.modelViews.Theater;

public class TicketDto : Baseview
{
    public string? Titre { get; set; }
    public string? Representation { get; set; }
    public string? Piecetitle { get; set; }
    public string? SalleName { get; set; }
    public int CommandId { get; set; }
}
public class AddTicketDto
{
    public string? Titre { get; set; }
    public string? Representation { get; set; }
    public string? Piecetitle { get; set; }
    public string? SalleName { get; set; }

}