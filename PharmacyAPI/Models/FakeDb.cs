using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Models
{
    public static class FakeDb
    {
        private static List<Medicine> _list;
        public static List<Medicine> GetList()
        {
            if (_list == null)
            {
                _list = new List<Medicine>() {
                new Medicine()
                {
                    Id = 1,
                    Company = "X",
                    Name = "abcd",
                    UnitsInStock = 15,
                    UnitPrice = 10,
                    ExpirationDate = new DateTime(2021,10,25)

                },
                new Medicine()
                {
                    Id = 2,
                    Company = "Y",
                    Name = "bcde",
                    UnitsInStock = 1,
                    UnitPrice = 15,
                    ExpirationDate = new DateTime(2022,1,15)
                },
                new Medicine()
                {
                    Id = 3,
                    Company = "X",
                    Name = "abde",
                    UnitsInStock = 20,
                    UnitPrice = 5,
                    ExpirationDate = new DateTime(2021,11,5)
                },
                new Medicine()
                {
                    Id = 4,
                    Company = "Y",
                    Name = "fgh",
                    UnitsInStock = 36,
                    UnitPrice = 8,
                    ExpirationDate = new DateTime(2022,12,5)
                },
                new Medicine()
                {
                    Id = 5,
                    Company = "Y",
                    Name = "dcba",
                    UnitsInStock = 5,
                    UnitPrice = 4,
                    ExpirationDate = new DateTime(2021,10,25)
                }

            };
            }


            return _list;
        }
    }
}
