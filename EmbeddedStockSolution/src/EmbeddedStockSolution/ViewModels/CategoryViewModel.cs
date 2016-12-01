using EmbeddedStockSolution.Models;

using System.Collections.Generic;
namespace EmbeddedStockSolution.ViewModels
{
  public class CategoryViewModel{
    public int Id{get; set;}
    public string Name { get; set; }
    public List<int> ComponentTypeIds{ get; set; }

    public List<ComponentType> ComponentTypes {get; set;}

  }
}