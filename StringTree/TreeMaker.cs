using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringTree
{
    class TreeMaker
    {
        private List<TreeNode> treeNodes = new List<TreeNode>();

        private List<int> depth = new List<int>();
        private List<string> parentValue = new List<string>();

        public TreeMaker()
        {
            
        }

        public bool LoadText(string[] textToLoad)
        {
            bool isReady = true;

            for (int i = 0; i < textToLoad.Length; i++)
            {
                depth.Add(0);

                var charsCurrentLine = textToLoad[i].ToCharArray();

                for (int j = 0; j < charsCurrentLine.Length; j++)
                {
                    if (charsCurrentLine[j] == '\t')
                    {
                        depth[i]++;
                    }
                    else if (charsCurrentLine[j] == ' ')
                    {
                        while (charsCurrentLine[j] == ' ')
                        {
                            j++;
                            if (j % 4 == 0)
                            {
                                depth[i]++;
                            }
                        }

                    }
                    else break;
                }

                
            }

            for (int i = 0; i < textToLoad.Length; i++)
            {
                parentValue.Add("N/A");

                if (depth[i] > 0)
                {
                    for (int j = i; depth[j] >= depth[i]; j--)
                    {
                        parentValue[i] = textToLoad[j - 1].Trim();
                    }
                }
                else parentValue[i] = "N/A";
            }

            for (int i = 0; i < textToLoad.Length; i++)
            {
                TreeNode node = new TreeNode();

                node.EnterValues(textToLoad[i].Trim(), parentValue[i], i, depth[i]);

                treeNodes.Add(node);

                Console.WriteLine(treeNodes[i].Number + " " + treeNodes[i].Name + " Depth: " + treeNodes[i].Depth + " Parent: " + treeNodes[i].ParentName);
            }

            Console.WriteLine("\nWrite data to a new file? y/n");

            string answer = Console.ReadLine();

            if (answer.ToLower() == "y")
            {
                WriteOutlineFile(treeNodes);
            }

            return isReady;
        }

        public void WriteOutlineFile(List<TreeNode> nodes)
        {
            Console.WriteLine("Please enter the name of target file (omit '.txt'):");

            string targetFileName = Console.ReadLine();

            string[] lines = new string[nodes.Count];

            for (int i = 0; i < lines.Length; i++)
            {
                if (nodes[i].Depth > 0)
                {
                    for (int j = 0; j < nodes[i].Depth; j++)
                    {
                        lines[i] += "\t";
                    }
                }

                lines[i] += nodes[i].Name;
            }

            for (int i = 0; i < lines.Length; i++)
            {
                File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + targetFileName + ".txt", lines);
            }

            Console.WriteLine("File written in path: " + AppDomain.CurrentDomain.BaseDirectory + targetFileName + ".txt");
        }
    }
}
