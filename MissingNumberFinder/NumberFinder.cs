using System;

namespace MissingNumberFinder
{
    public static class NumberFinder
    {
        private static void AssertValidSequence(int[] sequence)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException(nameof(sequence));
            }

            if (sequence.Length == 0 ||
                sequence.Length == 1 ||
                sequence.Length == 2)
            {
                throw new InvalidOperationException("Invalid sequence length");
            }
        }

        /// <summary>
        /// Given a list of numbers all spaced out by the same value, one of those values is missing. This
        /// function determines the delta between numbers via formula. 
        /// For a sequence of 0, 1, or 2 numbers this problem isn't valid. 
        /// Examples: 
        /// { 1,2,3,4,6 } (Note: The 5 is missing).  Δ = 1
        /// { 2,4,8 } (Note: 6 is missing). Δ = 2
        /// </summary>
        /// <param name="sequence">The array of whole numbers to analyze.</param>
        /// <returns>The whole nubmer representing the delta (Δ) value.</returns>
        public static int FindDelta(int[] sequence)
        {
            // Make sure the passed in params are somewhat sensical.
            AssertValidSequence(sequence);

            var startFinishDelta = sequence[sequence.Length - 1] - sequence[0];
            var delta = startFinishDelta / sequence.Length;

            return delta;
        }

        /// <summary>
        /// Finds the missing value in a sequence of whole numbers. 
        /// </summary>
        /// <remarks>
        /// Uses a basic binary search to scan the array lookig for the missing 
        /// value. The key observation is that we know what the value at a given
        /// index **should** be, and so we can quickly find the one that's 
        /// incorrect.                
        /// </remarks>
        /// <param name="sequence">The sequence of whole numbers (with one missing) to analyze.</param>
        /// <returns>The missing value.</returns>
        public static int FindMissingValue(int[] sequence)
        {
            // Make sure the passed in params are valid
            AssertValidSequence(sequence);

            // Get the expected delta value for the sequence
            int delta = FindDelta(sequence);
            if (delta == 0)
            {
                throw new InvalidOperationException("A delta of Zero is not valid.");
            }

            int startIndex = 0;
            int endIndex = sequence.Length - 1;
            while (startIndex <= endIndex)
            {
                int midpoint = (startIndex + endIndex) / 2;
                int expectedValue = ExpectedValueAtIndex(sequence, midpoint, delta);

                if (sequence[midpoint] == expectedValue)
                {
                    // Everything up to this point is good. Look to the right in the set. 
                    startIndex = midpoint + 1;
                }
                else if (sequence[midpoint - 1] == ExpectedValueAtIndex(sequence, midpoint - 1, delta))
                {
                    // Expected value is not correct at the current index, 
                    // yet the value just to the left of us is correct. That means we are 
                    // on the first incorrect index. Return the expected value. 
                    return expectedValue;
                }
                else
                {
                    // Expected value is not correct at the current index, 
                    // Yet the value just to the left of us is *ALSO* incorrect, 
                    // meaning the problem lies somewhere in the left half of the set.  
                    endIndex = midpoint - 1;
                }
            }

            throw new Exception("No Missing value found");
        }

        private static int ExpectedValueAtIndex(int[] sequence, int index, int delta)
        {
            return sequence[0] + (index * delta);
        }
    }
}