using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticSalesman
{
    class CityMap
    {
        const float minX = 0f;
        const float maxX = 5f;
        const float minY = 0f;
        const float maxY = 5f;

        static Random _random = new Random();

        public List<(float x, float y)> Coordinates { get; set; }

        public int Count { get => Coordinates.Count; }

        public CityMap(int count = 5)
        {
            Coordinates = new List<(float x, float y)>(count);

            for( int index = 0; index < count; ++index )
                Coordinates.Add(GetRandomPoint());
        }

        public (float x, float y) this[int key]
        {
            get => this.Coordinates[key];
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("[");

            for( int index = 0; index < Coordinates.Count; ++index )
            {
                sb.Append($"{index}:({Coordinates[index].x:n2},{Coordinates[index].y:n2})");

                if (index < Coordinates.Count - 1)
                    sb.Append(", ");
            }
            sb.Append("]");

            return sb.ToString();
        }

        private (float x, float y) GetRandomPoint()
        {
            float width = maxX - minX;
            float height = maxY - minY;

            float x = (float)_random.NextDouble() * width + minX;
            float y = (float)_random.NextDouble() * height + minY;

            return (x, y);
        }
    }
}
