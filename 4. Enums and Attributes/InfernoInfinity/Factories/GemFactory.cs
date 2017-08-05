using System;
using InfernoInfinity.Interfaces;
using InfernoInfinity.Models;

namespace InfernoInfinity.Factories
{
    public class GemFactory
    {
        public static IGem GenerateGem(string gemType, string clarity)
        {
            switch (gemType)
            {
                case "Amethyst":
                    return new Amethyst(clarity);

                case "Emerald":
                    return new Emerald(clarity);

                case "Ruby":
                    return new Ruby(clarity);
            }

            throw new ArgumentException("Invalid input gem type.");
        }
    }
}