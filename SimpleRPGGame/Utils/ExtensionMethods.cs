using System;
using System.Collections.Generic;

namespace WarlordsOfDraemor
{
    public static class ExtensionMethods
    {
        public static List<Object> Random(this List<Object> input, int count = 1)
        {
            // Generate an empty list to populate and return once populated
            List<Object> randomSelections = new List<object>();
            // Copy the input into a temporary list (to remove each item as it is added)
            List<Object> temp = input;
            // Generate an instance of Random
            Random myRand = new Random();
            // Copy the temp list into an array
            Object[] arr = temp.ToArray();

            // Loop the logic for the requested number of iterations (or until the array length is exceeded)
            for (int i = 0; i < count || i < arr.Length - 1; i++)
            {
                // Break if there are no items (left) in the array
                if (arr.Length == 0) break;
                // Choose a random item from the array
                Object chosen = arr[myRand.Next(arr.Length - 1)];
                // Add that selection to the intended output list
                randomSelections.Add(chosen);
                // Remove the selection from the temp list
                temp.Remove(chosen);
                // Copy the updated list temp back into the arr array
                arr = temp.ToArray();
            }

            // Return the now populated list of random items
            return randomSelections;
        }
    }
}
