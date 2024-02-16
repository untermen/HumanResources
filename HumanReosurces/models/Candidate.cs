namespace HumanReosurces.models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Candidate
    {
        public long Id_candidate { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Contact_info { get; set; }
        public string Resume { get; set; }
        public System.DateTime Interview_date { get; set; }
        public string Status { get; set; }
    }
}