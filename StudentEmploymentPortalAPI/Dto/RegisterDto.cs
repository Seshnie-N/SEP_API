﻿using StudentEmploymentPortalAPI.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentEmploymentPortalAPI.Dto
{
    public class RegisterDto : LoginDto
    {
        [Required(ErrorMessage = "Please enter your first name.")]
        [RegularExpression("^[^\\d]*$", ErrorMessage = "Invalid characters in field.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name.")]
        [RegularExpression("^[^\\d]*$", ErrorMessage = "Invalid characters in field.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression("^(\\+27|0)[6-8][0-9]{8}$", ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }
        public string? Address { set; get; }

        [Required(ErrorMessage = "Please enter your ID number")]
        /*[RegularExpression("(([0-9]{2})(0|1)([0-9])([0-3])([0-9]))([ ]?)(([ 0-9]{4})([ ]?)([ 0-1][8]([ ]?)[ 0-9]))", ErrorMessage = "Invalid ID number")]*/
        [SAIdentityNumber]
        public string IdNumber { set; get; }
        [DisplayName("DriversLicense")]
        [ForeignKeyCheck]
        [DefaultValue(1)]
        public int DriversLicenseId { get; set; }
        public string? CareerObjective { set; get; }
        [DisplayName("Gender")]
        [ForeignKeyCheck]
        [DefaultValue(1)]
        public int GenderId { get; set; }
        [DisplayName("Race")]
        [ForeignKeyCheck]
        [DefaultValue(1)]
        public int RaceId { get; set; }
        public bool IsSouthAfrican { get; set; }
        [DisplayName("Nationality")]
        [DefaultValue(1)]
        [ForeignKeyCheck]
        public int? NationalityId { get; set; }
        [DisplayName("YearOfStudy")]
        [ForeignKeyCheck]
        [DefaultValue(1)]
        public int YearOfStudyId { get; set; }
        [DisplayName("Department")]
        [ForeignKeyCheck]
        [DefaultValue(1)]
        public int DepartmentId { get; set; }
        public string? Skills { set; get; }
        public string? Achievements { set; get; }
        public string? Interests { set; get; }
    }
}