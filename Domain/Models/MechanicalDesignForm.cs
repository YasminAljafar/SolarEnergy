using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Models
{
    public class MechanicalDesignForm : SharedInfo
    {
        public int AmountOfElectricity { get; set; }
        public int PanelsNumber { get; set; }
        public string PlaceArea { get; set; }

        [EnumDataType(typeof(BaseType))]
        public BaseType Basetype { get; set; }    

     }
}
