using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblemApp
{
    public class Nodes
    {
        int data;
        public Nodes next;
        public Nodes prev;
        public Nodes(int value)
        {
            data = value;

        }
    }

    public class CircleInLinkedList
    {
       static Nodes head,tail;
        public  CircleInLinkedList()
        {
            head = null;
            tail = null;
        }
        public async Task InsertLinkedList(int data)
        {
            if (head == null)
            {
                head = new Nodes(data);
                tail = head;
            }
            else
            {
                tail.next = new Nodes(data);
                tail = tail.next;
            }
        }

        public async Task<bool> FindCircle()
        {
            Nodes ptr1 = head;
            Nodes ptr2 = head;

            while (ptr2 != null && ptr2.next != null)
            {
                ptr1 = ptr1.next;
                ptr2 = ptr2.next.next;

                if (ptr1 == ptr2)
                {
                    return true;
                }
            }

            return false;
        }

        static async Task Main(string[] args)
        {

            CircleInLinkedList circleInLinkedList = new CircleInLinkedList();
           await circleInLinkedList.InsertLinkedList(1);
           await circleInLinkedList.InsertLinkedList(2);
            await circleInLinkedList.InsertLinkedList(3);
            await circleInLinkedList.InsertLinkedList(4);
            await circleInLinkedList.InsertLinkedList(5);
            //tail.next = head;
            Console.WriteLine(await circleInLinkedList.FindCircle());




        }

    }
}
