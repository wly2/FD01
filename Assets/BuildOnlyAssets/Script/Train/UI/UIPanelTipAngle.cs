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
* Date : 2019.0606    14:12
* 功能描述：     ...............................    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class UIPanelTipAngle : UIWindow {

    public void makeSure()
    {
        base.OffUI();
        ControlAniTrain.instance.doneCRH2.SetActive(false);
        ControlAniTrain.instance.ani.SetBool("isRotate", true);
    }


}
