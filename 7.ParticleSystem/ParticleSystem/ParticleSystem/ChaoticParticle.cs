/*Create a ChaoticParticle class, which is a Particle, randomly changing its movement (Speed).
 * You are not allowed to edit any existing class.*/
namespace ParticleSystem
{
    using System;

    class ChaoticParticle : Particle
    {
        private Random rand;

        public ChaoticParticle(MatrixCoords position, MatrixCoords speed, int maxTolerance, Random randomGenerator)
            : base(position, speed)
        {
            this.MaxTolerance = maxTolerance;
            this.rand = randomGenerator;
        }

        public int MaxTolerance { get; private set; }

        protected override void Move()
        {
            int newRow = this.rand.Next(this.Speed.Row - this.MaxTolerance, this.Speed.Row + this.MaxTolerance + 1);
            int newCol = this.rand.Next(this.Speed.Col - this.MaxTolerance, this.Speed.Col + this.MaxTolerance + 1);

            this.Speed = new MatrixCoords(newRow, newCol);
            base.Move();
        }

        public override char[,] GetImage()
        {
            return new char[,] { { 'X' } };
        }
    }
}
