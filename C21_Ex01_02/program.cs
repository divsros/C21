using System.Text;

namespace C21_Ex01_02
{
    public class program
    {
        public static void Main()
        {
            StringBuilder str = new StringBuilder();
            sandClock.CreateSandClock(ref str);
            System.Console.WriteLine(str);
        }
    }


    public class sandClock
    {
        public static void CreateSandClock(ref StringBuilder o_ResultStr, int i_ClockHeight = 3, int i_Spaces = 0)
        {
            if (i_ClockHeight == 1)
            {
                o_ResultStr.Append(' ', i_Spaces);
                o_ResultStr.Append('*', i_ClockHeight * 2 - 1);
                o_ResultStr.Append('\n', 1);
                return;
            }
            o_ResultStr.Append(' ', i_Spaces);
            o_ResultStr.Append('*', i_ClockHeight * 2 - 1);
            o_ResultStr.Append('\n', 1);
            CreateSandClock(ref o_ResultStr, i_ClockHeight - 1, i_Spaces + 1);
            o_ResultStr.Append(' ', i_Spaces);
            o_ResultStr.Append('*', i_ClockHeight * 2 - 1);
            o_ResultStr.Append('\n', 1);
        }
    }
}
