using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragAndDrop : MonoBehaviour
{
    public GameObject Dog,Duck,Eagle,Sheep, DogBlack,EagleBlack, DuckBlack, SheepBlack;
    
    Vector2 DogInitiaPos,DuckInitiaPos,EagleInitiaPos,SheepInitiaPos;
    // Start is called before the first frame update
    void Start()
    {
        DogInitiaPos = Dog.transform.position;
        DuckInitiaPos = Duck.transform.position;
        EagleInitiaPos = Eagle.transform.position;
        SheepInitiaPos = Sheep.transform.position;
    }

    public void DragDog (){
        Dog.transform.position = Input.mousePosition;
    }

    public void DragDuck (){
        Duck.transform.position = Input.mousePosition;
    }

    public void DragEagle (){
        Eagle.transform.position = Input.mousePosition;
    }
    public void DragSheep (){
        Sheep.transform.position = Input.mousePosition;
    }

    public void DropDog(){
        float Distance = Vector3.Distance(Dog.transform.position,DogBlack.transform.position);
        if(Distance<50){
            Dog.transform.position = DogBlack.transform.position;
        }else{
            Dog.transform.position = DogInitiaPos;
        }
    }

    public void DropDuck(){
        float Distance = Vector3.Distance(Duck.transform.position,DuckBlack.transform.position);
        if(Distance<50){
            Duck.transform.position = DuckBlack.transform.position;
        }else{
            Duck.transform.position = DuckInitiaPos;
        }
    }
    public void DropEagle(){
        float Distance = Vector3.Distance(Eagle.transform.position,EagleBlack.transform.position);
        if(Distance<50){
            Eagle.transform.position = EagleBlack.transform.position;
        }else{
            Eagle.transform.position = EagleInitiaPos;
        }
    }

    public void DropSheep(){
        float Distance = Vector3.Distance(Sheep.transform.position,SheepBlack.transform.position);
        if(Distance<50){
            Sheep.transform.position = SheepBlack.transform.position;
        }else{
            Sheep.transform.position = SheepInitiaPos;
        }
    }
   
}
