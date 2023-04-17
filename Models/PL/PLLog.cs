using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace pramodSourceSystem.Models.PL
{
    public class PLLog
    {
        public int Ind { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public Nullable<int> ReletedCity { get; set; }
        public Nullable<int> Log_Count { get; set; }
        public DateTime Log_Date { get; set; }
        public string Log_IP { get; set; }
        public Nullable<bool> IsDel { get; set; }
        public Nullable<int> Status { get; set; }        
    }
}