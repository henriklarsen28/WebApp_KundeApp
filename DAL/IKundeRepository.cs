using KundeApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KundeApp1.DAL
{
    public interface IKundeRepository
    {
        Task<List<Kunde>> HentAlle();
        Task<bool> Slett(int id);
        Task<Kunde> HentEn(int id);
        Task<bool> Endre(Kunde endreKunde);
        Task<bool> Lagre(Kunde nykunde);
    }
}
