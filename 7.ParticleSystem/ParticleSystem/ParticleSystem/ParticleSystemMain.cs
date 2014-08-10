using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    class ParticleSystemMain
    {
        const int SimulationRows = 30;
        const int SimulationCols = 40;

        static readonly Random RandomGenerator = new Random();

        static void Main(string[] args)
        {
            var renderer = new ConsoleRenderer(SimulationRows, SimulationCols);
            var particleOperator = new AdvancedParticleOperator();
            var particleOperatorRepeller = new MoreComplexParticleOperator(); //Tasks 5 and 6

            var particles = new List<Particle>()
            {
               new Particle(new MatrixCoords(5, 5), new MatrixCoords(1, 1)),
               new Particle(new MatrixCoords(5, 15), new MatrixCoords(1, 0)),
                //new ParticleEmitter(new MatrixCoords(10, 20), new MatrixCoords(0, 0), RandomGenerator),
                new ParticleEmitter(new MatrixCoords(5, 20), new MatrixCoords(0, 0), RandomGenerator),
                //new VariousLifetimeParticleEmitter(new MatrixCoords(29, 1), new MatrixCoords(0, 0), RandomGenerator),

                //new ParticleAttractor(new MatrixCoords(15, 8), new MatrixCoords(), 5),
                //new ParticleAttractor(new MatrixCoords(15, 20), new MatrixCoords(), 1),

                //Tasks 1 and 2
                //new ChaoticParticle(new MatrixCoords(20, 20), new MatrixCoords(1, 0), 1, RandomGenerator), 
                //use 1 for tolerance to be able to see how the particle is moving randomly

                //Tasks 3 and 4
                //new ChickenParticle(new MatrixCoords(10, 20), new MatrixCoords(0, 0), 1, RandomGenerator), 
                // note that the new created ChickenParticle is visible at the next turn

                //Tasks 5 and 6
                new ParticleRepeller(new MatrixCoords(15, 15), new MatrixCoords(0,0), 2, 8),
            };

            //var engine = new Engine(renderer, particleOperator, particles, 500);
            var engine = new Engine(renderer, particleOperatorRepeller, particles, 500);

            engine.Run();
        }
    }
}
