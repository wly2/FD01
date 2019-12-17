using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AssemblyCSharp;
using DG.Tweening;

#region Author & Version
/* ========================================================================  
*Author：WLY 
* File name：
* Version：V1.0.1
* Company: 
* 创建：    
* Date : 2019.0611    10:42
* 功能描述：     ...............视角切换................    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class CameraSwitch : MonoSingleton<CameraSwitch>
{
    public GameObject[] cameraSwitch = new GameObject[2];//第一视角相机用于查看工具
    int CurrentActiveTxt;//记录当前的相机名称
    //[SerializeField] Text txtCameraName;//显示在面板上的相机名称
    [SerializeField] GameObject butCameraSwitch;//切换相机按钮

    public GameObject GOPlayer;

    private void Awake()
    {
        //butCameraSwitch.GetComponent<Button>().onClick.AddListener(() => { NextCamera(); });
        MyDebug.Log("<<<<<<<<<<<<<<<当前摄像机是：<<<<<<<<<<<<<<<<<" + cameraSwitch[0] + cameraSwitch[1]);
    }

    void Start()
    {
        cameraSwitch[0].SetActive(false);//第三视角
    }

    void Update()
    {
        if (cameraSwitch[0].activeSelf)
        {
            GOPlayer.GetComponent<ControlFDGame>().enabled = false;

            ManagerFDGame.instance.Tool.SetActive(false);//第三视角隐藏工具栏
            
            //ManagerFDGame.instance.txtTip.text = AssetsConfigPath.StepTxtTip.TIP_CAMERA;
            ManagerGame.destoryGameobject("tipbp");
        }
        else
        {
            GOPlayer.GetComponent<ControlFDGame>().enabled = true;

        }

        if (cameraSwitch[1].activeSelf)
        {
            GOPlayer.GetComponent<ControlPlayerMove>().enabled = false;
            ManagerFDGame.instance.Tool.SetActive(true);//第三视角隐藏工具栏
                                                      
        }
        else GOPlayer.GetComponent<ControlPlayerMove>().enabled = true;
    }

    /// <summary>
    /// 
    /// 切换相机按钮
    /// </summary>
    public void NextCamera()
    {
        MyDebug.Log("=======================切换相机================");
        int NextCurrentTxt = CurrentActiveTxt + 1 >= cameraSwitch.Length ? 0 : CurrentActiveTxt + 1;

        for (int i = 0; i < cameraSwitch.Length; i++)
        {
            cameraSwitch[i].SetActive(i == NextCurrentTxt);
            MyDebug.Log("*******************当前显示的相机*********************" + cameraSwitch[i]);
        }

        CurrentActiveTxt = NextCurrentTxt;
        MyDebug.Log("<<<<<<<<<<<<<<<<<<调试信息>>>>>>>>>>>>>>>>>>>>>>>" + MyDebug.list.Count);
    }
}
