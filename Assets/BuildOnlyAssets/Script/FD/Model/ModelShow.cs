using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;
using UnityEngine;
using UnityEngine.UI;

#region Author & Version
/* ========================================================================  
*Author：WLY 
* File name：
* Version：V1.0.1
* Company: 
* 创建：    
* Date : 2019.0606    14:12
* 功能描述：     ...............模型展示场景的UI交互................    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class ModelShow : MonoSingleton<ModelShow>
{

    [SerializeField] GameObject[] GO_modelShow = new GameObject[5];//薄片模型
    int CurrentActiveTxt;//记录当前的模型名称
    public Text Txt_modelname;//显示在面板上的模型名称
    GameObject But_nextmodel;//下一个
    int NextCurrentTxt;
    public GameObject Go_ModelShow;
    public GameObject Go_SceneMain;

    private void Awake()
    {
        MyDebug.Log("<<<<<<<<<<<<<<<当前模型是：<<<<<<<<<<<<<<<<<" + GO_modelShow[0] + GO_modelShow[1]);
    }


    private void OnEnable()
    {
        Txt_modelname.text = GO_modelShow[CurrentActiveTxt].name;
    }

    public void ChooModel(int modelName)
    {
        for (int i = 0; i < GO_modelShow.Length; i++)
        {
            GO_modelShow[i].SetActive(i == modelName);
        }
        
        int NextCurrentTxt = CurrentActiveTxt + 1 >= GO_modelShow.Length ? 0 : CurrentActiveTxt + 1;
        CurrentActiveTxt = modelName;
        Txt_modelname.text = GO_modelShow[CurrentActiveTxt].name;
        
        switch (modelName)
        {
            case 0:
                break;

            case 1:
                break;

            case 2:
                break;

            case 3:
                break;

            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
        }
    }



    /// <summary>
    /// 展示所有的模型,
    /// 下一个
    /// </summary>
    public void NextModelShowAdd()
    {
        MyDebug.Log("=======================切换模型================");
        int NextCurrentTxt = CurrentActiveTxt + 1 >= GO_modelShow.Length ? 0 : CurrentActiveTxt + 1;

        for (int i = 0; i < GO_modelShow.Length; i++)
        {
            GO_modelShow[i].SetActive(i == NextCurrentTxt);
            MyDebug.Log("*******************当前模型是：*********************" + GO_modelShow[i]);
        }

        CurrentActiveTxt = NextCurrentTxt;
        Txt_modelname.text = GO_modelShow[CurrentActiveTxt].name;
    }

    /// <summary>
    /// 上一个
    /// </summary>
    public void NextModelShowSubtract()
    {

        MyDebug.Log("=======================切换模型================");
        if (CurrentActiveTxt >= 1)
        {
            NextCurrentTxt = CurrentActiveTxt + 1 >= GO_modelShow.Length ? 0 : CurrentActiveTxt - 1;
        }


        for (int i = 0; i < GO_modelShow.Length; i++)
        {
            GO_modelShow[i].SetActive(i == NextCurrentTxt);
            MyDebug.Log("*******************当前模型是：*********************" + GO_modelShow[i]);
        }

        CurrentActiveTxt = NextCurrentTxt;
        Txt_modelname.text = GO_modelShow[CurrentActiveTxt].name;
    }

    /// <summary>
    /// 返回键
    /// </summary>
    public void btnBack()
    {
        Go_ModelShow.SetActive(false);
        ManagerFDGame.instance.canvasMian.SetActive(true);
        ManagerFDGame.instance.canvasUI.SetActive(true);
    }
}
