using KundeApp1.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KundeApp1.DAL
{
    public class InitDb
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<KundeDB>();

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var poststed1 = new Poststeder { postnr = "0353", poststed = "Oslo" };
                var poststed2 = new Poststeder { postnr = "0145", poststed = "Oslo" };

                var kunde1 = new Kunder { fornavn = "Ole", etternavn = "Hansen", adresse = "Bogstadveien 3", poststed = poststed1 };
                var kunde2 = new Kunder { fornavn = "Line", etternavn = "Andersen", adresse = "Karl Johansgate 2", poststed = poststed2 };

                context.Kunder.Add(kunde1);
                context.Kunder.Add(kunde2);

                context.SaveChanges();
            }
        }
    }
}
