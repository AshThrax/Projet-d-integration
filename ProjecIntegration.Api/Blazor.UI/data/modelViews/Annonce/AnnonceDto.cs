﻿using Blazor.UI.Data.modelViews;

namespace Blazor.UI.data.modelViews.Annonce;

public class AnnonceDto :MongoView
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int PieceId { get; set; }
    public EPrioirity Priority { get; set; }
}
public enum EPrioirity
{
    low = 0,
    high = 1
}