using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticSalesman
{
    class Path : IComparable<Path>
    {
        public List<int> Indexes { get; private set; }
        public int Count { get => Indexes.Count; }

        static Random _random = new Random();

        public string Name { get; set; } = "";
        public float Cost { get; set; } = -1f;


        public Path() : this(new int[] { })
        {
        }

        /// <summary>
        /// Initialize as a random path of a given length
        /// </summary>
        /// <param name="length"></param>
        public Path(int length)
        {
            int[] newPathIndexes = new int[length];

            // Initialize path to 0, 1, 2, 3, ...
            for (int index = 0; index < length; ++index)
                newPathIndexes[index] = index;

            // Do a Knuth shuffle
            for (int index = 0; index < length - 1; ++index)
            {
                // Determine pivot
                int pivotIndex = index + _random.Next(length - index);

                // swap index with pivot
                int temp = newPathIndexes[pivotIndex];
                newPathIndexes[pivotIndex] = newPathIndexes[index];
                newPathIndexes[index] = temp;
            }

            Indexes = new List<int>(newPathIndexes);
        }

        public Path(int[] indexes)
        {
            Indexes = new List<int>(indexes);
        }

        public Path Clone()
        {
            return new Path(Indexes.ToArray());
        }

        /// <summary>
        /// Perform given number of NEIGHBOR mutations. Default 1.
        /// </summary>
        public void Mutate(int mutationCount = 1)
        {
            for( int count = 0; count < mutationCount; ++count )
            {
                int index1 = _random.Next(Count - 1);
                int index2 = index1 + 1;

                //// Determine two random, unique indexes
                //int index1 = _random.Next(Count);
                //int index2 = index1;
                //
                //while (index1 == index2)
                //    index2 = _random.Next(Count);
                //
                //// Swap the indexes
                //// indexes of List called "Indexes"... not ideal
                int temp = Indexes[index1];
                Indexes[index1] = Indexes[index2];
                Indexes[index2] = temp;
            }
        }

        /// <summary>
        /// Breed two paths at given cut points. If cut points aren't given, they'll be randomly chosen
        /// </summary>
        /// <param name="otherPath"></param>
        /// <param name="cut1"></param>
        /// <param name="cut2"></param>
        /// <returns></returns>
        public Path BreedWith( Path otherPath, int cut1 = -1, int cut2 = -1 )
        {
            // If NOT passed cut points, choose two randomly that aren't equal
            while(cut1 < 0 || cut1 == cut2)
                cut1 = _random.Next(Count);
            while (cut2 < 0 || cut1 == cut2)
                cut2 = _random.Next(Count);

            // If cuts are out of order, swap them.
            if( cut1 > cut2 )
            {
                int temp = cut1;
                cut1 = cut2;
                cut1 = temp;
            }

            // Create the child. Fill with -1
            int[] childIndexes = new int[Count];
            for (int i = 0; i < Count; ++i)
                childIndexes[i] = -1;

            // Copy the middle section from this parent to child
            for (int i = cut1; i < cut2; ++i)
                childIndexes[i] = this[i];

            // Starting at index cut2, start pulling from other
            int otherParentIndex = cut2;
            for( int i = 0; i < cut1; ++i)
            {
                // move other pointer until it points to something that is not currently in child
                while( childIndexes.Contains(otherPath[otherParentIndex]))
                {
                    otherParentIndex = (otherParentIndex + 1) % Count;
                }

                // Assign that new value to child
                childIndexes[i] = otherPath[otherParentIndex];
            }
            // Do the same thing for child from cut2 to end
            for (int i = cut2; i < Count; ++i)
            {
                // move other pointer until it points to something that is not currently in child
                while (childIndexes.Contains(otherPath[otherParentIndex]))
                {
                    otherParentIndex = (otherParentIndex + 1) % Count;
                }

                // Assign that new value to child
                childIndexes[i] = otherPath[otherParentIndex];
            }

            return new Path(childIndexes);

            // TODO
        }

        /// <summary>
        /// Generate a random path of given length 
        /// </summary>
        /// <param name="length"></param>
        public static Path GenerateRandomPath(int length)
        {
            return new Path(length);
        }

        public int this[int key]
        {
            get => this.Indexes[key];
        }

        public override string ToString()
        {
            string rv = "";

            if (!string.IsNullOrWhiteSpace(Name))
                rv += $"{Name}: ";
            
            rv += "[" + string.Join(",",Indexes) + "]";

            if (Cost > 0)
                rv += $" (cost={Cost})";

            return rv;
        }

        public int CompareTo(Path other)
        {
            float difference = this.Cost - other.Cost;
            if (difference < 0)
                return -1;
            else if (difference > 0)
                return 1;
            else
                return 0;
        }
    }
}
