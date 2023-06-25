using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fungoodMVC.Models
{
  public class FoodItem
  {
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public int Price { get; set; }
    public enum Category
    {

    }

    public CustomizeOption? CustomizeOption { get; set; }

  }
}