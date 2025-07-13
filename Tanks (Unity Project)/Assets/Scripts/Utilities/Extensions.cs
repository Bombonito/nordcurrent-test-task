using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public static class Extensions
    {
        public static T Random<T>(this List<T> collection)
        {
            var randomIndex = UnityEngine.Random.Range(0, collection.Count);
            return collection[randomIndex];
        }

        public static T Random<T>(this T[] collection)
        {
            var randomIndex = UnityEngine.Random.Range(0, collection.Length);
            return collection[randomIndex];
        }
        
        public static void IgnoreCollisions(this GameObject root) => IgnoreCollisions(root, root);

        public static void IgnoreCollisions(this GameObject a, GameObject b)
        {
            if (a is null || a == false || b is null || b == false)
                return;
            
            var collidersA = a.GetComponentsInChildren<Collider>(includeInactive: true);
            var collidersB = b.GetComponentsInChildren<Collider>(includeInactive: true);
            
            for (int i = 0; i < collidersA.Length; i++)
            {
                for (int j = 0; j < collidersB.Length; j++)
                {
                    Physics.IgnoreCollision(collidersA[i], collidersB[j]);
                }
            }
        }
        
        // https://stackoverflow.com/questions/273313/randomize-a-listt
        public static void Shuffle<T>(this IList<T> list)  
        {  
            int n = list.Count;  
            while (n > 1) {  
                n--;
                int k = UnityEngine.Random.Range(0, n + 1);
                T value = list[k];  
                list[k] = list[n];  
                list[n] = value;  
            }  
        }
        
        // https://stackoverflow.com/questions/108819/best-way-to-randomize-an-array-with-net
        public static void Shuffle<T> (this T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = UnityEngine.Random.Range(0, n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }
}