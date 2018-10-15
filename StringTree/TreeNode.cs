using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringTree
{
    class TreeNode
    {
        public string Name;
        public string ParentName;
        public int Number;
        public int Depth;

        public TreeNode()
        {
            
        }

        public void EnterValues(string valName, string valParentName, int valNumber, int valDepth)
        {
            Name = valName;
            ParentName = valParentName;
            Number = valNumber;
            Depth = valDepth;
        }

    }
}
