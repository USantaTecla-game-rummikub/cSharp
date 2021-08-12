using Rummy.controllers;
using Rummy.types;

namespace Rummy.models.interpreter
{
    public class Group : Command
    {
        public static string NEW = "";
        private string group;

        public Group(string group)
        {
            this.group = group;
        }
       
        public Group()
        {
            this.group = NEW;
        }

        public override void execute(PlayController playController) {
            if (this.group != null && this.group != NEW && !playController.existGroup(this.group)) {
                this.error = ErrorMessage.WRONG_GROUP;
            } 
        }

        public string getGroup()
        {
            return this.group;
        }

        public int toInt()
        {
            if (this.group != Group.NEW)
            {
                return int.Parse(group);
            } else
            {
                return 0;
            }
        }
    }
}