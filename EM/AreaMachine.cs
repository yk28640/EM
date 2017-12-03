using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM
{
    class AreaMachine
    {

        public string FunctionLocation { set; get; }
        public string FunctionLocationName { set; get; }
        public string MainteananceWorkCenter { set; get; }
        public string PlannerGroup { set; get; }
        public string Descriptions { set; get; }
        public int Supprior_Area_A_ID { set; get; }
        public bool Machine { set; get; }
        public bool zone { set; get; }
        public bool Line { set; get; }
        public bool Plant { set; get; }
        public DateTime sop_date { set; get; }
        public bool BottleNeck { set; get; }

        public int BreakdownFactor { set; get; }

        public bool T3PartyResponsible { set; get; }
        public bool SupportOnsite { set; get; }
        public bool SupportItech { set; get; }
        public bool SupportChina { set; get; }
        public bool SupportInternational { set; get; }
        public bool NoSupport { set; get; }
    }
}