using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewSitefinityProject.Mvc.Models
{
    public class MessageModel
    {
        public string Text { get; set; }
        public int Repeat
        {
            get
            {
                return this.repeat;
            }
            set
            {
                this.repeat = value;
            }
        }

        private int repeat = 1;
    }
}