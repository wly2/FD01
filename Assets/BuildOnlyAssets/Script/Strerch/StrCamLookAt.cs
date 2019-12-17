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
* 功能描述：     .................主相机LookAt..............    
* 版本：     主.次.月.日.时.分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class StrCamLookAt : ManagerCamera
{
     [SerializeField] Transform traStrersh1;
     [SerializeField] GameObject cameraMain;
     [SerializeField] GameObject player;

    public void LookAtStrerch1()
    {
        cameraMain.GetComponent<CameraThird>().enabled = false;
        player.GetComponent<ControlPlayerMove>().enabled = false;
        base.LookAtTarget = traStrersh1;
        base.StrLookAtTarget();
    }


}
