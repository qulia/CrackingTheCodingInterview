using DataStructures;

namespace Question_02_08_LoopDetection
{
    public class Solution<T>
    {
        public LinkedList<T>.Node DetectLoop(LinkedList<T> linkedList)
        {
            if (linkedList.Head == null)
            {
                // Empty
                return null;
            }

            // Full loop?
            if (linkedList.Tail.Next == linkedList.Head)
            {
                return linkedList.Head;
            }

            LinkedList<T>.Iterator slowIterator = new LinkedList<T>.Iterator(linkedList.Head, 1);
            LinkedList<T>.Iterator fastIterator = new LinkedList<T>.Iterator(linkedList.Head, 2);

            var firstCollision = GetCollision(slowIterator, fastIterator);

            LinkedList<T>.Iterator slowIteratorAtCollision = new LinkedList<T>.Iterator(firstCollision, 1);
            LinkedList<T>.Iterator slowIteratorAtStart = new LinkedList<T>.Iterator(linkedList.Head, 1);

            var secondCollision = GetCollision(slowIteratorAtCollision, slowIteratorAtStart);

            return secondCollision;
         }

        LinkedList<T>.Node GetCollision(LinkedList<T>.Iterator iterator1, LinkedList<T>.Iterator iterator2)
        {
            while (iterator1.Current != null && iterator2.Current != null)
            {
                iterator1.Next();
                iterator2.Next();

                if (iterator1.Current == iterator2.Current)
                {
                    return iterator1.Current;
                }               
            }

            return null;
        }
    }
}
