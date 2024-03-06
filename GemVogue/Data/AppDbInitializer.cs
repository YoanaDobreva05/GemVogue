using GemVogue.Data.Enums;
using GemVogue.Data.Models;
using GemVogue.Models;


namespace GemVogue.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder ) 
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context=serviceScope.ServiceProvider.GetService<GemVogueDbContext>();

                context.Database.EnsureCreated();

                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new Producer()
                    {
                        FullName="Pandora",
                        Bio= "Магазина предлага изключителна селекция висококачествени бижута от подбрани колекции за да удовлетворим нуждите на тези, " +
                        "които вярват, че бижутата не са просто аксесоар. " +
                        "При нас всеки може да намери перфектното бижу," +
                        "с което да зарадва себе си, да изненада любим човек или да впечатли с подарък, " +
                        "който ще привлече погледите на всички." +
                        "Освен сертификат за автентичност можете да видите знака ALE щампован на нашите бижута, с изключение само на най-малките ни елементи." +
                        " Еквивалентът във Великобритания е знакът на спонсора, а в Дания – знак на отговорност." +
                        "Нашето стерлингово сребро е маркирано с главно S за сребро, последвано от чистотата на среброто," +
                        " която е цитирана като единици чисто сребро на хиляда: S925 (92.5% чисто сребро).",
                        ProfilePicture = @"\Images\pandora-logo.png"
                    },
                    new Producer()
                    {
                        FullName="Victoria Princess",
                        Bio= "Официалните бижутата са подходящи за различни поводи, като сватби, юбилеи, балове, приеми и други." +
                        " Можете да избирате между разнообразие от модели и стилове, които отговарят на вашите предпочитания и тоалет. " +
                        "Независимо дали предпочитате класически или модерни дизайни, бижутата Victoria Princess ще ви очароват със своята красота и изящество." +
                        "Официалните бижута са не само прекрасен аксесоар, но и ценен подарък за любим човек. " +
                        "Ако искате да изненадате вашата половинка, майка, сестра или приятелка с нещо специално," +
                        " можете да изберете бижу от нашата колекцията, което ще говори вместо вас за вашите чувства и уважение. " +
                        "Бижутата Victoria Princess са символ на любов, приятелство и лоялност.",
                        ProfilePicture= @"\Images\victoria princess-logo.png"
                    },
                    new Producer()
                    {
                        FullName = "Goto",
                        Bio= "GOTO порасна, отвори магазин и в Испания, а с годините се превърна в наложена марка, символ на разнообразие," +
                        " качество и класа, на която повече от 20 000 лоялни клиенти се довериха. " +
                        "Огромна привилегия и чест, носеща със себе си сериозна отговорност." +
                        " Тя ни задължава да продължаваме да се усъвършенстваме, за да сбъднем нашата мисия и най-голяма мечта – името на GOTO да се свързва с любовта, " +
                        "обичта и топлия спомен, облечени в качество и стил на световно ниво.",
                        ProfilePicture= @"\Images\goto-logo.jpg"
                    });
                    context.SaveChanges();

                } if (!context.Jewelry.Any())
                {
                    context.Jewelry.AddRange(new Jewelry()
                    {
                        Name = "Колие Феникс",
                        Description = "Сребърно колие с Феникс." +
                        "Феникса е символ на унищожаване на старият и начало на новият по-добър живот." +
                        "Размер на синджира: с регулиране от 42 до 45 см" +
                        "Размер на феникса: 22x20 мм",
                        Material = "Материал: Сребро, " +
                        "Камъни:кристали цирконий" +
                        "Карат: 925.0",
                        Image = @"\Images\kolie-feniks.jpg",
                        DateOfPosting = DateTime.Now,
                        ProducerId = 3,
                        Type = JewelryType.Necklace

                    },
                    new Jewelry()
                    {
                        Name = "Пръстен със зелен аметист",
                        Description = "Сребърен пръстен с изключително рядка зелена разновидност на скъпоценният камък Аметист." +
                         "Произход на камъка Бразилия." +
                         "Вярва се, че бижутата от аметист помагат на притежателя си да очарова хората около себе си, като засилва харизматичното му излъчване." +
                         "Размер на камъка: 8x6 мм, 2,3 cм",
                        Material = "Материал: Сребро" +
                        "Камъни: скъпоценен камък зелен Аметист" +
                        "Карат: 925.0",
                        Image = @"\Images\prsten-ss-zelen-ametist.jpg",
                        DateOfPosting = DateTime.Now,
                        ProducerId = 1,
                        Type = JewelryType.Ring
                    },
                    new Jewelry()
                    {
                        Name = "Гривна Звездопад",
                        Description = "Гривна Pandora Moments Звездопад." + "Този продукт е съвместим само с модели от колекция Pandora Moments" + "Карат: 925.0",
                        Material = "Материал :Сребро" +
                        "Камъни:Кубичен цирконий, Кристал" +
                        "Карат: 925.0",
                        Image = @"\Images\grivna-zvezdopdad.png",
                        DateOfPosting = DateTime.Now,
                        ProducerId = 1,
                        Type = JewelryType.Braclet
                    },
                    new Jewelry()
                    {
                        Name = " Домът на дракона",
                        Description = "Обеци Game of Thrones x Pandora Домът на дракона",
                        Material = "Материал :Сребро" +
                        "Камъни:Кристал" +
                        "Карат: 925.0",
                        Image = @"\Images\domut-na-drakona.png",
                        DateOfPosting = DateTime.Now,
                        ProducerId = 1,
                        Type = JewelryType.Earring
                    },
                    new Jewelry()
                    {
                        Name = "Сребърен пръстен с диаманти от сапфир",
                        Description = "Дамски сребърен пръстен с 18К бяла позлата и създадени диаманти и сапфир.",
                        Material = "Материал:Сребро" +
                        "Камъни: Създаден диамант, Създадени Скъпоценни Камъни." +
                        "Карат: 925.0",
                        Image = @"\Images\srebaren-prusten-sudadenid-sapfir.jpeg",
                        DateOfPosting = DateTime.Now,
                        ProducerId = 2,
                        Type = JewelryType.Ring
                    },
                    new Jewelry()
                    {
                        Name = "Дамска гривна за крак",
                        Description = " Сребърна дамска гривна за крак-класически стил.",
                        Material = "Материал: Сребро" +
                        "Карат: 925.0",
                        Image = @"\Images\damska-grivna-za-krak.jpeg",
                        DateOfPosting = DateTime.Now,
                        ProducerId = 1,
                        Type = JewelryType.Braclet
                    });
                    context.SaveChanges();
                }
                context.SaveChanges();
            }
        }
    }
}
