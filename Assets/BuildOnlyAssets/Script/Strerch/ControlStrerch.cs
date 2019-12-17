using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets;

#region Author & Version
/* ========================================================================  
*Author：WLY 
* File name：
* Version：V1.0.1
* Company: 
* 创建时间：    
*
* 功能描述：     .............实验逻辑控制..................    
* 版本：     主.次.月.日.时.分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class ControlStrerch : MonoBehaviour
{
    public static int gameprogress = 0;//游戏进程
    public Text txtTip;//操作提示
    [SerializeField] Image panelMune;//菜单栏
    public bool isTwice = false;//判断是否第二次点击
    [SerializeField] StrCamLookAt strcamlookat;
    [SerializeField] StrScreenLookAt strScreenLookAt;
    [SerializeField] Image imgResult;

    private void Start()
    {
        txtTip.text = "";
        panelMune.gameObject.SetActive(false);
        strcamlookat.GetComponent<StrCamLookAt>();
        strScreenLookAt.GetComponent<StrScreenLookAt>();
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        ControlStep();
        Menu();
    }


    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>触发碰撞器Cillider
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider something)
    {
        if (something.CompareTag("collidertableStep1") && gameprogress == 0)
        {

            txtTip.text = ConfigStrerch.tipPath.TIP4;
            gameprogress = 1;


        }

        if (something.CompareTag("colliderStep2") && gameprogress == 2)
        {
            MyDebug.Log("安选Q键进行拉伸实验");
            txtTip.text = ConfigStrerch.tipPath.TIP1;
        }

        if (something.CompareTag("colliderStep2") && gameprogress == 3)
        {
            MyDebug.Log("安选Q键进行拉伸实验");
            txtTip.text = ConfigStrerch.tipPath.TIP2;
        }
    }

    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>没有触发触碰器不响应操作步骤
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerExit(Collider other)
    {
        txtTip.text = "";
    }

    /// <summary>
    /// 实验操作逻辑控制
    /// </summary>
    public void ControlStep()
    {
        if (Input.anyKeyDown && gameprogress == 1)
        {
            imgResult.gameObject.SetActive(true);
            gameprogress = 2;
        }

        if (Input.GetKeyDown(KeyCode.Z) && gameprogress == 2)
        {
            MyDebug.Log("按下Z键");
            txtTip.text = ConfigStrerch.tipPath.TIP3;
            gameprogress = 3;
        }

        if (Input.GetKeyDown(KeyCode.X) && gameprogress == 2)
        {
            MyDebug.Log("按下X键");
            txtTip.text = ConfigStrerch.tipPath.TIP3;
        }

        if (Input.GetKeyDown(KeyCode.Q) && gameprogress == 3)
        {
            SplitScreen.instance.SplitStrerch1();

            ManagerStrAni.aniStrerch.SetBool("isStrerch1", true); //播放拉伸动画
            strcamlookat.LookAtStrerch1();//镜头看向拉伸动画
            strScreenLookAt.LookAtScreen();
            MyDebug.Log("按下Q键");
            gameprogress = 4;
            txtTip.text = null;
        }
    }

    /// <summary>
    /// 菜单栏
    /// </summary>
    public void Menu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !panelMune.gameObject.activeSelf)
        {
            panelMune.gameObject.SetActive(true);
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && panelMune.gameObject.activeSelf)
        {
            panelMune.gameObject.SetActive(false);
        }
    }
}
