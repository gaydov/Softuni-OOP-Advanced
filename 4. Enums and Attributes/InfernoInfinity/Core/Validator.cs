using InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfernoInfinity.Core
{
    public static class Validator
    {
        public static bool IsNull(object obj)
        {
            return obj == null;
        }

        public static bool IsIndexInArray(int index, int arrayLength)
        {
            return index >= 0 && index < arrayLength;
        }

        public static GemClarity TryParseClarity(string clarity)
        {
            try
            {
                return (GemClarity)Enum.Parse(typeof(GemClarity), clarity);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Invalid input clarity type");
            }
        }

        public static WeaponRarity TryParseRarity(string rarity)
        {
            try
            {
                return (WeaponRarity)Enum.Parse(typeof(WeaponRarity), rarity);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Invalid input rarity type");
            }
        }
    }
}
