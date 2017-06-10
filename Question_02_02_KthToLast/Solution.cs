
using DataStructures;

namespace Question_02_02_KthToLast
{
    public class Solution<T>
    {
        public T KthToLast(LinkedList<T> list, int k)
        {
            T data = default(T);
            KthToLast(list.Head, k, ref data);

            return data;
        }

        int KthToLast(LinkedList<T>.Node currentNode, int k, ref T data)
        {
            if (currentNode == null)
            {
                // Reached to the end
                // The value is not ready just return
                return 0;
            }

            int counter =  KthToLast(currentNode.Next, k, ref data);

            // going up the recursion, releasing calls
            if (counter == k)
            {
                // we are k away from the last call
                // save the data
                data = currentNode.Data;                   
            }

            // Increment the counter and go up the recursion stack
            counter++;                                                                                                                                                          
            return counter;
         }
    }
}
