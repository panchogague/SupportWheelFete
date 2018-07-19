using SupportWheelFate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportWheelFate.Classes
{
    public class Shift
    {
        private int _id;

        public Shift(int id)
        {
            _id = id;
        }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public Engineer Engineer { get; set; }
    }
}
