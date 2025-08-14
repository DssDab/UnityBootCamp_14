using UnityEngine;

// 인터페이스 (interface)
// 접근제한자 interface 이름
// {    
//  ...
//  값 들어가면 X
//  프로퍼티는 가능
// }
// 
// [작성 순서]
// 접근 제한자 class 자식클래스명 : 부모클래스명, 인터페이스1, 인터페이스2
// 특징 : 여러개의 연결 가능합니다.
// 기존의 클래스 상속 : 기능에 대한 재사용이 목적, 다중 상속 불가능
//                    접근 제한자에 대한 사용 가능
//                    재사용성이 있는 코드의 기능을 물려줘 빠른 설계를 도와주는 도구

// 인터페이스 상속 : 기능에 대한 설계를 부탁함, 중간 다리 역할
//                 인터페이스에 대한 상속 가능
//                 다중 상속에 대한 허용(선언만 포함하기에 충돌 문제가 거의 없음)
//                 --> 구현의 주체는 결국 인터페이스를 구현할 '클래스' 자신
//                 공통적인 동작에 대한 설계를 진행하는 도구

// >> 인터페이스는 결합도가 낮아서, 유연성이 높은 코드를 짜기 수월하다.

public interface IThrowable
{
    
}
public interface IWeapon
{

}
public interface ICountable
{

}
public interface IPotion
{

}
public interface IUsable
{

}
public class Item 
{

}

public class Sword : Item, IWeapon
{

}
public class Jabelin : Item, IWeapon, ICountable, IThrowable { }

public class MaxPotion : Item, IPotion,ICountable, IUsable { }

public class FirePotion : Item, IPotion, IThrowable,ICountable { }
public class InterfaceSample : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
