using System;
using System.Collections.Generic;
using System.Text;

namespace NetFullStack19.Core.Moderation
{
    public interface IModeration
    {
        ModerationResponse CheckAdult(string filePath);
        ModerationResponse CheckMedical();
        ModerationResponse CheckViolence();
    }
}
