using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Author & Version
/* ========================================================================  
*Author：WLY 
* File name：
* Version：V1.0.1
* Company: 
* 创建时间：    
*
* 功能描述：     ................第一次拉伸时分屏...............    
* 版本：     主.次.月.日.时.分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion


public class StrScreenLookAt : ManagerCamera
{
     [SerializeField] Transform traScreen;

    public void LookAtScreen()
    {
        base.LookAtTarget = traScreen;
        base.StrLookAtTarget();
    }
}
