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
* 功能描述：     ...............管理动画逻辑................    
* 版本：     主.次.月.日.时.分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class ManagerStrAni : MonoBehaviour
{
    public static Animator aniStrerch;
     [SerializeField] GameObject cameraMain;
     [SerializeField] GameObject player;

    private void Start()
    {
        aniStrerch = GetComponent<Animator>();
    }

    void FinishStrerch1()
    {
        SplitScreen.instance.ResetCamera();
        cameraMain.GetComponent<CameraThird>().enabled = true;
        player.GetComponent<ControlPlayerMove>().enabled = true;
        cameraMain.GetComponent<StrCamLookAt>().enabled = false;
    }
}
