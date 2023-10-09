﻿using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //원거리 공격용
    protected enum State
    {
        Ready,   //발사준비
        Empty,  //발사 완료
        Reloading   //쿨타임 대기중
    }
    protected string ID;
    protected State state {  get; set; }    //현재 발사체 상태
    public bool isAttack { get; set; }

    protected GameObject bullet;    // 총알 //
    protected Transform fireTransform;  //발사될 위치
    protected Rigidbody2D rb;       //총알 리지드바디

    protected GameObject GrandParent;   //Attack or Skill 에서 부모 오브젝트 저장
    protected IAttack GrandParentIAttack;

    protected GameObject newBullet;

    protected virtual void Fire()   //총알 생성 및 발사
    {
        newBullet = Instantiate(bullet, fireTransform.position, Quaternion.identity);
        rb = newBullet.GetComponent<Rigidbody2D>();
        rb.velocity = fireTransform.right * GrandParentIAttack.speed;
    }

    protected virtual void OnBullet() //스킬이면 오버라이드
    {
        int layerMask = 1 << LayerMask.NameToLayer("Raycase");
        RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.right, layerMask);
        IDamageable hitDamage = hit.collider.GetComponent<IDamageable>();
        if (hitDamage != null) //Damageaable을 쓰고있다면
        {
            Debug.Log(hit.collider.name);
            hitDamage.OnDamage(GrandParentIAttack.OnAttack(hit), hit);
            Destroy(newBullet);   //다 파괴됨
            //hit된 오브젝트에 자식 Attack값만큼 데미지입힘
        }
    }

    protected void StateCheck()
    {
        //이것도 적마다 방향 생각해서 작업해야하나
        //일반 공격
        if (state == State.Ready) //장전완료
        {
            //Debug.Log("생성");
            Fire();
            state = State.Empty;
        }
        if (state == State.Empty) { //데미지 체크
            //Debug.Log("데미지");

            OnBullet();
            state = State.Reloading;
        }
        //처치 완료 했을 경우 로딩상태로
    }

}
