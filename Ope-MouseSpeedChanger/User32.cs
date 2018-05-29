using System;
using System.Runtime.InteropServices;

namespace Ope_MouseSpeedChanger
{
    static partial class User32
    {

        [DllImport("User32.dll")]
        extern static bool SystemParametersInfo(SystemParameters action, uint param, IntPtr output, uint fWinIni);

        public static unsafe int GetMouseSpeed()
        {
            int speed;
            SystemParametersInfo(SystemParameters.SPI_GETMOUSESPEED, 0, new IntPtr(&speed), 0);
            return speed;
        }   

        public static unsafe int SetMouseSpeed(uint speed)
        {
            if (speed < 1 || speed > 20) return -1;
            SystemParametersInfo(SystemParameters.SPI_SETMOUSESPEED, 0, new IntPtr(speed), 0);
            return (int)speed;
        }
    }

    
}
