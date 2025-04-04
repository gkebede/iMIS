using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class DbInitializer
    {
            public static async Task SeedData(DataContext context)
            {
                if (!context.Students.Any()) // Ensure students are not already seeded
                {
                    var students = new List<Student>
                    {
                        new Student {
                            MemberId = Guid.NewGuid().ToString(),
                             FirstName = "John Doe",
                             LastName = "Mo",
                             BirthDay = new DateTime(2000, 1, 1),
                             Email = "johndoe@gmail.com",
                             PhoneNumber = 123-456-7890,
                             UniversityAttending = "Harvard University",
                              }
                    };

                    context.Students.AddRange(students);
                    await context.SaveChangesAsync();
                }
            }

    }
    
}