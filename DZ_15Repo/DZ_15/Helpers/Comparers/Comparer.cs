namespace DZ_15.Helpers.Comparers
{
    using System;
    using System.Collections;

    /// <summary>
    /// This is for comparing elements.
    /// </summary>
    public class Comparer : IComparer
    {
        /// <inheritdoc/>
        public int Compare(object first, object second)
        {
            try
            {
                int x = (int)first;
                int y = (int)second;

                if (x > y)
                {
                    return 1;
                }
                else if (x < y)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            catch (InvalidCastException e)
            {
                throw new InvalidCastException("Can`t convert to int.", e);
            }
        }
    }
}
