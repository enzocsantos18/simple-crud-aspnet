using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using crud_api.Models;

namespace crud_api.Data
{
    public class DbContextBooks : DbContext
    {
        public DbContextBooks(DbContextOptions<DbContextBooks> options) : base(options)
        {

        }

        public DbSet<Book> Books {get;set;}

    }
}
