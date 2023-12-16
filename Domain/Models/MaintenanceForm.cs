using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class MaintenanceForm : SharedInfo
    {
        public string ImagePath { get; set; }
        public DeviceType Devicetype { get; set; }
    }
}
