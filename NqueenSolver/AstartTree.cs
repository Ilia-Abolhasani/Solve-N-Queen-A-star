using System.Collections.Generic;

namespace NqueenSolver
{
    public class AstartTree
    {
        private Node Root;
        private List<Node> ExpandedNodes;
        public void JoinList(List<Node> Base, List<Node> Additional)
        {
            foreach (var node in Additional)
                Base.Add(node);
        }
        public void Sort(List<Node> list)
        {
            list.Sort((x, y) => x.Fn.CompareTo(y.Fn));
        }
        public Node Run()
        {
            Root = new Node();
            ExpandedNodes = new List<Node>();
            JoinList(ExpandedNodes, Root.GetChildren());
            while (ExpandedNodes.Count>0)
            {   
                Sort(ExpandedNodes);
                Node node = ExpandedNodes[0];
                ExpandedNodes.RemoveAt(0);
                if ((node.Depth == Data.ChessSize) && (node.Fn == 0))
                    return node;
                JoinList(ExpandedNodes, node.GetChildren());
            }
            return null;
        }
    }
}
