using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class StageButton : MonoBehaviour
{
    public int stageIndex; // �� ��ư�� �ش��ϴ� �������� ��ȣ�� �ν����Ϳ��� ����
    public M_D01 monster; // M_D01 ��ũ��Ʈ�� �ν����Ϳ��� �Ҵ�

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        if (monster != null)
        {
            // ���������Ʈ�� �� �ε����� 0���� �����ϹǷ� rowIndex�� ���
            int rowIndex = stageIndex;

            if (rowIndex >= 0 && rowIndex < monster.monsterData.monsterdatas.Length)
            {
                // �ش� ���������� ���� �����͸� �������� ó��
                //MonsterD ���� ������ ����Ʈ�� ���� (�����Ͱ� ����Ǿ�����)
                MonsterD stageData = monster.monsterData.monsterdatas[rowIndex];
                

                // �������� �����͸� ����Ͽ� ������ �Ӽ��� ����
                monster.ID_m = stageData.stageID;
                monster.HP = stageData.hp;
                monster.Attack = stageData.attack;
                monster.AtkTime = stageData.atktime;

                //Ȯ���� ���� ��� 
                Debug.Log("Clicked stage button with stageIndex: " + stageIndex);
                Debug.Log("Stage " + stageIndex + " - ID: " + monster.ID_m + "," +
                    " HP: " + monster.HP + ", Attack: " + monster.Attack + ", Attack Time: " + monster.AtkTime);
               
            }
            else
            {
                Debug.LogError("Invalid stage index: " + stageIndex);
            }
        }
        //Ŭ���ϰ� �����ϱ� ��ư ������ �� �ѱ��
        // ENTER ��ũ��Ʈ �ϳ� ¥�� �׳� , �ε� ���� �ϱ�� 
    }
}
//����Ƽ
/*, ������ ������ StageButton ��ũ��Ʈ�� UI ��ư�� �߰��ϰ� �� ��ư�� �ش��ϴ� 
 * �������� ��ȣ�� �Ҵ��ϸ� �˴ϴ�. �� ��ũ��Ʈ�� �� �������� ��ư�� Ŭ���Ǹ� 
 * �ش� �������� �����͸� �������� ���Ϳ� �Ҵ��ϴ� ������ �մϴ�. ���� �������� ��ư�� 
 * ���� ��ũ��Ʈ ���� ��ȣ �ۿ��� ���� �ν����Ϳ��� �� ��ư�� ���� M_D01 ���� ��ũ��Ʈ�� �Ҵ��ؾ� �մϴ�.

��ư�� Ŭ���� �� �ش� ���������� �����͸� �������� ������ �Ӽ��� �����Ϸ���
������ ������ ��ũ��Ʈ�� ����Ͻø� �˴ϴ�. �� ��ũ��Ʈ�� ���ϴ� ������ ������ ���Դϴ�.
*/