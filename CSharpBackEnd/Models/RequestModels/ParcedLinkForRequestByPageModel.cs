﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBackEnd.Models.RequestModels
{
    public class ParcedLinkForRequestByPageModel
    {
        public int Id { get; set; }
        public int PageNum { get; set; }
        public int PageSize { get; set; }
    }
}
