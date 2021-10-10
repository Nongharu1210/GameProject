// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Shufball : MonoBehaviour
// {
//     // Start is called before the first frame update
//      public GameObject Cup1,Cup2,Cup3;
//      public Vector3 temppostion,Cup1pos,Cup2pos,Cup3pos;
//      private float lerp = 0f, speed = 3f;
//      readonly int shuffleSpeed = 100;
//     int shuffle = 0;

//     void Start()
//     {
//         swap();
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
//     void swap(){        
//         for(int i =0;i<=5;i++){
//             Cup1.transform.position = Cup3pos.transform.position;
//             Cup2.transform.position = Cup1pos.transform.position;
//             Cup3.transform.position = Cup2pos.transform.position;
//         }
//     }
// }
