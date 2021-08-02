using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAnimController : MonoBehaviour
{
    Animator _animator;
    CubeController _cubeController;
    public CubeAnimController(CubeController cubeController)
    {
        _cubeController = cubeController;
        _animator = cubeController.GetComponent<Animator>();
    }
    public void DamagedAnim()
    {   
        _animator.SetTrigger("IsDamaged");
        _animator.SetTrigger("IsNormal");
    }
}
