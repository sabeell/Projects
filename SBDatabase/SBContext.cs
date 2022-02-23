using SBEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBDatabase
{
    public class SBContext : DbContext
    {
        public SBContext() : base("dbConnection")
        {

        }
        public DbSet<InventoryItem> InventoryItems { get; set; }
    }
}
