using System;

namespace ScreenRuler
{
    /// <summary>
    /// Defines possible appearance modes of the form.
    /// </summary>
    [Flags]
    public enum FormResizeMode
    {
        Horizontal = 1,
        Vertical = 2,
        TwoDimensional = 3
    }
}
