﻿using UnityEngine;

namespace CodeBase.Services.Input
{
    public interface IInputService : IService
    {
        public Vector2 Axis { get; }
    }
}