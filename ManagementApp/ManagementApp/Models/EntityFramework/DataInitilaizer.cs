using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ManagementApp.Models.EntityFramework
{
    public class DataInitilaizer: DropCreateDatabaseIfModelChanges<ManagementContext>
    {

    }
}