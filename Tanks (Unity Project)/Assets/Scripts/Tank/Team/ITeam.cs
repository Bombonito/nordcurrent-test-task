using System;

namespace Tank.Team
{
    public interface ITeam
    {
        string Team { get; }

        bool IsSameTeam(ITeam other);
    }
}