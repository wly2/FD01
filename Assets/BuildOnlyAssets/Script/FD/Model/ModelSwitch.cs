using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AssemblyCSharp;
using UnityEngine.SceneManagement;

#region Author & Version
/* ========================================================================  
*Author：WLY 
* File name：
* Version：V1.0.1
* Company: 
* 创建：    
* Date : 
* 功能描述：     ................游戏场景挑选薄片类型的效果..............    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class ModelSwitch : ManagerModel
{
    [SerializeField] GameObject[] GO_modelswitch = new GameObject[2];//薄片模型
    [SerializeField] Renderer[] Go_baopian = new Renderer[3];//所有薄片
    int CurrentActiveTxt;//记录当前的模型名称
    public Text Txt_modelname;//显示在面板上的模型名称
    GameObject But_nextmodel;//下一个
    public CameraLookAt cameraLookat;
    int NextCurrentTxt;

    private void Awake()
    {
        MyDebug.Log("<<<<<<<<<<<<<<<当前模型是：<<<<<<<<<<<<<<<<<" + GO_modelswitch[0] + GO_modelswitch[1]);
    }

    void Start()
    {
        cameraLookat.GetComponent<CameraLookAt>();
        GO_modelswitch[0].SetActive(false);//第三视角
    }


    private void OnEnable()
    {
        Txt_modelname.text = GO_modelswitch[CurrentActiveTxt].name;
    }


    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        BXGBPOnScene("BXGBP");
        LHJBPOnScene("LHJBP");

    }


    /// <summary>
    /// 不锈钢薄片场景选中效果
    /// </summary>
    public void BXGBPOnScene(string modelName)
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.gameObject.tag == modelName && Input.GetMouseButtonDown(0))
        {
            AssemblyCSharp.MyDebug.Log("**************************触发场景薄片点击事件***********************");
            MyDebug.Log("===========================选中不锈钢薄片========================");
            ManagerFDGame.instance.canvasModel.SetActive(false);
            ManagerFDGame.instance.canvasMian.SetActive(true);
            ManagerFDGame.instance.canvasUI.SetActive(true);

            ManagerFDGame.instance.isBXG = true;
            // ManagerFDGame.instance.txtTip.text = AssetsConfigPath.StepTxtTip.TIP_STEP15;
            cameraLookat.NearZhiChi();
            MyDebug.Log("######################游戏进行到进程：#############################" + "第" + ControlFDGame.GameProgress + "步");
        }
    }

    /// <summary>
    /// 铝合金
    /// </summary>
    /// <param name="modelName"></param>
    public void LHJBPOnScene(string modelName)
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.gameObject.tag == modelName && Input.GetMouseButtonDown(0))
        {
            AssemblyCSharp.MyDebug.Log("**************************触发场景薄片点击事件***********************");
            MyDebug.Log("===========================选中铝合金薄片========================");
            ManagerFDGame.instance.canvasModel.SetActive(false);
            ManagerFDGame.instance.canvasMian.SetActive(true);
            ManagerFDGame.instance.canvasUI.SetActive(true);
            cameraLookat.NearZhiChi();

            ManagerFDGame.instance.isLHJ = true;
            MyDebug.Log("######################游戏进行到进程：#############################" + "第" + ControlFDGame.GameProgress + "步");
        }
    }



    /// <summary>
    /// 
    /// 切换相机按钮
    /// </summary>
    public void NextModel()
    {
        MyDebug.Log("=======================切换模型================");
        int NextCurrentTxt = CurrentActiveTxt + 1 >= GO_modelswitch.Length ? 0 : CurrentActiveTxt + 1;

        for (int i = 0; i < GO_modelswitch.Length; i++)
        {
            GO_modelswitch[i].SetActive(i == NextCurrentTxt);
            MyDebug.Log("*******************当前模型*********************" + GO_modelswitch[i]);
        }

        CurrentActiveTxt = NextCurrentTxt;
        Txt_modelname.text = GO_modelswitch[CurrentActiveTxt].name;

        MyDebug.Log("<<<<<<<<<<<<<<<<<<调试信息>>>>>>>>>>>>>>>>>>>>>>>" + MyDebug.list.Count);

        if (GO_modelswitch[0].activeSelf)
        {
            for (int i = 0; i < Go_baopian.Length; i++)
            {
                Go_baopian[i].GetComponent<Renderer>().material.color = Color.black;
            }
            //Go_baopian[0].GetComponent<Renderer>().material.color = Color.black;
            //Go_baopian[1].GetComponent<Renderer>().material.color = Color.black;
            //Go_baopian[2].GetComponent<Renderer>().material.color = Color.black;
        }
        else
        {
            for (int i = 0; i < Go_baopian.Length; i++)
            {
                Go_baopian[i].GetComponent<Renderer>().material.color = Color.gray;
            }
            //Go_baopian[0].GetComponent<Renderer>().material.color = Color.gray;
            //Go_baopian[1].GetComponent<Renderer>().material.color = Color.gray;
            //Go_baopian[2].GetComponent<Renderer>().material.color = Color.gray;
        }
    }


}
