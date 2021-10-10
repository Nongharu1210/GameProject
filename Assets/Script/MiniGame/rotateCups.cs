using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class rotateCups : MonoBehaviour
{
    private float lerp = 0f, speed = 5f;
    static List<Vector3> listOfCupPositions, shuffleList;
    Vector3 theNewPos, startPos;
    int shuffleSpeed = 200;
    public GameObject Ball;
    int shuffle = 0;
    static public int count = 0;
    void Start()
    {
        if (null == listOfCupPositions)
        {
            // These lists are global to each cup
            listOfCupPositions = new List<Vector3>();
            shuffleList = new List<Vector3>();
        }
        theNewPos = startPos = transform.position;
        listOfCupPositions.Add(theNewPos); // Add this cup to the main list
    }

    void Update()
    {
        if (startPos != theNewPos){

            if(count <= 20){  //สลับวัตถุ
            //lerp = 5;
            //lerp += 1 * speed;
            lerp += Time.deltaTime * speed;
            lerp = Mathf.Clamp(lerp, 0f, 1f); // keep lerp between the values 0..1
            transform.position = Vector3.Lerp(startPos, theNewPos, lerp);
            if (lerp >= 1f)
            {
                startPos = theNewPos;
                lerp = 0f;
            }
            if(transform.position == startPos){
                speed++;
                count++;
            }
       
        //}
        Ball.transform.position = transform.position; 
        //Debug.Log(transform.position);
        //Debug.Log(count);
        
            }
        }
    }

    void LateUpdate()
    {
        //หาตัวที่สลับ (สุ่มหาตำแหน่งที่สลับ)
        if (--shuffle <= 0)
        { 
            
           // Shuffle the cups
            shuffle = shuffleSpeed;
            if (0 == shuffleList.Count)
                shuffleList = listOfCupPositions.ToList(); // refresh shuffle positions

            int index = 0;
            do
            {
                //ตำแหน่งของกล่องที่ให้สลับ 0-2 (ค่าของกล่อง
                index = Random.Range(0, shuffleList.Count);
            } while (startPos == shuffleList[index] && shuffleList.Count > 1);

            //give this cup a new position
            theNewPos = shuffleList[index];
            shuffleList.RemoveAt(index); // remove position from shuffle list so it isn't duplicated to another cup 0,2
            //Debug.Log(shuffleList.Count);
            //Debug.Log(shuffle);
            shuffle--;
            }
            
        }           
    }
