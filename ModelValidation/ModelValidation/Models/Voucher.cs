using ModelValidation.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ModelValidation.Models
{
    [VoucherValidation]
	public class Voucher:IValidatableObject
	{
        [Required]
        [StringLength(50, MinimumLength = 5)]
        //[Remote("ValidateName", "Home")]
		public string Name { get; set; }

        [PrefixLogic(6)]
		public string Prefix { get; set; }
		public string Postfix { get; set; }

        [Required]
        [DisplayName("Min Amount")]
        [Range(5, double.MaxValue)]
        public decimal? MinimalAmount { get; set; }

        [Required]
        [Range(0.5, 100)]
		public decimal? Percentage { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
		public bool SingleUse { get; set; }
		public string Title
		{
			get
			{
				return string.Format("Voucher {0}", 
					string.Format("{0} {1} {2}", Prefix, Name, Postfix)
					.Trim().Replace(' ','_'));
			}
		}

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errorList = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(Name))
            {
                errorList.Add(new ValidationResult("Please enter voucher name."));
            }
            else if (Name.Length > 50)
            {
                errorList.Add(new ValidationResult("Voucher name should be less then 50 symbols."));
            }

            return errorList;
        }
    }
}