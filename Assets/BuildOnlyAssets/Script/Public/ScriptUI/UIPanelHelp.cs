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
* Date : 2019.0619           10:11
* 功能描述：     ................操作说明...............    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class UIPanelHelp : UIWindow
{
    public void UIOff()
    {
        base.OffUI();
        ManagerUI.instance.UIOffState();
    }


}
