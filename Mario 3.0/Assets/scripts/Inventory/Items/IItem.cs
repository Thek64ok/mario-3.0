﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem 
{
    string Name { get; }
    Texture2D UIIcon { get; }
}
