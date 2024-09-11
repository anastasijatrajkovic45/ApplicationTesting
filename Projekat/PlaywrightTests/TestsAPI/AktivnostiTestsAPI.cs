using Microsoft.Playwright;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollector.InProcDataCollector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Intrinsics.X86;

namespace PlaywrightTests.TestsAPI
{
    internal class AktivnostiTestsAPI : PlaywrightTest
    {
        private IAPIRequestContext Request;

        [SetUp]
        public async Task SetUpAPITesting()
        {
            var headers = new Dictionary<string, string>
            {
                { "Accept", "application/json" }
            };

            Request = await Playwright.APIRequest.NewContextAsync(new()
            {
                BaseURL = "https://localhost:7193",
                ExtraHTTPHeaders = headers,
                IgnoreHTTPSErrors = true
            });
        }

        [Test]
        public async Task ObrisiAktivnost_NepostojeciId_ReturnsBadRequest()
        {
            int nonExistingId = -1; //nevažeći ID-em

            await using var response = await Request.DeleteAsync($"/AktivnostContoller/ObrisiAktivnost/{nonExistingId}");

            Assert.That(response.Status, Is.EqualTo(404));
            var tekstOdgovora = await response.TextAsync();
            Assert.That(tekstOdgovora, Does.Contain(""));
        }

        [Test]
        public async Task PreuzmiAktivnostiNaPutovanju_PostojeciId_VracaOk()
        {
            int putovanjeId = 1; //id postojeceg putovanja

            await using var response = await Request.GetAsync($"/Aktivnosti/PreuzmiAktivnostiNaPutovanju/{putovanjeId}");

            Assert.That(response.Status, Is.EqualTo(200));
            var jsonResponse = await response.JsonAsync(); 
            Assert.That(jsonResponse, Is.Not.Null);
        }
        [Test]
        public async Task DodajaAktivnostPutovanju_NeispravanId_VracaNotFound()
        {
            var nevalidniId = -1;

            var novaAktivnost = new
            {
                naziv = "Aktivnost",
                cena = 1500
            };

            await using var response = await Request.PostAsync($"/Aktivnosti/DodajAktivnostUPutovanje/{nevalidniId}", new APIRequestContextOptions
            {
                Headers = new Dictionary<string, string>
                {
                    { "Content-Type", "application/json" }
                },
                DataObject = novaAktivnost
            });

            Assert.That(response.Status, Is.EqualTo(404));
            var textResponse = await response.TextAsync();
            Assert.That(textResponse, Does.Contain("Putovanje nije pronađeno."));
        }
        [Test]
        public async Task AzurirajAktivnostPutovanja_NeispravanId_VracaBadRequest()
        {
            int neispravanId = -1;
            var azuriranaAktivnost = new
            {
                naziv = "Obilazak grada",
                cena = 1500
            };

            await using var response = await Request.PutAsync($"/Aktivnosti/AzurirajAktivnost/{neispravanId}", new APIRequestContextOptions
            {
                Headers = new Dictionary<string, string>
        {
            { "Content-Type", "application/json" }
        },
                DataObject = azuriranaAktivnost
            });

            Assert.That(response.Status, Is.EqualTo(400));
            var textResponse = await response.TextAsync();
            Assert.That(textResponse, Does.Contain("Nije uspelo azuriranje aktivnosti!"));
        }
    }
}
