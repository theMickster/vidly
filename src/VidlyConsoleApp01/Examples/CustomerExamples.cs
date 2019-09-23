using System;
using System.Data.Entity;
using System.Linq;
using Vidly.DataServices.DbContexts;

namespace VidlyConsoleApp01.Examples
{
    public class CustomerExamples
    {

        public void Example01()
        {
            using (var db = new VidlyDbContext())
            {
                var result = db.Customers.ToList();

                Console.WriteLine("All customers in the database are as follows...");
                Console.WriteLine();
                foreach (var item in result)
                {
                    /*****************************************************************************************************************************************************************
                     * Example of Interpolated Strings: An interpolated string looks like a template string that contains interpolated expressions. 
                     * Example of the "Elvis" Operator: returns one of two values depending on the value of a Boolean expression. condition ? first_expression : second_expression;
                     ******************************************************************************************************************************************************************/
                    Console.WriteLine("Display Name: {0}, Email Address: {1}, Date of Birth: {2}"
                        , item.DisplayName
                        , item.EmailAddress
                        , item.Dob != null ? $"{item.Dob:MM/dd/yy}" : "Unknown");
                }
            }
        }

        public void Example03()
        {
            using (var db = new VidlyDbContext())
            {
                var customers = db.Customers.Include(c => c.MembershipTypeCode).ToList();

                foreach (var item in customers)
                {
                    Console.WriteLine($"Display Name: {item.DisplayName}, Email Address: {item.EmailAddress}, Membership Type Id: {item.MembershipTypeCodeId}, Membership Type {item.MembershipTypeCode.MembershipTypeDesc}");
                }

            }
        }
    }
}
