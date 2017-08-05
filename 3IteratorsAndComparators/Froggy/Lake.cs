using System.Collections;
using System.Collections.Generic;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        private int[] stones;

        public Lake(int[] inputStones)
        {
            this.stones = inputStones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.stones.Length; i += 2)
            {
                yield return this.stones[i];
            }

            int reverseStartPoint = this.stones.Length - 1;
            if (this.stones.Length % 2 != 0)
            {
                reverseStartPoint = this.stones.Length - 2;
            }

            for (int i = reverseStartPoint; i >= 1; i -= 2)
            {
                yield return this.stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
