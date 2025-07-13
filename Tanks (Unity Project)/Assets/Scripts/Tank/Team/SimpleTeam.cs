using System;

namespace Tank.Team
{
    public class SimpleTeam : ITeam
    {
        private string _team;
        
        public string Team => _team;

        public SimpleTeam(string team)
        {
            _team = team;
        }
        
        public bool IsSameTeam(ITeam other)
        {
            if (other is null)
                return false;

            return _team.Equals(other.Team, StringComparison.InvariantCulture);
        }
    }
}