using System;
using System.Collections.Generic;
using System.Text;

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