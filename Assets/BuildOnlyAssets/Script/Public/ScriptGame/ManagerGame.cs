using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Author & Version
/* ========================================================================  
*Author：WLY 
* File name：
* Version：V1.0.1
* Company: 
* 创建：    
* Date : 2019.0802    15：24
* 功能描述：     ................游戏共用脚本...............    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class ManagerGame : MonoSingleton<ManagerGame>
{
    public static int txtPrintSpeed = 1;//提示框字体打字速度


    /// <summary>
    /// 销毁预设体
    /// </summary>
    /// <param name="modelName"></param>
    public static void destoryGameobject(string modelName)
    {
        GameObject go = GameObject.FindWithTag(modelName);
        Destroy(go);
    }
}
