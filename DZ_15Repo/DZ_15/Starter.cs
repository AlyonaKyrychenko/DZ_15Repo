namespace DZ_15
{
    using System;

    /// <summary>
    /// This is sratrer of this programm.
    /// </summary>
    public class Starter
    {
        /// <summary>
        /// This is method for starting.
        /// </summary>
        public void Run()
        {
            const string separator = "_______________________\n";
            const int position = 3;
            const int index = 22;
            const int valueToRemove = 9;
            const int valueToInsert = 18;

            var myList = new SomeList<int>();

            myList.AddObject(1);
            myList.AddObject(9);
            myList.AddObject(22);
            myList.AddObject(5);
            myList.AddObject(3);

            Console.WriteLine("All your objects:\n");
            foreach (object ob in myList.ObjectList)
            {
                Console.WriteLine(ob.ToString());
            }

            Console.WriteLine(separator);

            Console.WriteLine($"Inserting object to the position {position}:\n");
            myList.InsertList(position, valueToInsert);
            foreach (object ob in myList.ObjectList)
            {
                Console.WriteLine(ob);
            }

            Console.WriteLine(separator);

            Console.WriteLine($"After removing {valueToRemove} object from list:\n");
            myList.Remove(valueToRemove);
            foreach (object ob in myList.ObjectList)
            {
                Console.WriteLine(ob);
            }

            Console.WriteLine(separator);

            Console.WriteLine($"After removing objects after position {position} from list:\n");
            myList.RemoveAt(position);
            foreach (object ob in myList.ObjectList)
            {
                Console.WriteLine(ob);
            }

            Console.WriteLine(separator);

            Console.WriteLine($"Index of {index} element:\n");
            myList.IndexOf(index);

            Console.WriteLine(separator);

            Console.WriteLine($"After sorting list:\n");
            myList.Sort();
            foreach (object ob in myList.ObjectList)
            {
                Console.WriteLine(ob);
            }
        }
    }
}
