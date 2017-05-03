using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SweetSpot
{
    public class Model
    {
        public int modelID;
        public string modelName;

        public Model() { }

        public Model(int id, string name)
        {
            modelID = id;
            modelName = name;
        }

    }
}