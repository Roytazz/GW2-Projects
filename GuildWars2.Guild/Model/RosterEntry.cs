namespace GuildWars2Guild.Model
{
    class RosterEntry : DisplayLogEntry     
    {
        public string RosterAction {
            get {
                if(User.Equals(KickedBy)) {
                    return "Left";
                }
                else if(!string.IsNullOrEmpty(KickedBy)) {
                    return "Kicked By";
                }
                else if(!string.IsNullOrEmpty(InvitedBy)) {
                    return "Invited By";
                }
                else {
                    return "Joined";
                }
            }
        }

        public string UserBy
        {
            get {
                if(!string.IsNullOrEmpty(KickedBy) && !User.Equals(KickedBy)) { //If someone leaves the systems thinks the user got kicked by himself
                    return KickedBy;
                }
                else if(!string.IsNullOrEmpty(InvitedBy)) {
                    return InvitedBy;
                }
                
                else {
                    return string.Empty;
                }
            }
        }
    }    
}
