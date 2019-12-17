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
* 功能描述：     ................拉伸时分屏...............    
* 版本：     主.次.月.日.时.分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion
public class SplitScreen : MonoSingleton<SplitScreen>
{

    [SerializeField] Camera cameraMain;//主相机
    [SerializeField] Camera cameraScreen;//分屏相机


    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        cameraMain = Camera.main;
        cameraScreen.GetComponent<Camera>();
    }

    /// <summary>
    /// 拉伸铸铁时分屏
    /// </summary>
    public void SplitStrerch1()
    {
        cameraMain.rect = new Rect(0, 0, 0.5f, 1);
        cameraScreen.gameObject.SetActive(true);
        cameraScreen.rect = new Rect(0.5f, 0, 0.5f, 1);

    }

    //拉伸碳钢方法
    //...待添加

    /// <summary>
    /// 重置相机
    /// </summary>
    public void ResetCamera()
    {
        cameraMain.rect = new Rect(0, 0, 1, 1);
        cameraScreen.gameObject.SetActive(false);

    }
}
