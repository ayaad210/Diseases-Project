using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiseasesProject.Models
{

    [MetadataType(typeof(PreDataAnnotation))]

    public partial class Precantion
    {


    }

    public class PreDataAnnotation
    {
        [Required]
        public string Info { get; set; }
        public string Name { get; set; }
    }


    [MetadataType(typeof(DietDataAnnotation))]
    public partial class Diet
    {
   
    }

    public class DietDataAnnotation
    {
        public String Name { get; set; }
        [Required]
        public string Diet1 { get; set; }
    }


    [MetadataType(typeof(DiseasDataAnnotation))]
    public partial class Disease
    {
        
    }

    public class DiseasDataAnnotation
    {
       [Required]
        public string Name { get; set; }
        [Required]
        public string GeneralInfo { get; set; }
    }


    [MetadataType(typeof(sportDataAnnotation))]

    public partial class Sport
    {
  

    }

    public class sportDataAnnotation
    {
        [Required]
        public string Info { get; set; }

        public string Name { get; set; }
    }




}