using MissingNumberFinder;
using System;
using Xunit;

namespace MissingNumberFinderTests
{
    /// <summary>
    /// Runs through basic tests for finding the expected delta in 
    /// the NumberFinder FindDelta function. 
    /// Leverages simple XUnit theory tests. 
    /// </summary>
    public class FindDeltaTests
    {
        [Fact]
        public void Null_Array_Should_Throw()
        {
            Assert.Throws<ArgumentNullException>(() => NumberFinder.FindDelta(null));
        }

        [Fact]
        public void Invalid_Length_Array_Should_Throw()
        {
            // Empty array should throw
            Assert.Throws<InvalidOperationException>(() => NumberFinder.FindDelta(new int[] {}));

            // Array length of 1 should throw
            Assert.Throws<InvalidOperationException>(() => NumberFinder.FindDelta( new int[] { 0 } ));

            // Array length of 2 should throw
            Assert.Throws<InvalidOperationException>(() => NumberFinder.FindDelta(new int[] { 0, 1}));            
        }

        [Theory] // [item, item,item, Expected Delta]
        [InlineData(1, 2, 4, 1)] 
        [InlineData(2, 4, 8, 2)]
        [InlineData(3, 9, 12, 3)]
        public void Correct_Results_For_Three_Item_Lists(int value0, int value1, int value2, int delta)
        {
            int[] values = new int[] { value0, value1, value2 };
            int result = NumberFinder.FindDelta(values);
            Assert.True(result == delta, $"Incorrect value. Actual: {result}, Expected: {delta}");
        }

        [Theory] // [item, item,item, item, Expected Delta]
        [InlineData(1, 2, 3, 5, 1)]
        [InlineData(2, 6, 8, 10, 2)]
        [InlineData(3, 6, 9, 15, 3)]
        public void Correct_Results_For_Four_Item_Lists(int value0, int value1, int value2, int value3, int delta)
        {
            int[] values = new int[] { value0, value1, value2, value3 };
            int result = NumberFinder.FindDelta(values);
            Assert.True(result == delta, $"Incorrect value. Actual: {result}, Expected: {delta}");
        }

        [Theory] // [item, item, item, item, Expected Delta]
        [InlineData(1, 2, 3, 5, 7, 1)]
        [InlineData(2, 6, 8, 10, 12, 2)]
        [InlineData(3, 6, 9, 15, 18, 3)]
        public void Correct_Results_For_Five_Item_Lists(int value0, int value1, int value2, int value3, int value4, int delta)
        {
            int[] values = new int[] { value0, value1, value2, value3, value4 };
            int result = NumberFinder.FindDelta(values);
            Assert.True(result == delta, $"Incorrect value. Actual: {result}, Expected: {delta}");
        }
    }
}
