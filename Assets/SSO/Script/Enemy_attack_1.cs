using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_attack_1 : MonoBehaviour
{
    // ���� �������� �������� ������ ��ũ��Ʈ
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Castle") || collision.CompareTag("Player"))
        {
            Debug.Log("���ݴ���");
        }
    }
}
