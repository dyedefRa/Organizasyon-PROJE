using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Organizasyon.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<OrganizasyonWebModule>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.InitializeApplication();
        }
    }
}


//Company , Adminin eklediği organızasyonlardan birden çok seçim yapabılecek.
//Her organızasyon ıcın Consept ekleyebılecek.
// 1 organizasyonun 1den cok consepti olabılır
// ve bunu company bazında yapacak ynaı

// 1 Company 1 org 1 conpent
//1 company 1org 2 concept




//Company Information > Hakkında  , iletişim (Açık adress,Konum bilgisi,Şirket e postası,)

//Sıkça sorulan sorular ıle sırketı bagla . ve cevapları 
// ya etiketlerden yada girdi olarak eklesınler(karar ver.)
//company Özelliker için etiketlere bagla.
//Company genel özellikler die bir tablo olsutur 
//Davet Alanları,Mekan Özellikleri vs gibi admin eklesin.
//Company bu ozellıklerden ıstedıgını secıp bunları ıster etıketten ıster gırdı olarak eklesın (karar ver)
//Fiyatlandırma konusunu dusun
//https://dugun.com/kir-dugunu/antalya/golbasi-restaurant
//


//https://github.com/abpframework/abp/blob/dev/modules/identity/src/Volo.Abp.Identity.Web/Pages/Identity/Roles/CreateModal.cshtml