using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ObjectPauser : MonoBehaviour
{
    static List<ObjectPauser> targets = new List<ObjectPauser>();

    Behaviour[] pausedBehaviours = null;

    //RigidBody
    Rigidbody[] rigidbodies = null;
    Vector3[] rigidbodyVelocities = null;
    Vector3[] rigidbodyAngularVelocities = null;
    //RigidBody2D
    Rigidbody2D[] rigidbody2Ds = null;
    Vector2[] rigidbody2DVelocities = null;
    float[] rigidbody2DAngularVelocities = null ;

    void OnEnable()
    {
        targets.Add(this);
    
    }
    void OnDisable()
    {
        targets.Remove(this);
    }
    void OnDestroy()
    {
        targets.Remove(this);
    }

    //ポーズされたとき
    void OnPause() 
    {
        if (pausedBehaviours == null) return;

        //有効なコンポーネントを取得
        pausedBehaviours = Array.FindAll(GetComponentsInChildren<Behaviour>(), (obj) => { return obj.enabled; });
        foreach(var components in pausedBehaviours) 
        {
            components.enabled = false;
        }
        //RigidBodyの状態を保存
        rigidbodies = Array.FindAll(GetComponentsInChildren<Rigidbody>(), (obj) => { return !obj.IsSleeping(); });
        rigidbodyVelocities = new Vector3[rigidbodies.Length];
        rigidbodyAngularVelocities = new Vector3[rigidbodies.Length];
        for(int i = 0; i < rigidbodies.Length; i++) 
        {
            rigidbodyVelocities[i] = rigidbodies[i].velocity;
            rigidbodyAngularVelocities[i] = rigidbodies[i].angularVelocity;
        }
        //RigidBody2dの状態を保存
        rigidbody2Ds = Array.FindAll(GetComponentsInChildren<Rigidbody2D>(), (obj) => { return !obj.IsSleeping(); });
        rigidbody2DVelocities = new Vector2[rigidbody2Ds.Length];
        rigidbody2DAngularVelocities = new float[rigidbody2Ds.Length];
        for(int i = 0; i < rigidbody2Ds.Length; i++) 
        {
            rigidbody2DVelocities[i] = rigidbody2Ds[i].velocity;
            rigidbody2DAngularVelocities[i] = rigidbody2Ds[i].angularVelocity;
        }

    }
    //ポーズ解除されたとき
    void OnResume() 
    {
        if (pausedBehaviours == null) return;
        foreach (var component in pausedBehaviours) component.enabled = true;

        //RigidBodyの状態を復元
        for (int i = 0; i < rigidbodies.Length; i++)
        {
            rigidbodies[i].WakeUp();
            rigidbodies[i].velocity = rigidbodyVelocities[i];
            rigidbodies[i].angularVelocity = rigidbodyAngularVelocities[i];
        }
        //RigidBody2Dの状態を復元
        for (int i = 0; i < rigidbody2Ds.Length; i++)
        {
            rigidbody2Ds[i].WakeUp();
            rigidbody2Ds[i].velocity = rigidbody2DVelocities[i];
            rigidbody2Ds[i].angularVelocity = rigidbody2DAngularVelocities[i];
        }

        //変数を初期化
        pausedBehaviours = null;

        rigidbodies = null;
        rigidbodyVelocities = null;
        rigidbodyAngularVelocities = null;
        
        rigidbody2Ds = null;
        rigidbody2DVelocities = null;
        rigidbody2DAngularVelocities = null;
    }

    public static void Pause() 
    {
        foreach (var obj in targets) obj.OnPause();
    }

    public static void Resume() 
    {
        foreach (var obj in targets) obj.OnResume();
    }
}