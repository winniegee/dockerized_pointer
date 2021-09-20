using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Campaign
    {
        public int CampaignID { get; set; }
        public User UserProfile { get; set; }
        public List<Tasks> Tasks { get; set; }
    }
}
