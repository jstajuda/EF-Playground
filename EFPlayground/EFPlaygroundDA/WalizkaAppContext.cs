using EFPlaygroundBL;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPlaygroundDA
{
    public class WalizkaAppContext : DbContext
    {
        public WalizkaAppContext() : base("EFPlaygroundDB")
        {
            // przy każdym uruchomieniu aplikacji kasuje bazę i tworzy nową
            // przy okazji zapełnia bazę przykładowymi danymi
            // (klasa WalizkaAppDbInitializer zdefiniowana niżej)
            // wywala wyjątek jeżeli są jakiekolwiek otwarte połączenia z bazą (nawet server explorer w vs)
            Database.SetInitializer<WalizkaAppContext>(new WalizkaAppDBInitializer());

            // tworzy pustą bazę danych jeśli nie istnieje - dobre na produkcję
            //Database.SetInitializer<WalizkaAppContext>(new CreateDatabaseIfNotExists<WalizkaAppContext>());
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ListOfItems> ListsOfItems { get; set; }
        public DbSet<Param> Params { get; set; }
        public DbSet<ParamGroup> ParamsGroups { get; set; }
       
    }

    public class WalizkaAppDBInitializer : DropCreateDatabaseAlways<WalizkaAppContext>
    {
        protected override void Seed(WalizkaAppContext context)
        {

            #region Categories Seed
            IList<Category> defaultCategories = new List<Category>();
            defaultCategories.Add(new Category() { Name = "Odzież", Description = "Ubrania" });
            defaultCategories.Add(new Category() { Name = "Obuwie", Description = "Buty - te opisy sa chyba zbedne ;)" });
            defaultCategories.Add(new Category() { Name = "Higiena", Description = "Waciki etc" });
            defaultCategories.Add(new Category() { Name = "Elektronika", Description = "Akcesoria" });
            defaultCategories.Add(new Category() { Name = "Inne", Description = "Tu pasuje wszystko" });            
            #endregion

            #region Items Seed
            IList<Item> defaultItems = new List<Item>();
            var cat = defaultCategories[0]; //Odzież
            defaultItems.Add(new Item() { Name = "Sweter", Description = "Różowy w niebieskie grochy", CategoryId = cat.Id, Category = cat });
            defaultItems.Add(new Item() { Name = "Bluza", Description = "Ziomalska z kapturem", CategoryId = cat.Id, Category = cat });
            defaultItems.Add(new Item() { Name = "Jeansy", Description = "Poszarpane na wygląd bezdomnego", CategoryId = cat.Id, Category = cat });
            defaultItems.Add(new Item() { Name = "Spodnie", Description = "Czarne wyjściowe", CategoryId = cat.Id, Category = cat });
            defaultItems.Add(new Item() { Name = "Rękawiczki", Description = "Wełniane od babci", CategoryId = cat.Id, Category = cat });

            cat = defaultCategories[1]; //Obuwie
            defaultItems.Add(new Item() { Name = "Trampki", Description = "Zielone świecące w ciemności", CategoryId = cat.Id, Category = cat });
            defaultItems.Add(new Item() { Name = "Półbuty", Description = "Brązowe skórzane z wyprzedaży w Stonce", CategoryId = cat.Id, Category = cat });
            defaultItems.Add(new Item() { Name = "Trekkingi", Description = "Nieprzemakalne samochodzące z gpsem", CategoryId = cat.Id, Category = cat });
            defaultItems.Add(new Item() { Name = "Sandały", Description = "Jesus style", CategoryId = cat.Id, Category = cat });

            cat = defaultCategories[2]; //Higiena
            defaultItems.Add(new Item() { Name = "Waciki", Description = "Te za 300 dolarów", CategoryId = cat.Id, Category = cat });
            defaultItems.Add(new Item() { Name = "Ręcznik", Description = "Biały mięciutki jak kaczuszka", CategoryId = cat.Id, Category = cat });
            defaultItems.Add(new Item() { Name = "Żel pod prysznic", Description = "Extra strong only for manly men", CategoryId = cat.Id, Category = cat });
            defaultItems.Add(new Item() { Name = "Szampon", Description = "Z ekstraktem z konopii", CategoryId = cat.Id, Category = cat });
            defaultItems.Add(new Item() { Name = "Dezodorant", Description = "666H super protection", CategoryId = cat.Id, Category = cat });


            cat = defaultCategories[3]; //Elektronika
            defaultItems.Add(new Item() { Name = "Ładowarka USB", Description = "Uniwersalna do wszystkiego", CategoryId = cat.Id, Category = cat });
            defaultItems.Add(new Item() { Name = "Powerbank", Description = "30000 MAh z latarką", CategoryId = cat.Id, Category = cat });
            defaultItems.Add(new Item() { Name = "Myszka", Description = "Ta mała energooszczędna", CategoryId = cat.Id, Category = cat });
            defaultItems.Add(new Item() { Name = "Głośniki", Description = "Bluetooth z extra basem", CategoryId = cat.Id, Category = cat });

            cat = defaultCategories[4]; //Inne
            defaultItems.Add(new Item() { Name = "Miska na wodę", Description = "Psia miska podróżna", CategoryId = cat.Id, Category = cat });
            defaultItems.Add(new Item() { Name = "Książka", Description = "Jakakolwiek na wszelki wypadek", CategoryId = cat.Id, Category = cat });
            defaultItems.Add(new Item() { Name = "Bulbulator", Description = "Niezbędny w podróży", CategoryId = cat.Id, Category = cat });
            defaultItems.Add(new Item() { Name = "Otwieracz do wina", Description = "Must have", CategoryId = cat.Id, Category = cat });
            #endregion

            context.Categories.AddRange(defaultCategories);
            context.Items.AddRange(defaultItems);
            base.Seed(context);
        }
    }
}
