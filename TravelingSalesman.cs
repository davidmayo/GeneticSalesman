using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticSalesman
{
    class TravelingSalesman
    {
        public double InitialCost { get; private set; }
        public double ImprovementFraction { get => Paths[0].Cost / InitialCost; }
        public int MutationRate { get; set; } = 1;
        private static Random _random = new Random();
        public int Generations { get; private set; }
        public CityMap Map { get; set; }
        public List<Path> Paths { get => paths; private set => paths = value; }

        private int totalPathsCreated;
        private List<Path> paths;

        public TravelingSalesman(int cityCount, int pathCount)
        {
            Generations = 0;
            Map = new CityMap(cityCount);

            totalPathsCreated = 0;

            Paths = new List<Path>(pathCount);
            for (int i = 0; i < pathCount; ++i)
                Paths.Add(Path.GenerateRandomPath(cityCount));

            Path path;
            for (int index = 0; index < pathCount; ++index)
            {
                path = Paths[index];
                //CalculatePathCost(ref path);
                path.Name = $"path-{totalPathsCreated,0:0,000}";
                ++totalPathsCreated;
            }
            CalculateAllCosts();

            Paths.Sort();

            InitialCost = Paths[0].Cost;
        }

        public void Evolve(int generationsToEvolve = 1, bool addRandomParents = false, bool addMutantClones = false, bool randomizeMutationRate = false)
        {
            for (int genCount = 0; genCount < generationsToEvolve; ++genCount)
            {
                ++Generations;

                // If add random parents, add a bunch of random parents first
                // (My guess is that this won't be helpful, but it will slow things down)
                int originalParentCount = Paths.Count;
                if (addRandomParents)
                {
                    for (int i = 0; i < originalParentCount; ++i)
                    {
                        Paths.Add(Path.GenerateRandomPath(Map.Count));
                        ++totalPathsCreated;
                    }
                }

                // Generate number of children equal to current size
                // choosing random parents for each.
                int numParents = Paths.Count;
                for (int i = 0; i < numParents; ++i)
                {
                    int parent1index = _random.Next(numParents);
                    int parent2index = _random.Next(numParents);

                    while (parent1index == parent2index)
                        parent2index = _random.Next(numParents);

                    // Generate child
                    Path childPath = Paths[parent1index].BreedWith(Paths[parent2index]);
                    //CalculatePathCost(ref childPath);
                    childPath.Name = $"path-{totalPathsCreated,0:0,000}";
                    ++totalPathsCreated;

                    // Mutate all children
                    int thisChildMutationRate = randomizeMutationRate ? _random.Next(MutationRate * 2) : MutationRate;
                    childPath.Mutate(thisChildMutationRate);

                    Paths.Add(childPath);
                }

                // If addMutantClones, create mutated clones of all the original parents
                // I don't know if this wll be good.
                if (addMutantClones)
                {
                    for (int i = 0; i < originalParentCount; ++i)
                    {
                        Path clonePath = Paths[i].Clone();

                        int thisChildMutationRate = randomizeMutationRate ? _random.Next(MutationRate * 2) : MutationRate;
                        clonePath.Mutate(thisChildMutationRate);

                        Paths.Add(clonePath);
                        ++totalPathsCreated;
                    }
                }
                

                CalculateAllCosts();

                // Sort
                Paths.Sort();

                // Chop off worst performers, so that population size stays constant
                //Paths.RemoveRange(numParents, numParents);
                Paths = Paths.GetRange(0, originalParentCount);
            }
        }

        private void CalculateAllCosts()
        {
            for (int i = 0; i < Paths.Count; ++i)
            {
                paths[i].Cost = CalculatePathCost(paths[i]);
                //CalculatePathCost(ref path);
            }
        }

        private static float CalculateDistance((float x, float y) coord1, (float x, float y) coord2)
        {
            float deltaX = coord1.x - coord2.x;
            float deltaY = coord1.y - coord2.y;

            float rv = (float)Math.Sqrt((double)(deltaX * deltaX + deltaY * deltaY));

            //MessageBox.Show($"({coord1.x},{coord1.y}) to ({coord2.x},{coord2.y})\ndeltaX={deltaX}; deltaY={deltaY}\nrv={rv}");
            return rv;
        }

        private float CalculatePathCost(Path path)
        {
            (float x, float y) startCoord = Map[path[0]];
            (float x, float y) endCoord;

            float distance = 0f;

            // Calculate each leg from start to end
            for (int i = 0; i < path.Count - 1; ++i)
            {
                startCoord = Map[path[i]];
                endCoord = Map[path[i + 1]];
                distance += CalculateDistance(startCoord, endCoord);
            }

            // Calculate end to start leg (close the loop)
            startCoord = Map[path[path.Count - 1]];
            endCoord = Map[path[0]];
            distance += CalculateDistance(startCoord, endCoord);

            return distance;
        }
        //private void CalculatePathCost(ref Path path)
        //{
        //    (float x, float y) startCoord = Map[path[0]];
        //    (float x, float y) endCoord;
        //
        //    float distance = 0f;
        //
        //    // Calculate each leg from start to end
        //    for (int i = 1; i < path.Count; ++i)
        //    {
        //        endCoord = Map[path[i]];
        //        distance += CalculateDistance(startCoord, endCoord);
        //    }
        //
        //    // Calculate end to start leg (close the loop)
        //    startCoord = Map[Map.Count - 1];
        //    endCoord = Map[0];
        //    distance += CalculateDistance(startCoord, endCoord);
        //
        //    path.Cost = distance;
        //}

        public void ResetAll()
        {
            // TODO
        }

        public List<(float x, float y)> GetPathCoordinates(Path path)
        {
            List<(float x, float y)> rv = new List<(float x, float y)>();

            foreach (int index in path.Indexes)
            {
                rv.Add(Map[index]);
            }

            return rv;
        }

        public List<(float x, float y)> GetWorstPathCoordinates()
        {
            return GetPathCoordinates(Paths[Paths.Count - 1]);
            throw new NotImplementedException();
        }

        public List<(float x, float y)> GetBestPathCoordinates()
        {
            return GetPathCoordinates(Paths[0]);
            //throw new NotImplementedException();
        }

        public override string ToString()
        {
            string rv = "";
            rv += $"Gen={Generations}. Pop={Paths.Count}. Total={totalPathsCreated}.\r\nCurrent best cost={Paths[0].Cost:n3}    Initial best cost={InitialCost:n3}   Fraction={100.0 * ImprovementFraction:n3}%\r\n\r\n";

            rv += Map.ToString() + "\r\n\r\n";

            foreach (Path path in Paths)
                rv += path.ToString() + "\r\n";

            return rv;
        }
    }
}
