using System;
using System.Collections.Generic;
using System.Text;

namespace SharpPlanner
{
    public class TutorialObject
    {
        public string Description { get; set; }
        public string Img { get; set; }

        public TutorialObject(string desc, string img)
        {
            Description = desc;
            Img = img;
        }
    }
}
