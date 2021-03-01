﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BackEnd.InterTech;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Models.Inizialization
{
    public class TechData
    {
        public static void Inizialization(TechDbContext context)
        {
          
            List<Address> addresses=new List<Address>()
            {
                new Address(){  Apartament = 646,Home = "дом 173m", Street ="ул.Хомутовский"},   
                new Address(){  Apartament = 116,Home = "дом 70h", Street = "ул.Орликов"},
                new Address(){  Apartament = 453,Home = "дом 112d", Street = "ул.Берзарина"},
                new Address(){  Apartament = 35,Home = "дом 78c", Street = "ул.Дамба"},
                new Address(){  Apartament = 792,Home = "дом 16b", Street = "ул.Люботинский"}, 
                new Address(){  Apartament = 760,Home = "дом 53n", Street = "ул.Попова,"},


            };

            context.Addresses.RemoveRange(context.Addresses);
            context.Addresses.AddRange(addresses);
          

            List<Specialty> specialties=new List<Specialty>()
            {

                new Specialty(){ TitleSpec = "Механик"},
                new Specialty(){ TitleSpec = "Диспетчер"},
                new Specialty(){ TitleSpec = "Администратор"},

            };

            context.Specialties.RemoveRange(context.Specialties);
          
            context.Specialties.AddRange(specialties);
           
   

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
          
            List<Status> statuses=new List<Status>()
            {

                new Status(){status ="Свободен"},
                new Status(){status="Занят"},

            };

            context.Statuses.RemoveRange(context.Statuses);
            context.Statuses.AddRange(statuses);
           

            List<Break> breaks=new List<Break>()
            {

                new Break(){BreakName = "Поломан Двигатель", PeriodBreak = 37, Price = 1900},
                new Break(){BreakName = "Поврежден бампер", PeriodBreak = 11, Price = 1000},
                new Break(){BreakName = "Поломка Руля", PeriodBreak = 5, Price = 800},
                new Break(){BreakName = "Пробито колесо", PeriodBreak = 1, Price = 500},




            };
           

            context.Break.RemoveRange(context.Break);
            context.Break.AddRange(breaks);
          

            List<Enroller> enrollers=new List<Enroller>()
            {

                new Enroller(){Person = persons.First(p=> p.Passport=="RF32816"), Specialty = specialties.First(p=>p.TitleSpec=="Механик"), 
                    Status = statuses.FirstOrDefault(p=>p.status=="Свободен"), Level = "1", PeriodWork = "397"},


            };
            context.Enrollers.RemoveRange(context.Enrollers);
            context.Enrollers.AddRange(enrollers);
       


            List<Auto> autos = new List<Auto>()
            {
                new Auto(){ Brand = brands.First(p=>p.TitleBrand=="BMW"), Color = "Red",DateStart = 2019, Person = persons.First(p=>p.Passport=="1432827"), RegNumer = "AK33BM", Break = breaks.First(p=>p.Price==500),},
                new Auto(){ Brand = brands.First(p=>p.TitleBrand=="Audi"), Color = "Blue",DateStart = 2015, Person = persons.First(p=>p.Passport=="B179351"), RegNumer = "DT43DK", Break =   breaks.First(p=>p.Price==800),},
                new Auto(){ Brand = brands.First(p=>p.TitleBrand=="Bugatti"), Color = "White",DateStart = 2017, Person = persons.First(p=>p.Passport=="9038745"), RegNumer = "AM53PL", Break =  breaks.First(p=>p.Price==1900),},


            };
            context.Autos.RemoveRange(context.Autos);
       context.Autos.AddRange(autos);
         
            
            List<Client> clients=new List<Client>()
            {

                new Client(){ DateBirth = new DateTime(1990, 12,31), Address = addresses.FirstOrDefault(p=>p.Apartament==453), Person = persons.FirstOrDefault(p=>p.Passport=="FQ94951"), PhoneNumber = "341231"},
                new Client(){ DateBirth = new DateTime(1990, 12,31), Address = addresses.FirstOrDefault(p=>p.Apartament==35), Person =persons.FirstOrDefault(p=>p.Passport=="RJ24476"), PhoneNumber = "341231"},
                new Client(){ DateBirth = new DateTime(1990, 12,31), Address = addresses.FirstOrDefault(p=>p.Apartament==792), Person = persons.FirstOrDefault(p=>p.Passport=="8J71375"), PhoneNumber = "341231"},
                new Client(){ DateBirth = new DateTime(1990, 12,31), Address = addresses.FirstOrDefault(p=>p.Apartament==760), Person = persons.FirstOrDefault(p=>p.Passport=="Z392956"), PhoneNumber = "341231"},
                new Client(){ DateBirth = new DateTime(1990, 12,31), Address = addresses.FirstOrDefault(p=>p.Apartament==116), Person = persons.FirstOrDefault(p=>p.Passport=="QX32591"), PhoneNumber = "341231"},

            }; 
            context.Clients.RemoveRange(context.Clients);
            context.Clients.AddRange(clients);
           

          

            context.Requests.RemoveRange(context.Requests);
            
            context.RequestForFixArchives.RemoveRange(context.RequestForFixArchives);
            context.SaveChanges();

        }
    }
}
