using System.Collections.Generic;

namespace NqueenSolver
{
    public class Node
    {
        public int[] Position { get; set; }
        public int Depth { get; set; }
        public float Fn { get; set; }

        public Node()
        {
            Position = new int[Data.ChessSize];
            Depth = 0;
        }
        public Node(int[] Position, int Depth)
        {
            this.Position = (int[]) Position.Clone();
            this.Depth = Depth;
            SetFn();
        }
        private void SetFn()
        {
            int Gn = 0;
            for (int i = 0; i < Depth - 1; i++)
                for (int j = i + 1; j < Depth; j++)
                    if (Abstract(Position[i] - Position[j]) == Abstract(i - j))
                        Gn++;
            //float FillHome = 0;
            //for (int i = 0; i < Data.ChessSize; i++)            
            //    for (int j = Depth; j < Data.ChessSize; j++)                
            //        for (int k = 0; k < Depth; k++)
            //        {
            //            bool Conditon1 = Position[k] == i;
            //            bool Conditon2 = Abstract(Position[k]-i)==Abstract(Position[k]-j);
            //            if (Conditon1|| Conditon2)
            //            {
            //                FillHome++;
            //                break;
            //            }
            //        }
            //float Hn1 = FillHome/(Data.ChessSize* (Data.ChessSize- Depth));
            float Hn = (float)(Data.ChessSize-Depth) / (float)Data.ChessSize;
            Fn = Gn + Hn;
        }
        public List<int> GetUnUsedNumber()
        {
            List<int> UnUsedNumber = new List<int>();
            for (int i = 1; i <= Position.Length; i++)
                UnUsedNumber.Add(i);
            for (int i = 0; i < Depth; i++)
                UnUsedNumber.Remove(Position[i]);
            return UnUsedNumber;
        }
        public List<Node> GetChildren()
        {
            List<Node> Childrens = new List<Node>();
            List<int> UnUsedNumber = GetUnUsedNumber();
            foreach (int item in UnUsedNumber)
            {
                int[] TempPositon = (int[] ) this.Position.Clone();
                if (Depth < Data.ChessSize)
                    TempPositon[Depth] = item;                
                Childrens.Add(new Node(TempPositon, Depth + 1));
            }
            return Childrens;
        }
        private int Abstract(int Input)
        {
            return (Input < 0) ? Input * -1 : Input;
        }
    }
}
