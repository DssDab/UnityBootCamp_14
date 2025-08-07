using UnityEngine;

public class UnitStat : MonoBehaviour
{
    public int m_HP;
    public int m_ATK;
    public int m_MP;
    public int m_Int;

    public UnitInventory m_Inventory;

    private void Start()
    {
        m_HP = 30;
        m_ATK = 10;
        m_Int = 20;
        m_MP = m_Int*2;
        m_Inventory = new UnitInventory();
        m_Inventory.inventory.Add("���", 1000);
        m_Inventory.inventory.Add("���", 3);
        m_Inventory.inventory.Add("�����̾�", 2);
        m_Inventory.inventory.Add("���¼�", 1);
    }
}
