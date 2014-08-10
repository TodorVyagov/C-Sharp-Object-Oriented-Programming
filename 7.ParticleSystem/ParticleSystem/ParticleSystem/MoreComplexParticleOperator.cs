using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    class MoreComplexParticleOperator : ParticleUpdater
    {
        private List<Particle> currentTickParticles = new List<Particle>();

        private List<ParticleRepeller> currentTickRepellers = new List<ParticleRepeller>();

        public override IEnumerable<Particle> OperateOn(Particle p)
        {
            var castedRepeller = p as ParticleRepeller;

            if (castedRepeller != null)
            {
                currentTickRepellers.Add(castedRepeller);
            }
            else
            {
                this.currentTickParticles.Add(p);
            }

            return base.OperateOn(p);
        }

        public override void TickEnded()
        {
            foreach (var repeller in this.currentTickRepellers)
            {
                foreach (var particle in this.currentTickParticles)
                {
                    int radius = (int)Math.Sqrt((repeller.Position.Col - particle.Position.Col) * 
                        (repeller.Position.Col - particle.Position.Col) + (repeller.Position.Row - particle.Position.Row) *
                        (repeller.Position.Row - particle.Position.Row));

                    if (radius < repeller.RepellingDistance)
                    {
                        var repellingVector = repeller.Position - particle.Position;
                        int pToAttrRow = repellingVector.Row;
                        pToAttrRow = DecreaseVectorCoordToPower(repeller, pToAttrRow);
                        int pToAttrCol = repellingVector.Col;
                        pToAttrCol = DecreaseVectorCoordToPower(repeller, pToAttrCol);

                        var currentAccelaration = new MatrixCoords(-pToAttrRow, -pToAttrCol);

                        particle.Accelerate(currentAccelaration);
                    }

                }
            }


            this.currentTickParticles.Clear();
            this.currentTickRepellers.Clear();

            base.TickEnded();
        }

        private static int DecreaseVectorCoordToPower(ParticleRepeller repeller, int pToAttrCoord)
        {
            if (Math.Abs(pToAttrCoord) > repeller.RepellingPower)
            {
                pToAttrCoord = (pToAttrCoord / (int)Math.Abs(pToAttrCoord)) * repeller.RepellingPower;
            }

            return pToAttrCoord;
        }
    }
}
