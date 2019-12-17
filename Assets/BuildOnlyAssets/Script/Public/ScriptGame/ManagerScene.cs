using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using AssetsConfigPath;
using UnityEngine.UI;

#region Author & Version
/* ========================================================================  
*Author：WLY 
* File name：
* Version：V1.0.1
* Company: 
* 创建：    
* Date : 2019.0605    14:12
* 功能描述：     ...............场景管理................    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class ManagerScene : MonoSingleton<ManagerScene>
{
    [HideInInspector] public AsyncOperation async;
    float curProgressValue = 0;//当前进度条值
    public static string SceneType;


    /// <summary>
    /// 异步加载
    /// </summary>
    /// <returns></returns>
    public void asyncLoading()
    {
        float progrssValue;//加载时实际进度条值

        if (async == null)
        {
            return;
        }

        if (async.progress < 0.9f)
        {
            progrssValue = async.progress * 100;
        }

        else progrssValue = 100;

        if (curProgressValue < progrssValue)//如果当前值小于储存值，当前值递增
        {
            curProgressValue++;
        }
        ControlLoading.instance.txtProgess.text = curProgressValue + "%";
        ControlLoading.instance.imgPregress.fillAmount = curProgressValue / 100;

        if (curProgressValue == 100)
        {
            async.allowSceneActivation = true;
        }
    }


    public IEnumerator ILoadingScene(string sceneName)
    {
        async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;//当进度条走到0.9时会自动跳转场景
        yield return async;
    }


    /// <summary>
    /// 同步加载
    /// </summary>
    /// <param name="loadingscene"></param>
    public void loadingScene(string loadingscene)
    {
        SceneManager.LoadScene(loadingscene);
    }

    /// <summary>
    /// 场景类型
    /// </summary>
    public class ScenesType
    {
        public const string SCENEFD = "FD";
        public const string SCENETRAIN = "TRAIN";
    }
}
