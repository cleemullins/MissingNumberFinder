using MissingNumberFinder;
using System;
using Xunit;

namespace MissingNumberFinderTests
{
    public class FindMissingNumberTests
    {
        [Fact]
        public void Null_Array_Should_Throw()
        {
            Assert.Throws<ArgumentNullException>(() => NumberFinder.FindMissingValue(null));
        }

        [Fact]
        public void Zero_Delta_Should_Throw()
        {
            Assert.Throws<InvalidOperationException>(() => NumberFinder.FindMissingValue(new int[] { 0, 0, 0 }));
        }

        [Theory] // [item, item, item, MISSING NUMBER]
        [InlineData(1, 2, 4, 3)]
        [InlineData(1, 3, 4, 2)]
        [InlineData(10, 12, 13, 11)]
        public void Correct_Results_For_Three_Item_Lists(int value0, int value1, int value2, int missingNumber)
        {
            int[] values = new int[] { value0, value1, value2 };
            int result = NumberFinder.FindMissingValue(values);
            Assert.True(result == missingNumber, $"Incorrect value. Actual: {result}, Expected: {missingNumber}");
        }

        [Theory] // [item, [...], item, MISSING NUMBER]
        [InlineData(1, 2, 4, 5, 3)] // midpoint missing
        [InlineData(1, 3, 4, 5, 2)] // left of center missing
        [InlineData(10, 11, 12, 14, 13)] // right of center missing
        public void Correct_Results_For_Four_Item_Lists(int value0, int value1, int value2, int value3, int missingNumber)
        {
            int[] values = new int[] { value0, value1, value2, value3 };
            int result = NumberFinder.FindMissingValue(values);
            Assert.True(result == missingNumber, $"Incorrect value. Actual: {result}, Expected: {missingNumber}");
        }

        [Theory] // [item, [...], item, MISSING NUMBER]
        [InlineData(1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 10)] // 10 missing (right end)
        [InlineData(1, 3, 4, 5, 6, 7, 8, 9, 10, 11, 2)] // 2 missing (left end)
        [InlineData(1, 2, 3, 4, 6, 7, 8, 9, 10, 11, 5)] // 5 missing (midpoint)
        public void Correct_Results_For_10_Item_Lists(int value0, int value1, int value2, int value3,
                                                        int value4, int value5, int value6,
                                                        int value7, int value8, int value9,
                                                        int missingNumber)
        {
            int[] values = new int[] { value0, value1, value2, value3, value4, value5, value6, value7, value8, value9 };
            int result = NumberFinder.FindMissingValue(values);
            Assert.True(result == missingNumber, $"Incorrect value. Actual: {result}, Expected: {missingNumber}");
        }
    }
}
