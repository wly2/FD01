using System.Collections.Generic;
using UnityEngine;

  #region Author & Version
    /* ========================================================================  
    *Author：WLY 
    * File name：
    * Version：V1.0.1
    * Company: 
    * 创建：    
    * Date : 
    * 功能描述：     ................调试脚本...............    
    * 版本：     主.次.月日.时分  修改者姓名  修改内容    
    *            ............       ....      .......        
    * ========================================================================
    */
    #endregion

namespace AssemblyCSharp
{
    public class MyDebug
    {
        private static bool flag;
        private static bool Testflag;
        private static bool socketFlag;
        public static List<string> list = new List<string>();

        public MyDebug()
        {
        }

        public static void Log(object message)
        {
            if (flag == false)
            {
                Debug.Log(message);
                list.Add(message.ToString());
            }
        }

        public static void LogError(object message)
        {
            if (flag == false)
            {
                Debug.Log(message);

            }
        }

        public static void LogWarning(object message)
        {
            if (flag == false)
            {
                Debug.LogWarning(message);

            }
        }

        public static void TestLog(object message)
        {
            if (Testflag)
            {
                Debug.Log("Test log --------------------" + message);
                list.Add(message.ToString());
            }

        }

        public static void SocketLog(object message)
        {
            if (socketFlag)
            {
                Debug.Log(message);
                list.Add(message.ToString());
            }
        }
    }
}