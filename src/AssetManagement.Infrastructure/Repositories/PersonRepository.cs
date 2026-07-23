using AssetManagement.Domain.Persons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Infrastructure.Repositories;

internal sealed class PersonRepository : Repository<Person>, IPersonRepository

{
    public PersonRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }
    public Person Update(Person person)
    {
        DbContext.Set<Person>().Update(person);
        return person;
    }
}