using UnityEngine;
using System.Collections;

#region Author & Version
/* ========================================================================  
*Author：WLY 
* File name：
* Version：V1.0.1
* Company: 
* 创建：    
* Date : 2019.0605    14:12
* 功能描述：     .............选中模型时，相机跟随模型平滑移动..................    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class ControlPlayerMove : MonoBehaviour
{
    CharacterController playCC;
    Animator anmtor;
    private float fSpeed = 0;
    private float fRunCount = 0;
    private float grav = 9.8f;
    private bool IsMove = false;
    private float rotSpeed = 20f;
    private float moveSpeed = 0f;
    [SerializeField] private float walkSpeed = 3;
    [SerializeField] private float runSpeed = 5;
    [SerializeField] private float backSpeed = 3;
    private Vector3 vecDir;
    //角色是否需要不移动
    [HideInInspector] public static bool canMove = true;
    [HideInInspector] public static Vector3 MoveToTrans;
    [HideInInspector] public static Vector3 SeeToTrans;

    // Use this for initialization
    void Start()
    {
        walkSpeed = 1f;
        runSpeed = 3f;
        backSpeed = 1f;

        playCC = GetComponent<CharacterController>();
        anmtor = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            CameraThird.nUseModel = 0;
            fSpeed = Input.GetAxis("Vertical");

            IsMove = fSpeed > 0.1f ? true : fSpeed < -0.1f ? true : false;
            transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * rotSpeed, 0);

            if (playCC.isGrounded)
            {
                //世界坐标轴转换为自身的坐标轴
                vecDir = transform.TransformDirection(Vector3.forward);
                vecDir *= fSpeed * Time.deltaTime * moveSpeed;
            }
            vecDir.y -= grav * Time.deltaTime;
            playCC.Move(vecDir);

            if (fSpeed >= 1)
            {
                fRunCount++;
                //anmtor.SetBool("IsDown_1",false);
                if (fRunCount > 80)
                {
                    //anmtor.SetBool("IsWalk",false);
                    //anmtor.SetBool("IsRun", true);
                    moveSpeed = runSpeed;
                }
                else
                {
                    //anmtor.SetBool("IsRun", false);
                    //anmtor.SetBool("IsWalk", IsMove);
                    moveSpeed = walkSpeed;
                }
            }
            else if (fSpeed < 0)
            {
                fRunCount = 0;
                //anmtor.SetBool("IsBackWalk", IsMove);
                moveSpeed = backSpeed;
            }
            else
            {
                fRunCount = 0;
                //anmtor.SetBool("IsRun", false);
                // anmtor.SetBool("IsBackWalk", false);
                // anmtor.SetBool("IsWalk", IsMove);
                moveSpeed = walkSpeed;
            }
        }
        else
        {
            CameraThird.nUseModel = 1;
        }
    }
}
