using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forestry_test.Models;

namespace Forestry_test.Data
{
    public class DbInitialize
    {
        public static void Initialize(ForestryContext db)
        {
            db.Database.EnsureCreated();
            if(db.Forests.Any())
            {
                return;
            }

            int mazist_number = 10;
            int product_number = 10;
            int sort_number = 10;
            int location_number = 10;
            int appointment_number = 10;
            int forest_number = 10;
            string voc = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
            Random random = new Random(1);

            for(int CarID = 1; CarID < mazist_number; CarID++)
            {
                string FirstName = GetRandom(voc, 5);
                string CarName = GetRandom(voc, 8);
                db.Mazists.Add(new Mazist {
                    FIO = FirstName,
                    CarNumber = CarName
                });
            }
            db.SaveChanges();

            for (int PointID = 1; PointID < appointment_number; PointID++)
            {
                string PointsName = GetRandom(voc, 5);
                db.Appointments.Add(new Appointment
                {
                    PointName = PointsName
                });
            }
            db.SaveChanges();

            for (int SortID = 1; SortID < sort_number; SortID++)
            {
                string SortName = GetRandom(voc, 5);
                db.Sorts.Add(new Sort
                {
                    SortD = SortName
                });
            }
            db.SaveChanges();

            for (int LocID = 1; LocID < location_number; LocID++)
            {
                string LocName = GetRandom(voc, 5);
                db.Locations.Add(new Location
                {
                    Loc = LocName
                });
            }
            db.SaveChanges();

            for (int ProdID = 1; ProdID < product_number; ProdID++)
            {
                int SortsID = random.Next(1, sort_number - 1);
                int Lghts = random.Next(1, sort_number - 1);
                int Volumes = random.Next(1, sort_number - 1);
                int Quarters = random.Next(1, sort_number - 1);
                int Locations = random.Next(1, location_number - 1);
                DateTime DateOfShipment = new DateTime(1);
                db.Products.Add(new Product
                {
                    SortID = SortsID,
                    Lght = Lghts,
                    Volume = Volumes,
                    Quarters = Quarters,
                    LocID = Locations,
                    DateOfShipment = DateOfShipment
                });
            }
            db.SaveChanges();

            for (int ForestID = 1; ForestID < forest_number; ForestID++)
            {
                int CarsID = random.Next(1, mazist_number - 1);
                int SortID = random.Next(1, product_number - 1);
                int PointsID = random.Next(1, appointment_number - 1);
                int Quarter = random.Next(1, appointment_number - 1);
                int Locations = random.Next(1, location_number - 1);
                DateTime DateOfAppointment = new DateTime(1);
                db.Forests.Add(new Forest
                {
                    CarID = CarsID,
                    SortID = SortID,
                    PointID = PointsID,
                    Quarter = Quarter,
                    LocID = Locations,
                    DateOfAppointment = DateOfAppointment
                });
            }
            db.SaveChanges();

        }

        public static string GetRandom(string Word, int Length)
        {
            Random random = new Random();
            StringBuilder stringBuilder = new StringBuilder(Length - 1);
            int Position = 0;
            string ret = "";
            for (int i=0; i<Length;i++)
            {
                Position = random.Next(0, Word.Length - 1);
                ret += Word[Position];
            }
            return ret;

        }
    }
}
