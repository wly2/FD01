using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
using AssetsConfigPath;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


#region Author & Version
/* ========================================================================  
*Author：WLY 
* File name：
* Version：V1.0.1
* Company: 
* 创建：    
* Date : 
* 功能描述：     .................开始界面逻辑控制..............    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion


public class ControlStart : MonoBehaviour
{
    private void Start()
    {
        //GameObject obj = GameObject.Find(UIConfigPath.UIPanelStart_BUTSTART);
        //obj.GetComponent<Button>().onClick.AddListener(() => { LoadingFD(); });
    }

    private void Update()
    {
        //ManagerScene.instance.asyncLoading();
    }


    /// <summary>
    /// 加载风洞试验进度条
    /// </summary>
    public void LoadingFD()
    {
        ManagerScene.instance.loadingScene(SceneLocalPath.SCENE_LOADINGFD);
        ManagerScene.SceneType = ManagerScene.ScenesType.SCENEFD;
    }

    /// <summary>
    /// 加载高速列车进度条
    /// </summary>
    public void LoadingTrain()
    {
        ManagerScene.instance.loadingScene(SceneLocalPath.SCENE_LOADINGFD);
        ManagerScene.SceneType = ManagerScene.ScenesType.SCENETRAIN;
    }

    public void UIOff()
    {
        UIWindow.instance.OffUI();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
