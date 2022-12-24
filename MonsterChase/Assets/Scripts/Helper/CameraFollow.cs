using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform _player;

    private Vector3 _tempPos;

    [SerializeField] private float minX = -60f, maxX = 60f;

    private void Start()
    {
        _player = GameObject.FindWithTag(TagManager.PLAYER_TAG).transform;
       
    }

    private void LateUpdate()
    {

        if (!_player)
        {
            return;
        }
        
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        _tempPos = transform.position;
        _tempPos.x = _player.position.x;

        if (_tempPos.x<minX)
        {
            _tempPos.x = minX;
        }

        if (_tempPos.x>maxX)
        {
            _tempPos.x = maxX;
        }

        transform.position = _tempPos;
    }
}
