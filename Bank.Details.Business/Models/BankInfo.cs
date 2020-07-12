using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bank.Details.Business.Models
{
    public class BankInfo
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Branch Name is Required")]
        public string BranchName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bank is Required")]
        public string Bank { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "IFSC Code is Required")]
        public string IfscCode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "State is Required")]
        public string State { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "District is Required")]
        public string District { get; set; }
    }
}
