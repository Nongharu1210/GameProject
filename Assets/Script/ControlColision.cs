using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class ControlColision : MonoBehaviour
{
    //component
    private CharacterController characterController;
    private Animator animator;
    private Transform meshPlayer;
    public Transform playerCameraParent;

    //Move 
    private float inputX;
    private float inputZ;
    private Vector3 V_movement; 
    private float MoveSpeed;
    private float gravity;
    public float lookSpeed = 2.0f;
    Vector2 rotation = Vector2.zero;
    public float lookXLimit = 60.0f;
    static public int ItemQuestCollection;
    void Start()
    {
     MoveSpeed = 0.042f; //กำหนดความเร็ว
     gravity = 0.5f; //กำหนดแรงโน้มถ่วง
     GameObject tempPlayer = GameObject.FindGameObjectWithTag("Player"); //หาgame object ที่มีแท็ก player เก็บไว้ที่ temp เพื่อนำไปใช้
     meshPlayer = tempPlayer.transform.GetChild(0);
     characterController = tempPlayer.GetComponent<CharacterController>(); //รับค่าจากคีย์บอร์ด
     animator = meshPlayer.GetComponent<Animator>();
     rotation.y = transform.eulerAngles.y;
    }

    void Update()
    {   //การบังคับตัวละคร 
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
        rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
        rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotation.x = Mathf.Clamp(rotation.x, -lookXLimit, lookXLimit);
        playerCameraParent.localRotation = Quaternion.Euler(rotation.x, 0, 0);
        //Debug.Log(inputX + inputZ);
        if(inputX == 0 && inputZ == 0){
            animator.SetBool("Run",false);
        }else{
            animator.SetBool("Run",true);
        }
        Debug.Log(ItemQuestCollection);
    }

    private void FixedUpdate(){
        //gravity
        //ถ้าตัวละครติดพิ้น กำหนดค่าเดินเท่ากับ 0
        if(characterController.isGrounded){
            V_movement.y = 0f;
        }else{
            V_movement.y -= gravity * Time.deltaTime;
        }

        V_movement = new Vector3 (inputX * MoveSpeed,V_movement.y,inputZ * MoveSpeed);
        characterController.Move(V_movement);
        //mesh rotate
        if(inputX != 0 || inputZ !=0){
        Vector3 lookDir = new Vector3 (V_movement.x,0,V_movement.z);
        meshPlayer.rotation = Quaternion.LookRotation(lookDir);
        }
        
    }
}
