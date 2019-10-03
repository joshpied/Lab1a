using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1a.Models
{
    public class DealershipMgr
    {
        // not in db
        // hardcoded list of dealerships
        // few functinos with get/post whatever
        // verbs working as if youbre using it from another system

        //Dealership[] dealerships =
        //{
        //    new Dealership{Id=1, Name="Joshs Cars", Email="dealer@josh.ca", PhoneNumber="905-123-4567"},
        //    new Dealership{Id=2, Name="Used Cars", Email="used@car.ca", PhoneNumber="905-122-3461"}
        //};

        public static List<Dealership> dealerships = new List<Dealership>
        {
                new Dealership{Id=1, Name="Joshs Cars", Email="dealer@josh.ca", PhoneNumber="905-123-4567"},
                new Dealership{Id=2, Name="Used Cars", Email="used@car.ca", PhoneNumber="905-122-3461"}
        };

        public IEnumerable<Dealership> Get()
        {
            return dealerships;
        }

        public Dealership Get(int id)
        {
            return dealerships[id - 1];
        }

        // public Dealership Post([Bind("Id,Name,Email,PhoneNumber")] Dealership dealership)
        public Dealership Post([Bind("Id,Name,Email,PhoneNumber")] Dealership dealership)
        {
            // insert id, name,email,phonenumber
            dealerships.Add(new Dealership { Id = dealership.Id, Name = dealership.Name, Email = dealership.Email, PhoneNumber = dealership.PhoneNumber });
            return dealerships[dealerships.Count() - 1];
        }

        public Dealership Put(int id, [Bind("Id,Name,Email,PhoneNumber")] Dealership dealership)
        {
            dealerships[id - 1] = dealership;
            return dealerships[id - 1];
        }

        public void Delete(int id)
        {
            dealerships.RemoveAt(id - 1);
        }
    }
}
