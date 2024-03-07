using GemVogue.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GemVogue.Data.Enums;
using Microsoft.AspNetCore.Identity;

namespace GemVogue.Data
{
    public class GemVogueDbContext : IdentityDbContext<User>
    {
        public GemVogueDbContext(DbContextOptions<GemVogueDbContext> options)
            : base(options)
        {
        }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<Favorite> Favorites { get; set; }

        public DbSet<Jewel> Jewelry { get; set; }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Jewel>()
                .HasOne(j => j.Producer)
                .WithMany(p => p.Jewels)
                .HasForeignKey(j => j.ProducerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Favorite>()
                .HasKey(f => new { f.JewelId, f.UserId });

            builder.Entity<Favorite>()
                .HasOne(f => f.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Favorite>()
                .HasOne(f => f.Jewel)
                .WithMany(j => j.Favorites)
                .HasForeignKey(f => f.JewelId)
                .OnDelete(DeleteBehavior.Cascade);

            var roleId = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>()
                .HasData(new IdentityRole()
                {
                    Id = roleId,
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                    ConcurrencyStamp = roleId
                });

            var adminId = Guid.NewGuid().ToString();

            var admin = new User()
            {
                Id = adminId,
                Email = "admin@gemvogue.com",
                NormalizedEmail = "ADMIN@GEMVOGUE.COM",
                EmailConfirmed = true,
                UserName = "admin@gemvogue.com",
                NormalizedUserName = "ADMIN@GEMVOGUE.COM",
                Name = "Администратор"
            };

            var ph = new PasswordHasher<User>();
            admin.PasswordHash = ph.HashPassword(admin, "Admin_GemVogue_2024");

            builder.Entity<User>()
                .HasData(admin);

            builder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>()
                {
                    UserId = adminId,
                    RoleId = roleId
                });

            builder.Entity<Producer>()
                .HasData(
                    new Producer() 
                    {
                        Id = 1,
                        FullName = "Pandora",
                        Bio = "Магазина предлага изключителна селекция висококачествени бижута от подбрани колекции за да удовлетворим нуждите на тези, " +
                            "които вярват, че бижутата не са просто аксесоар. " +
                            "При нас всеки може да намери перфектното бижу," +
                            "с което да зарадва себе си, да изненада любим човек или да впечатли с подарък, " +
                            """който ще привлече погледите на всички.""" +
                            "Освен сертификат за автентичност можете да видите знака ALE щампован на нашите бижута, с изключение само на най-малките ни елементи." +
                            " Еквивалентът във Великобритания е знакът на спонсора, а в Дания – знак на отговорност." +
                            "Нашето стерлингово сребро е маркирано с главно S за сребро, последвано от чистотата на среброто," +
                            " която е цитирана като единици чисто сребро на хиляда: S925 (92.5% чисто сребро).",
                        ProfilePicture = @"\Images\pandora-logo.png"
                    }, 
                    new Producer()
                    {
                        Id = 2,
                        FullName = "Victoria Princess",
                        Bio = "Официалните бижутата са подходящи за различни поводи, като сватби, юбилеи, балове, приеми и други." +
                        " Можете да избирате между разнообразие от модели и стилове, които отговарят на вашите предпочитания и тоалет. " +
                        "Независимо дали предпочитате класически или модерни дизайни, бижутата Victoria Princess ще ви очароват със своята красота и изящество." +
                        "Официалните бижута са не само прекрасен аксесоар, но и ценен подарък за любим човек. " +
                        "Ако искате да изненадате вашата половинка, майка, сестра или приятелка с нещо специално," +
                        " можете да изберете бижу от нашата колекцията, което ще говори вместо вас за вашите чувства и уважение. " +
                        "Бижутата Victoria Princess са символ на любов, приятелство и лоялност.",
                        ProfilePicture = @"\Images\victoria princess-logo.png"
                    },
                    new Producer()
                    {
                        Id = 3,
                        FullName = "Goto",
                        Bio = "GOTO порасна, отвори магазин и в Испания, а с годините се превърна в наложена марка, символ на разнообразие," +
                        " качество и класа, на която повече от 20 000 лоялни клиенти се довериха. " +
                        "Огромна привилегия и чест, носеща със себе си сериозна отговорност." +
                        " Тя ни задължава да продължаваме да се усъвършенстваме, за да сбъднем нашата мисия и най-голяма мечта – името на GOTO да се свързва с любовта, " +
                        "обичта и топлия спомен, облечени в качество и стил на световно ниво.",
                        ProfilePicture = @"\Images\goto-logo.jpg"
                    });

            builder.Entity<Jewel>()
                .HasData(
                    new Jewel()
                    {
                        Id = 1,
                        Name = "Колие Феникс",
                        Description = "Сребърно колие с Феникс." +
                            "Феникса е символ на унищожаване на старият и начало на новият по-добър живот." +
                            "Размер на синджира: с регулиране от 42 до 45 см" +
                            "Размер на феникса: 22x20 мм",
                        Material = "Материал: Сребро, " +
                            "Камъни: кристали цирконий" +
                            "Карат: 925.0",
                        Image = @"\Images\kolie-feniks.jpg",
                        CreatedOn = DateTime.Now,
                        ProducerId = 3,
                        Type = JewelryType.Necklace

                    },
                    new Jewel()
                    {
                        Id = 2,
                        Name = "Пръстен със зелен аметист",
                        Description = "Сребърен пръстен с изключително рядка зелена разновидност на скъпоценният камък Аметист." +
                         "Произход на камъка Бразилия." +
                         "Вярва се, че бижутата от аметист помагат на притежателя си да очарова хората около себе си, като засилва харизматичното му излъчване." +
                         "Размер на камъка: 8x6 мм, 2,3 cм",
                        Material = "Материал: Сребро" +
                        "Камъни: скъпоценен камък зелен Аметист" +
                        "Карат: 925.0",
                        Image = @"\Images\prsten-ss-zelen-ametist.jpg",
                        CreatedOn = DateTime.Now,
                        ProducerId = 1,
                        Type = JewelryType.Ring
                    },
                    new Jewel()
                    {
                        Id = 3,
                        Name = "Гривна Звездопад",
                        Description = "Гривна Pandora Moments Звездопад." + "Този продукт е съвместим само с модели от колекция Pandora Moments" + "Карат: 925.0",
                        Material = "Материал :Сребро" +
                        "Камъни: Кубичен цирконий, Кристал" +
                        "Карат: 925.0",
                        Image = @"\Images\grivna-zvezdopdad.png",
                        CreatedOn = DateTime.Now,
                        ProducerId = 1,
                        Type = JewelryType.Bracelet
                    },
                    new Jewel()
                    {
                        Id = 4,
                        Name = " Домът на дракона",
                        Description = "Обеци Game of Thrones x Pandora Домът на дракона",
                        Material = "Материал :Сребро" +
                        "Камъни:Кристал" +
                        "Карат: 925.0",
                        Image = @"\Images\domut-na-drakona.png",
                        CreatedOn = DateTime.Now,
                        ProducerId = 1,
                        Type = JewelryType.Earring
                    },
                    new Jewel()
                    {
                        Id = 5,
                        Name = "Сребърен пръстен с диаманти от сапфир",
                        Description = "Дамски сребърен пръстен с 18К бяла позлата и създадени диаманти и сапфир.",
                        Material = "Материал:Сребро" +
                        "Камъни: Създаден диамант, Създадени Скъпоценни Камъни." +
                        "Карат: 925.0",
                        Image = @"\Images\srebaren-prusten-sudadenid-sapfir.jpeg",
                        CreatedOn = DateTime.Now,
                        ProducerId = 2,
                        Type = JewelryType.Ring
                    },
                    new Jewel()
                    {
                        Id = 6,
                        Name = "Дамска гривна за крак",
                        Description = " Сребърна дамска гривна за крак-класически стил.",
                        Material = "Материал: Сребро" +
                        "Карат: 925.0",
                        Image = @"\Images\damska-grivna-za-krak.jpeg",
                        CreatedOn = DateTime.Now,
                        ProducerId = 1,
                        Type = JewelryType.Bracelet
                    });
        }
    }
}
