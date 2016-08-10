using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WebDeveloper.Model
{
    [JsonObject]
    [Table("Person.BusinessEntityAddress")]
    public partial class BusinessEntityAddress
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BusinessEntityID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AddressID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AddressTypeID { get; set; }

        public Guid rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }

        [JsonProperty]
        public virtual Address Address { get; set; }

        [JsonProperty]
        public virtual AddressType AddressType { get; set; }
        [JsonIgnore]
        public virtual BusinessEntity BusinessEntity { get; set; }
    }
}
