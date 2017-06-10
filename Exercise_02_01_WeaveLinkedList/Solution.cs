
using DataStructures;
using System.Diagnostics;

namespace Exercise_02_01_WeaveLinkedList
{
    public class Solution<T>
    {
        // Convert
        // a1->a2->a3->a4.....->an->b1->b2->b3->......->bn
        // to
        // a1->b1->a2->b2->.....->an->bn

        public void WeaveLinkedList(LinkedList<T> linkedList)
        {
            linkedList.Print();

            // Create to pointers one moves twice as fast as the other
            LinkedList<T>.Node walking = linkedList.Head;
            LinkedList<T>.Node running = linkedList.Head;

            // Find midpoint
            while (running!= null && running.Next != null && running.Next.Next != null)
            { 
                // Move walking
                walking = walking.Next;
                // Move running
                running = running.Next.Next;
            }

            // Now reset running back to head
            running = linkedList.Head;
            walking = walking.Next;

            // Start weaving
            while (walking != null && walking.Next != null)
            {
                var temp = walking.Next;
                // Remove the node where walking pointer at
                var removedNode = linkedList.Remove(walking);

                Debug.Assert(removedNode != null, "Node should exist");
                linkedList.InsertAtNode(running, removedNode);

                // Update pointers
                walking = temp;
                running = running.Next.Next;

                linkedList.Print();
            }

            linkedList.Print();
        }
    }
}
