using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fungoodMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace fungoodMVC.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> option) : base(option)
    {

    }

    public DbSet<FoodItem> food_items => Set<FoodItem>();
  }
}