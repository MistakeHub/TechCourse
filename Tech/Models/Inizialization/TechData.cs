using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BackEnd.InterTech;

namespace BackEnd.Models.Inizialization
{
    public class TechData
    {
        public static void Inizialization(TechDbContext context)
        {

            List<Address> addresses=new List<Address>()
            {
                new Address(){  Apartament = 32,Home = "Home1", Street = "street1"},
                new Address(){  Apartament = 33,Home = "Home2", Street = "street2"},
                new Address(){  Apartament = 34,Home = "Home3", Street = "street3"},
                new Address(){  Apartament = 35,Home = "Home4", Street = "street4"},
                new Address(){  Apartament = 36,Home = "Home5", Street = "street5"},
                new Address(){  Apartament = 37,Home = "Home6", Street = "street6"},


            };

            context.Addresses.RemoveRange(context.Addresses);
            context.Addresses.AddRange(addresses);
            context.SaveChanges();

            List<Specialty> specialties=new List<Specialty>()
            {

                new Specialty(){ TitleSpec = "Механик"},
                new Specialty(){ TitleSpec = "Диспетчер"},
                new Specialty(){ TitleSpec = "Администратор"},

            };

            context.Specialties.RemoveRange(context.Specialties);
          
            context.Specialties.AddRange(specialties);
           
            context.SaveChanges();

            List<Brand> brands=new List<Brand>()
            {

                new Brand(){TitleBrand ="Audi", Model = "A3Sedan"},
                new Brand(){TitleBrand ="Acure", Model = "MDX"},
            new Brand(){TitleBrand ="BMW", Model = "X3M"},
            new Brand(){TitleBrand ="Bugatti", Model = "Chiron"},
            new Brand(){TitleBrand ="Bentley", Model = "Azure"},

            };
            context.Brands.RemoveRange(context.Brands);
            context.Brands.AddRange(brands);
            context.SaveChanges();
            List<Person> persons=new List<Person>()
            {
                 new Person(){SurnameNP ="Котова Евдокия Данилевна",Passport = "FQ94951"},
                 new Person(){SurnameNP ="Ильясова Ирина Данииловна",Passport = "RF32816"},
                 new Person(){SurnameNP ="Церетели Лаврентий Михаилович",Passport = "QX32591"},
                 new Person(){SurnameNP ="Углицкий Вацлав Прохорович",Passport = "Z392956"},
                 new Person(){SurnameNP ="Стеблева Агафья Юлиевна",Passport = "9038745"},
                 new Person(){SurnameNP ="Гершельман Семён Святославович",Passport = "8J71375"},
                 new Person(){SurnameNP ="Венедиктов Артём Леонидович",Passport = "1432827"},
                 new Person(){SurnameNP ="Клюкин Кирилл Глебович",Passport = "RJ24476"},
                 new Person(){SurnameNP ="Бугакова Людмила Никитевна",Passport = "B179351"},
                 new Person(){SurnameNP ="Шандаров Вячеслав Агапович",Passport = "8153437"},



            };

            context.Persons.RemoveRange(context.Persons);
            context.Persons.AddRange(persons);
            context.SaveChanges();
            List<Status> statuses=new List<Status>()
            {

                new Status(){status ="Свободен"},
                new Status(){status="Занят"},

            };

            context.Statuses.RemoveRange(context.Statuses);
            context.Statuses.AddRange(statuses);
            context.SaveChanges();

            List<Break> breaks=new List<Break>()
            {

                new Break(){BreakName = "Поломан Двигатель", PeriodBreak = 37, Price = 1900},
                new Break(){BreakName = "Поврежден бампер", PeriodBreak = 11, Price = 1000},
                new Break(){BreakName = "Поломка Руля", PeriodBreak = 5, Price = 800},
                new Break(){BreakName = "Пробито колесо", PeriodBreak = 1, Price = 500},

            };
            context.Breaks.RemoveRange(context.Breaks);
            context.Breaks.AddRange(context.Breaks);
            context.SaveChanges();

            List<Enroller> enrollers=new List<Enroller>()
            {

                new Enroller(){IdPerson = context.Persons.First(p=> p.Id>=6).Id, IdSpecialty = context.Specialties.First(p=>p.TitleSpec=="Механик").Id, 
                    idStatus = context.Statuses.FirstOrDefault(p=>p.Id>=0).Id, Level = "Высший", PeriodWork = "397"},


            };
            context.Enrollers.RemoveRange(context.Enrollers);
            context.Enrollers.AddRange(enrollers);
            context.SaveChanges();
            List<Auto> autos=new List<Auto>()
            {
                new Auto(){ IdBrand = context.Brands.First(p=>p.TitleBrand=="BMW").id, Color = "Red",DateStart = 2019, IdPerson = context.Persons.First(p=>p.Id>=0).Id, RegNumer = "AK33BM"},


            };
            context.Autos.RemoveRange(context.Autos);
            context.Autos.AddRange(autos);
            context.SaveChanges();
            
            List<Client> clients=new List<Client>()
            {

                new Client(){ DateBirth = new DateTime(1990, 12,31), IdAddress = context.Addresses.FirstOrDefault(p=>p.Id>=0).Id, IdPerson = context.Persons.FirstOrDefault(p=>p.Id>=0).Id, PhoneNumber = "341231"},

            }; 
            context.Clients.RemoveRange(context.Clients);
            context.Clients.AddRange(clients);
            context.SaveChanges();


        }
    }
}
