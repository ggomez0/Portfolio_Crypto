﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio_GasparG.RegistroLogin.MasterDetail
{
    public class MyMasterDetailPageMenuItem
    {
        public MyMasterDetailPageMenuItem()
        {
            TargetType = typeof(MyMasterDetailPageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public Type TargetType { get; set; }
    }
}
