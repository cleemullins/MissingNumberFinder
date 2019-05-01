# Summary
This repo explores how to use XUnit Theory tests using the InlineData attribute. 

# Problem
A given sequence of whole numbers all have the same delta (Δ), yet one number is missing. Find the missing number. For example:

Example 1: {1,2,4} Δ=1, Missing = 3 <br/>
Example 2: {1,3,4} Δ=1, Missing = 2 <br/>
Example 3: {2,6,8} Δ=2, Missing = 4 <br/>
Example 4: {1,2,4,5} Δ=1, Missing = 3 <br/>
Example 5: {10,20,40,50} Δ=10, Missing = 30 <br/>
Example 6: {10,20,30,50} Δ=10, Missing = 40 <br/>

Sequences of length 0, 1, or 2 are invalid. 
Malformed sequnces will not be passed in (all sequences are assumed to be legit)

# Use of XUnit
This project makes use of XUnit Theory tests to allow multiple sequences to easily be tested. In each case, a sequence is passed as inline data, with the "missing" number being the last one. In the code below, the "real" sequence is:
```
{1, 2, 3, 4}
```
The theory tests allow different ways of expressing the missing number. For example:
```
[InlineData(1, 2, 4, 3)]
```
Represents the same sequence, but the "3" is missing. By placing the "3" at the end, the test Asserts the correct value was found.

Test cases end up looking like:
```cs
[Theory] // [item, item, item, MISSING NUMBER]
[InlineData(1, 2, 4, 3)]
[InlineData(1, 3, 4, 2)]
[InlineData(10, 12, 13, 11)]
```

This seems to provide a good balance between:
* Data driven tests
* The ability to put breakpoints on tests
* Human test readability
* Test maintainability

# Other Testing Options
Other XUnit theory tests (ClassData, MemberData) were explored, but the "test noise" overwhelmed the clarity of the simpler solution. 
