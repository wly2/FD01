using System;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;
using UnityEngine;

#region Author & Version
/* ========================================================================  
*Author：WLY 
* File name：
* Version：V1.0.1
* Company: 
* 创建：    
* Date : 2019.0620    10:28
* 功能描述：     ................判断鼠标左右拖动...............    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class MouseEventTrain : MonoBehaviour
{

    Vector2 first = Vector2.zero;    //记录鼠标点击的初始位置
    Vector2 second = Vector2.zero;   //记录鼠标移动时的位置
    bool directorToLeft = false;
    bool directorToRight = false;
    bool dragging = false;   //标记是否鼠标在滑动
    float speed = 0;
    public static int rotateValue = 0;
    float moveSpeed = 1f;
    public GameObject GoCube;

    void Update()
    {
        ManagerTrainGame.instance.txtVFeng.text = Math.Round((double)MouseEventTrain.rotateValue, 2) + "";

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "DIY")
                {
                    print("qizi");
                    Vector3 newPosition = Vector3.zero;
                    if (directorToLeft == true)
                    {
                        newPosition = new Vector3(0, -1, 0);
                        speed = 15;
                        MyDebug.Log("left");
                        if (rotateValue > 0)
                        {
                            rotateValue--;
                        }
                        GoCube.transform.rotation = Quaternion.Euler(-31.5f, 0, rotateValue * moveSpeed);

                        MyDebug.Log("===============================y=======================" + rotateValue);
                        // ManagerFDGame.instance.txtVFeng.text = MouseEvent.rotateValue + "";
                    }
                    if (directorToRight == true)
                    {
                        speed = 10;
                        newPosition = new Vector3(0, 1, 0);
                        MyDebug.Log("right");
                        if (rotateValue < 20)
                        {
                            rotateValue++;
                        }
                        GoCube.transform.rotation = Quaternion.Euler(-31.5f, 0, rotateValue * moveSpeed);

                        MyDebug.Log("===============================y=======================" + rotateValue);
                    }
                }
            }
        }
    }


    void OnGUI()
    {

        if (Event.current.type == EventType.MouseDown)
        {
            first = Event.current.mousePosition;//记录鼠标按下的位置 
        }

        dragging = false;

        if (Event.current.type == EventType.MouseDrag)//记录鼠标拖动的位置 
        {
            dragging = true;
            second = Event.current.mousePosition;
            Vector2 slideDirection = second - first;
            float x = slideDirection.x, y = slideDirection.y;

            if (y < x && y > -x)// right 
            {
                directorToRight = true;
                directorToLeft = false;
            }
            else if (y > x && y < -x)// left
            {
                directorToLeft = true;
                directorToRight = false;
            }
        }

    }
}
