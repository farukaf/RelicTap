using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public static class Assist
    {
        public static string[] RandomNames = { "Monstro1", "Monstro2", "Monstro3",
            "Aberracao1", "Aberracao2", "Aberracao3",
            "Demon1", "Demon2", "Demon3" };


        /// <summary>
        /// Genera a number betwee min and max (including boths)
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int IntGenerator(int min, int max)
        {
            int result = 0;

            double a = Random.value * ((max + 0.99999) - min);

            result = (int)(min + a);

            return result;
        }

        public static float FloatGenerator(float min, float max)
        {
            float result = 0;

            double a = Random.value * (max - min);

            result = (float)(min + a);

            return result;
        }

        public static Sprite[] AllItemSprites = Resources.LoadAll<Sprite>("RandomItems");

        /// <summary>
        /// Add a string with the "enemyId|skillId" to be dealt withing the next update in the right place
        /// </summary>
        public static string[] skillQuery;

        public static Items AllItems(int Id)
        {
            Items item = new Items() { id = Id };
            item.Load();

            return item;
        }

        public static void Randomize<T>(T[] items)
        {

            Random rand = new Random();

            for (int i = 0; i < items.Length - 1; i++)
            {
                int j = IntGenerator(i, items.Length-1);
                T temp = items[i];
                items[i] = items[j];
                items[j] = temp;
            }
        }
    }
}
