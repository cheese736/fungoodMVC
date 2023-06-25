using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace fungoodMVC.Models
{
  public class Order
  {
    public int MyProperty { get; set; }
    public int OrderNumber { get; set; }
    public int FoodItemId { get; set; }
  }
}