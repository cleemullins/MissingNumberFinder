using System;

namespace MissingNumberFinder
{
    public static class NumberFinder
    {
        private static void AssertValidSequence(int [] sequence)
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

        public static int FindDelta(int [] sequence)
        {
            // Given a list of numbers all spaced out by the same value, one of those values is missing. This
            // function determines the delta between numbers. 
            // For a sequnce of 0, 1, or 2 numbers this problem isn't valid. 
            // Examples: 
            // { 1,2,3,4,6 } (Note: The 5 is missing).  Δ = 1
            // { 2,4,8 } (Note: 6 is missing). Δ = 2

            // Make sure the passed in params are valid
            AssertValidSequence(sequence);

            var startFinishDelta = sequence[sequence.Length - 1] - sequence[0];
            var delta = startFinishDelta / sequence.Length;

            return delta;
        }

        public static int FindMissingValue( int [] sequence)
        {
            // Make sure the passed in params are valid
            AssertValidSequence(sequence);

            // Get the expected delta value for the sequence
            int delta = FindDelta(sequence);
            if (delta == 0)
            {
                throw new InvalidOperationException("Not allowed for a zero delta.");
            }

            int startIndex = 0;
            int endIndex = sequence.Length - 1;
            while (startIndex <= endIndex)
            {
                // 0, 1, 3
                // Expected value at:
                // [0] = 0
                // [1] = 0 + ([1] * 1)
                // [2] = 0 + (2 * 1)

                // {1, 3, 4 }                

                int midpoint = (startIndex + endIndex) / 2;
                int expectedValue = sequence[0] + (midpoint * delta);
                if (sequence[midpoint] == ExpectedValueAtIndex(sequence, midpoint, delta))
                {
                    // Everything up to this point is good. Look to the right. 
                    startIndex = midpoint + 1;
                }
                else if (sequence[midpoint-1] == ExpectedValueAtIndex(sequence, midpoint-1, delta))
                {
                    return expectedValue;
                }
                else
                {
                    endIndex = midpoint - 1;
                }
            }

            throw new Exception("No Missing value found");
        }

        private static int ExpectedValueAtIndex(int [] sequence, int index, int delta)
        {
            return sequence[0] + (index * delta);
        }
    }
}