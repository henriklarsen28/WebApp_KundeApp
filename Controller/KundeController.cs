using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KundeApp1.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace KundeApp1
{   
    [Route("[controller]/[action]")]
    public class KundeController : ControllerBase
    {
        private readonly KundeDB _kundeDB;

        private readonly ILogger<KundeController> _logger;

        public KundeController(KundeDB kundeDb)
        {
            _kundeDB = kundeDb;
        }

        public async Task<List<Kunde>> HentAlle() 
        {
            

            try
            {
                List<Kunde> kundene = await _kundeDB.Kunder.Select(k=> new Kunde
                {
                    id = k.id,
                    fornavn = k.fornavn,
                    etternavn = k.etternavn,
                    adresse = k.adresse,
                    postnr = k.poststed.postnr,
                    poststed = k.poststed.postnr
                }).ToListAsync();
                Console.WriteLine("Henter kunder");
                return kundene;
            }
            catch
            {
                return null;  // Returnerer tom liste
            }
        }


        public async Task<bool> Slett(int id)
        {
            try
            {
                Kunder enKunde = _kundeDB.Kunder.Find(id);
                _kundeDB.Kunder.Remove(enKunde);
                await _kundeDB.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Kunde> HentEn(int id)
        {
            try
            {
                Kunder enKunde = await _kundeDB.Kunder.FindAsync(id);
                var hentetKunde = new Kunde()
                {
                    id = enKunde.id,
                    fornavn = enKunde.fornavn,
                    etternavn = enKunde.etternavn,
                    adresse = enKunde.adresse,
                    postnr = enKunde.poststed.postnr,
                    poststed = enKunde.poststed.postnr
                };
                return hentetKunde;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Endre(Kunde endreKunde)
        {
            try
            {
                Kunder enKunde = await _kundeDB.Kunder.FindAsync(endreKunde.id);
                if(enKunde.poststed.postnr != endreKunde.postnr)
                {
                    var sjekkpoststed = _kundeDB.Poststeder.Find(endreKunde.postnr);
                    if(sjekkpoststed == null)
                    {
                        var nyttpoststed = new Poststeder();
                        nyttpoststed.postnr = endreKunde.postnr;
                        nyttpoststed.poststed = endreKunde.poststed;
                        enKunde.poststed = nyttpoststed;
                    }
                    else
                    {
                        enKunde.poststed = sjekkpoststed;
                    }
                }
                enKunde.fornavn = endreKunde.fornavn;
                enKunde.etternavn = endreKunde.etternavn;
                enKunde.adresse = endreKunde.adresse;

                await _kundeDB.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Lagre(Kunde nykunde)
        {
            try
            {
                var kunde = new Kunder
                {
                    fornavn = nykunde.fornavn,
                    etternavn = nykunde.etternavn,
                    adresse = nykunde.adresse


                };
                var sjekkPoststed = _kundeDB.Poststeder.Find(nykunde.postnr);
                if(sjekkPoststed == null)
                {
                    var nyttPoststed = new Poststeder();
                    nyttPoststed.postnr = nykunde.postnr;
                    nyttPoststed.poststed = nykunde.poststed;
                    kunde.poststed = nyttPoststed;
                }
                else
                {
                    kunde.poststed = sjekkPoststed;
                }
                

                _kundeDB.Kunder.Add(kunde);
                await _kundeDB.SaveChangesAsync();
               
                return true;
            }
            catch
            {
                return false;
            }
           
        }
    }
}
