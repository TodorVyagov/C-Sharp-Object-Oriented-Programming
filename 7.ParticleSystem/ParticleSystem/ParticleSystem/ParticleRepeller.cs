using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    class ParticleRepeller : Particle
    {
        public int RepellingPower { get; protected set; }

        public int RepellingDistance { get; private set; }

        public ParticleRepeller(MatrixCoords position, MatrixCoords speed, int repellingPower, int repellingDistance) 
            : base(position, speed)
        {
            this.RepellingPower = repellingPower;
            this.RepellingDistance = repellingDistance;
        }

        public override char[,] GetImage()
        {
            return new char[,] { { 'V' } };
        }
    }
}
