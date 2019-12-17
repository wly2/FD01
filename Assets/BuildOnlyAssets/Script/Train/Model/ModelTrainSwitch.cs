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
* 功能描述：     ................游戏场景挑选列车类型的效果..............    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class ModelTrainSwitch : ManagerModel
{
    [SerializeField] GameObject[] GO_modelswitch = new GameObject[2];//薄片模型
    int CurrentActiveTxt;//记录当前的模型名称
    public Text Txt_modelname;//显示在面板上的模型名称
    GameObject But_nextmodel;//下一个
    public CameraLookAtTrain cameraLookat;
    int NextCurrentTxt;
    public GameObject goTipTypeRun;//列车运行方式



    private void Awake()
    {
        MyDebug.Log("<<<<<<<<<<<<<<<当前模型是：<<<<<<<<<<<<<<<<<" + GO_modelswitch[0] + GO_modelswitch[1]);
    }

    void Start()
    {
        goTipTypeRun.SetActive(false);
        cameraLookat.GetComponent<CameraLookAtTrain>();
        GO_modelswitch[1].SetActive(true);
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
        CRH2OnScene("CRH2");
        CNH380AOnScene("CNH380A");

    }


    /// <summary>
    /// 不锈钢薄片场景选中效果
    /// </summary>
    public void CRH2OnScene(string modelName)
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.gameObject.tag == modelName && Input.GetMouseButtonDown(0))
        {
            AssemblyCSharp.MyDebug.Log("**************************触发场景薄片点击事件***********************");
            MyDebug.Log("===========================选中CRH2========================");
            goTipTypeRun.SetActive(true);
        }
    }

    /// <summary>
    /// 铝合金
    /// </summary>
    /// <param name="modelName"></param>
    public void CNH380AOnScene(string modelName)
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.gameObject.tag == modelName && Input.GetMouseButtonDown(0))
        {
            AssemblyCSharp.MyDebug.Log("**************************触发场景薄片点击事件***********************");
            MyDebug.Log("===========================选中CNH380A========================");
            goTipTypeRun.SetActive(true);
            //ManagerFDGame.instance.canvasModel.SetActive(false);
            //ManagerFDGame.instance.canvasMian.SetActive(true);
            //ManagerFDGame.instance.canvasUI.SetActive(true);
        }
    }

    public void btnTypeRun(string type)
    {
        switch (type)
        {
            case "路堤运行":
                ManagerTrainGame.instance.canvasModel.SetActive(false);
                ManagerTrainGame.instance.canvasMian.SetActive(true);
                ManagerTrainGame.instance.canvasUI.SetActive(true);
                cameraLookat.lookAtModel("CRH2");
                ControlAniTrain.instance.ani.SetBool("isCRH2", true);
                //ManagerFDGame.instance.txtTip.text = AssetsConfigPath.StepTxtTip.TIP_STEP15;

                break;

            case "平地运行":
                ManagerTrainGame.instance.canvasModel.SetActive(false);
                ManagerTrainGame.instance.canvasMian.SetActive(true);
                ManagerTrainGame.instance.canvasUI.SetActive(true);
                break;
        }
       
    }



    /// <summary>
    /// 
    /// 切换相机按钮
    /// </summary>
    public void NextModel()
    {
        goTipTypeRun.SetActive(false);
        MyDebug.Log("=======================切换模型================");
        int NextCurrentTxt = CurrentActiveTxt + 1 >= GO_modelswitch.Length ? 0 : CurrentActiveTxt + 1;

        for (int i = 0; i < GO_modelswitch.Length; i++)
        {
            GO_modelswitch[i].SetActive(i == NextCurrentTxt);
            MyDebug.Log("*******************当前模型*********************" + GO_modelswitch[i]);
        }

        CurrentActiveTxt = NextCurrentTxt;
        Txt_modelname.text = GO_modelswitch[CurrentActiveTxt].name;
        ManagerTrainGame.txtTypeCar = Txt_modelname.text;
        MyDebug.Log("<<<<<<<<<<<<<<<<<<调试信息>>>>>>>>>>>>>>>>>>>>>>>" + MyDebug.list.Count);
    }

}
