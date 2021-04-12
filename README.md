# TimeElapsedClass
Keep track of code execution times with this class!

//Author: poipoi300
//Purpose: Code speed analysis
//Date: 2021-04-11
//Version: 1.01

Description: 
I made this object following a recommendation for code optimization I had received.
I really wasn't sure if what I was proposed was actually faster in terms of execution times, 
so I made an object that could keep track of that for me. (+ some neat features for real-world use c:)
 
The answer to my original question is that no, the "optimization" wasn't faster. However, I did find an even faster method than what I was originally using.
If you have a known number of inputs in a limited range, switch statements are faster than if-else statements after 3 conditions tested.
The only exception is if your input is the first or second condition in a series of if-else statements, then switch is slower. 
If the number of possible valid inputs is very high, lookup tables are superior.

 
If there are any bugs or the object doesn't behave as expected, please report an issue!

