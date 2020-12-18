namespace DZ_15
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Comparer = DZ_15.Helpers.Comparers.Comparer;

    /// <summary>
    /// This is for methods of list.
    /// </summary>
    /// <typeparam name="T">T is for IComparable.</typeparam>
    public class SomeList<T> : IEnumerable, IEnumerator
    where T : IComparable<T>
    {
        private T[] objectList = new T[0];
        private int index = -1;
        private int count = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="SomeList{T}"/> class.
        /// </summary>
        public SomeList()
        {
            this.objectList = new T[0];
        }

        /// <inheritdoc/>
        public object Current
        {
            get
            {
                return this.objectList[this.index];
            }
        }

        /// <summary>
        /// Gets count of elements in array.
        /// </summary>
        public int Count => this.count;

        /// <summary>
        /// Gets this length of array.
        /// </summary>
        public int Length
        {
            get { return this.objectList.Length; }
        }

        /// <summary>
        /// Gets or sets this T.
        /// </summary>
        public T[] ObjectList { get => this.objectList; set => this.objectList = value; }

        /// <summary>
        /// This is for IEnumerable.
        /// </summary>
        /// <returns>IEnumerable methods.</returns>
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        /// <summary>
        /// This is one of IEnumerator methods.
        /// </summary>
        /// <returns>bool.</returns>
        public bool MoveNext()
        {
            if (this.index == this.objectList.Length - 1)
            {
                this.Reset();
                return false;
            }

            this.index++;
            return true;
        }

        /// <summary>
        /// This is one of IEnumerator methods.
        /// </summary>
        public void Reset()
        {
            this.index = -1;
        }

        /// <summary>
        /// This is for adding objects to array.
        /// </summary>
        /// <param name="ob">ob is some object of array.</param>
        public void AddObject(T ob)
        {
            if (this.count == this.objectList.Length)
            {
                Array.Resize(ref this.objectList, this.objectList.Length + 1);
            }

            this.objectList[this.count] = ob;
            this.count++;
        }

        /// <summary>
        /// This is for adding objects to array.
        /// </summary>
        /// <param name="ob">collection is some object of array.</param>
        public void AddRange(ICollection<T> ob)
        {
            foreach (var obj in ob)
            {
                this.AddObject(obj);
            }
        }

        /// <summary>
        /// This is for inserting to the array.
        /// </summary>
        /// <param name="index">index of element to insert.</param>
        /// <param name="ob">some object of array.</param>
        public void InsertList(int index, T ob)
        {
            if (index < 0 || index >= this.count)
            {
                return;
            }

            var arr = new T[this.objectList.Length + 1];
            Array.Copy(this.objectList, arr, index);
            arr[index] = ob;

            for (int i = index; i < this.objectList.Length; i++)
            {
                arr[i + 1] = this.objectList[i];
            }

            this.objectList = arr;
        }

        /// <summary>
        /// This is for removing from the array.
        /// </summary>
        /// <param name="ob">some object of array.</param>
        /// <returns>can or can`t remove.</returns>
        public bool Remove(T ob)
        {
            for (int i = 0; i < this.count; i++)
            {
                if (this.objectList[i].Equals(ob))
                {
                    var arr = new T[this.objectList.Length - 1];
                    Array.Copy(this.objectList, arr, i);
                    for (; i < arr.Length; i++)
                    {
                        arr[i] = this.objectList[i + 1];
                    }

                    this.objectList = arr;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// This is for inserting to the array.
        /// </summary>
        /// <param name="position">position of the object.</param>
        public void RemoveAt(int position)
        {
            if (position <= this.count && position > -1)
            {
                var arr = new T[position];
                Array.Copy(this.objectList, arr, position);
                this.objectList = arr;
                this.count = arr.Length;
            }
        }

        /// <summary>
        /// This is for getting index of object in the array.
        /// </summary>
        /// <param name="ob">some object of array.</param>
        /// <returns>index of element.</returns>
        public int IndexOf(int ob)
        {
            int i = Array.IndexOf(this.objectList, ob);
            Console.WriteLine(i);
            return i;
        }

        /// <summary>
        /// This method for sorting.
        /// </summary>
        public void Sort()
        {
            IComparer comparer = new Comparer();
            Array.Sort(this.objectList, 0, this.objectList.Length, comparer);
        }
    }
}
