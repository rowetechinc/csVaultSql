using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace csVaultSql.Models
{
    public partial class Adcp
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Created { get; set; }
        public string Serialnumber { get; set; }
        public string Customer { get; set; }

        [Display(Name = "Order Number")]
        public string Ordernumber { get; set; }

        [Display(Name = "Depth Rating")]
        public string Depthrating { get; set; }
        public string Headtype { get; set; }
        public string Hardware { get; set; }
        public string Connectortype { get; set; }
        public string Frequency { get; set; }
        public string Firmware { get; set; }
        public string Software { get; set; }
        public bool? Temperaturepresent { get; set; }
        public bool? Pressuresensorpresent { get; set; }
        public string Pressuresensorrating { get; set; }
        public bool? Ethernetinstalled { get; set; }
        public string Recordersize { get; set; }
        public bool? Recorderformatted { get; set; }
        public string Systemtype { get; set; }
        public string Application { get; set; }
        public string Numbatts { get; set; }
        public string Productnumber { get; set; }
        public string Scalefactor { get; set; }
        public bool? Isvesselmount { get; set; }
        public bool? Isriversystem { get; set; }
        public string Boardorientation { get; set; }
        public string Housingtype { get; set; }
        public string Cablelength { get; set; }
        public bool? Istriggerout { get; set; }
        public bool? Istriggerin { get; set; }
        public DateTime? Modified { get; set; }
        public string Rmanumber { get; set; }
    }
}
