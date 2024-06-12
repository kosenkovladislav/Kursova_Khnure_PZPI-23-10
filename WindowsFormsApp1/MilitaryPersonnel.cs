using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class MilitaryPersonnel : Person
    {
        public string Rank { get; set; }
        public string RankDate { get; set; }
        public string Unit { get; set; } 
        public string ServiceType { get; set; }
        public string ServicePeriod { get; set; }
        public string PersonalityTraits { get; set; }

        public MilitaryPersonnel(string name, int age, string gender, string address, string profession, string education,
                                 string rank, string rankDate,string unit, string serviceType, string servicePeriod,
                                 string personalityTraits)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Address = address;
            Profession = profession;
            Education = education;
            Rank = rank;
            RankDate = rankDate;
            Unit = unit;
            ServiceType = serviceType;
            ServicePeriod = servicePeriod;
            PersonalityTraits = personalityTraits;
        }
    }
}