using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pramodSourceSystem.Models.PL
{
    public class PL
    {
        public int Ind { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string AadharNo { get; set; }
        public DateTime DOB { get; set; }
        public string StudentAddress { get; set; }
        public Nullable<int> ReletedCity { get; set; }
        public Nullable<int> CollegeName { get; set; }
        public Nullable<int> Category { get; set; }
        public Nullable<int> Course { get; set; }
        public DateTime RegDT { get; set; }
        public Nullable<int> StudentStatus { get; set; }
        public string Remark { get; set; }
        public Nullable<bool> IsDel { get; set; }
        public Nullable<int> Fees { get; set; }
        public string PIC { get; set; }
        public string FolderName { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
    }
}