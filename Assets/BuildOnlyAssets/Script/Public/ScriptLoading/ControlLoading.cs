using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using AssetsConfigPath;

#region Author & Version
/* ========================================================================  
*Author：WLY 
* File name：
* Version：V1.0.1
* Company: 
* 创建：    
* Date : 2079.5.31  13:50
* 功能描述：     .................加载实验场景..............    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class ControlLoading : MonoSingleton<ControlLoading>
{
    public Text txtProgess;
    public Image imgPregress;

    void Start()
    {
        loadScene();
    }

    void Update()
    {
        ManagerScene.instance.asyncLoading();
    }

    public void loadScene()
    {
        //风洞试验
        if (ManagerScene.SceneType == ManagerScene.ScenesType.SCENEFD)
        {
            StartCoroutine(ManagerScene.instance.ILoadingScene(SceneLocalPath.SCENE_FD));
        }

        //高速列车
        if (ManagerScene.SceneType == ManagerScene.ScenesType.SCENETRAIN)
        {
            StartCoroutine(ManagerScene.instance.ILoadingScene(SceneLocalPath.SCENE_TRAIN));
        }

    }
}
