//entity layer for apply passport and passport renewal
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pvmsentity.layer
{
     public class entitypassport
    {
        public string state_name
        { get; set; }
        public string state_id
        { get; set; }
        public string city
        { get; set; }
        public string passsport_id
        { set; get; }
        public string user_id
        { set; get; }
        public string country
        { set; get; }
        public string state
        { set; get; }
        public string pin
        { set; get; }
        public DateTime issue_date
        { set; get; }
        public string type_of_service
        { set; get; }
        public string booklet_type
        { set; get; }
        public DateTime expiry_date
        { get; set; }
        public string amount
        { get; set; }
        public int new_pass_id
        { get; set; }
        public DateTime new_issue_date
        { get; set; }
        public string new_service_type
        { get; set; }
        public string new_booklet_type
        { get; set; }
        public DateTime new_expiry_date
        { get; set; }
        public string renew_amount
        { get; set; }
      
        
    }
}
