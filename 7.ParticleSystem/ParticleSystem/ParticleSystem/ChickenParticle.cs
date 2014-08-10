/* Create a ChickenParticle class. The ChickenParticle class moves like a ChaoticParticle, but 
randomly stops at different positions for several simulation ticks and, for each of those stops,
creates (lays) a new ChickenParticle. You are not allowed to edit any existing class. */
namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;

    class ChickenParticle : ChaoticParticle
    {
        private const int MaxStopTime = 5;

        private bool isStopped;
        private int waitingTurns;
        private Random rand;

        public ChickenParticle(MatrixCoords position, MatrixCoords speed, int maxTolerance, Random randomGenerator)
            : base(position, speed, maxTolerance, randomGenerator)
        {
            this.rand = randomGenerator;
            this.isStopped = false;
            this.waitingTurns = 0;
        }

        public override IEnumerable<Particle> Update()
        {
            var produced = new List<Particle>();

            if (isStopped == false && rand.Next(101) >= 80) // 20% chance to stop
            {
                this.isStopped = true;
                this.waitingTurns = this.rand.Next(1, MaxStopTime + 1);
            }

            if (this.waitingTurns > 0)
            {
                this.waitingTurns--;
            }
            else if (this.waitingTurns == 0 && this.isStopped == true)
            {
                this.isStopped = false;
                produced.Add(new ChickenParticle(this.Position, this.Speed, this.MaxTolerance, this.rand));
            }

            if (this.isStopped == false)
            {
                this.Move();
            }

            return produced;
        }

        public override char[,] GetImage()
        {
            return new char[,] { { 'O' } };
        }
    }
}
