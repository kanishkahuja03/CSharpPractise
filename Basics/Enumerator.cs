using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    public enum Grade
    {
        A,
        B,
        C,
        D,
        E,
        F
    }

    public class GradingSystem
    {
        //private (Grade G, String msg) messenger;
        public static (Grade G, String msg) GradeMsg(Grade g)
        {
            switch(g)
            {
                case Grade.A:

                    return (Grade.A,"Excellent");
                case Grade.B:

                    return (Grade.B, "Good");
                case Grade.C:

                    return (Grade.C, "Average");
                case Grade.D:

                    return (Grade.D, "Need Improvement");
                case Grade.E:

                    return (Grade.E, "FAIL");
                default:
                    return (Grade.F, "Enter valid grade");
            }
        }
        public static void GradeMain()
        {
            Console.WriteLine(GradeMsg(Grade.E));
        }
    }
}