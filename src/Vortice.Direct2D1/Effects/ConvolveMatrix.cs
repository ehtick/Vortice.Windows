﻿// Copyright (c) Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

using System.ComponentModel;

namespace Vortice.Direct2D1.Effects;

/// <summary>
/// <see cref="https://learn.microsoft.com/en-us/windows/win32/direct2d/convolve-matrix"/>
/// </summary>
public sealed class ConvolveMatrix : ID2D1Effect
{
    public ConvolveMatrix(ID2D1DeviceContext context)
        : base(context.CreateEffect(EffectGuids.ConvolveMatrix))
    {
    }

    public ConvolveMatrix(ID2D1EffectContext context)
        : base(context.CreateEffect(EffectGuids.ConvolveMatrix))
    {
    }

    [DefaultValue(1.0f)]
    public float KernelUnitLength
    {
        get => GetFloatValue((int)ConvolveMatrixProperties.KernelUnitLength);
        set => SetValue((int)ConvolveMatrixProperties.KernelUnitLength, value);
    }

    public ConvolveMatrixScaleMode ScaleMode
    {
        get => GetEnumValue<ConvolveMatrixScaleMode>((int)ConvolveMatrixProperties.ScaleMode);
        set => SetValue((int)ConvolveMatrixProperties.ScaleMode, value);
    }

    [DefaultValue(3)]
    public uint KernelSizeX
    {
        get => GetUIntValue((int)ConvolveMatrixProperties.KernelSizeX);
        set => SetValue((int)ConvolveMatrixProperties.KernelSizeX, value);
    }

    [DefaultValue(3)]
    public uint KernelSizeY
    {
        get => GetUIntValue((int)ConvolveMatrixProperties.KernelSizeY);
        set => SetValue((int)ConvolveMatrixProperties.KernelSizeY, value);
    }

    public unsafe float[] KernelMatrix
    {
        get
        {
            uint size = KernelSizeX * KernelSizeY;
            Span<float> value = stackalloc float[(int)size];
            fixed (float* valuePtr = value)
            {
                GetValue((int)ConvolveMatrixProperties.KernelMatrix, PropertyType.Blob, valuePtr, sizeof(float) * size);
            }

            return value.ToArray();
        }
        set
        {
            uint size = KernelSizeX * KernelSizeY;
            if (value.Length != size)
            {
                throw new ArgumentException($"{nameof(KernelMatrix)} must be KernelSizeX * KernelSizeY");
            }

            fixed (void* valuePtr = value)
            {
                SetValue((int)ConvolveMatrixProperties.KernelMatrix, PropertyType.Blob, valuePtr, sizeof(float) * size);
            }
        }
    }

    [DefaultValue(1.0f)]
    public float Divisor
    {
        get => GetFloatValue((uint)ConvolveMatrixProperties.Divisor);
        set => SetValue((uint)ConvolveMatrixProperties.Divisor, value);
    }

    [DefaultValue(0.0f)]
    public float Bias
    {
        get => GetFloatValue((uint)ConvolveMatrixProperties.Bias);
        set => SetValue((uint)ConvolveMatrixProperties.Bias, value);
    }

    public Vector2 KernelOffset
    {
        get => GetVector2Value((uint)ConvolveMatrixProperties.KernelOffset);
        set => SetValue((uint)ConvolveMatrixProperties.KernelOffset, value);
    }

    [DefaultValue(false)]
    public bool PreserveAlpha
    {
        get => GetBoolValue((int)ConvolveMatrixProperties.PreserveAlpha);
        set => SetValue((int)ConvolveMatrixProperties.PreserveAlpha, value);
    }

    public BorderMode BorderMode
    {
        set => SetValue((int)ConvolveMatrixProperties.BorderMode, value);
        get => GetEnumValue<BorderMode>((int)ConvolveMatrixProperties.BorderMode);
    }

    [DefaultValue(false)]
    public bool ClampOutput
    {
        get => GetBoolValue((int)ConvolveMatrixProperties.ClampOutput);
        set => SetValue((int)ConvolveMatrixProperties.ClampOutput, value);
    }
}
