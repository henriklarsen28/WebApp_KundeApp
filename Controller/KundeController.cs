using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KundeApp1.Models;
using Microsoft.Extensions.Logging;

using KundeApp1.DAL;

namespace KundeApp1
{
    [Route("[controller]/[action]")]
    public class KundeController : ControllerBase
    {
        private readonly IKundeRepository _rep;

        public KundeController(IKundeRepository rep)
        {
            _rep = rep;
        }

        public async Task<List<Kunde>> HentAlle()
        {
            return await _rep.HentAlle();
        }


        public async Task<bool> Slett(int id)
        {
            return await _rep.Slett(id);
        }

        public async Task<Kunde> HentEn(int id)
        {
            return await _rep.HentEn(id);
        }

        public async Task<bool> Endre(Kunde endreKunde)
        {
            return await _rep.Endre(endreKunde);
        }

        public async Task<bool> Lagre(Kunde nykunde)
        {
            return await _rep.Lagre(nykunde);
        }
    }
}
