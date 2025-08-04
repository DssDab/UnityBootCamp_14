using UnityEngine;

// 1. 프리팹을 직접 등록한다.
// 2. 생성된 오브젝트에 대한 정보를 내부에서 가진다.
// 3. 생성 후에 파괴에 대한 딜레이 시간을 가진다.

// 해당 스크립트를 가진 오브젝트가 실행하면, 생성을 진행하고 일정 시간 뒤 파괴하도록
// 처리합니다.
// 조건) 프리팹이 등록이 되어있을 때 해당 작업 수행. 아닐 경우 경고 메세지를 안내합니다.

public class PrefabSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    private GameObject spawned;
    public float delayTime = 3f;
    
    //public List<GameObject> objectsPool = new List<GameObject>();    

    void Start()
    {
        if(cubePrefab != null)
        {
            //spawned = Instantiate(cubePrefab);
            //// 생성 코드 : Instantiate()
            //// 1. Instantiate(GameObject) : 해당 프리팹의 정보에 맞게 위치와 회전 값 등이 설정되고 생성됩니다.
            //// 2. Instantiate(GameObject, transform.position, Quaternion.identity);
            //// --> 해당 프리팹을 설정하고, 위치와 회전 값의 정보대로 오브젝트의 위치와 회전 값을 설정합니다.
            //// 3. Instantiate(GameObject, transform.parent);
            //// 오브젝트를 생성하고 그 오브젝트를 전달한 위치의 자식으로써 등록합니다.
            //// 4. Instantiate(GameObject, position, quaternion, parent);

            //spawned.name = "Enemy";
            //// 생성된 오브젝트의 이름을 변경하는 코드
            //// spawned.AddComponent<Rigidbody>();
            //// 그 후 생성된 오브젝트에 컴포넌트를 추가합니다.

            //Debug.Log(spawned.name + "이 생성되었습니다.");

            //Destroy(spawned, delayTime);    // delayTime 이후 오브젝트 파괴
        }
        //else
        //{
        //    Debug.LogWarning("등록된 프리팹이 존재하지 않습니다.");
        //}
    }

   
}
