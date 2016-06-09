//entity layer for apply visa and cancel visa
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pvmsentity.layer
{
     public class entityvisa
    {
         public string visa_id
         { get; set; }
         public string passport_id
         { get; set; }
         public string user_id
         { get; set; }
         public string destination
         { get; set; }
         public string occupation
         { get; set; }
         public string cost
         { get; set; }
         public string visa_permit
         { get; set; }
         public DateTime date_of_apply
         { get; set; }
         public DateTime date_of_issue
         { get; set; }
         public DateTime date_of_expiry
         { get; set; }
         public string new_visa_tag
         { get; set; }
         public int new_visa_id
         { get; set; }
         public string security_question
         { get; set; }
         public string security_answer
         { get; set; }
         public DateTime date_of_cancel
         { get; set; }
         public string fine_amount
         { get; set; }
    }
}
