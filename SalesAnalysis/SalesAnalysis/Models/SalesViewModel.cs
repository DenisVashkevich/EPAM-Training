using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DAL.Models;

namespace SalesAnalysis.Models
{
    public class SalesViewModel
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name="Maneger")]
        public ManagerViewModel Manager { get; set; }

        [Display(Name="Client")]
        public Client Client { get; set; }

        [Display(Name="Product")]
        public Goods Goodds { get; set; }

        [Display(Name="Total sum")]
        public double Cost { get; set; }
    }
}