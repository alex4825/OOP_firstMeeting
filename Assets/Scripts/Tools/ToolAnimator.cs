using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolAnimator : MonoBehaviour
{
    [SerializeField] private float _verticatLoopSpeed = 3.0f;
    [SerializeField] private float _rotationSpeed = 100f;

    private bool _isAnimate;

    private void Update()
    {
        if (_isAnimate)
        {
            transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
        }
    }

    public void PlayAnimation()
    {
        _isAnimate = true;
    }

    public void StopAnimation()
    {
        _isAnimate = false;
        transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
    }

}
