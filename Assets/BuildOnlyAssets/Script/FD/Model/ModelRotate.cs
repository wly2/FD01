using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Author & Version
/* ========================================================================  
*Author：WLY 
* File name：
* Version：V1.0.1
* Company: 
* 创建：    
* Date : 2019.0606    14:12
* 功能描述：     ...............模型展示场景的模型查看效果................    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class ModelRotate : MonoBehaviour
{

    public GameObject Go_Model;
    Vector2 first = Vector2.zero;    //记录鼠标点击的初始位置
    Vector2 second = Vector2.zero;   //记录鼠标移动时的位置
    bool directorToLeft = false;
    bool directorToRight = false;
    bool dragging = false;   //标记是否鼠标在滑动
    float speed = 0;
    public static int y = 0;
    float moveSpeed = 3f;
    float isRotate = 0f;
    Ray ray;
    RaycastHit hit;

    void Update()
    {
        modelRotate();
    }


    /// <summary>
    /// 模型查看效果
    /// </summary>
    public void modelRotate()
    {
        isRotate = y;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButton(0) && Physics.Raycast(ray, out hit))
        {
            //================================薄片====================================//
            if (hit.collider.gameObject.tag == "baopianrotate")
            {
                Vector3 newPosition = Vector3.zero;

                if (directorToRight == true)
                {
                    speed = 10;
                    newPosition = new Vector3(0, 1, 0);
                    y++;
                    Go_Model.transform.rotation = Quaternion.Euler(90, 0, y * moveSpeed);
                }
            }

            //================================直尺====================================//
            if (hit.collider.gameObject.tag == "zhichiRotate")
            {
                Vector3 newPosition = Vector3.zero;
                if (directorToRight == true)
                {
                    speed = 10;
                    newPosition = new Vector3(0, 1, 0);
                    y++;
                    Go_Model.transform.rotation = Quaternion.Euler(180f, -y * moveSpeed, 90f);
                }
            }

            //================================游标卡尺====================================//
            if (hit.collider.gameObject.tag == "ybkcRotate")
            {
                Vector3 newPosition = Vector3.zero;
                if (directorToRight == true)
                {
                    speed = 10;
                    newPosition = new Vector3(0, 1, 0);
                    y++;
                    Go_Model.transform.rotation = Quaternion.Euler(0, -y * moveSpeed, -90f);
                }
            }

            //================================螺丝刀====================================//
            if (hit.collider.gameObject.tag == "luosidaoRotate")
            {
                Vector3 newPosition = Vector3.zero;
                if (directorToRight == true)
                {
                    speed = 10;
                    newPosition = new Vector3(0, 1, 0);
                    y++;
                    Go_Model.transform.rotation = Quaternion.Euler(0, -y * moveSpeed, 0);
                }
            }
        }
        return;
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
            else if (y > x && y < -x && isRotate > 0)// left
            {
                directorToLeft = true;
                directorToRight = false;
            }

        }

    }
}
