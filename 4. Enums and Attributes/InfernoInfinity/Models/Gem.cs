using System;
using InfernoInfinity.Enums;
using InfernoInfinity.Interfaces;
using InfernoInfinity.Core;

namespace InfernoInfinity.Models
{
    public abstract class Gem : IGem
    {
        protected Gem(string clarity)
        {
            this.Clarity = Validator.TryParseClarity(clarity);
            this.StrengthIncrease = (int)this.Clarity;
            this.AgilityIncrease = (int)this.Clarity;
            this.VitalityIncrease = (int)this.Clarity;
        }

        public int StrengthIncrease { get; protected set; }
        public int AgilityIncrease { get; protected set; }
        public int VitalityIncrease { get; protected set; }
        public GemClarity Clarity { get; }
    }
}