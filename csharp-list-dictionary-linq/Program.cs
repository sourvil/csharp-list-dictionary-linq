using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharp_list_dictionary_linq;

namespace csharp_list_dictionary_linq
{
    class Program
    {
        static List<City> lstCity;
        static List<Team> lstTeam;
        static List<Stadium> lstStadium;
        static Dictionary<Team, Stadium> dictTeamStadium;

        static void Main(string[] args)
        {
            #region Set Initial Values

            // Set List Value
            SetCity();
            SetStadium();
            SetTeam();

            // Set Dictionary Value
            SetTeamStadium();

            #endregion

            #region Print Initial Values

            // Print List Value by LINQ Method (lambda expression)
            //PrintCity();
            //PrintTeam();
            //PrintStadium();

            // Print TeamStadium Dictionary Value by LINQ Method (lambda expression)
            //PrintTeamStadium();

            #endregion

            #region LINQ Method Lambda Expression

            // Print LINQ Method (lambda expression)
            //PrintStadiumCapacitySum();
            //PrintStadiumLargeCapacity();

            #endregion

            #region LINQ Query

            // Print LINQ Query
            PrintStadiumCapacitySumByQuery();
            PrintStadiumLargeCapacityByQuery();

            #endregion

            Console.ReadLine();
        }

        #region Print LINQ Query

        private static void PrintStadiumLargeCapacityByQuery()
        {
            Console.WriteLine("Stadium Capacity Largers by Query");
            var largeStadium =
                from stad in lstStadium
                where stad.Capacity > 40000
                orderby stad.Name ascending
                select stad;

            foreach (var stadium in largeStadium)
            {
                Console.WriteLine("Stadyum: {0}, {1}", stadium.Name, stadium.Capacity);
            }
        }

        private static void PrintStadiumCapacitySumByQuery()
        {
            Console.WriteLine("Stadium Capacity Sum by Query");
            int stadiumTotalCapacity =
                (from stadTotal in lstStadium
                 select stadTotal.Capacity
                ).Sum();
            Console.WriteLine(stadiumTotalCapacity.ToString());

            Console.WriteLine("Stadium Count by City");
            var stadiumCountByCity =
                (from team in lstTeam
                 group team by team.TeamCity into groupedTeam
                 select new
                 {
                     GroupedTeamCity = groupedTeam.Key,
                     TeamCityCount = groupedTeam.Count()
                 });
            foreach (var tc in stadiumCountByCity)
            {
                Console.WriteLine("{0},{1}", tc.GroupedTeamCity.Name, tc.TeamCityCount);
            }

            Console.WriteLine("Stadium Capacity by City");
            var stadiumCapacityByCity =
                (from stadium in lstStadium
                 join team in lstTeam on stadium.Name equals team.TeamStadium.Name
                 group stadium by team.TeamCity into groupedCity
                 orderby groupedCity.Key.Name
                 select new
                 {
                     GroupedCity = groupedCity.Key,
                     CityCapacity = groupedCity.Sum(c => c.Capacity)

                 });
            foreach (var tc in stadiumCapacityByCity)
            {
                Console.WriteLine("{0},{1}", tc.GroupedCity.Name, tc.CityCapacity);
            }
        }

        #endregion

        #region Print LINQ Method Lambda Expression

        private static void PrintStadiumLargeCapacity()
        {
            Console.WriteLine("Stadium Capacity Largers");
            foreach (var stadium in lstStadium)
            {
                if (stadium.Capacity > 40000)
                    Console.WriteLine("Stadyum: {0}, {1}", stadium.Name, stadium.Capacity);
            }
        }

        private static void PrintStadiumCapacitySum()
        {
            Console.WriteLine("Stadium Capacity Sum");
            Console.WriteLine(lstStadium.Sum(s => s.Capacity));
        }

        #endregion

        #region Print Initial Values
        private static void PrintTeamStadium()
        {
            Console.WriteLine("Team Stadium");
            foreach (var team in lstTeam)
            {
                Console.WriteLine("{0},{1}, {2}", team.Name, dictTeamStadium[team].Name, dictTeamStadium[team].Capacity);
            }
        }

        private static void PrintStadium()
        {
            Console.WriteLine("Stadium List");
            //foreach (var stadium in lstStadium)
            //{
            //    Console.WriteLine("Stadyum: {0}, {1}", stadium.Name, stadium.Capacity);
            //}
            lstStadium.ForEach(s => Console.WriteLine("{0},{1}", s.Name, s.Capacity));
        }

        private static void PrintTeam()
        {
            Console.WriteLine("Team List");
            foreach (var team in lstTeam)
            {
                Console.WriteLine("{0}:\t{1},{2}", team.Name, team.FoundedYear, team.TeamCity.Name);
            }
        }

        private static void PrintCity()
        {
            Console.WriteLine("City List");
            foreach (var city in lstCity)
            {
                Console.WriteLine("Şehir: {0}, {1}", city.Name, city.Code);
            }
        }

        #endregion

        #region Set Initial Values

        private static void SetTeamStadium()
        {
            dictTeamStadium = new Dictionary<Team, Stadium>();

            foreach (var team in lstTeam)
            {
                dictTeamStadium.Add(team, lstStadium.FirstOrDefault(s => s.Name == team.TeamStadium.Name));
            }
        }

        private static void SetStadium()
        {
            lstStadium = new List<Stadium>();
            lstStadium.Add(new Stadium() { Name = "Tevfik Sırrı Gür", Capacity = 30000 });
            lstStadium.Add(new Stadium() { Name = "Şükrü Saraçoğlu", Capacity = 50000 });
            lstStadium.Add(new Stadium() { Name = "Ali Sami Yen", Capacity = 52000 });
            lstStadium.Add(new Stadium() { Name = "Vodafone Arena", Capacity = 42000 });
            lstStadium.Add(new Stadium() { Name = "İzmir Atatürk", Capacity = 51000 });
            lstStadium.Add(new Stadium() { Name = "Antalya Arena", Capacity = 33000 });
        }

        private static void SetCity()
        {
            lstCity = new List<City>();
            lstCity.Add(new City() { Code = 34, Name = "İstanbul" });
            lstCity.Add(new City() { Code = 33, Name = "Mersin" });
            lstCity.Add(new City() { Code = 7, Name = "Antalya" });
            lstCity.Add(new City() { Code = 35, Name = "İzmir" });
        }

        private static void SetTeam()
        {
            lstTeam = new List<Team>();
            lstTeam.Add(new Team() { Name = "Fenerbahçe", FoundedYear = 1907, TeamCity = lstCity.FirstOrDefault(c => c.Code == 34), TeamStadium = lstStadium.FirstOrDefault(s => s.Name == "Şükrü Saraçoğlu") });
            lstTeam.Add(new Team() { Name = "Galatasaray", FoundedYear = 1905, TeamCity = lstCity.FirstOrDefault(c => c.Code == 34), TeamStadium = lstStadium.FirstOrDefault(s => s.Name == "Ali Sami Yen") });
            lstTeam.Add(new Team() { Name = "Beşiktaş", FoundedYear = 1903, TeamCity = lstCity.FirstOrDefault(c => c.Code == 34), TeamStadium = lstStadium.FirstOrDefault(s => s.Name == "Vodafone Arena") });
            lstTeam.Add(new Team() { Name = "MİY", FoundedYear = 1925, TeamCity = lstCity.FirstOrDefault(c => c.Code == 33), TeamStadium = lstStadium.FirstOrDefault(s => s.Name == "Tevfik Sırrı Gür") });
            lstTeam.Add(new Team() { Name = "Antalya Spor", FoundedYear = 1966, TeamCity = lstCity.FirstOrDefault(c => c.Code == 7), TeamStadium = lstStadium.FirstOrDefault(s => s.Name == "Antalya Arena") });
            lstTeam.Add(new Team() { Name = "Karşıyaka", FoundedYear = 1912, TeamCity = lstCity.FirstOrDefault(c => c.Code == 35), TeamStadium = lstStadium.FirstOrDefault(s => s.Name == "İzmir Atatürk") });
            lstTeam.Add(new Team() { Name = "Göztepe", FoundedYear = 1925, TeamCity = lstCity.FirstOrDefault(c => c.Code == 35), TeamStadium = lstStadium.FirstOrDefault(s => s.Name == "İzmir Atatürk") });

        }

        #endregion
    }
}
