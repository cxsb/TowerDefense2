﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonTimer : SingletonMono<CommonTimer>
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.lockCursor = true;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
