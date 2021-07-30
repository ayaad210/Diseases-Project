using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiseasesProject.Models
{
 

   public partial class Diet
    {

        public Diet()
        {
            this.DiseaseDiets = new HashSet<DiseaseDiet>();
        }
        public String Name { get; set; }

        public int ID { get; set; }
        public string Diet1 { get; set; }


        public virtual ICollection<DiseaseDiet> DiseaseDiets { get; set; }
    }
  public partial class Precantion
    {

        public Precantion()
        {
            this.DiseaseDiets = new HashSet<DiseaseDiet>();
        }

        public int id { get; set; }
        public string Info { get; set; }
        public string Name { get; set; }


        public virtual ICollection<DiseaseDiet> DiseaseDiets { get; set; }
    }

   public partial class Sport
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sport()
        {
            this.DiseaseDiets = new HashSet<DiseaseDiet>();
        }

        public int id { get; set; }
        public string Info { get; set; }
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DiseaseDiet> DiseaseDiets { get; set; }
    }





 public partial class Disease
    {

        public Disease()
        {
            this.DiseaseDiets = new HashSet<DiseaseDiet>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string GeneralInfo { get; set; }


        public virtual ICollection<DiseaseDiet> DiseaseDiets { get; set; }
    }

    public partial class DiseaseDiet
    {
        public int ID { get; set; }
   //     public Nullable<int> DiseaseID { get; set; }
     //   public Nullable<int> dlID { get; set; }
        public Nullable<int> AgeFrom { get; set; }
        public Nullable<int> AgeTo { get; set; }

        public Nullable<bool> Gender { get; set; }
        //public Nullable<int> PreID { get; set; }
        //public Nullable<int> Sportsid { get; set; }

        public virtual Diet Diet { get; set; }
        public virtual Precantion Precantion { get; set; }
        public virtual Sport Sport { get; set; }
        public virtual Disease Disease { get; set; }
    }




    public partial class Contact
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contact()
        {

        }
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }


    }


}