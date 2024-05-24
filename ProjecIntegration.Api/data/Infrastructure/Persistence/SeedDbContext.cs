using dataInfraTheather.Infrastructure.Persistence;
using Domain.Entity.TheatherEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace DataInfraTheather.Infrastructure.Persistence
{
    public class SeedDbContext
    {
        public async Task SeedAsync(ApplicationDbContext context)
        {
            if(!context.Theme.Any())
            {
                await context.Theme.AddRangeAsync(GetPreconFiguredTheme());
                _=await context.SaveChangesAsync();
            }
            if (!context.Image.Any())
            {
                await context.Image.AddRangeAsync(GetPreconfiguredImage());
                _ = await context.SaveChangesAsync();
            }
            if (!context.Complexe.Any())
            {
                await context.Complexe.AddRangeAsync(GetPreconFiguredComplexe());
                _ = await context.SaveChangesAsync();
            }

            if (!context.Catalogue.Any())
            {
                await context.Catalogue.AddRangeAsync(GetPreconFiguredCatalogue(context));
                _ = await context.SaveChangesAsync();
            }
            if(!context.SalleDeTheatres.Any())
            {
                await context.SalleDeTheatres.AddRangeAsync(GetPreconFiguredSalle(context));
                _ = await context.SaveChangesAsync();
            }
            if (!context.Pieces.Any())
            {
                await context.Pieces.AddRangeAsync(GetPreconFiguredPiece(context));
                _ = await context.SaveChangesAsync();
            }
            if (!context.Siege.Any())
            {
                 await context.Siege.AddRangeAsync(GetPreconFiguredSiege(context));
                _ = await context.SaveChangesAsync();
            }
        }

        private static List<Piece> GetPreconFiguredPiece(ApplicationDbContext context)
        {
            Theme gettheme= context.Theme.FirstOrDefault(x=>x.Id==1);
            Image getimage= context.Image.FirstOrDefault(x=>x.Id==1);
            return new List<Piece>
            {
                new Piece
                {
                    Description="Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                    Auteur="Mark Aurel",
                    Duree=50,
                    Titre="lorem ipsum",
                    ThemeId=gettheme.Id,
                    Theme= gettheme,
                    Image= getimage,
                    ImageId=getimage.Id,
                    Representations=new(),
                    CreatedDate=DateTime.Now,
                },
                new Piece
                {
                    Description="Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                    Auteur="mark aurel",
                    Duree=50,
                    Titre="lorem ipsum",
                    ThemeId=gettheme.Id,
                    Theme= gettheme,
                    Image= getimage,
                    ImageId=getimage.Id,
                    Representations=new(),
                    CreatedDate=DateTime.Now,
                },
                new Piece
                {
                    Description="Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                    Auteur="mark aurtel",
                    Duree=50,
                    Titre="lorem ipsum",
                    ThemeId=gettheme.Id,
                    Theme= gettheme,
                    Image= getimage,
                    ImageId=getimage.Id,
                    Representations=new(),
                    CreatedDate=DateTime.Now,
                }
            };
        }

        private static List<Complexe> GetPreconFiguredComplexe()
        {
            return new List<Complexe>
           {
               new Complexe
               {
                   Name="Théatre de Poche",
                   Adress="Rue de l'Industrie 12",
                   Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                   CreatedDate=DateTime.Now 
               },
               new Complexe
               {
                   Name="Théatre Royal ",
                   Adress="Sentier de l'Embarcadere 1",
                   Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                   CreatedDate=DateTime.Now 
               },
               new Complexe
               {
                   Name="Théatre de Louvain",
                   Adress="Rue Duquesnoy 5",
                   Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                   CreatedDate=DateTime.Now 
               },
               new Complexe{
                   Name="Théatre de Bruxelles ",
                   Adress="Avenue Louise 196",
                   Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
                   ,CreatedDate=DateTime.Now 
               },
               new Complexe
               {Name="Théatre de la Main",
                   Adress="Rue Blaesstraat 208",
                   Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                   CreatedDate=DateTime.Now },
               new Complexe
               {
                   Name="Futuroscope",
                   Adress="Gretrystraat 46",
                   Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                   CreatedDate=DateTime.Now
               },
           };
        }

        public static List<SalleDeTheatre> GetPreconFiguredSalle( ApplicationDbContext context)
        {
            Complexe getcomplexe= context.Complexe.FirstOrDefault(x=>x.Id==1) ;

            return new List<SalleDeTheatre>
            {
               new SalleDeTheatre
               {
                   Name ="salle 45",
                   ComplexeId=getcomplexe.Id,
                   Complexe=getcomplexe,
                   PlaceMax=45,
                   sieges = new List<Siege>(),
                   Representations=new List<Representation>(),
                   CreatedDate = DateTime.Now,
                  
                
               },
               new SalleDeTheatre
               {
                   Name ="salle 47",
                   ComplexeId=getcomplexe.Id,
                   Complexe=getcomplexe,
                   PlaceMax=45,
                   sieges = new List<Siege>(),
                   Representations=new List<Representation>(),
                   CreatedDate = DateTime.Now,

               },
               new SalleDeTheatre
               {
                   Name ="salle 48",
                   ComplexeId=getcomplexe.Id,
                   Complexe=getcomplexe,
                   PlaceMax=45,
                   sieges = new List<Siege>(),
                   Representations=new List<Representation>(),
                   CreatedDate = DateTime.Now,

               }
            };
        }
        private static List<Siege> GetPreconFiguredSiege(ApplicationDbContext context)
        {
            SalleDeTheatre salleDeTheatre= context.SalleDeTheatres.FirstOrDefault(c=>c.Id==1);
            return new List<Siege>
            {
                new Siege 
                {
                    Name="b45",
                    SalleDeTheatre=salleDeTheatre,
                    SalleId=salleDeTheatre.Id,
                    CreatedDate=DateTime.Now,
                },
                new Siege 
                {
                    Name="b46",
                    SalleDeTheatre=salleDeTheatre,
                    SalleId=salleDeTheatre.Id,
                    CreatedDate=DateTime.Now,
                },
                new Siege
                {
                    Name="b46",
                    SalleDeTheatre=salleDeTheatre,
                    SalleId=salleDeTheatre.Id,
                    CreatedDate=DateTime.Now,
                }
            };
        }

        private static List<Theme> GetPreconFiguredTheme()
        {
            return new List<Theme>
            {
                new Theme{Libelle="Comédie", CreatedDate=new DateTime(), },
                new Theme{Libelle="Drame", CreatedDate=new DateTime(), },
                new Theme{Libelle="Tragedie", CreatedDate=new DateTime(), },
                new Theme{Libelle="Moderne", CreatedDate=new DateTime(), },
                new Theme{Libelle="Huit Clos", CreatedDate=new DateTime(), },
                new Theme{Libelle="Avant gardiste", CreatedDate=new DateTime(), },
                new Theme{Libelle="ComédieMusical", CreatedDate=new DateTime(), },
                new Theme{Libelle="Classic", CreatedDate=new DateTime(), }
            };
        }

        private static List<Image> GetPreconfiguredImage()
        {
            return new List<Image>
            {
                new Image
                {
                    ImageRessource="00ebf450-bba9-406b-95b8-8b3941735f46.jpg",
                    CreatedDate = DateTime.Now,

                },
                new Image
                {
                    ImageRessource="0c689e51-cc55-46b0-88a1-8ebf4955174a.jpg",
                    CreatedDate = DateTime.Now,
                }
            };
        }

        public static List<Catalogue> GetPreconFiguredCatalogue(ApplicationDbContext context)
        {
            Complexe getcomplexe = context.Complexe.FirstOrDefault();

            return new List<Catalogue>
            {
                new Catalogue 
                {
                    Name="hiver",
                    ComplexeId=getcomplexe.Id,
                    Complexe=getcomplexe,
                    Description="catalogue d'hiver",
                    CreatedDate=new DateTime(),
                },
                new Catalogue 
                {
                     Name="été",
                    ComplexeId=getcomplexe.Id,
                    Complexe=getcomplexe,
                    Description="catalogue d'été",
                    CreatedDate=new DateTime(),
                },
                new Catalogue 
                {
                     Name="Primtemps",
                    ComplexeId=getcomplexe.Id,
                    Complexe=getcomplexe,
                    Description="catalogue de Primtemps",
                    CreatedDate=new DateTime(),
                },
            };
        }

    }
}
