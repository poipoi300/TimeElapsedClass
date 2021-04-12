using System;
using System.Collections.Generic;
using System.Text;

//Author: poipoi300
//Purpose: Code speed analysis
//Date: 2021-04-11
//Version: 1.0

/* Description: 
 * I made this object following a recommendation for code optimization I had received.
 * I really wasn't sure if what I was proposed was actually faster in terms of execution times, 
 * so I made an object that could keep track of that for me. (+ some neat features for real-world use c:)
 * 
 * The answer to my original question is that no, the "optimization" wasn't faster. However, I did find an even faster method than what I was originally using.
 * If you have a known number of inputs in a limited range, switch statements are faster than if-else statements after 3 conditions tested.
 * The only exception is if your input is the first or second condition in a series of if-else statements, then switch is slower. 
 * If the number of possible valid inputs is very high, lookup tables are superior.
 * 
 * 
 * If there are any bugs or the object doesn't behave as expected, please 
*/
namespace Timer
{
    class TimeElapsed
    {
        DateTime timeStart;
        DateTime timeEnd;
        DateTime timePaused;
        TimeSpan currentTotal;
        string testInfo;
        bool paused = false;
        public TimeElapsed(string testInfo)
        {
            this.testInfo = testInfo;
        }

        public int GetCurrentTotal()
        {
            //This only returns an above 0 value if the timer has been paused at least once.
            return (int)currentTotal.TotalMilliseconds;
        }

        public void Start()
        {
            Console.WriteLine("Time starting now, " + testInfo);
            timeStart = DateTime.Now;
        }
        public void End()
        {
            if (!paused)
            {
                timeEnd = DateTime.Now;
                TimeSpan difference = timeEnd - timeStart + currentTotal;
                double milliseconds = (double)difference.TotalMilliseconds;
                Console.WriteLine("Time elapsed from start is: " + milliseconds + "ms");
            }
            else
            {
                double milliseconds = (double)currentTotal.TotalMilliseconds;
                Console.WriteLine("Time elapsed from start is: " + milliseconds + "ms");
            }
        }
        public void Pause()
        {
            if (!paused)
            {
                timePaused = DateTime.Now;
                TimeSpan difference = timePaused - timeStart;
                currentTotal += difference;
                paused = true;
            }
        }
        public void Resume()
        {
            if (paused)
            {
                timeStart = DateTime.Now;
                paused = false;
            }
        }
        public void Toggle()
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
}
