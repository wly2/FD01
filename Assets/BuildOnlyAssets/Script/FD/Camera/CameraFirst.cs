using UnityEngine;
using System.Collections;
using AssemblyCSharp;

#region Author & Version
/* ========================================================================  
*Author：WLY 
* File name：
* Version：V1.0.1
* Company: 
* 创建：    
* Date : 
* 功能描述：     ...............................    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class CameraFirst : MonoBehaviour
{
    [SerializeField] float FVrange = 20;//滚轮缩放值
    float FCameraXpos;
    [SerializeField] Camera cameraFirst;
    float y;
    [SerializeField] float minSee;
    [SerializeField] float maxSee;




    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        cameraFirst = GetComponent<Camera>();
        MyDebug.Log("===============当前相机是==================" + cameraFirst);
    }



    /// <summary>
    /// LateUpdate is called every frame, if the Behaviour is enabled.
    /// It is called after all Update functions have been called.
    /// </summary>
    void LateUpdate()
    {
        //MouseEvent();
        ScrollWheelEvent();
    }

    /// <summary>
    /// 滑动滚轮缩放
    /// </summary>
    public void ScrollWheelEvent()
    {

        if (FVrange > 0)
        {
            FVrange += Input.GetAxis("Mouse ScrollWheel") * 10f;
            FVrange = FVrange > 30 ? 30 : FVrange < 3 ? 3 : FVrange;
            cameraFirst.fieldOfView = FVrange;
            //MyDebug.Log("==================当前相机深度范围是===============" + FVrange);

        }

        if (Input.GetMouseButtonUp(2))
        {
            MyDebug.Log("==================按下滚轮键===============");
        }
    }

    /// <summary>
    /// 鼠标键响应事件
    /// </summary>
    public void MouseEvent()
    {
        if (Input.GetMouseButtonDown(1))
        {
            MyDebug.Log("==================按下右键===============");
            FCameraXpos -= 0.1f;
            FCameraXpos = FCameraXpos > -8.23f ? -8.23f : FCameraXpos < -9.44f ? -9.44f : FCameraXpos;

            //右键上下查看
            y -= Input.GetAxis("Mouse Y") * 10f;
            y = Mathf.Clamp(y, minSee, maxSee);


            cameraFirst.transform.position = new Vector3(FCameraXpos, cameraFirst.transform.position.y, cameraFirst.transform.position.z);
        }

        if (Input.GetMouseButtonDown(0))
        {
            MyDebug.Log("==================按下左键===============");
            FCameraXpos += 0.1f;
            FCameraXpos = FCameraXpos > -8.23f ? -8.23f : FCameraXpos;

            cameraFirst.transform.position = new Vector3(FCameraXpos, cameraFirst.transform.position.y, cameraFirst.transform.position.z);
        }


    }
}
