using System;
using System.Drawing;

namespace PEHandle
{

    [AttributeUsage(AttributeTargets.Property,AllowMultiple=false,Inherited=false)]
    public class DescriptionAttribute:Attribute
    {
        public string desc;
        public string format;
        //private int rgba;
        public int RGBA { get; set; }
        public DescriptionAttribute(string desc,string format)
        {
            this.desc = desc;
            this.format = format;
        }
    }
}
